using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace JpWebServer
{
    public class HttpServer
    {
        private bool _isRunning;

        private Socket _serverSocket;

        public HttpServer(IPAddress addr, int port, string root)
        {
            ServerIP = addr;
            ServerPort = port;
            if (!Directory.Exists(root))
                ServerRoot = AppDomain.CurrentDomain.BaseDirectory;
            else
                ServerRoot = root;
        }

        public HttpServer(string addr, int port, string root) :
            this(IPAddress.Parse(addr), port, root)
        {
        }

        public HttpServer(int port, string root) :
            this(IPAddress.Loopback, port, root)
        {
        }

        public HttpServer(int port) :
            this(IPAddress.Loopback, port, AppDomain.CurrentDomain.BaseDirectory)
        {
        }

        public IPAddress ServerIP { get; }

        public int ServerPort { get; }

        public string ServerRoot { get; }

        public void ProessRequest(Socket handler)
        {
            var request = new HttpRequest(handler);

            switch (request.Method)
            {
                case "GET":
                    DoGet(request);
                    break;
                case "POST":
                    DoPost(request);
                    break;
                default:
                    DoDefault(request);
                    break;
            }
        }

        public void ProcessResponse(Socket handler, HttpResponse response)
        {
            var header = Encoding.UTF8.GetBytes(response.BulidHeader());

            handler.Send(header);

            handler.Send(Encoding.UTF8.GetBytes(Environment.NewLine));

            handler.Send(response.Content);
            handler.Close();
        }

        private HttpResponse ResponseFile(string fileAddr)
        {
            HttpResponse response;
            var fileExtension = Path.GetExtension(fileAddr);
            var contentType = ParseTools.GetContentType(fileExtension);

            if (!File.Exists(fileAddr))
            {
                response = new HttpResponse("<html><body><br>404 Not Found<br><body><html>");
                response.StatusCode = "404";
                response.Header.Content_Type = "text/html";
                response.Header.Server = "JpTestServer";
                response.Header.Date = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                Console.WriteLine("can't find" + fileAddr);
            }
            else
            {
                response = new HttpResponse(File.ReadAllBytes(fileAddr));
                response.StatusCode = "200";
                response.Header.Content_Type = contentType;
                response.Header.Date = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                response.Header.Server = "JpTestServer";
            }
            return response;
        }

        public void DoDefault(HttpRequest request)
        {
        }

        public void DoPost(HttpRequest request)
        {
        }

        public void DoGet(HttpRequest request)
        {
            if (request.Method == "GET")
            {
                var requestUrl = request.Url.Replace('/', '\\');

                var requestFile = ServerRoot + requestUrl + (Path.HasExtension(requestUrl)
                                      ? ""
                                      : "index.html");
                Console.WriteLine(ServerRoot);
                Console.WriteLine(requestUrl);
                Console.WriteLine(requestFile);

                var response = ResponseFile(requestFile);
                ProcessResponse(request.Handler, response);
            }
        }

        public void Start()
        {
            if (_isRunning)
                return;
            _isRunning = true;
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            _serverSocket.Bind(new IPEndPoint(ServerIP, ServerPort));

            _serverSocket.Listen(10);

            while (true)
            {
                var clientSocket = _serverSocket.Accept();

                var task = new Task(() => ProessRequest(clientSocket));
                task.Start();
            }
        }




        public void Stop()
        {
            _isRunning = false;
            _serverSocket.Close();
        }
    }
}
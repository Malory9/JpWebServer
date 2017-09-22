using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JpWebServer
{
    public class Program
    {
        public static void Main()
        {
            HttpServer server = new HttpServer("127.0.0.1", 80, "D:\\TestAddr");
            CancellationTokenSource cts = new CancellationTokenSource();
            
         var task =   Task.Run(()=> server.Start(),cts.Token);
            Console.ReadLine();
            if (cts.IsCancellationRequested)
            {
                server.Stop();
                cts.Cancel();
            }


        }
    }
}
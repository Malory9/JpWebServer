using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace JpWebServer
{
   public class HttpRequest
    {
        private readonly byte[] _bytes = new byte[1024*1024*2];

        public HttpRequest(Socket handler)
        {
            Handler = handler;
            handler.Receive(_bytes);

            var content = Encoding.UTF8.GetString(_bytes);

            var lines = content.Split('\n');

            Method = string.IsNullOrEmpty(lines[0]) ? "" : lines[0].Split(' ').First();
            Url = string.IsNullOrEmpty(lines[0]) ? "" : lines[0].Split(' ')[1];

            if ((Method == "GET") && Url.Contains('?'))
                Params = ParseTools.GetRequestParams(lines[0].Split(' ')[1].Split('?')[1]);
            else if (Method == "POST")
                Params = ParseTools.GetRequestParams(lines[lines.Length - 1]);
            

            Header = new HttpRequestHeader
            {
                Accept = ParseTools.GetKeyValueArrayByKey(content, "Accept"),
                Accept_Charset = ParseTools.GetKeyValueArrayByKey(content, "Accept-Charset"),
                Accept_Encoding = ParseTools.GetKeyValueArrayByKey(content, "Accept-Encoding"),
                Accept_Language = ParseTools.GetKeyValueArrayByKey(content, "Accept-Langauge"),
                Authorization = ParseTools.GetValueByKey(content, "Authorization"),
                If_Match = ParseTools.GetValueByKey(content, "If-Match"),
                If_None_Match = ParseTools.GetValueByKey(content, "If-None-Match"),
                If_Modified_Since = ParseTools.GetValueByKey(content, "If-Modified-Since"),
                If_Unmodified_Since = ParseTools.GetValueByKey(content, "If-Unmodified-Since"),
                If_Range = ParseTools.GetValueByKey(content, "If-Range"),
                Range = ParseTools.GetValueByKey(content, "Range"),
                Proxy_Authenticate = ParseTools.GetValueByKey(content, "Proxy-Authenticate"),
                Proxy_Authorization = ParseTools.GetValueByKey(content, "Proxy-Authorization"),
                Host = ParseTools.GetValueByKey(content, "Host"),
                Referer = ParseTools.GetValueByKey(content, "Referer"),
                User_Agent = ParseTools.GetValueByKey(content, "User-Agent"),
                Cache_Control = ParseTools.GetValueByKey(content, "Cache-Control"),
                Pragma = ParseTools.GetValueByKey(content, "Pragma"),
                Connection = ParseTools.GetValueByKey(content, "Connection"),
                Date = ParseTools.GetValueByKey(content, "Date"),
                Transfer_Encoding = ParseTools.GetValueByKey(content, "Transfe-Encoding"),
                Upgrade = ParseTools.GetValueByKey(content, "Upgrade"),
                Via = ParseTools.GetValueByKey(content, "Via"),
                Allow = ParseTools.GetValueByKey(content, "Allow"),
                Location = ParseTools.GetValueByKey(content, "Location"),
                Content_Base = ParseTools.GetValueByKey(content, "Content-Base"),
                Content_Encoding = ParseTools.GetValueByKey(content, "Content-Encoidng"),
                Content_Language = ParseTools.GetValueByKey(content, "Content-Language"),
                Content_Length = ParseTools.GetValueByKey(content, "Content-Length"),
                Content_Location = ParseTools.GetValueByKey(content, "Content-Location"),
                Content_MD5 = ParseTools.GetValueByKey(content, "Content-MD5"),
                Content_Range = ParseTools.GetValueByKey(content, "Content-Range"),
                Content_Type = ParseTools.GetValueByKey(content, "Content-Type"),
                Etag = ParseTools.GetValueByKey(content, "Etag"),
                Expires = ParseTools.GetValueByKey(content, "Expires")
            };
        }

        public HttpRequestHeader Header { set; get; }
        public string Method { set; get; }
        public Dictionary<string, string> Params { set; get; }
        public string Url { set; get; }
        public Socket Handler { set; get; }
    }
}
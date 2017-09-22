using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpWebServer
{
   public class HttpResponse 
    {
        public HttpResponseHeader Header { set; get; }

        public string StatusCode { set; get; }
        public byte[] Content { get; }

        public HttpResponse(byte[] content)
        {
            Content = content;
            Header = new HttpResponseHeader();
            
        }

        public HttpResponse(string content)
        {
            Content = Encoding.UTF8.GetBytes(content);
            Header = new HttpResponseHeader();
        }

        public string BulidHeader()
        {
            StringBuilder builder = new StringBuilder();

            if (!string.IsNullOrEmpty(StatusCode))
                builder.Append("HTTP/1.1 " + StatusCode + "\r\n");
            return builder + Header.BuildHeader();
        }

    }
}

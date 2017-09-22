using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpWebServer
{
   public class HttpResponseHeader : HttpBaseHeader
    {
        public string Age { set; get; }
        public string Server { set; get; }
        public string Accept_Ranges { set; get; }
        public string Vary { set; get; }


        public HttpResponseHeader()
        {
            Age = "";
            Server = "";
            Accept_Ranges = "";
            Vary = "";
        }
        public string BuildHeader()
        {
            StringBuilder builder = new StringBuilder();

          
            if (!string.IsNullOrEmpty(Age))
                builder.Append("Age:" + Age + "\r\n");

            if (!string.IsNullOrEmpty(Server))
                builder.Append("Sever:" + Server + "\r\n");

            if (!string.IsNullOrEmpty(Accept_Ranges))
                builder.Append("Accept-Ranges:" + Accept_Ranges + "\r\n");

            if (!string.IsNullOrEmpty(Vary))
                builder.Append("Vary:" + Vary + "\r\n");

            if (!string.IsNullOrEmpty(Vary))
                builder.Append("Vary:" + Vary + "\r\n");

            if (!string.IsNullOrEmpty(Cache_Control))
                builder.Append("Cache-Control:" + Cache_Control + "\r\n");

            if (!string.IsNullOrEmpty(Pragma))
                builder.Append("Pragma:" + Pragma + "\r\n");

            if (!string.IsNullOrEmpty(Connection))
                builder.Append("Connection:" + Connection + "\r\n");

            if (!string.IsNullOrEmpty(Date))
                builder.Append("Date:" + Date + "\r\n");

            if (!string.IsNullOrEmpty(Transfer_Encoding))
                builder.Append("Transfer-Encoding:" + Transfer_Encoding + "\r\n");

            if (!string.IsNullOrEmpty(Upgrade))
                builder.Append("Upgrade:" + Upgrade + "\r\n");

            if (!string.IsNullOrEmpty(Via))
                builder.Append("Via:" + Via + "\r\n");

            if (!string.IsNullOrEmpty(Allow))
                builder.Append("Allow:" + Allow + "\r\n");

            if (!string.IsNullOrEmpty(Location))
                builder.Append("Location:" + Location + "\r\n");

            if (!string.IsNullOrEmpty(Content_Base))
                builder.Append("Content-Base:" + Content_Base + "\r\n");

            if (!string.IsNullOrEmpty(Content_Encoding))
                builder.Append("Content-Encoding:" + Content_Encoding + "\r\n");

            if (!string.IsNullOrEmpty(Content_Length))
                builder.Append("Content-Length:" + Content_Length + "\r\n");

            if (!string.IsNullOrEmpty(Content_Location))
                builder.Append("Content-Location:" + Content_Location + "\r\n");

            if (!string.IsNullOrEmpty(Content_MD5))
                builder.Append("Content-MD5:" + Content_MD5 + "\r\n");

            if (!string.IsNullOrEmpty(Content_Range))
                builder.Append("Content_Range:" + Content_Range + "\r\n");

            if (!string.IsNullOrEmpty(Content_Type))
                builder.Append("Content-Type:" + Content_Type + "\r\n");

            if (!string.IsNullOrEmpty(Etag))
                builder.Append("Etag:" + Etag + "\r\n");

            if (!string.IsNullOrEmpty(Expires))
                builder.Append("Expires:" + Expires + "\r\n");

            if (!string.IsNullOrEmpty(Last_Modified))
                builder.Append("Last-Modified :" + Last_Modified + "\r\n");

            return builder.ToString();
        }
    }
}

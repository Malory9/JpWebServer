using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpWebServer
{
  public  class HttpRequestHeader : HttpBaseHeader
    {
        public string[] Accept { set; get; }
        public string[] Accept_Charset { set; get; }
        public string[] Accept_Encoding { set; get; }
        public string[] Accept_Language { set; get; }
        public string Authorization { set; get; }
        public string If_Match { set; get; }
        public string If_None_Match { set; get; }
        public string If_Modified_Since { set; get; }
        public string If_Unmodified_Since { set; get; }
        public string If_Range { set; get; }
        public string Range { set; get; }
        public string Proxy_Authenticate { set; get; }
        public string Proxy_Authorization { set; get; }
        public string Host { set; get; }
        public string Referer { set; get; }
        public string User_Agent { set; get; }

        public Dictionary<string, string> Params { set; get; }

        
       

    }
}

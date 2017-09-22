using System.Collections.Generic;
using System.Linq;

namespace JpWebServer
{
    /// <summary>
    ///     此为公共的头部定义
    /// </summary>
    public class HttpBaseHeader
    {
        public HttpBaseHeader()
        {
            Cache_Control = "";
            Pragma = "";
            Connection ="";
            Date = "";
            Transfer_Encoding ="";
            Upgrade = "";
            Via = "";
            Allow = "";
            Location = "";
            Content_Base = "";
            Content_Encoding = "";
            Content_Language = "";
            Content_Length = "";
            Content_Location = "";
            Content_MD5 ="";
            Content_Range ="";
            Content_Type = "";
            Etag = "";
            Expires = "";
            Last_Modified ="";
        }

        /// <summary>
        /// 以下为公共头部
        /// </summary>
        public string Cache_Control { set; get; }

        public string Pragma { set; get; }

        public string Connection { set; get; }

        public string Date { set; get; }

        public string Transfer_Encoding { set; get; }

        public string Upgrade { set; get; }

        public string Via { set; get; }


        /// <summary>
        /// 以下为实体头部
        /// </summary>
        public string Allow { get; set; }

        public string Location { get; set; }

        public string Content_Base { get; set; }

        public string Content_Encoding { get; set; }

        public string Content_Language { get; set; }

        public string Content_Length { get; set; }

        public string Content_Location { get; set; }

        public string Content_MD5 { get; set; }

        public string Content_Range { get; set; }

        public string Content_Type { get; set; }

        public string Etag { get; set; }

        public string Expires { get; set; }

        public string Last_Modified { get; set; }


        
    }
}
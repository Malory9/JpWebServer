using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpWebServer
{
    static class ParseTools
    {
        public static  string[] GetKeyValueArrayByKey(string content, string key)
        {
            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(key))
                return null;
            var lines = content.Split('\n');
            var line = lines.Where(item => item.Split(':').First() == key);
            if (!line.Any())
                return null;

            var values = line.First().Split(':')[1];
            if (!values.Any())
                return null;

            return values.Split(',');


        }

        public static string GetValueByKey(string content, string key)
        {
            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(key))
                return null;
            var lines = content.Split('\n');

            var line = lines.Where(item => item.Split(':').First() == key);
            if(!line.Any())
            return null;

            var value = line.First().Split(':');
            if (value.Length <= 1)
                return null;
            return value[1];

        }
        public  static Dictionary<string, string> GetRequestParams(string content)
        {
            if (string.IsNullOrEmpty(content))
                return null;
            var pairs = content.Split('&');
            if (!pairs.Any())
                return null;
            var dict = new Dictionary<string, string>();

            foreach (var variable in pairs)
            {
                var pair = variable.Split('=');
                if (pair.Length < 2)
                    dict.Add(pair[0], "");
                else
                    dict.Add(pair[0], pair[1]);
            }
            return dict;
        }
        public static  string GetContentType(string extension)
        {
            string type = string.Empty;

            if (string.IsNullOrEmpty(extension))
                return null;

            switch (extension)
            {
                case ".htm":
                    type = "text/html";
                    break;
                case ".html":
                    type = "text/html";
                    break;
                case ".txt":
                    type = "text/plain";
                    break;
                case ".css":
                    type = "text/css";
                    break;
                case ".png":
                    type = "image/png";
                    break;
                case ".gif":
                    type = "image/gif";
                    break;
                case ".jpg":
                    type = "image/jpg";
                    break;
                case ".jpeg":
                    type = "image/jgeg";
                    break;
                case ".zip":
                    type = "application/zip";
                    break;
            }
            return type;
        }

    }
}

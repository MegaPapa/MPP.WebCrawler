using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MPP_WebCrawler
{
    public class HTMLParser
    {
        private static string GetResponse(string uri)
        {
            StringBuilder sb = new StringBuilder();
            byte[] buf = new byte[8192];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            int count = 0;
            do
            {
                count = resStream.Read(buf, 0, buf.Length);
                if (count != 0)
                {
                    sb.Append(Encoding.Default.GetString(buf, 0, count));
                }
            }
            while (count > 0);
            return sb.ToString();
        }


        public static List<String> GetAllLinks(string SourceHTML, string url)
        {
            List<String> Links = new List<String>();
            Match m;
            string HRefPattern = @"(?i)<\s*?a\s+[\S\s\x22\x27\x3d]*?href=[\x22\x27]?([^\s\x22\x27<>]+)[\x22\x27]?.*?>";
            m = Regex.Match(SourceHTML, HRefPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            while (m.Success)
            {
                if ((m.Groups[1].Value[0] == 'h') && (m.Groups[1].Value != url))
                    Links.Add(m.Groups[1].Value);
                m = m.NextMatch();
            }
            return Links;
        }

        public static List<String> GetHref(string url)
        {
            List<String> result = null;
            try
            {
                
                String htmlCode = GetResponse(url);
                result = GetAllLinks(htmlCode, url);
            }
            finally
            {
                
            }
            return result;
            
        }
    }
}

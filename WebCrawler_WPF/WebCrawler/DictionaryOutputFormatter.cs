using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler_WPF
{
    public class DictionaryOutputFormatter
    {
        private String result;
        private static String WriteWithTabs(int depth, String url)
        {
            String result = "";
            for (int i = 0; i < depth; i++)
                result += "\t"; // replace this on tabs
            result += url;
            return result;
        }

        public static String FormatOutput(CrawlResult crawlResult,int depth)
        {
            StringBuilder result = new StringBuilder("");
            foreach(KeyValuePair<String,CrawlResult> entry in crawlResult.InnerUrls)
            {
                if (entry.Value != null)
                {
                    /*result += "\r\n";
                    result += WriteWithTabs(depth, entry.Key);
                    result += FormatOutput(entry.Value, depth + 1);*/
                    result.Append("\r\n");
                    result.Append(WriteWithTabs(depth, entry.Key));
                    result.Append(FormatOutput(entry.Value, depth + 1));
                }
            }
            return result.ToString();
        }
    }
}

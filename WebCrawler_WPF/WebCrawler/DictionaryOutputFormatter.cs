using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler_WPF
{
    public class DictionaryOutputFormatter
    {
        private static String WriteWithTabs(int depth, String url)
        {
            StringBuilder result = new StringBuilder("");
            result.Append('\t', depth);
            result.Append(url);
            return result.ToString();
        }

        public static String FormatOutput(CrawlResult crawlResult,int depth)
        {
            StringBuilder result = new StringBuilder("");
            foreach(KeyValuePair<String,CrawlResult> entry in crawlResult.InnerUrls)
            {
                if (entry.Value != null)
                {
                    result.Append("\r\n");
                    result.Append(WriteWithTabs(depth, entry.Key));
                    result.Append(FormatOutput(entry.Value, depth + 1));
                }
            }
            return result.ToString();
        }
    }
}

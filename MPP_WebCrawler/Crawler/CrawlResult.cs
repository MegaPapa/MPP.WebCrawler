using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP_WebCrawler
{
    public class CrawlResult
    {
        private String url;
        public String Url
        {
            get { return url; }
            set { this.url = value; }
        }
        private Dictionary<String,CrawlResult> innerUrls;
        public Dictionary<String, CrawlResult> InnerUrls
        {
            get { return innerUrls; }
            set { innerUrls = value; }
        }

        public void AddCrawlResult(String key,CrawlResult crawlResult)
        {
            innerUrls.Add(key,crawlResult);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WebCrawler_WPF
{
    public class WebCrawler : IWebCrawler
    {
        private int maxDepth;
        public int MaxDepth
        {
            get { return maxDepth; }
            set { maxDepth = value; }
        }
        public WebCrawler(int maxDepth)
        {
            this.maxDepth = maxDepth;
        }

        public async Task<CrawlResult> StartCrawlingAsync(List<string> urls, int currentDepth)
        {
            Dictionary<string, CrawlResult> crawlResultList = new Dictionary<string, CrawlResult>();
            foreach (string url in urls)
            {
                try
                {
                    CrawlResult currentUrlCrawlResult = null;
                    if (currentDepth < maxDepth)
                    {
                        List<string> parsedUrls = HTMLParser.GetHref(url);
                        if (parsedUrls != null)
                            currentUrlCrawlResult = await StartCrawlingAsync(parsedUrls, currentDepth + 1);
                        if ((currentUrlCrawlResult != null) && (!crawlResultList.ContainsKey(url)))
                            crawlResultList.Add(url, currentUrlCrawlResult); ;
                    }
                }
                catch {  }
            }

            CrawlResult crawlResult = new CrawlResult();
            crawlResult.InnerUrls = crawlResultList;
            return crawlResult;
            
        }
    }
}

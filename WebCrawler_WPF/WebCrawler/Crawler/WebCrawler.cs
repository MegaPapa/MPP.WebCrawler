using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP_WebCrawler
{
    public class WebCrawler : IWebCrawler
    {
        private int maxDepth;
        public WebCrawler(int maxDepth)
        {
            this.maxDepth = maxDepth;
        }

        
        private String writeWithTabs(int depth, String url)
        {
            String result = "";
            for (int i = 0; i < depth; i++)
                result += "(heyyou)"; // replace this on tabs
            result += url;
            return result;
        }

        public async Task<CrawlResult> StartCrawlingAsync(List<string> urls, int currentDepth)
        {
            Dictionary<string, CrawlResult> crawlResultList = new Dictionary<string, CrawlResult>();
            foreach (string url in urls)
            {
                Console.WriteLine(writeWithTabs(currentDepth,url));
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

            CrawlResult crawlResult = new CrawlResult();
            crawlResult.InnerUrls = crawlResultList;
            return crawlResult;
            
        }
    }
}

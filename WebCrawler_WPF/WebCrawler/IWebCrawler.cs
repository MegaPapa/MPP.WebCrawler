using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler_WPF
{
    interface IWebCrawler
    {
        Task<CrawlResult> StartCrawlingAsync(List<string> rootUrls, int currentDepth);
    }
}

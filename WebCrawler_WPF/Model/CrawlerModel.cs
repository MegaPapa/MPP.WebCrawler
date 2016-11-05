using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler_WPF.XML_Deserializer;

namespace WebCrawler_WPF.Model
{
    public class CrawlerModel
    {
        private const byte START_CRAWLING_LEVEL = 1;
        private WebCrawler webCrawler;
        private String xmlPath;

        public void SetNewCrawlingLevel(int newLevel)
        {
            this.webCrawler.MaxDepth = newLevel;
        }

        public void SetXmlPath(String xmlPath)
        {
            this.xmlPath = xmlPath;
        }

        public CrawlerModel()
        {
            webCrawler = new WebCrawler(START_CRAWLING_LEVEL);
        }

        public Task<CrawlResult> GetCrawlResultAsync()
        {
            List<String> urls = new List<String>();
            urls = XMLDeserializator.DeserializeStringList(xmlPath);
            return webCrawler.StartCrawlingAsync(urls,0);
        }
    }
}

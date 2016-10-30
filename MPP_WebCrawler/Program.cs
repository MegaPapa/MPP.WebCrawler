using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MPP_WebCrawler
{
    class Program
    {

        private static Task<int> TaskTest(int border,int time)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(time);
                return border;
            });
        }

        private async static void nuGo()
        {
            try
            {
                List<string> listhref = HTMLParser.GetHref("http://www.online-life.cc");
                Console.WriteLine(listhref.Count);
                WebCrawler wc = new WebCrawler(2);
                CrawlResult cr = new CrawlResult();
                cr = await wc.StartCrawlingAsync(listhref, 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void Main(string[] args)
        {
            nuGo();
            Console.ReadKey();
        }
    }
}

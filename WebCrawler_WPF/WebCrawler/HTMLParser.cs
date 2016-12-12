using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NLog;

namespace WebCrawler_WPF
{
    public class HTMLParser
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        //Get HTML document from url
        private static HtmlDocument GetHTMLDoc(String url)
        {
            try
            {
                HtmlWeb htmlWeb = new HtmlWeb();
                HtmlDocument resultDoc = new HtmlDocument();
                resultDoc = htmlWeb.Load(url);
                return resultDoc;
            }
            catch (Exception e)
            {
                logger.Warn(e);
            }
            return null;
        }

        //Get all href's from url
        public static List<String> GetHref(String url)
        {
            try
            {
                List<String> result = new List<String>();
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument = GetHTMLDoc(url);
                if (htmlDocument != null)
                {
                    foreach (HtmlNode link in htmlDocument.DocumentNode.SelectNodes("//a[@href]"))
                    {
                        // Get the value of the href attribute
                        String hrefValue = link.GetAttributeValue("href", string.Empty);
                        if (hrefValue[0] == 'h')
                            result.Add(hrefValue);
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                logger.Warn(e);
            }
            return null;
        }
    }
}

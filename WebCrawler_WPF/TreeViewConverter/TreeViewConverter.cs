using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using WebCrawler_WPF;

namespace WebCrawler_WPF.TreeViewConverter
{
    public class TreeViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CrawlResult crawlResult = value as CrawlResult;
            if (crawlResult == null)
            {
                return new object();
            }

            TreeViewItem currentTreeViewItem = CreateTreeViewItem("Result:");
            ConvertCrawlResultToTreeViewItem(crawlResult, currentTreeViewItem);

            return new List<TreeViewItem>() { currentTreeViewItem };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private TreeViewItem ConvertCrawlResultToTreeViewItem(CrawlResult crawlResult, TreeViewItem treeViewItem)
        {
            if (crawlResult == null)
            {
                return null;
            }
            foreach (KeyValuePair<string, CrawlResult> urlUnit in crawlResult.InnerUrls)
            {
                TreeViewItem currentTreeViewItem = CreateTreeViewItem(urlUnit.Key);
                ConvertCrawlResultToTreeViewItem(urlUnit.Value, currentTreeViewItem);
                treeViewItem.Items.Add(currentTreeViewItem);
            }
            return treeViewItem;
        }

        private TreeViewItem CreateTreeViewItem(string header)
        {
            return new TreeViewItem() { Header = header };
        }
    }
}

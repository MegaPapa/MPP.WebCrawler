using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WebCrawler_WPF.AsyncCommands;
using WebCrawler_WPF.Model;

namespace WebCrawler_WPF.ViewModel
{
    public class CrawlerViewModel : ViewModelRoot
    {
        private CrawlerModel crawlerModel;
        private int maxDepth;
        private String xmlRootPath;
        private CrawlResult crawlResult;
        private AsynchronousCommand startCrawlCommand;
        private AsynchronousCommand openDialogCommand;
        private String outputString;

        public AsynchronousCommand StartCrawlCommand
        {
            get { return startCrawlCommand; }
        }

        public AsynchronousCommand OpenDialogCommand
        {
            get { return openDialogCommand; }
        }

        private void InitializeCommands()
        {
            //Command to start crawling
            startCrawlCommand = new AsynchronousCommand(async () =>
            {
                if (File.Exists(@xmlRootPath))
                {
                    if (startCrawlCommand.CanExecute)
                        startCrawlCommand.CanExecute = false;

                    CrawlResult = await Task.Run(() => crawlerModel.GetCrawlResultAsync());
                    startCrawlCommand.CanExecute = true;
                    OutputString = DictionaryOutputFormatter.FormatOutput(crawlResult, 0);
                }
            });

            //Command for open file dialog
            openDialogCommand = new AsynchronousCommand(async () =>
            {
                if (startCrawlCommand.CanExecute != false)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    Nullable<bool> result = openFileDialog.ShowDialog();
                    if (result == true)
                        XmlRootPath = (openFileDialog.FileName);
                }
            });
        }

        public CrawlerViewModel()
        {
            crawlerModel = new CrawlerModel();
            InitializeCommands(); //Initialize all async commands
        }

        

        /*---properties---*/
        public String OutputString
        {
            get { return outputString; }
            set
            {
                if (startCrawlCommand.CanExecute != false)
                {
                    outputString = value;
                    OnPropertyChanged("OutputString");
                }
            }
        }

        public int MaxDepth
        {
            get { return maxDepth; }
            set
            {
                if (startCrawlCommand.CanExecute != false)
                {
                    if (value >= 6)
                        maxDepth = 6;
                    else
                        maxDepth = value;
                    crawlerModel.SetNewCrawlingLevel(maxDepth);
                    OnPropertyChanged("MaxDepth");
                }
            }
        }

        
        public String XmlRootPath
        {
            get { return xmlRootPath; }
            set 
            {
                if (startCrawlCommand.CanExecute != false)
                {
                    if (File.Exists(@value))
                        xmlRootPath = value;
                    else
                        xmlRootPath = "NaN";
                    crawlerModel.SetXmlPath(xmlRootPath);
                    OnPropertyChanged("XmlRootPath");
                }
            }
        }

        public CrawlResult CrawlResult
        {
            get { return crawlResult; }
            set
            {
                crawlResult = value;
                MessageBox.Show(value.InnerUrls.Count.ToString());
            }
        }

       /*---properties end---*/
    }
}

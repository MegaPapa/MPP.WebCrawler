using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP_WebCrawler
{
    class ParametersContainer
    {
        private String url;
        public String Url 
        { 
            get { return url; }
            set { url = value; }
        }
        private int depth;
        public int Depth
        {
            get { return depth; }
            set { depth = value; }
        }
    }
}

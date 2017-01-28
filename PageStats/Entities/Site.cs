using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PageStats.Readers;

namespace PageStats.Entities
{
    /**
     * This class will map the whole site to lists of elements
     * 
     **/
    public class Site
    {
        public List<HtmlNode> Resources { get; private set; }
        public Site()
        {
            this.Resources = new List<HtmlNode>();
        }


    }
}

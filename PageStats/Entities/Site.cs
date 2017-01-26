using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace PageStats.Entities
{
    
    public class Site
    {
        private HtmlDocument Document;
        private List<HtmlNode> Resources;
        public Site(HtmlDocument document)
        {
            this.Resources = new List<HtmlNode>();
            this.Document = document;
            MapResources();
        }

        private void MapResources()
        {
            this.Resources = this.Document.DocumentNode.Descendants("img").ToList();
        }

        public List<HtmlNode> GetResources()
        {
            return this.Resources;
        }

        
    }
}

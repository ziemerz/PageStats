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
        private List<HtmlNode> ResourcesImg;
        private List<HtmlNode> ResourcesScript;
        private List<HtmlNode> ResourcesCSS;
        public Site(HtmlDocument document)
        {
            this.ResourcesImg = new List<HtmlNode>();
            this.ResourcesScript = new List<HtmlNode>();
            this.ResourcesCSS = new List<HtmlNode>();

            this.Document = document;
            MapResources();
        }

        private void MapResources()
        {
            this.ResourcesImg = this.Document.DocumentNode.Descendants("img").ToList();
            this.ResourcesScript = this.Document.DocumentNode.Descendants("script")
                .Where(s => s.Attributes.Contains("src"))
                .ToList();
            this.ResourcesCSS = this.Document.DocumentNode.Descendants("link")
                .Where(c => c.Attributes.Contains("href"))
                .Where(c => c.Attributes["rel"].Value.Equals("stylesheet"))
                .ToList();
        }

        public List<HtmlNode> GetImgResources()
        {
            return this.ResourcesImg;
        }

        public List<HtmlNode> GetScriptResources()
        {
            return this.ResourcesScript;
        }

        public List<HtmlNode> GetCSSResources()
        {
            return this.ResourcesCSS;
        }


    }
}

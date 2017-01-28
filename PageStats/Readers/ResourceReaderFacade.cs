using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace PageStats.Readers
{
    class ResourceReaderFacade : IResourceReaderFacade
    {
        IResourceReader ResourceReader;
        public ResourceReaderFacade(IResourceReader resourceReader)
        {
            this.ResourceReader = resourceReader;
        }
        public List<HtmlNode> GetAllResources(HtmlDocument document)
        {
            List<HtmlNode> resources = new List<HtmlNode>();
            resources.AddRange(GetCSSResources(document));
            resources.AddRange(GetImageResources(document));
            resources.AddRange(GetScriptResources(document));
            return resources;
        }

        public List<HtmlNode> GetCSSResources(HtmlDocument document)
        {
            return ResourceReader.ReadCSS(document);
        }

        public List<HtmlNode> GetImageResources(HtmlDocument document)
        {
            return ResourceReader.ReadImages(document);
        }

        public List<HtmlNode> GetScriptResources(HtmlDocument document)
        {
            return ResourceReader.ReadScripts(document);
        }

        public double GetResourceSize(HtmlNode node)
        {
            return ResourceReader.GetResourceSize(node);
        }

        public String GetResourceString(HtmlNode node)
        {
            return ResourceReader.ReadResource(node);
        }

        public double GetTotalSize()
        {
            throw new NotImplementedException();
        }
    }
}

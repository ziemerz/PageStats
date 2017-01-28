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
        HtmlDocument Document;
        public ResourceReaderFacade(IResourceReader resourceReader)
        {
            this.ResourceReader = resourceReader;
        }
        public List<HtmlNode> getAllResources(HtmlDocument document)
        {
            List<HtmlNode> resources = new List<HtmlNode>();
            resources.AddRange(getCSSResources(document));
            resources.AddRange(getImageResources(document));
            resources.AddRange(getScriptResources(document));
            return resources;
        }

        public List<HtmlNode> getCSSResources(HtmlDocument document)
        {
            return ResourceReader.ReadCSS(document);
        }

        public List<HtmlNode> getImageResources(HtmlDocument document)
        {
            return ResourceReader.ReadImages(document);
        }

        public List<HtmlNode> getScriptResources(HtmlDocument document)
        {
            return ResourceReader.ReadScripts(document);
        }

        public double getResourceSize(string url)
        {
            return ResourceReader.GetResourceSize(url);
        }

        public String getResourceString(string url)
        {
            return ResourceReader.ReadResource(url);
        }

        public double getTotalSize()
        {
            throw new NotImplementedException();
        }
    }
}

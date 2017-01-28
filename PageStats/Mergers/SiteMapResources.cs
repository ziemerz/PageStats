using HtmlAgilityPack;
using PageStats.Entities;
using PageStats.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageStats.Mergers
{
    class SiteMapResources
    {
        IResourceReaderFacade ResourceReader;
        public SiteMapResources(IResourceReaderFacade resourceReader)
        {
            this.ResourceReader = resourceReader;
        }

        public void MapToSite(ref Site site, HtmlDocument document)
        {
            site.Resources.AddRange(ResourceReader.GetAllResources(document));
        }
    }
}

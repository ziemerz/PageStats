using PageStats.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using PageStats.Formatters;
using PageStats.Readers;
using PageStats.Mergers;

namespace PageStats.Connectors
{
    public class PageConnector : IConnector
    {
        private IResourceReaderFacade ResourceReader;

        public PageConnector(IResourceReaderFacade resourceReader)
        {
            this.ResourceReader = resourceReader;
        }
        public Site GetSite(String url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();

            HtmlDocument document = htmlWeb.Load(url);
            Site site = new Site();
            SiteMapResources mapper = new SiteMapResources(ResourceReader);
            mapper.MapToSite(ref site, document);
            return site;
        }
    }
}

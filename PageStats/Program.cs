using HtmlAgilityPack;
using PageStats.Connectors;
using PageStats.Entities;
using PageStats.Formatters;
using PageStats.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PageStats
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IResourceReader resourceReader = new ResourceReader();
            IResourceReaderFacade resourceReaderFacade = new ResourceReaderFacade(resourceReader);
            PageConnector PageConnector = new PageConnector(resourceReaderFacade);

            Site site = PageConnector.GetSite("http://oasen2720.dk/");

            foreach (HtmlNode node in site.Resources)
            {

                String getUrl = URITrimmer.TrimUrl(node.Attributes["href"].Value);
                WebRequest req = WebRequest.Create(getUrl);

                req.Method = "HEAD";
                using (WebResponse resp = req.GetResponse())
                {
                    double size = (double)resp.ContentLength;
                    if (size == -1)
                    {
                        size = resourceReader.GetResourceSize(getUrl);
                    }
                    string sizeWithEnding = "";
                    if (size > 1024)
                    {
                        sizeWithEnding = SizeFormatter.FormatToKB(size) + " Kb";
                    }
                    else if (size > 1024 * 1024)
                    {
                        sizeWithEnding = SizeFormatter.FormatToMB(size) + "Mb";
                    }
                    else
                    {
                        sizeWithEnding = size + " bytes";
                    }
                    Console.WriteLine("Size of: " + node.Attributes["href"].Value + " is: " + sizeWithEnding);
                }

            }
        }
    }
}

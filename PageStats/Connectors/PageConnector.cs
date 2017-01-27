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

namespace PageStats.Connectors
{
    public class PageConnector : IConnector
    {
        public Site GetSite(String url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();

            HtmlDocument document = htmlWeb.Load(url);
            Site site = new Site(document);

            foreach (HtmlNode node in site.GetCSSResources())
            {
                String getUrl = URITrimmer.TrimUrl(node.Attributes["href"].Value);
                WebRequest req = WebRequest.Create(getUrl);
                req.Method = "HEAD";
                using (WebResponse resp = req.GetResponse())
                {
                    double size = (double)resp.ContentLength;
                    if(size == -1)
                    {
                        size = ResourceReader.GetResourceSize(getUrl);
                    }
                    string sizeWithEnding = "";
                    if (size > 1024)
                    {
                        sizeWithEnding = SizeFormatter.FormatToKB(size) + " Kb";
                    } else if(size > 1024 * 1024)
                    {
                        sizeWithEnding = SizeFormatter.FormatToMB(size) + "Mb";
                    } else
                    {
                        sizeWithEnding = size + " bytes";
                    }
                    Console.WriteLine("Size of: " + node.Attributes["href"].Value + " is: " + sizeWithEnding);
                }
               
            }
            return null;
        }
    }
}

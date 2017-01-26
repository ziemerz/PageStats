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

namespace PageStats.Connectors
{
    public class PageConnector : Connector
    {
        public Site GetSite(String url)
        {
            /*
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(url);
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            Console.Write(objReader.ReadToEnd());
            Console.Read();
            */
            HtmlWeb htmlWeb = new HtmlWeb();

            HtmlAgilityPack.HtmlDocument document = htmlWeb.Load(url);

            Site site = new Site(document);

            foreach (HtmlNode node in site.GetResources())
            {
                WebRequest req = WebRequest.Create(node.Attributes["src"].Value);
                req.Method = "HEAD";
                using (WebResponse resp = req.GetResponse())
                {
                    double size = (double)resp.ContentLength;
                    string sizeWithEnding = "";
                    if (resp.ContentLength > 1024)
                    {
                        sizeWithEnding = SizeFormatter.FormatToKB(size) + " Kb";
                    } else if(resp.ContentLength > 1024 * 1024)
                    {
                        sizeWithEnding = SizeFormatter.FormatToMB(size) + "Mb";
                    } else
                    {
                        sizeWithEnding = size + " bytes";
                    }
                    Console.WriteLine("Size of: " + node.Attributes["src"].Value + " is: " + sizeWithEnding);
                }
               
            }
            {

            }
            


            return null;
        }
    }
}

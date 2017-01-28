using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PageStats.Readers
{
    public class ResourceReader : IResourceReader
    {
        /**
         * Reads all resources with no header with Content-Length. This includes pure HTML documents
         **/
        public  String ReadResource(string url)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(url);
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public double GetResourceSize(string url)
        {
            return ASCIIEncoding.Unicode.GetByteCount(ReadResource(url));
        }

        public List<HtmlNode> ReadCSS(HtmlDocument document)
        {
            return document.DocumentNode.Descendants("link")
                .Where(c => c.Attributes.Contains("href"))
                .Where(c => c.Attributes["rel"].Value.Equals("stylesheet"))
                .ToList();
        }

        public List<HtmlNode> ReadScripts(HtmlDocument document)
        {
            return document.DocumentNode.Descendants("script")
                .Where(s => s.Attributes.Contains("src"))
                .ToList();
        }

        public List<HtmlNode> ReadImages(HtmlDocument document)
        {
            return document.DocumentNode.Descendants("img").ToList();
        }
    }
}

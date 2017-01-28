using HtmlAgilityPack;
using PageStats.Formatters;
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
        public  String ReadResource(HtmlNode node)
        {
            String getUrl = UrlFormatter(node);
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(getUrl);
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public double GetResourceSize(HtmlNode node)
        {
            return ASCIIEncoding.Unicode.GetByteCount(ReadResource(node));
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

        /**
         * Checks what kind of node has been parsed, makes a request to the resource and returns the response
         **/
        public WebResponse GetResourceResponse(HtmlNode node)
        {
            WebRequest request = WebRequest.Create(UrlFormatter(node));
            request.Method = "HEAD";
            return request.GetResponse();
        }

        private String UrlFormatter(HtmlNode node)
        {
            if (node.ChildAttributes("href").Any())
            {
                return URITrimmer.TrimUrl(node.Attributes["href"].Value);
            }
            else if (node.ChildAttributes("src").Any())
            {
                return URITrimmer.TrimUrl(node.Attributes["src"].Value);
            }
            return "";
        }
    }
}

using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using PageStats.Formatters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace PageStats.Readers
{
    public class ResourceReaderDeprecated
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

        public String ReadResource(String url)
        {
            String getUrl = URITrimmer.TrimUrl(url);
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(getUrl);
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public double GetResourceSize(HtmlNode node)
        {
            return ASCIIEncoding.Unicode.GetByteCount(ReadResource(node));
        }

        public double GetResourceSize(String html)
        {
            return ASCIIEncoding.Unicode.GetByteCount(html);
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

        public List<String> ReadAlternativeImgUrls(HtmlDocument document)
        {
            List<String> images = new List<String>();
            foreach (HtmlNode node in document.DocumentNode.SelectNodes("//body"))
            {
                string style = node.Attributes["style"].Value;
                string Img = Regex.Match(style, @"(?<=\().+?(?=\))").Value;
                images.Add(Img);
            }
            return images;
        }

        /**
         * Checks what kind of node has been parsed, makes a request to the resource and returns the response
         **/
        public WebResponse GetResourceResponse(HtmlNode node, String baseUrl)
        {
            Console.WriteLine(UrlFormatter(node));
            String url = UrlFormatter(node);
            WebRequest request;
            try
            {
                request = WebRequest.Create(url);
            } catch (Exception)
            {
                request = WebRequest.Create(baseUrl + url);
            }
            request.Method = "HEAD";

            WebResponse response = null;
            // TODO: Handle 403 forbidden exception here. "System.Net.WebException"
            try
            {
                response = request.GetResponse();
            }
            catch (System.Net.WebException ex)
            {
                Console.Write(ex.Message);
            }
            return response;
        }

        //Alternative
        public WebResponse GetResourceResponse(String url)
        {
            String Url = URITrimmer.TrimUrl(url);
            WebRequest request;
            try
            {
                request = WebRequest.Create(url);
            }
            catch (Exception)
            {
                request = WebRequest.Create(url);
            }
            request.Method = "HEAD";

            WebResponse response = null;
            // TODO: Handle 403 forbidden exception here. "System.Net.WebException"
            try
            {
                response = request.GetResponse();
            }
            catch (System.Net.WebException ex)
            {
                Console.Write(ex.Message);
            }
            return response;
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

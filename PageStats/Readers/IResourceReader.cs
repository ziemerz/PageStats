using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PageStats.Readers
{
    interface IResourceReader
    {
        String ReadResource(HtmlNode node);
        double GetResourceSize(HtmlNode node);
        List<HtmlNode> ReadCSS(HtmlDocument document);
        List<HtmlNode> ReadScripts(HtmlDocument document);
        List<HtmlNode> ReadImages(HtmlDocument document);
        WebResponse GetResourceResponse(HtmlNode node);


    }
}

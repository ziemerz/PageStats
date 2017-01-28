using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageStats.Readers
{
    interface IResourceReader
    {
        String ReadResource(string url);
        double GetResourceSize(string url);
        List<HtmlNode> ReadCSS(HtmlDocument document);
        List<HtmlNode> ReadScripts(HtmlDocument document);
        List<HtmlNode> ReadImages(HtmlDocument document);

    }
}

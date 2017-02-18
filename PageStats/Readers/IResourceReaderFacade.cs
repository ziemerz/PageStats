using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageStats.Readers
{
    public interface IResourceReaderFacade
    {
        List<HtmlNode> GetAllResources(HtmlDocument document);
        String ReadHTML(String url);
        double GetResourceSize(String html);
        double GetResourceSize(HtmlNode node);
        double GetTotalSize();

        List<HtmlNode> GetCSSResources(HtmlDocument document);
        List<HtmlNode> GetScriptResources(HtmlDocument document);
        List<HtmlNode> GetImageResources(HtmlDocument document);
    }
}

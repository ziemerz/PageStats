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
        double GetTotalSize();

        List<HtmlNode> GetCSSResources(HtmlDocument document);
        List<HtmlNode> GetScriptResources(HtmlDocument document);
        List<HtmlNode> GetImageResources(HtmlDocument document);
    }
}

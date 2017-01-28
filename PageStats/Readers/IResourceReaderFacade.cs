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
        List<HtmlNode> getAllResources(HtmlDocument document);
        double getTotalSize();

        List<HtmlNode> getCSSResources(HtmlDocument document);
        List<HtmlNode> getScriptResources(HtmlDocument document);
        List<HtmlNode> getImageResources(HtmlDocument document);
    }
}

using HtmlAgilityPack;
using PageStats.Entities;
using PageStats.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageStats.Collectors
{
    class CSSCollector : TypeCollector
    {
        public override List<Resource> Collect(string baseUrl)
        {
            List<String> CSSUrls = ResourceIsolator.IsolateCSSUrls(baseUrl);
            List<Resource> Resources = ResourceReader.ReadCSS(CSSUrls);
            return Resources;
        }
    }
}

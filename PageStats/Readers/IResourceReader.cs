using PageStats.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageStats.Readers
{
    interface IResourceReader
    {
        List<Resource> ReadHTML(List<String> urls);
        List<Resource> ReadCSS(List<String> urls);
        List<Resource> ReadScripts(List<String> urls);
        List<Resource> ReadImages(List<String> urls);
    }
}

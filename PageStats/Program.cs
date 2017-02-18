using HtmlAgilityPack;
using PageStats.Collectors;
using PageStats.Entities;
using PageStats.Facades;
using PageStats.Formatters;
using PageStats.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PageStats
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<TypeCollector> Collectors = new List<TypeCollector>();
            Collectors.Add(new HTMLCollector());
            Collectors.Add(new CSSCollector());
            Collectors.Add(new ScriptCollector());
            Collectors.Add(new ImageCollector());

            IResourceCollector ResourceCollector = new ResourceCollector(Collectors);
            IActions action = new Actions(ResourceCollector);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageStats.Entities;

namespace PageStats.Facades
{
    class Actions : IActions
    {
        private IResourceCollector ResourceCollector;
        public Actions(IResourceCollector collector)
        {
            this.ResourceCollector = collector;
        }

        public List<Resource> Analyze(string baseUrl)
        {
            return ResourceCollector.GatherResources(baseUrl);
        }

        public String ExportCSV(List<Resource> resources)
        {
            //This is a completely different part of the software. Will be implemented at a much later time
            throw new NotImplementedException();
        }

        public String ImportCSV(String file)
        {
            //This is a completely different part of the software. Will be implemented at a much later time
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageStats.Entities;
using PageStats.Collectors;

namespace PageStats.Facades
{
    class ResourceCollector : IResourceCollector
    {
        List<TypeCollector> Collectors;
        public ResourceCollector(List<TypeCollector> collectors)
        {
            this.Collectors = collectors;
        }
        public List<Resource> GatherResources(string baseUrl)
        {
            List<Resource> Resources = new List<Resource>();
            foreach (TypeCollector collector in Collectors)
            {
                Resources.Concat(collector.Collect(baseUrl));
            }
            return Resources;
        }
    }
}

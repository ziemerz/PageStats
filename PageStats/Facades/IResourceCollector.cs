using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageStats.Facades
{
    interface IResourceCollector
    {
        List<Resource> GatherResources(String baseUrl);
    }
}

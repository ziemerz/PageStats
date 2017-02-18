using PageStats.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageStats.Collectors
{
    interface TypeCollector
    {
        List<Resource> Collect(String baseUrl);
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageStats.Facades
{
    interface IActions
    {
        List<Resource> Analyze(String baseUrl);
        File ExportCSV(List<Resource> resources);
        File ImportCSV(File file);
    }
}

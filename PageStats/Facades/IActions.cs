using PageStats.Entities;
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

        //Change return type to something file-ish
        String ExportCSV(List<Resource> resources);
        
        //Change the return and param type to something else. Should be File - File
        String ImportCSV(String file);
    }
}

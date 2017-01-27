using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PageStats.Readers
{
    public static class ResourceReader
    {
        public static String ReadResource(string url)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(url);
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static double GetResourceSize(string url)
        {
            return ASCIIEncoding.Unicode.GetByteCount(ReadResource(url));
        }
    }
}

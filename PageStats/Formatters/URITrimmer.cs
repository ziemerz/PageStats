using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageStats.Formatters
{
    public static class URITrimmer
    {
        public static String TrimUrl(String url)
        {
            if (url.Substring(0, 2).Equals("//"))
            {
                return "http:" + url;
            }
            return url;
            
        }
    }
}

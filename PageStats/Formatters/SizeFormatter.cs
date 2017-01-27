using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageStats.Formatters
{
    public static class SizeFormatter
    {
        public static double FormatToMB(double value)
        {
            return Math.Round((value / (1024 * 1024)), 2);
        }

        public static double FormatToKB(double value)
        {
            return Math.Round((value / 1024), 2);
        }

    }
}

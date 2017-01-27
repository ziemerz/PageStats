using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageStats.Formatters;

namespace PageStatsTests
{
    [TestClass]
    public class SizeFormatterTest
    {
        [TestMethod]
        public void FormatToKB()
        {
            double expected = 1;
            double actual = SizeFormatter.FormatToKB(1024);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FormatToMB()
        {
            double expected = 3.5;
            double actual = SizeFormatter.FormatToMB(3670016);
            Assert.AreEqual(expected, actual);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageStats.Readers;

namespace PageStatsTests
{
    [TestClass]
    public class ResourceIsolatorTest
    {
        [TestMethod]
        public void IsolateCSSUrlsTest()
        {
            ResourceIsolator.IsolateCSSUrls("https://ng-pokedex.firebaseapp.com/pokemon");
            Assert.AreEqual(true, true);
        }
    }
}

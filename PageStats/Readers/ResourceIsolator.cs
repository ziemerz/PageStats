using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageStats.Readers
{
    //This class will do the actual scraping for the URLS. The ResourceReader will get all neccesary information about the URLS and map it to a Resource. 
    static public class ResourceIsolator
    {
        static public List<String> IsolateCSSUrls(String baseUrl)
        {
            //We need a Selenium RC started for this to work. Maybe find an alternative?!
            IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.HtmlUnitWithJavaScript());
            driver.Navigate().GoToUrl(baseUrl);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            String source = driver.PageSource;
            Console.Write("Printing source...");
            Console.Write(source);
            return null;
        }
    }
}

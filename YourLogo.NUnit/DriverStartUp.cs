using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Threading;
using System.Runtime;
using YourLogo;

namespace YourLogo.NUnit
{
    public class DriverStartup
    {
        IWebDriver _driver;
        public IWebDriver Driver()
        {
            return _driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
        }
    }

}
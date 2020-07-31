using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
using System.IO;
using System.Threading;
using System.Runtime;
using NUnit.Framework;

namespace  YourLogo.NUnit
{
    

    public class TestBase
    {
        IWebDriver _driver;
        public TestBase(IWebDriver driver)
        {
            _driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
        }

        public void AssertEnabledAndDisplayed(IWebElement element)
        {
            Assert.That(element.Enabled);
            Assert.That(element.Displayed);
        }

        public void AssertTextContains(IWebElement element, string text)
        {
            Assert.That(element.Text.Contains(text));
        }

        public void AssertTextEquals(IWebElement element, string text)
        {
            Assert.That(element.Text == text);
        }

    }
}
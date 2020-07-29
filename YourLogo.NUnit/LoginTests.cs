using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
using System.IO;
using System.Threading;
using System.Runtime;

namespace YourLogo.NUnit
{
    public class LoginTests
    {
        IWebDriver driver;

        [SetUp]
        public void Before()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
        }

        [TearDown]
        public void After()
        {

        }

        [Test]
        public void BasicLoginTest()
        {
            driver.Url = "http://automationpractice.com/index.php?";

            driver.FindElement(By.CssSelector("a[href='http://automationpractice.com/index.php?controller=my-account']")).Click();
            
            WebDriverWait waiter = new WebDriverWait(driver, System.TimeSpan.FromSeconds(90));
            waiter.Until(ExpectedConditions.ElementExists(By.CssSelector("#email")));
            waiter.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#email")));
            Thread.Sleep(1000);

            IWebElement emailAddressField = driver.FindElement(By.CssSelector("#email"));
                        
            Assert.That(emailAddressField.Displayed);
            Assert.That(emailAddressField.Enabled);

            

        }
    }
}
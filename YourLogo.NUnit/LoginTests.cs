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

            emailAddressField.SendKeys("johnathanbeal@gmail.com");

            var passwordField = driver.FindElement(By.CssSelector("#passwd"));

            Assert.That(passwordField.Displayed);
            Assert.That(passwordField.Enabled);
            
            passwordField.SendKeys("9D^?}xlU>,_c");
            Thread.Sleep(1000);

            var signInButton = driver.FindElement(By.CssSelector("#SubmitLogin"));
            signInButton.Click();
            Thread.Sleep(1000);
        }

        [Test]
        public void WrongEmailLoginTest()
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
            emailAddressField.SendKeys("jbealer@gmail.com");

var passwordField = driver.FindElement(By.CssSelector("#passwd"));

            Assert.That(passwordField.Displayed);
            Assert.That(passwordField.Enabled);
            
            passwordField.SendKeys("9D^?}xlU>,_c");
            Thread.Sleep(1000);

            var signInButton = driver.FindElement(By.CssSelector("#SubmitLogin"));
            signInButton.Click();
            Thread.Sleep(3000);

            waiter.Until(ExpectedConditions.ElementExists(By.CssSelector(".alert.alert-danger")));
            waiter.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".alert.alert-danger")));
            var alertDiv = driver.FindElement(By.CssSelector(".alert.alert-danger"));

            Assert.That(alertDiv.Text.Contains("There is 1 error"));
            Assert.That(alertDiv.Text.Contains("Authentication failed."));
            
        }
    }
}
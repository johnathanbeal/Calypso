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
        DriverStartup Driver;
        IWebDriver driver;


        [SetUp]
        public void Before()
        {
            Driver = new DriverStartup();
            driver = Driver.Driver();
            
        }

        [TearDown]
        public void After()
        {
            driver.Close();
            Driver.Driver().Close();
            
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

            var myAccountSpan = driver.FindElement(By.CssSelector(".navigation_page"));

            Assert.That(myAccountSpan.Displayed);
            Assert.That(myAccountSpan.Enabled);

            Assert.That(myAccountSpan.Text.Contains("My account"));

            var myAccountHeader = driver.FindElement(By.CssSelector("span.navigation_page"));

            Assert.That(myAccountHeader.Displayed);
            Assert.That(myAccountHeader.Enabled);

            Assert.That(myAccountHeader.Text == "My account");

            var welcomeMessage = driver.FindElement(By.CssSelector("p.info-account"));

            Assert.That(welcomeMessage.Displayed);
            Assert.That(welcomeMessage.Enabled);

            Assert.That(welcomeMessage.Text.Contains("Welcome to your account. Here you can manage all of your personal information and orders."));

            var myName = driver.FindElement(By.CssSelector("a.account"));

            Assert.That(myName.Displayed);
            Assert.That(myName.Enabled);

            Assert.That(myName.Text == "Johnathan Beal");
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

        [Test]
        public void BadPasswordLoginTest()
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
            
            passwordField.SendKeys("badpassword");
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
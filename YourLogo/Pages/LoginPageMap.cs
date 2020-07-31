using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
using System.IO;
using System.Threading;
using System.Runtime;

namespace YourLogo
{
    public class LoginPageMap : Base
    {       
        IWebDriver _driver;

        public LoginPageMap(IWebDriver driver) : base (driver)
        {
            _driver = driver;
            _driver.Url = "http://automationpractice.com/index.php?";
        }

        public void CloseDriver()
        {
            _driver.Close();
        }

        public string HomepageUrl => _driver.Url;

        public IWebElement SignInLink => _driver.FindElement(By.CssSelector("a[href='http://automationpractice.com/index.php?controller=my-account']"));
        
        public IWebElement EmailAddressField => _driver.FindElement(By.CssSelector("#email"));

        public IWebElement PasswordField => _driver.FindElement(By.CssSelector("#passwd"));

        public IWebElement SignInButton => _driver.FindElement(By.CssSelector("#SubmitLogin"));

        public IWebElement MyAccountSpan => _driver.FindElement(By.CssSelector(".navigation_page"));

        public IWebElement MyAccountHeader => _driver.FindElement(By.CssSelector("span.navigation_page"));

        public IWebElement WelcomeMessage => _driver.FindElement(By.CssSelector("p.info-account"));
        
        public IWebElement MyName => _driver.FindElement(By.CssSelector("a.account"));
        
        public IWebElement Alert => _driver.FindElement(By.CssSelector(".alert.alert-danger"));
        
        //public IWebElement WomenTab => _driver.FindElement(By.CssSelector("#block_top_menu > ul > li:nth-child(1) > a"));
        public IWebElement WomenTab => _driver.FindElement(By.LinkText("Women"));

    }
}
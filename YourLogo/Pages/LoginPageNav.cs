
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
using System.IO;
using System.Threading;
using System.Runtime;

namespace YourLogo
{
    public class LoginPageNav : Base
    {       
        public LoginPageMap Map;

        public IWebDriver _driver;

        public LoginPageNav(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            Map = new LoginPageMap(driver);
        }

        public void CloseDriver()
        {
            _driver.Close();
            Map.CloseDriver();
        }

        public void Login()
        {
            _driver.Url = Map.HomepageUrl;

            Map.SignInLink.Click();
            
            WaitByCss(_driver, "#email");
                       
            Map.EmailAddressField.SendKeys("johnathanbeal@gmail.com");
            
            Map.PasswordField.SendKeys("9D^?}xlU>,_c");

            Map.SignInButton.Click();          
        }

        public void ClickWomenTab()
        {
            Map.WomenTab.Click();
        }

    }
}
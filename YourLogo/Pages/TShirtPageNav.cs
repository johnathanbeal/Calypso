using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
using System.IO;
using System.Threading;
using System.Runtime;

namespace  YourLogo
{
    public class TShirtPageNav : Base
    {
        public TShirtsPageMap Map;
        public LoginPageNav LoginPage;
        IWebDriver _driver;
        public TShirtPageNav(IWebDriver driver) : base (driver)
        {
            _driver = driver;
            Map = new TShirtsPageMap(_driver);
            
        }

        public void CloseDriver()
        {
            _driver.Close();
            Map.CloseDriver();
        }
    
        public void ClickAddToCart()
        {
            Map.AddToCartButton.Click();
        }

        public void ClickProceedToCheckout()
        {
            Thread.Sleep(1700);
            _driver.SwitchTo().ActiveElement();
            Map.ProceedToCheckoutButton.Click();
            //WaitByCss(_driver, "button.btn.btn-default.standard-checkout.button-medium");
            Thread.Sleep(700);
            Map.ProceedToCheckoutButton.Click();
        }

        public void Comment()
        {
            Map.CommentForm.SendKeys("When you want to succeed as bad as you want to breathe, then you’ll be successful. Eric Thomas");
        }

        public void ClickThirdProceedToCheckoutButton()
        {
            Thread.Sleep(500);
            Map.ThirdProceedToCheckoutButton.Click();
        }

        public void ClickFourthProceedToCheckoutButton()
        {
            Thread.Sleep(500);
            Map.FourthProceedToCheckoutButton.Click();
        }

        public void AgreeToTermsOfService()
        {
            Map.IAgreeToTermsOfServiceCheckBox.Click();
        }

        public void PayByBankWire()
        {
            Map.PayByBankWireLink.Click();
        }

        public void Submit()
        {
            Map.ConfirmOrderButton.Click();
        }
    }
}
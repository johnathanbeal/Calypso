using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
using System.IO;
using System.Threading;
using System.Runtime;

namespace  YourLogo
{
    

    public class TShirtsPageMap 
    {
        IWebDriver _driver;
        public TShirtsPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public void CloseDriver()
        {
            _driver.Close();
        }

        public IWebElement SortBySelect => _driver.FindElement(By.CssSelector("selectProductSort"));

        public IWebElement AddToCartButton => _driver.FindElement(By.CssSelector("a.button.ajax_add_to_cart_button.btn.btn-default"));

        public IWebElement ProceedToCheckoutButton => _driver.FindElement(By.LinkText("Proceed to checkout"));

        //public IWebElement SecondProceedToCheckoutButton => _driver.FindElement(By.CssSelector("button.btn.btn-default.standard-checkout.button-medium"));

        public IWebElement CommentForm => _driver.FindElement(By.CssSelector("textarea.form-control"));
    
        public IWebElement ThirdProceedToCheckoutButton => _driver.FindElement(By.Name("processAddress"));

        public IWebElement FourthProceedToCheckoutButton => _driver.FindElement(By.Name("processCarrier"));

        public IWebElement IAgreeToTermsOfServiceCheckBox => _driver.FindElement(By.Id("cgv"));

        public IWebElement PayByBankWireLink => _driver.FindElement(By.ClassName("bankwire"));

        public IWebElement ConfirmOrderButton => _driver.FindElement(By.CssSelector("button.btn.btn-default.button-medium"));
    }

}
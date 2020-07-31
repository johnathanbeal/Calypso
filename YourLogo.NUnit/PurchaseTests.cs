using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using NUnit.Framework;
using YourLogo;

namespace YourLogo.NUnit
{
    public class PurchaseTests
    {
        TShirtPageNav TShirtPage;
        LoginPageNav LoginPage;
        DriverStartup Driver;
        IWebDriver _driver;

        [SetUp]
        public void Before()
        {
            Driver = new DriverStartup();
            _driver = Driver.Driver();
            TShirtPage = new TShirtPageNav(_driver);
            LoginPage = new LoginPageNav(_driver);
        }

        [TearDown]
        public void After()
        {
            //_driver.Close();
            //Driver.Driver().Close();
            //LoginPage.CloseDriver();
            //TShirtPage.CloseDriver();
        }

        [Test]
        public void ImpulsePurchase()
        {
            LoginPage.Login();
            LoginPage.ClickWomenTab();
            TShirtPage.ClickAddToCart();
            
            TShirtPage.ClickProceedToCheckout();
            TShirtPage.Comment();
            TShirtPage.ClickThirdProceedToCheckoutButton();
            TShirtPage.AgreeToTermsOfService();
            TShirtPage.ClickFourthProceedToCheckoutButton();
            TShirtPage.PayByBankWire();
            TShirtPage.Submit();

        }

    }
}
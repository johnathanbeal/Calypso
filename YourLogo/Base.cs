using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
using System.IO;
using System.Threading;
using System.Runtime;
using System;
using System.Collections.Generic;

namespace  YourLogo
{
    

    public class Base
    {
        IWebDriver _driver;
        public Base(IWebDriver driver)
        {
            _driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
        }

        public void WaitByCss(IWebDriver driver, string css)
        {
            WebDriverWait waiter = new WebDriverWait(driver, System.TimeSpan.FromSeconds(90));
            waiter.Until(ExpectedConditions.ElementExists(By.CssSelector(css)));
            waiter.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(css)));
        }

    }

}
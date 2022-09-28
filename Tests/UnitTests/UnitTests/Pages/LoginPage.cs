using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace UnitTests.Pages
{
    public class LoginPage
    {
        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }

        public LoginPage(IWebDriver _webDriver)
        {
            Driver = _webDriver;
            Wait = new WebDriverWait(Driver,TimeSpan.FromSeconds(5));
        }

        public IWebElement BtnLogin => Driver.FindElement(By.XPath("/html/body/div/main/div[2]/form/div[2]/button"));

        public IWebElement TextBoxEmail => Driver.FindElement(By.Id(":r0:"));
        public IWebElement TextBoxPassword => Driver.FindElement(By.Id(":r1:"));

        public string DoLogin()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(":r0:")));
            TextBoxEmail.SendKeys("cilaxo4326@oncebar.com");
            TextBoxPassword.SendKeys("McKNvG2FSjz7Ksz");
            BtnLogin.Click();
            Thread.Sleep(2000);
            return Driver.Url;
        }
    }
}

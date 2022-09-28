using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace UnitTests.Pages
{
    public  class UserPanel
    {
        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }

        public IWebElement BtnAddNewDevice => Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/button[1]"));

        public UserPanel(IWebDriver _webDriver)
        {
            Driver = _webDriver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public string ClickButtonAddNewDevice()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/button[1]")));
            BtnAddNewDevice.Click();
            return Driver.Url;
        }

    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTests.Pages
{
    public class DevicePage
    {

        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }
        public IWebElement TxtDeviceName =>       Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[1]/div[2]/div/div/div/div/div[1]/div/input"));
        public IWebElement TxtDeviceIdentifier => Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[1]/div[2]/div/div/div/div/div[2]/div/input"));

        public IWebElement TxtPhone => Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[2]/div[2]/div/div/div/div/div[2]/div/input"));
        public IWebElement TxtModel => Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[2]/div[2]/div/div/div/div/div[3]/div/input"));
        public IWebElement BtnShowExtra => Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[2]/div[1]"));

        public IWebElement BtnSave => Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[4]/button[2]"));
        public DevicePage(IWebDriver _webDriver)
        {
            Driver = _webDriver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public string FillDeviceInformations(string DeviceName, string DeviceIdentifier, string Phone, string Model)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div/div/div[2]/div/div[1]/div[2]/div/div/div/div/div[1]/div/input")));
            TxtDeviceIdentifier.SendKeys(DeviceIdentifier);
            TxtDeviceName.SendKeys(DeviceName);
            BtnShowExtra.Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div/div/div[2]/div/div[2]/div[2]/div/div/div/div/div[2]/div/input")));
            TxtPhone.SendKeys(Phone);
            TxtModel.SendKeys(Model);
            BtnSave.Click();
            Thread.Sleep(1000);
            return Driver.Url;
        }
    }
}

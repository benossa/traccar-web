using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTests.Pages;

namespace UnitTests.Tests
{
    internal class AddNewDeviceTest
    {

        private IWebDriver ChromeDriver = new ChromeDriver();
        private string siteUrl = @"https://demo3.traccar.org/login";
        private UserPanel userPanel { get; set; }
        private LoginPage loginPage { get; set; }
        private DevicePage devicePage { get; set; }

        [SetUp]
        public void Setup()
        {
            ChromeDriver.Navigate().GoToUrl(siteUrl);
            userPanel = new UserPanel(ChromeDriver);
            loginPage = new LoginPage(ChromeDriver);
            devicePage = new DevicePage(ChromeDriver);
        }

        [Test]
        public void AddNewDevice()
        {
            string response = loginPage.DoLogin();
            if(!siteUrl.Contains(response))
                Assert.Fail();

            response = userPanel.ClickButtonAddNewDevice();
            if (!response.Contains("settings/device"))
                Assert.Fail();

            response = devicePage.FillDeviceInformations("Audi", "1234567890"+DateTime.Now.Second.ToString(),"+358192554","Audi A6");
            if (!siteUrl.Contains(response))
                Assert.Fail();
            else
            Assert.Pass();
        }


        [TearDown]
        public void DisposeRemaining()
        {
            //ChromeDriver.Quit();
        }

    }
}

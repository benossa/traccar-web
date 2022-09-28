using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnitTests.Tests
{
    public  class DoLoginTest
    {
        private IWebDriver ChromeDriver = new ChromeDriver();
        private string siteUrl = @"https://demo3.traccar.org/login";
        [SetUp]
        public void Setup()
        {
            ChromeDriver.Navigate().GoToUrl(siteUrl);
        }
        [Test]
        public void DoLogin()
        {
            LoginPage loginPage = new LoginPage(ChromeDriver);
            string response = loginPage.DoLogin();
            if(siteUrl.Contains(response))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [TearDown]
        public void DisposeRemaining()
        {
            //ChromeDriver.Quit();
        }
    }
}

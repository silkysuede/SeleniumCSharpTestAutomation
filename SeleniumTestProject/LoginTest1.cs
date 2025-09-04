using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using PageObjectModel.Source.Pages;
using System.Configuration;
using NUnit.Framework.Internal;


namespace SeleniumTestProject
{
    public class LoginTests
    {
        private IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void LoginTest()
        {
            string? User = TestContext.Parameters["user"];
            string? Password = TestContext.Parameters["password"];
            LoginPage lg = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(TestContext.Parameters["login_url"]);
            lg.login(User, Password);
        }

        [TearDownAttribute]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}

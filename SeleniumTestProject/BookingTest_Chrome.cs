using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectModel.Source.Pages;
using NUnit.Framework.Internal;

namespace SeleniumTestProject
{
    
    internal class BookingTest_Chrome
    {
        private ChromeDriver _driver;
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Booking()
        {
            BookingPage booking = new BookingPage(_driver);
            booking.Booking();
        }

        [TearDownAttribute]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}

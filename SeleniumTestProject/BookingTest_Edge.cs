using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectModel.Source.Pages;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Edge;

namespace SeleniumTestProject
{

    internal class BookingTest_Edge
    {
        private EdgeDriver _driver;
        [SetUp]
        public void Setup()
        {
            _driver = new EdgeDriver();
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

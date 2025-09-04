using System;
using System.Configuration;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using PageObjectModel.Source.Pages;

namespace SeleniumTestProject
{
    public class GolfTest_Firefox
    {
        private FirefoxDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.FullScreen();
        }

        [Test]
        public void searchTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage golf = new GolfPage(_driver);
            try
            {
                golf.search("Sky Golf Course");
            }
            catch (NoSuchElementException e)
            {
                golf.takeScreenshot("golf");
            }
        }

        [Test]
        public void selectTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage golf = new GolfPage(_driver);
            try
            {
                golf.select("United States");
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e);
            }
        }

        [Test]
        public void addGolf()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage golf = new GolfPage(_driver);
            golf.addGolfCourse();
        }

        [Test]
        public void editGolf()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage golf = new GolfPage(_driver);
            try
            {
                golf.editGolfCourse();
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e);
            }
        }

        [Test]
        public void deleteGolf()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage golf = new GolfPage(_driver);
            try
            {
                golf.deleteGolfCourse();
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e);
            }
        }

        [TearDownAttribute]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}

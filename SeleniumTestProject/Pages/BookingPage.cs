using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace PageObjectModel.Source.Pages
{
    internal class BookingPage
    {
        private IWebDriver _driver;
        [FindsBy(How = How.XPath, Using = "//button[@title='Book schedule for a Golf Course !']")]
        private IWebElement Bookingbtn;
        [FindsBy(How = How.Id, Using = "GolfName")]
        private IWebElement GolfNameSelect;
        [FindsBy(How = How.Id, Using = "Customer")]
        private IWebElement Customertxt;
        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement Emailtxt;
        [FindsBy(How = How.Id, Using = "Phone")]
        private IWebElement Phonetxt;
        [FindsBy(How = How.Id, Using = "Date")]
        private IWebElement Datetxt;
        [FindsBy(How = How.Id, Using = "StartTime")]
        private IWebElement StartTimetxt;
        [FindsBy(How = How.Id, Using = "EndTime")]
        private IWebElement EndTimetxt;
        [FindsBy(How = How.XPath, Using = "//input[@value='Create']")]
        private IWebElement Createbtn;

        public BookingPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Booking()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            Thread.Sleep(1000);
            Bookingbtn.Click();
            Thread.Sleep(1000);
            var selectElement = GolfNameSelect;
            var select = new SelectElement(selectElement);
            select.SelectByText("Tiger A");
            Customertxt.SendKeys("John Smith");
            Emailtxt.SendKeys("john@adminlucid.com");
            Phonetxt.SendKeys("780-2478899");
            IJavaScriptExecutor jse = (IJavaScriptExecutor)_driver; 
            jse.ExecuteScript("document.getElementById('Date').value='2024-03-18'");
            jse.ExecuteScript("document.getElementById('StartTime').value='08:30'");
            jse.ExecuteScript("document.getElementById('EndTime').value='09:30'");
            Createbtn.Click();
        }
    }
}

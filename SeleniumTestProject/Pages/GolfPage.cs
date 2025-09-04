using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace PageObjectModel.Source.Pages
{
    public class GolfPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Name, Using = "SearchString")]
        private IWebElement searchTxt;
        [FindsBy(How = How.XPath, Using = "//input[@name = 'SearchString']/following-sibling::button")]
        private IWebElement searchBtn;
        [FindsBy(How = How.XPath, Using = "//table[@class = 'table']/thead/tr[1]/th[2]")]
        private IWebElement columnAddress;
        [FindsBy(How = How.XPath, Using = "//table[@class = 'table']/thead/tr[1]/th[3]")]
        private IWebElement columnDesc;
        [FindsBy(How = How.XPath, Using = "//table[@class = 'table']/tbody/tr/td[1]")]
        private IWebElement columnNameTwo;
        [FindsBy(How = How.ClassName, Using = "select")]
        private IWebElement selectCountry;
        [FindsBy(How = How.XPath, Using = "//table[@class = 'table']/tbody/tr/td[2]")]
        private IWebElement addressOne;
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody/tr/td[2]/form//button")]
        private IWebElement filter;
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody/tr/td[5]/form//button")]
        private IWebElement addGolf;
        [FindsBy(How = How.Id, Using = "Name")]
        private IWebElement name;
        [FindsBy(How = How.Id, Using = "Address")]
        private IWebElement address;
        [FindsBy(How = How.Id, Using = "City")]
        private IWebElement city;
        [FindsBy(How = How.Id, Using = "Province")]
        private IWebElement province;
        [FindsBy(How = How.Id, Using = "Country")]
        private IWebElement country;
        [FindsBy(How = How.Id, Using = "Description")]
        private IWebElement description;
        [FindsBy(How = How.Id, Using = "LongDes")]
        private IWebElement longDes;
        [FindsBy(How = How.Id, Using = "Owner")]
        private IWebElement owner;
        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement email;
        [FindsBy(How = How.Id, Using = "PhoneNumber")]
        private IWebElement phoneNumber;
        [FindsBy(How = How.XPath, Using = "//input[@value = 'Create']")]
        private IWebElement create;
        [FindsBy(How = How.Id, Using = "Input_Email")]
        private IWebElement emailTxt;
        [FindsBy(How = How.Id, Using = "Input_Password")]
        private IWebElement passwordTxt;
        [FindsBy(How = How.Id, Using = "login-submit")]
        private IWebElement loginBtn;
        [FindsBy(How = How.XPath, Using = "//nav[@class = 'navbar-nav']//a")]
        private IWebElement loginLink;
        [FindsBy(How = How.XPath, Using = "//table[@class = 'table']/tbody/tr/td[6]/a[2]")]
        private IWebElement editLink;
        [FindsBy(How = How.XPath, Using = "//table[@class = 'table']/tbody/tr/td[6]/a[2]")]
        private IWebElement editSaveBtn;
        [FindsBy(How = How.XPath, Using = "//input[@value = 'Save']")]
        private IWebElement deleteLink;
        [FindsBy(How = How.XPath, Using = "//table[@class = 'table']/tbody/tr/td[6]/a[3]")]
        private IWebElement deleteSaveBtn;

        public GolfPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void search(string searchStr)
        {
            searchTxt.Clear();
            searchTxt.SendKeys(searchStr);
            searchBtn.Click();
            IWebElement columnName = _driver.FindElement(By.XPath("//table[2]/thead/tr[1]/th[1]"));
            Assert.That(columnName.Text, Is.EqualTo("Name ^"));
            Assert.That(columnAddress.Text, Is.EqualTo("Address"));
            Assert.That(columnDesc.Text, Is.EqualTo("Description"));
            Assert.That(columnNameTwo.Text, Is.EqualTo(searchStr));
        }

        public void select(string country)
        {
            var selectElement = selectCountry;
            var select = new SelectElement(selectElement);
            select.SelectByText(country);
            filter.Click();
            IWebElement columnName = _driver.FindElement(By.XPath("//table[2]/thead/tr[1]/th[1]"));
            Assert.That(columnName.Text, Is.EqualTo("Name ^"));
            Assert.That(columnAddress.Text, Is.EqualTo("Address"));
            Assert.That(columnDesc.Text, Is.EqualTo("Description"));
            Assert.That(addressOne.Text, Contains.Substring(country));
        }

        public void addGolfCourse()
        {
            addGolf.Click();
            string? User = TestContext.Parameters["user"];
            string? Password = TestContext.Parameters["password"];
            emailTxt.SendKeys(User);
            passwordTxt.SendKeys(Password);
            loginBtn.Click();
            Thread.Sleep(5000);
            name.SendKeys("Testing Golf Course A");
            address.SendKeys("1200 AVE NW");
            city.SendKeys("Edmonton");
            province.SendKeys("AB");
            country.SendKeys("Canada");
            description.SendKeys("A very nice golf course!");
            longDes.SendKeys("It's located in NW Edmonton. It's country style and full services.");
            owner.SendKeys("Dillon");
            IJavaScriptExecutor jse = (IJavaScriptExecutor)_driver;
            jse.ExecuteScript("document.getElementById('Email').value='test2@admlucid.com'");
            phoneNumber.SendKeys("587-889-3349");
            _driver.Manage().Window.FullScreen();
            create.Click();
        }

        public void editGolfCourse()
        {
            loginLink.Click();
            string? User = TestContext.Parameters["user"];
            string? Password = TestContext.Parameters["password"];
            emailTxt.SendKeys(User);
            passwordTxt.SendKeys(Password);
            loginBtn.Click();
            Thread.Sleep(5000);
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            Thread.Sleep(2500);
            searchTxt.SendKeys("Testing Golf Course A");
            searchBtn.Click();
            editLink.Click();
            owner.Clear();
            owner.SendKeys("Adm Test2");
            editSaveBtn.Click();
        }

        public void deleteGolfCourse()
        {
            loginLink.Click();
            string? User = TestContext.Parameters["user"];
            string? Password = TestContext.Parameters["password"];
            emailTxt.SendKeys(User);
            passwordTxt.SendKeys(Password);
            loginBtn.Click();
            Thread.Sleep(5000);
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            Thread.Sleep(2500);
            searchTxt.SendKeys("Testing Golf Course A");
            searchBtn.Click();
            deleteLink.Click();
            deleteSaveBtn.Click();
            Thread.Sleep(2500);
        }

        public void takeScreenshot(string screenshotName)
        {
            try
            {
                ITakesScreenshot ts = (ITakesScreenshot)_driver;
                string filename = @"C:\Users\thedi\Downloads\" + screenshotName + DateTime.Now.ToString("MMddyyyy_hhmmt") + ".png";
                ts.GetScreenshot().SaveAsFile(filename);
                Console.WriteLine(filename);
            }
            catch(InvalidCastException e)
            {
                Console.WriteLine("Screenshot: " + e.ToString());
            }
        }
    }
}

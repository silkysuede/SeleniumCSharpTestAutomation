using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTestProject
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            //driver = new EdgeDriver();
            //driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/");

            Assert.That(driver.Url, Is.EqualTo("https://admlucid.com/"));
            Assert.That(driver.Title, Is.EqualTo("Home Page - Admlucid"));
        }

        [Test]
        public void Textbox()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            Assert.That(driver.Url, Is.EqualTo("https://admlucid.com/Home/WebElements"));
            driver.FindElement(By.Id("Text1")).Clear();
            driver.FindElement(By.Id("Text1")).SendKeys("adm123456");
            Thread.Sleep(1000);
        }

        [Test]
        public void TextArea()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            Assert.That(driver.Url, Is.EqualTo("https://admlucid.com/Home/WebElements"));
            driver.FindElement(By.Name("TextArea2")).Clear();
            driver.FindElement(By.Name("TextArea2")).SendKeys("If you want to create robust, browser-based tests, use Selenium!");
        }

        [Test]
        public void Button()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            Assert.That(driver.Url, Is.EqualTo("https://admlucid.com/Home/WebElements"));
            driver.FindElement(By.Id("Button1")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void RadioButtonCheckBox()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            Assert.That(driver.Url, Is.EqualTo("https://admlucid.com/Home/WebElements"));
            driver.FindElement(By.Id("Checkbox1")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement radio2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("Radio2")));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", radio2);
        }

        [Test]
        public void FormSubmit()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            Assert.That(driver.Url, Is.EqualTo("https://admlucid.com/Home/WebElements"));
            driver.FindElement(By.Name("Name")).SendKeys("Hatfield, Dillon");
            driver.FindElement(By.Name("EMail")).SendKeys("dhatfie40@gmail.com");
            driver.FindElement(By.Name("Telephone")).SendKeys("9137083463");
            driver.FindElement(By.Name("Gender")).Click();

            var selectElement = driver.FindElement(By.Name("age"));
            var select = new SelectElement(selectElement);
            select.SelectByText("4");

            var selectElement2 = driver.FindElement(By.Name("Service"));
            var select2 = new SelectElement(selectElement2);
            select2.SelectByText("Child Care");

            driver.FindElement(By.Name("Submit")).Submit();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void MultipleWindows()
        {
            string originalWindow = driver.CurrentWindowHandle;
            driver.Navigate().GoToUrl("https://www.alberta.ca/child-care-subsidy#jumplinks-4");
            driver.FindElement(By.LinkText("online subsidy estimator")).Click();
            foreach (string window in driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            Assert.That(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"content\"]/h1"))).Text, Is.EqualTo("Child Care Subsidy Estimator"));
        }

        [Test]
        public void WebElementText()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            Assert.That(driver.Url, Is.EqualTo("https://admlucid.com/Home/WebElements"));
            Assert.That(driver.FindElement(By.XPath("//main/h1")).Text, Is.EqualTo("Web Elements and Locators"));
            Assert.That(driver.FindElement(By.XPath("//main/h2")).Text, Is.EqualTo("CHILD CARE REGISTRATION"));
        }

        [TearDownAttribute]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
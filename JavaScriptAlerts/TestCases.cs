using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace JavaScriptAlerts
{
    [TestClass]
    public class TestCases
    {
        public IWebDriver driver = new FirefoxDriver();

        [TestMethod]
        public void TestCase1()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            driver.Manage().Window.Maximize();

            // Click the button <Click for JS Alert>.
            IWebElement ele_btn_JSAlert = driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[1]/button"));
            ele_btn_JSAlert.Click();
            Thread.Sleep(2000);

            IAlert alert = driver.SwitchTo().Alert();
            if (alert.Text.Contains("I am a JS Alert"))
            {
                alert.Accept();
            }
            Thread.Sleep(2000);

            string eleText_result = driver.FindElement(By.Id("result")).Text;
            string expected_result = "You successfuly clicked an alert";
            Assert.AreEqual(eleText_result, expected_result);

            driver.Quit();
        }

        [TestMethod]
        public void TestCase2()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            driver.Manage().Window.Maximize();

            // Click the button <Click for JS Confirm>.
            IWebElement ele_btn_JSConfirm = driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[2]/button"));
            ele_btn_JSConfirm.Click();
            Thread.Sleep(2000);

            IAlert alert = driver.SwitchTo().Alert();
            if (alert.Text.Contains("I am a JS Confirm"))
            {
                alert.Accept();
            }
            Thread.Sleep(2000);

            string eleText_result = driver.FindElement(By.Id("result")).Text;
            string expected_result = "You clicked: Ok";
            Assert.AreEqual(eleText_result, expected_result);

            driver.Quit();
        }

        [TestMethod]
        public void TestCase3()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            driver.Manage().Window.Maximize();

            // Click the button <Click for JS Confirm>.
            IWebElement ele_btn_JSConfirm = driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[2]/button"));
            ele_btn_JSConfirm.Click();
            Thread.Sleep(2000);

            IAlert alert = driver.SwitchTo().Alert();
            if (alert.Text.Contains("I am a JS Confirm"))
            {
                alert.Dismiss();
            }
            Thread.Sleep(2000);

            string eleText_result = driver.FindElement(By.Id("result")).Text;
            string expected_result = "You clicked: Cancel";
            Assert.AreEqual(eleText_result, expected_result);

            driver.Quit();
        }

        [TestMethod]
        public void TestCase4()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            driver.Manage().Window.Maximize();

            // Click the button <Click for JS Confirm>.
            IWebElement ele_btn_JSPrompt = driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[3]/button"));
            ele_btn_JSPrompt.Click();
            Thread.Sleep(2000);

            IAlert alert = driver.SwitchTo().Alert();
            string inputText = "abc123";
            if (alert.Text.Contains("I am a JS prompt"))
            {
                alert.SendKeys(inputText);
                alert.Accept();
            }
            Thread.Sleep(2000);

            string eleText_result = driver.FindElement(By.Id("result")).Text;
            string expected_result = "You entered: " + inputText;
            Assert.AreEqual(eleText_result, expected_result);

            driver.Quit();
        }

        [TestMethod]
        public void TestCase5()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            driver.Manage().Window.Maximize();

            // Click the button <Click for JS Confirm>.
            IWebElement ele_btn_JSPrompt = driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[3]/button"));
            ele_btn_JSPrompt.Click();
            Thread.Sleep(2000);

            IAlert alert = driver.SwitchTo().Alert();
            string inputText = "abc123";
            if (alert.Text.Contains("I am a JS prompt"))
            {
                alert.SendKeys(inputText);
                alert.Dismiss();
            }
            Thread.Sleep(2000);

            string eleText_result = driver.FindElement(By.Id("result")).Text;
            string expected_result = "You entered: null";
            Assert.AreEqual(eleText_result, expected_result);

            driver.Quit();
        }
    }
}

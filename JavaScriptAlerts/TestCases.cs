using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace JavaScriptAlerts
{
    [TestClass]
    public class TestCases
    {
        public IWebDriver driver = new FirefoxDriver();

        [TestMethod]
        public void TestCaseA1()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            driver.Manage().Window.Maximize();

            // Click the button <Click for JS Alert>.
            IWebElement ele_btn_JSAlert = driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[1]/button"));
            ele_btn_JSAlert.Click();

            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
            IAlert alert = explicitWait.Until(d => d.SwitchTo().Alert());
            if (alert.Text.Contains("I am a JS Alert"))
            {
                alert.Accept();
            }

            // Verify the expected result.
            string eleText_result = explicitWait.Until(d => driver.FindElement(By.Id("result"))).Text;
            string expected_result = "You successfuly clicked an alert";
            Assert.AreEqual(eleText_result, expected_result);

            driver.Quit();
        }

        [TestMethod]
        public void TestCaseA2()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            driver.Manage().Window.Maximize();

            // Click the button <Click for JS Confirm>.
            IWebElement ele_btn_JSConfirm = driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[2]/button"));
            ele_btn_JSConfirm.Click();

            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
            IAlert alert = explicitWait.Until(d => d.SwitchTo().Alert());
            if (alert.Text.Contains("I am a JS Confirm"))
            {
                alert.Accept();
            }

            // Verify the expected result.
            string eleText_result = explicitWait.Until(d => driver.FindElement(By.Id("result"))).Text;
            string expected_result = "You clicked: Ok";
            Assert.AreEqual(eleText_result, expected_result);

            driver.Quit();
        }

        [TestMethod]
        public void TestCaseA3()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            driver.Manage().Window.Maximize();

            // Click the button <Click for JS Confirm>.
            IWebElement ele_btn_JSConfirm = driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[2]/button"));
            ele_btn_JSConfirm.Click();

            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
            IAlert alert = explicitWait.Until(d => d.SwitchTo().Alert());
            if (alert.Text.Contains("I am a JS Confirm"))
            {
                alert.Dismiss();
            }

            // Verify the expected result.
            string eleText_result = explicitWait.Until(d => driver.FindElement(By.Id("result"))).Text;
            string expected_result = "You clicked: Cancel";
            Assert.AreEqual(eleText_result, expected_result);

            driver.Quit();
        }

        [TestMethod]
        public void TestCaseA4()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            driver.Manage().Window.Maximize();

            // Click the button <Click for JS Confirm>.
            IWebElement ele_btn_JSPrompt = driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[3]/button"));
            ele_btn_JSPrompt.Click();

            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
            IAlert alert = explicitWait.Until(d => d.SwitchTo().Alert());
            string inputText = "abc123";
            if (alert.Text.Contains("I am a JS prompt"))
            {
                alert.SendKeys(inputText);
                alert.Accept();
            }

            // Verify the expected result.
            string eleText_result = explicitWait.Until(d => driver.FindElement(By.Id("result"))).Text;
            string expected_result = "You entered: " + inputText;
            Assert.AreEqual(eleText_result, expected_result);

            driver.Quit();
        }

        [TestMethod]
        public void TestCaseA5()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            driver.Manage().Window.Maximize();

            // Click the button <Click for JS Confirm>.
            IWebElement ele_btn_JSPrompt = driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[3]/button"));
            ele_btn_JSPrompt.Click();

            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
            IAlert alert = explicitWait.Until(d => d.SwitchTo().Alert());
            string inputText = "abc123";
            if (alert.Text.Contains("I am a JS prompt"))
            {
                alert.SendKeys(inputText);
                alert.Dismiss();
            }

            // Verify the expected result.
            string eleText_result = explicitWait.Until(d => driver.FindElement(By.Id("result"))).Text;
            string expected_result = "You entered: null";
            Assert.AreEqual(eleText_result, expected_result);

            driver.Quit();
        }
    }
}

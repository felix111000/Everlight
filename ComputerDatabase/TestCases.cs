using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace ComputerDatabase
{
    [TestClass]
    public class TestCases
    {

        public IWebDriver driver = new FirefoxDriver();

        // Add a new computer
        [TestMethod]
        public void TestCaseA1()
        {
            driver.Navigate().GoToUrl("http://computer-database.gatling.io/");
            driver.Manage().Window.Maximize();

            // Add a new computer
            IWebElement ele_btn_addNewComputer = driver.FindElement(By.Id("add"));
            ele_btn_addNewComputer.Click();
            string newComputerName = "ABC";
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
            IWebElement textBox_computerName = explicitWait.Until(driver => driver.FindElement(By.Id("name")));
            IWebElement btn_createComputer = explicitWait.Until(driver => driver.FindElement(By.XPath("//*[@id='main']/form/div/input")));
            textBox_computerName.SendKeys(newComputerName);
            btn_createComputer.Click();

            // Verify the expected result
            string eleText_result = explicitWait.Until(driver => driver.FindElement(By.XPath("//*[@id='main']/div[1]"))).Text;
            string expected_result = "Done ! Computer " + newComputerName + " has been created";
            Assert.AreEqual(eleText_result, expected_result);

            driver.Quit();
        }

        // Retrieve a computer
        [TestMethod]
        public void TestCaseA2()
        {
            driver.Navigate().GoToUrl("http://computer-database.gatling.io/");
            driver.Manage().Window.Maximize();

            // Retrieve a computer in the search box
            string computerName = "APEXC";
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
            IWebElement ele_searchBox = explicitWait.Until(driver => driver.FindElement(By.Id("searchbox")));
            IWebElement btn_searchSubmit = explicitWait.Until(driver => driver.FindElement(By.Id("searchsubmit")));
            ele_searchBox.SendKeys(computerName);
            btn_searchSubmit.Click();

            // Verify the exepcted result
            string eleText_result = explicitWait.Until(driver => driver.FindElement(By.XPath("//*[@id='main']/h1"))).Text;
            string expected_result = "One computer found";
            Assert.AreEqual(eleText_result, expected_result);

            driver.Quit();
        }

        // Update a computer
        [TestMethod]
        public void TestCaseA3()
        {
            string mainUrl = "http://computer-database.gatling.io/";
            driver.Navigate().GoToUrl(mainUrl);
            driver.Manage().Window.Maximize();

            // Retrieve a computer in the search box
            string computerName = "ARRA";
            IWebElement ele_searchBox = driver.FindElement(By.Id("searchbox"));
            IWebElement btn_searchSubmit = driver.FindElement(By.Id("searchsubmit"));
            ele_searchBox.SendKeys(computerName);
            btn_searchSubmit.Click();

            // Update the computer name
            string newComputerName = "ABC";
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
            string newUrl = explicitWait.Until(driver => driver.FindElement(By.XPath("//*[@id='main']/table/tbody/tr[1]/td[1]/a"))).GetAttribute("href");
            driver.Navigate().GoToUrl(newUrl);
            IWebElement textBox_computerName = explicitWait.Until(driver => driver.FindElement(By.Id("name")));
            IWebElement btn_saveComputer = explicitWait.Until(driver => driver.FindElement(By.XPath("//*[@id='main']/form/div/input")));
            textBox_computerName.Clear();
            textBox_computerName.SendKeys(newComputerName);
            btn_saveComputer.Click();

            // Verify the expected result
            string eleText_result = explicitWait.Until(driver => driver.FindElement(By.XPath("//*[@id='main']/div[1]"))).Text;
            string expected_result = "Done ! Computer " + newComputerName + " has been updated";
            Assert.AreEqual(eleText_result, expected_result);

            driver.Quit();
        }

        // Delete a computer
        [TestMethod]
        public void TestCaseA4()
        {
            string mainUrl = "http://computer-database.gatling.io/";
            driver.Navigate().GoToUrl(mainUrl);
            driver.Manage().Window.Maximize();

            // Retrieve a computer in the search box
            string computerName = "ACE";
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
            IWebElement ele_searchBox = explicitWait.Until(driver => driver.FindElement(By.Id("searchbox")));
            IWebElement btn_searchSubmit = explicitWait.Until(driver => driver.FindElement(By.Id("searchsubmit")));
            ele_searchBox.SendKeys(computerName);
            btn_searchSubmit.Click();

            // Delete the computer name      
            string newUrl = explicitWait.Until(driver => driver.FindElement(By.XPath("//*[@id='main']/table/tbody/tr[1]/td[1]/a"))).GetAttribute("href");
            driver.Navigate().GoToUrl(newUrl);
            IWebElement btn_deleteComputer = explicitWait.Until(driver => driver.FindElement(By.XPath("//*[@id='main']/form[2]/input")));
            btn_deleteComputer.Click();

            // Verify the expected result
            string eleText_result = explicitWait.Until(driver => driver.FindElement(By.XPath("//*[@id='main']/div[1]"))).Text;
            string expected_result = "Done ! Computer " + computerName + " has been deleted";
            Assert.AreEqual(eleText_result, expected_result);

            driver.Quit();
        }

        // Retrieve an invalid computer
        [TestMethod]
        public void TestCaseB1()
        {
            driver.Navigate().GoToUrl("http://computer-database.gatling.io/");
            driver.Manage().Window.Maximize();

            // Retrieve a computer in the search box
            string computerName = "TESTCOMPUTER";
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
            IWebElement ele_searchBox = explicitWait.Until(driver => driver.FindElement(By.Id("searchbox")));
            IWebElement btn_searchSubmit = explicitWait.Until(driver => driver.FindElement(By.Id("searchsubmit")));
            ele_searchBox.SendKeys(computerName);
            btn_searchSubmit.Click();

            // Verify the exepcted result           
            string eleText_result = explicitWait.Until(driver => driver.FindElement(By.XPath("//*[@id='main']/h1"))).Text;
            string eleText_content = explicitWait.Until(driver => driver.FindElement(By.XPath("//*[@id='main']/div[2]/em"))).Text;
            string expected_result = "No computer";
            string expected_content = "Nothing to display";
            Assert.AreEqual(eleText_result, expected_result);
            Assert.AreEqual(eleText_content, expected_content);

            driver.Quit();
        }
    }
}

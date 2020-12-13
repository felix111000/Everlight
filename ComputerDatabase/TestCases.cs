using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

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
            Thread.Sleep(2000);
            string newComputerName = "ABC";
            IWebElement textBox_computerName = driver.FindElement(By.Id("name"));
            IWebElement btn_createComputer = driver.FindElement(By.XPath("//*[@id='main']/form/div/input"));
            textBox_computerName.SendKeys(newComputerName);
            btn_createComputer.Click();
            Thread.Sleep(2000);

            // Verify the expected result
            string eleText_result = driver.FindElement(By.XPath("//*[@id='main']/div[1]")).Text;
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
            IWebElement ele_searchBox = driver.FindElement(By.Id("searchbox"));
            IWebElement btn_searchSubmit = driver.FindElement(By.Id("searchsubmit"));
            ele_searchBox.SendKeys(computerName);
            btn_searchSubmit.Click();
            Thread.Sleep(2000);

            // Verify the exepcted result
            string eleText_result = driver.FindElement(By.XPath("//*[@id='main']/h1")).Text;
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
            Thread.Sleep(2000);

            // Update the computer name
            string newComputerName = "ABC";
            string newUrl = driver.FindElement(By.XPath("//*[@id='main']/table/tbody/tr[1]/td[1]/a")).GetAttribute("href");
            driver.Navigate().GoToUrl(newUrl);
            Thread.Sleep(2000);
            IWebElement textBox_computerName = driver.FindElement(By.Id("name"));
            IWebElement btn_saveComputer = driver.FindElement(By.XPath("//*[@id='main']/form/div/input"));
            textBox_computerName.Clear();
            textBox_computerName.SendKeys(newComputerName);
            btn_saveComputer.Click();
            Thread.Sleep(2000);

            // Verify the expected result
            string eleText_result = driver.FindElement(By.XPath("//*[@id='main']/div[1]")).Text;
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
            IWebElement ele_searchBox = driver.FindElement(By.Id("searchbox"));
            IWebElement btn_searchSubmit = driver.FindElement(By.Id("searchsubmit"));
            ele_searchBox.SendKeys(computerName);
            btn_searchSubmit.Click();
            Thread.Sleep(2000);

            // Delete the computer name
            string newUrl = driver.FindElement(By.XPath("//*[@id='main']/table/tbody/tr[1]/td[1]/a")).GetAttribute("href");
            driver.Navigate().GoToUrl(newUrl);
            Thread.Sleep(2000);
            IWebElement btn_deleteComputer = driver.FindElement(By.XPath("//*[@id='main']/form[2]/input"));
            btn_deleteComputer.Click();
            Thread.Sleep(2000);

            // Verify the expected result
            string eleText_result = driver.FindElement(By.XPath("//*[@id='main']/div[1]")).Text;
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
            IWebElement ele_searchBox = driver.FindElement(By.Id("searchbox"));
            IWebElement btn_searchSubmit = driver.FindElement(By.Id("searchsubmit"));
            ele_searchBox.SendKeys(computerName);
            btn_searchSubmit.Click();
            Thread.Sleep(2000);

            // Verify the exepcted result
            string eleText_result = driver.FindElement(By.XPath("//*[@id='main']/h1")).Text;
            string eleText_content = driver.FindElement(By.XPath("//*[@id='main']/div[2]/em")).Text;
            string expected_result = "No computer";
            string expected_content = "Nothing to display";
            Assert.AreEqual(eleText_result, expected_result);
            Assert.AreEqual(eleText_content, expected_content);

            driver.Quit();
        }
    }
}

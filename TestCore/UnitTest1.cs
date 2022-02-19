using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TestCore
{
    [TestFixture]
    public class BcyipTest
    {
        IWebDriver driver;


        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            //Navigate to the site
            driver.Navigate().GoToUrl("http://localhost:50783/Account/Login?ReturnUrl=%2F");
            // If starting the web site from the command line, the port number will be different.
            // By default, it will be 8080. 
            // Comment the line above and uncomment the following one if starting the site from command line.
            // driver.Navigate().GoToUrl("http://localhost:8080/Account/Login?ReturnUrl=%2F");


        }

        // Story 1

        [Test]
        public void SignInWithValidCredentials()
        {
            // Enter valid user name and password
            Login("user", "password");
            IWebElement element = driver.FindElement(By.Id("logoutForm"));
            Assert.AreEqual(element.Text, "sign-out");
        }

        [Test]
        public void ErrorMessageShowingWhileInValidCredential()
        {
            // Enter valid user name and password
            Login("user", "passworde");
            bool display = driver.FindElement(By.TagName("li")).Displayed;
            Assert.IsTrue(display);
        }

        [Test]
        public void ReYipLinkIsEnableforUser()
        {
            // Enter valid user name and password
            Login("user", "password");
            bool reyipenabled = driver.FindElement(By.ClassName("reyip-link")).Enabled;
            Assert.IsTrue(reyipenabled);
        }


        [Test]
        public void SendNewYip()
        {
            // Enter valid user name and password
            Login("user", "password");
            driver.Manage().Window.Maximize();
            int yipListCount = driver.FindElements(By.ClassName("yip")).Count;
            IWebElement messageForm = driver.FindElement(By.Id("Content"));
            messageForm.SendKeys("my test form 3");
            IWebElement sendButton = driver.FindElement(By.ClassName("create-yip-button"));
            sendButton.Click();
            string ComposeText = driver.FindElement(By.Id("Content")).GetAttribute("placeholder");
            string expected = "Compose new yip...";
            Assert.AreEqual(expected, ComposeText);
        }

        private void Login(string userName = "user", string password = "password")
        {
            driver.FindElement(By.Id("UserName")).SendKeys(userName);
            driver.FindElement(By.Id("Password")).SendKeys(password + Keys.Enter);
        }

        [Test]
        public void CanSignOut()
        {
            Login();
            IWebElement logOutButton = driver.FindElement(By.Id("logoutForm"));
            logOutButton.Click();
            IWebElement usernameLine = driver.FindElement(By.Id("UserName"));
            Assert.AreEqual("Username", usernameLine.GetAttribute("placeholder"));

        }

        [TearDown]
        public void Cleanup()
        {
            //close the browser.
            //driver.Close();
            driver.Quit();
        }
    }
}

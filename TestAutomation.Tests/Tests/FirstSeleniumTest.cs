using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestAutomation.Tests.Tests
{
    public class FirstSeleniumTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Login_WithValidCredentials_houldDisplayProducts()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            
            IWebElement userName = driver.FindElement(By.Id("user-name"));
            IWebElement password = driver.FindElement(By.CssSelector("#password"));
            IWebElement loginButton = driver.FindElement(By.XPath("//input[@id='login-button']"));

            userName.SendKeys("standard_user");
            password.SendKeys("secret_sauce");
            loginButton.Click();

            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            IWebElement productsTitle = wait.Until(d => d.FindElement(By.CssSelector("[data-test='title']")));

            Assert.That(productsTitle.Text, Is.EqualTo("Products"));

        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}

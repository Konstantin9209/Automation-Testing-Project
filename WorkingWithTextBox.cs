using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace SeleniumTesting;
using NUnit.Framework;
using System;


[TestFixture]
public class WorkingWithTextBox
    {
        IWebDriver Driver;

    [SetUp]
        public void Setup()
        {
Driver = new ChromeDriver();

            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Driver.Url = "https://test.qatechhub.com/contact-us/";
        }

        [Test]
        public void VerifyContactUsFormFill()
        {
            Driver.FindElement(By.Id("wpforms-20-field_0")).SendKeys("Konstantin");

            Driver.FindElement(By.Name("wpforms[fields][0][last]")).SendKeys("Petkov");

            Driver.FindElement(By.Id("wpforms-20-field_1")).SendKeys("Konstantin.z.petkov@gmail.com");

            Driver.FindElement(By.Id("wpforms-20-field_2")).SendKeys("Trying this text box");

            Driver.FindElement(By.Id("wpforms-submit-20")).Click();

            string expectedMessage = "Thanks for contacting us! We will be in touch with you shortly.";

            string actualMessage = Driver.FindElement(By.Id("wpforms-confirmation-20")).Text;
            

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }

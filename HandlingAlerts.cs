using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace SeleniumTesting;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;


[TestFixture]
public class HandlingAlerts

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

            Driver.Url = "https://test.qatechhub.com/alert-handling/";
        }

        [Test]
        public void VerifyAlert()
        {
Driver.FindElement(By.Id("NormalAlert")).Click();

Thread.Sleep(5000);

IAlert alert = Driver.SwitchTo().Alert();

Console.Write("Alert Message - "+ alert.Text);

alert.Accept();

        }
        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }

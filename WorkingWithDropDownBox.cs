using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace SeleniumTesting;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;


[TestFixture]
public class WorkingWithDropdownBox
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

            Driver.Url = "https://test.qatechhub.com/form-elements/";
        }

        [Test]
        public void VerifyContactUsFormFill()
        {
            Driver.FindElement(By.Id("wpforms-49-field_1")).SendKeys("Konstantin");

            Driver.FindElement(By.Name("wpforms[fields][1][last]")).SendKeys("Petkov");

            Driver.FindElement(By.Id("wpforms-49-field_2")).SendKeys("Konstantin.z.petkov@gmail.com");

            Driver.FindElement(By.Id("wpforms-49-field_4")).SendKeys("0885250010");

Driver.FindElement(By.XPath("//input[@value= 'Female']")).Click();

IWebElement dropdown = Driver.FindElement(By.Name("wpforms[fields][5]"));

SelectElement select = new SelectElement(dropdown);

select.SelectByText("Selenium");



Driver.FindElement(By.Name("wpforms[submit]")).Click();



        }
        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }

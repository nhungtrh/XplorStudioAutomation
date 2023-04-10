using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XplorStudio.TestCase
{
    [TestFixture]
    public class CapeCoral
    {
        protected IWebDriver Driver;

        [SetUp]
        public void BeforeAll()
        {
            Driver = new ChromeDriver();

        }

        [Test]
        public void Login()

        {

            IWebDriver driver = new ChromeDriver();
            

            //get page title 
            String title = driver.Title;


            //add new event
            driver.Navigate().GoToUrl("http://dev.pre.studio.xplor.co/app/schedule/");
            driver.Url = "http://dev.pre.studio.xplor.co/app/schedule/";

            IWebElement element3 = driver.FindElement(By.Id("addEventsButton"));
            element3.Click();

            IWebElement element4 = driver.FindElement(By.Id("add-class-icon"));
            element4.Click();

            //add new remember

            //IWebElement element4 = driver.FindElement(By.XPath("//*[@class='btn btn-primary create-first-reminder']"));
            //element4.Click();

            //IWebElement element5 = driver.FindElement(By.Id("addEventsButton"));
            //element5.SendKeys("03/23/2023");

            //IWebElement element6 = driver.FindElement(By.Id("dp1679501598747"));
            //element6.SendKeys("03/23/2023");



        }


        [TearDown]
        public void AfterAll()
        {
            Driver.Close();
        }


    }
}

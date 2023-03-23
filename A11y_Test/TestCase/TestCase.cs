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
            driver.Navigate().GoToUrl("http://dev.pre.studio.xplor.co/login/");

            //login

            IWebElement element = driver.FindElement(By.Id("inputEmail"));
            element.SendKeys("mpv@test.com");

            IWebElement element1 = driver.FindElement(By.Id("InputPassword1"));
            element1.SendKeys("12341234");

            IWebElement element2 = driver.FindElement(By.XPath("//*[@type = 'submit' and @class = 'btn btn-primary btn-lg']"));
            element2.Click();

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

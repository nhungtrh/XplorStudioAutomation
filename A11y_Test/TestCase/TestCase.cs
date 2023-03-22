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

            IWebElement element = driver.FindElement(By.Id("inputEmail"));
            element.SendKeys("mpv@test.com");

            IWebElement element1 = driver.FindElement(By.Id("InputPassword1"));
            element1.SendKeys("12341234");

            IWebElement element2 = driver.FindElement(By.XPath("//*[@type = 'submit' and @class = 'btn btn-primary btn-lg']"));
            element2.Click();

            IWebElement elemen4 = driver.FindElement(By.XPath("//*[@type = 'submit' and @class = 'btn btn-primary btn-lg']"));
            element4.Click();
        }
     

        [TearDown]
        public void AfterAll()
        {
            Driver.Close();
        }


    }
}

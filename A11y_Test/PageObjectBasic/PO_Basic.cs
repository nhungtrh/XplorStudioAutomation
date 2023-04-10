using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace XplorStudio.PageObjectBasic
{
	public class PO_Basic
	{
		protected IWebDriver Driver;
		//locator
		protected IWebElement CoachEmail => Driver.FindElement(By.Id("inputEmail"));
		protected IWebElement CoachPassword => Driver.FindElement(By.Id("InputPassword1"));
		protected IWebElement Login_btn => Driver.FindElement(By.XPath("//*[@type = 'submit' and @class = 'btn btn-primary btn-lg']"));
		protected IWebElement Login_message => Driver.FindElement(By.XPath("//*[@class= 'alert alert-danger alert-homepage hide']"));
        protected IWebElement Profile_btn => Driver.FindElement(By.XPath("//*[@id = 'communication-menu']/following::div[1]"));
        protected IWebElement LogOut_btn => Driver.FindElement(By.XPath("//*[contains(text(),'Sign out')]"));
        protected IWebElement SignInMessage => (IWebElement)Driver.FindElements(By.XPath("//*[contains(text(),'Sign in to Xplor Studio')]"));




        public PO_Basic(IWebDriver driver)
		{
			Driver = driver;

		}
        //Verify the login page
        public void GotoLoginPage()
		{
            IWebDriver driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("http://dev.pre.studio.xplor.co");
			Thread.Sleep(2000);

            bool text = SignInMessage.Displayed;

			if (text == true)
			{
				Assert.AreEqual(true, text);
				Console.WriteLine("the text: Sign in to Xplor Studio found");
			}

			else
			{
				Assert.Fail("Text not found");
			}



        }

		//Login
		public void LogIn(string email, string password)
		{
            IWebDriver driver = new ChromeDriver();
            //Driver.Navigate().GoToUrl("http://dev.pre.studio.xplor.co");
			CoachEmail.SendKeys(email);
			CoachPassword.SendKeys(password);
			Login_btn.Click();
			String DashboardLink = driver.Url;

			if (DashboardLink == "http://dev.pre.studio.xplor.co/app/dashboard")
			{
				Assert.AreEqual("http://dev.pre.studio.xplor.co/app/dashboard", DashboardLink);
				Console.WriteLine("Login successfully");
				
			}
			else
			{
				Assert.Fail("Login failed");
			}
        }

		//logout
		public void LogOut()
		{
			Profile_btn.Click();
			Thread.Sleep(1000);
			LogOut_btn.Click();
            
            bool text = SignInMessage.Displayed;

            if (text == true)
            {
                Assert.AreEqual(true, text);
                Console.WriteLine("the text: Logout successfully");
            }

            else
            {
                Assert.Fail("Can't logout");
            }

        }
    }

	}




using java.sql;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Security.Principal;
using WebRegression.TestStructure;
using WebRegression.Utilities;

namespace WebRegression.PageObjects
{  /// <summary>
   /// This class creates an object of the Service Autopilot Log In page and all elements therein.
   /// </summary>
    public class LogInPage
    {
        //Class variables.
        private static readonly IWebDriver Driver = SetUpDriver.GetDriverInstance();
        private readonly LogTool _logtool = new LogTool();

        #region locators

        private IWebElement Email => Library.FindByXPath("//input[@id='inputEmail']");
        private IWebElement Password => Library.FindByXPath("//input[@id='InputPassword1']");
        private IWebElement Submit => Library.FindByXPath("//button[@class='btn btn-primary btn-lg']");
        private IWebElement myAccount => Library.FindByXPath("//div[@class='no-image noselect nodrag']");
        private IWebElement SignOffBtn => Library.FindByXPath("(//a[@href='/app/signin/logout/'])");


        //By.CssSelector("[href*='Vacancies.aspx?param=apply:16']")

        #endregion


        /// <summary>
        /// Constructor
        /// </summary>
        public LogInPage()
        {

        }

        /// <summary>
        /// Set the current username and password of this account.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void LogIntoSite(String username, String password)
        {

            try
            {
                Email.SendKeys(username);
                Library.CustomWait(3);
                Password.SendKeys(password);
                Library.CustomWait(3);
                Submit.Click();
                Library.CustomWait(10);
                //Library.RefreshPage();
            }
            catch (WebDriverException w)
            {
                TestContext.Out.WriteLine(w);
                throw new Exception("Could not reach the login page!!");
            }
        }



        public void LogInToAccountWithDifferentUser(string userName, string password)
        {
            try
            {
                LogIntoSite(userName, password);
                TestContext.Out.WriteLine("Login to site with these given credentials :" + userName + password);
            }
            catch (Exception e)
            {
                TestContext.Out.WriteLine(e + "the given user name and Pass word are invalid");
            }
        }

        
        public void LogOutAccount()
        {
            myAccount.Click();
            Library.SwichToPopUp();
            SignOffBtn.Click();
            Library.CustomWait(3);
            Assert.IsTrue(Driver.Url.Contains("triiblogin"));
            _logtool.AddToLogFile("log out successfully!");
        }
    }

}
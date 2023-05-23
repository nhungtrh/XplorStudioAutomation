using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using WebRegression.PageObjects;
using WebRegression.Utilities;
namespace WebRegression.TestStructure
{
    public class LogInCoach : TestBase
    {
        private readonly LogInPage _loginCoach = new LogInPage();
        //static variables.
        private string _currentTestName = "";
        #region
        #endregion
        [SetUp]
        public void BeforeEachTest()
        {
            //Refresh the page before each test
            Library.RefreshPage();
            _currentTestName = TestContext.CurrentContext.Test.Name;
        }
        [Test, Order(2), Category("Login")]
        public void LoginInCoach()
        {
            UiTest(() =>
            {
                _loginCoach.LogIntoSite("new@payout.com", "12341234");
                Library.CustomWait(3);
                _loginCoach.LogOutAccount();
            }, _currentTestName);
        }
        [TearDown]
        public void AfterEachTest()
        {
        }
    }
}
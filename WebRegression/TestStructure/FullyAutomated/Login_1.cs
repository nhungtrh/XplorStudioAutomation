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
    public class Login_1 : TestBase
    {
        //static variables.
        private string _currentTestName = "";
       
        private readonly LogInPage _login = new LogInPage();
        private readonly LogTool _loginTool = new LogTool();
        private readonly ListMenu _mainmenu = new ListMenu();
        #region
        private IWebElement TextErrorMsg => Library.FindByXPath("//div[@class='alert alert-danger alert-homepage hide']");


        //

        #endregion

        [SetUp]
        public void BeforeEachTest()
        {
            //Refresh the page before each test
            Library.RefreshPage();
            _currentTestName = TestContext.CurrentContext.Test.Name;
        }

        [Test, Order(1), Category("Login")]
        public void Login_NOT_Successfull()
        {
            UiTest(() =>
            {
                _login.LogIntoSite("new@payout.com1", "12341234");
                Assert.IsTrue(Library.IsElementVisible(By.XPath("//div[contains(text(),'password incorrect or your account is not active')]")));
                _loginTool.AddToLogFile("When the user and pass are invalid the app displayes the right error msg");
                Library.RefreshPage();
                Library.CustomWait(3);

            }, _currentTestName);
        }
        [Test, Order(2), Category("Login")]
        public void Login_Successfull()
        {
            UiTest(() =>
            {
                //_mainmenu.goto
                _login.LogIntoSite("new@payout.com", "12341234");
                Library.CustomWait(3);
                _login.LogOutAccount();

            }, _currentTestName);
        }
       



        [TearDown]
        public void AfterEachTest()
        {

        }
    }
}
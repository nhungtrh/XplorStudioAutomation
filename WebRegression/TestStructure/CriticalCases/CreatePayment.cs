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
    public class MakeaPayment : TestBase
    {
        //static variables.
        private string _currentTestName = "";

        private readonly LogInPage _login = new LogInPage();
        private readonly LogTool _loginTool = new LogTool();
        private readonly ListMenu _mainmenu = new ListMenu();
        private readonly PaymentPage _payment = new PaymentPage();

        //private readonly Library _library = new Library();
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
            _login.LogIntoSite("new@payout.com", "12341234");
        }


        [Test, Order(1), Category("Payments")]
        public void MakeaPayment_Full()
        {
            UiTest(() =>
            {

                _login.LogIntoSite("new@payout.com", "12341234");
                Library.CustomWait(3);
                _payment.CreateStripePayment("Auto Test", "100", "testing_note");


            }, _currentTestName);
        }

        [Test, Order(2), Category("Payments")]
        public void makeCashPayment()
        {
            UiTest(() =>
            {

              
                Library.CustomWait(3);
                _payment.CreateCashPayment("Auto Test","2023-05-20", "100", "testing_note");


            }, _currentTestName);
        }

        [TearDown]
        public void AfterEachTest()
        {

        }
    }
}
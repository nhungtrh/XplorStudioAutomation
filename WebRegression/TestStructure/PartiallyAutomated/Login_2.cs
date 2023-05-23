using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using WebRegression.PageObjects;
using WebRegression.Utilities;
namespace WebRegression.TestStructure
{
    public class Login_2 : TestBase
    {
        //static variables.
        private string _currentTestName = "";
        //private readonly DashboardPage _dashboard = new DashboardPage();
        //private readonly RegularReportPage _report = new RegularReportPage();
          private static readonly RandomDataGenerator _random = new RandomDataGenerator();
        #region
        private IWebElement Category => Library.FindByXPath("//div[contains(text(),'category')]");
        private IWebElement Category1 => Library.FindByXPath("//div[contains(text(),'Category')]");
        private IList<IWebElement> allCategory => Library.FindByListByXPath("//tbody[@class='fixed-body']//td//span");
        private IList<IWebElement> allCategory1 => Library.FindByListByXPath("//tbody[@class='fixed-body']//td//div");
        #endregion
        ///<summary>
        ///Refresh the page before each test.
        ///</summary>
        ///
        [SetUp]
        public void BeforeEachTest()
        {
            //Refresh the page before each test
            Library.RefreshPage();
            _currentTestName = TestContext.CurrentContext.Test.Name;
        }

        [Test, Order(1), Category("category")]
        public void Name_for_Test_Case()
        {
            UiTest(() =>
            {
                
            }, _currentTestName);
        }

       

        [TearDown]
        public void AfterEachTest()
        {

        }
    }
}
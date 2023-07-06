using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using WebRegression.PageObjects;
using WebRegression.Utilities;

namespace WebRegression.TestStructure

{
	public class CreateService : TestBase
    {
		
        private string _currentTestName = "";
		private readonly LogInPage _LoginCoach = new LogInPage();
		private readonly ServicesPage _service = new ServicesPage();
        private readonly ListMenu _menu = new ListMenu();



        #region
        private IWebElement PackageAUTO => Library.FindByXPath("//td[@title='Package Auto']//parent::tr//i");
        private IWebElement RemovePackage => Library.FindByXPath("//button[@class='btn left remove-modal-footer-btn']");
        private IWebElement YesRemove => Library.FindByXPath("//button[@class='btn btn-primary' and text()='Yes']");

        #endregion

        [Test, Order(1),Category("Services")]
        public void CreateAPackage()
        {
         
                UiTest(() =>
                {
                    
                    _LoginCoach.LogIntoSite("new@payout.com", "12341234");
                    Library.CustomWait(3);
                    //remove data before adding package
                    _menu.GoToServices_Package();
                    Library.CustomWait(2);
                    Boolean ExistingPackage = PackageAUTO.Displayed;

                    if (ExistingPackage == true)
                    {
                        PackageAUTO.Click();
                        Library.CustomWait(1);
                        RemovePackage.Click();
                        Library.CustomWait(1);
                        YesRemove.Click();

                    }
                    else
                    {

                    }

                    _service.CreatePackage("Package Auto", "Package is created from Automation toool","2", "100", "3", "5");
                    


                }, _currentTestName);

        }

        [Test, Order(2), Category("Services")]
        public void CreateAMembership()
        {

            UiTest(() =>
            {

                _LoginCoach.LogIntoSite("new@payout.com", "12341234");
                Library.CustomWait(3);
                _service.CreateMembership("Membership Auto", "Membership is created from Automation toool", "5", "100","20", "3", "5");


            }, _currentTestName);

        }

        [Test, Order(3), Category("Services")]
        public void CreateAProduct()
        {
            UiTest(() =>
            {
                _LoginCoach.LogIntoSite("new@payout.com", "12341234");
                Library.CustomWait(2);
                _service.CreateProduct("Product Auto", "Product is created from Automation tool", "100");

            }, _currentTestName);
        }
        [Test, Order(4), Category("Services")]
        public void CreateAnAppointment()
        {
            UiTest(() =>
            {
                _LoginCoach.LogIntoSite("new@payout.com", "12341234");
                Library.CustomWait(2);
                _service.CreateAppointment("Apppointment Auto", "60", "100", "2", "10");
            }, _currentTestName);

        }

        [Test, Order(5), Category("Serivices")]
        public void CreateAClass()
        {
            UiTest(() =>
            {
                _LoginCoach.LogIntoSite("new@payout.com", "12341234");
                Library.CustomWait(2);
                _service.CreateClass("Class Auto", "Class is created from Automation tool", "60", "100","5", "2", "10");

            }, _currentTestName);
        }

        [TearDown]
        public void AfterEachTest()
        {

        }
    }
}



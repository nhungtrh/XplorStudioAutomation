using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using WebRegression.PageObjects;
using WebRegression.TestStructure;
using WebRegression.Utilities;
using System.Linq;
using System.Collections.Generic;

namespace WebRegression.PageObjects
{
    public class ListMenu

    {
        //Class variables.
        private static readonly IWebDriver Driver = SetUpDriver.GetDriverInstance();
        private readonly LogTool _logger = new LogTool();
        private static readonly DateTime now = DateTime.Now;
        private static readonly string LayoutName = now.ToString("LayoutNameMMddHHmm");

        /// <summary>
        /// Constructor.
        /// </summary>


        #region Page Locators
        private IWebElement Schedule => Library.FindByXPath("(//a[@href='/app/schedule/'])");
        private IWebElement Schedule_Calendar => Library.FindByXPath("(//a[@href='/app/schedule/'])");//same when user clicks the Schedule
        private IWebElement Schedule_Event => Library.FindByXPath("(//a[@href='/app/events'])");
        private IWebElement Finances => Library.FindByXPath("//a[@href='/app/finances/invoices' and @class='nav-link nav-toggle animsition-link']");
        private IWebElement Finances_Payment => Library.FindByXPath("//a[@class='animsition-link' and text()='Payments']");
        private IWebElement Services => Library.FindByXPath("//a[@href='/app/services/']");
        private IWebElement Services_Packages => Library.FindByXPath("//a[@href='#packages_tab']");
        private IWebElement Services_Memberships => Library.FindByXPath("//a[@href='#memberships_tab']");
        private IWebElement Services_Retail => Library.FindByXPath("//a[@href='#storeproducts_tab']");
        private IWebElement Services_Appointments => Library.FindByXPath("//a[@href='#appointment_types_tab']");
        private IWebElement Services_Classes => Library.FindByXPath("//a[@href='#class_types_tab']");
        private IWebElement Services_Discounts => Library.FindByXPath("//a[@href='#discount_types_tab']");








        #endregion

        /// <summary>
        /// Click on settings tab from dashboard
        /// </summary>
        public void GoToSchedule_Calendar()
        {
            Schedule.Click();
            Library.WaitForPageLoadCompletely();
            Assert.IsTrue(Driver.Url.Contains("/app/schedule/"));
            TestContext.Out.WriteLine(" Appointment Block Configuration loaded successfully");


        }
        public void GoToSchedule_Event()
        {

            Schedule_Event.Click();
            Library.WaitForPageLoadCompletely();
            Assert.IsTrue(Driver.Url.Contains("/app/schedule/"));
            TestContext.Out.WriteLine(" Appointment Block Configuration loaded successfully");


        }
        public void GoToMember()
        {

           Schedule_Event.Click();
            Library.WaitForPageLoadCompletely();
            Assert.IsTrue(Driver.Url.Contains("/app/schedule/"));
            TestContext.Out.WriteLine(" Appointment Block Configuration loaded successfully");


        }
        public void GoToServices_Package()
        {
            Services.Click();
            Library.WaitForPageLoadCompletely();
            Services_Packages.Click();
            Library.WaitForPageLoadCompletely();
            Assert.IsTrue(Driver.Url.Contains("/app/services/"));
            TestContext.Out.WriteLine(" Packages Block Configuration loaded successfully");



        }
        public void GoToServices_MemberShip()
        {

            Services.Click();
            Library.WaitForPageLoadCompletely();
            Services_Memberships.Click();
            Library.WaitForPageLoadCompletely();
            Assert.IsTrue(Driver.Url.Contains("/app/services/memberships"));
            TestContext.Out.WriteLine(" Memberships Block Configuration loaded successfully");

        }
        public void GoToServices_Retail()
        {

            Services.Click();
            Library.WaitForPageLoadCompletely();
            Services_Retail.Click();
            Library.WaitForPageLoadCompletely();
            Assert.IsTrue(Driver.Url.Contains("app/services/products"));
            TestContext.Out.WriteLine("Retail Block Configuration loaded successfully");


        }
        public void GoToServices_Appoitment()
        {
            Services.Click();
            Library.WaitForPageLoadCompletely();
            Services_Appointments.Click();
            Library.WaitForPageLoadCompletely();
            Assert.IsTrue(Driver.Url.Contains("/app/services/session-templates"));
            TestContext.Out.WriteLine("Appointments Block Configuration loaded successfully");


        }
        public void GoToServices_Classes()
        {

            Services.Click();
            Library.WaitForPageLoadCompletely();
            Services_Classes.Click();
            Library.WaitForPageLoadCompletely();
            Assert.IsTrue(Driver.Url.Contains("/app/services/class-templates"));
            TestContext.Out.WriteLine("Classes Block Configuration loaded successfully");


        }
        public void GoToServices_Discount()
        {

            Services.Click();
            Library.WaitForPageLoadCompletely();
            Services_Discounts.Click();
            Library.WaitForPageLoadCompletely();
            Assert.IsTrue(Driver.Url.Contains("/app/services/discounts"));
            TestContext.Out.WriteLine("Discounts Block Configuration loaded successfully");


        }
        public void GoToFinances_Invoices()
        {

            Library.CustomWait(3);
            Library.RefreshPage();


        }
        public void GoToFinances_Payments()
        {
            Finances.Click();
            Library.CustomWait(3);
            Finances_Payment.Click();
            Library.WaitForPageLoadCompletely();
            Assert.IsTrue(Driver.Url.Contains("app/finances/payments"));
            TestContext.Out.WriteLine(" Finances Payments loaded successfully");


        }
        public void GoToFinances_Balances()
        {

            Library.CustomWait(3);
            Library.RefreshPage();


        }
        public void GoToFinances_Expenses()
        {

            Library.CustomWait(3);
            Library.RefreshPage();


        }
        public void GoToGeneralReport_Sumary()
        {

            Library.CustomWait(3);
            Library.RefreshPage();


        }
        public void GoToGeneralReport_DailySchudule()
        {

            Library.CustomWait(3);
            Library.RefreshPage();


        }
        public void GoToGeneralReport_Appoitment_ClassSummary()
        {

            Library.CustomWait(3);
            Library.RefreshPage();


        }
        public void GoToGeneralReport_MemberList()
        {

            Library.CustomWait(3);
            Library.RefreshPage();


        }
        public void GoToGeneralReport_PackageandMembership()
        {

            Library.CustomWait(3);
            Library.RefreshPage();


        }
        public void GoToGeneralReport_Attendance()
        {

            Library.CustomWait(3);
            Library.RefreshPage();


        }
        public void GoToGeneralReport_CheckIn()
        {

            Library.CustomWait(3);
            Library.RefreshPage();


        }
        //Complete the rest of the reports.

        public void GoToProgramming_Calendar()
        {

            Library.CustomWait(3);
            Library.RefreshPage();


        }
        public void GoToProgramming_LeaderBoard()
        {

            Library.CustomWait(3);
            Library.RefreshPage();


        }
    }
}





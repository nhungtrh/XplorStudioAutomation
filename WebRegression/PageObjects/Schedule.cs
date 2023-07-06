using java.sql;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Security.Principal;
using WebRegression.TestStructure;
using WebRegression.Utilities;

namespace WebRegression.PageObjects
{
	public class Schedule
	{
        //Class variables.
        private static readonly IWebDriver Driver = SetUpDriver.GetDriverInstance();
        private readonly LogTool _logSchedule = new LogTool();
        private readonly LogInPage _LogIn = new LogInPage();
        private readonly ServicesPage _services = new ServicesPage();
        private readonly ListMenu _listmenu = new ListMenu();


        #region locators

        private IWebElement BnNewEvent => Library.FindByXPath("//div[@id='addEventsButton']");
        private IWebElement BnNewClass => Library.FindById("add-class-icon");
        private IWebElement BnNewAppointment => Library.FindById("add-appointment-icon");
        private IWebElement BnPersonalTime => Library.FindById("add-personal-time-icon");
        private IWebElement BnMVPEvent => Library.FindById("add-event-icon");

        //Class modal
        private IWebElement ClassProgramType => Library.FindById("select2-programming_type_id-container");
        private IWebElement ClassName => Library.FindByXPath("//input[@id='event_name']");
        private IWebElement ClassDescription => Library.FindByXPath("//textarea[@name='big_description']");
        private IWebElement ClassTabIsFocused => Library.FindByXPath("//a[@href='#class_tab']//parent::li");
        private IWebElement EventDate => Library.FindByXPath("//input[@id = 'event_date']");
        private IWebElement EventStartTime => Library.FindByXPath("//div[@id='class_details']//input[@id = 'time_from']");
        private IWebElement EventEndTime => Library.FindByXPath("//div[@id='class_details']//input[@id = 'time_to']");
        private IWebElement ServiceTemplate => Library.FindByXPath("//span[@Id='select2-class_type_id-container']//parent::span");
        private IWebElement SearchService => Library.FindByXPath("//input[@class='select2-search__field']");
        private IWebElement ServiceFirstOption => Library.FindByXPath("//li[@class='select2-results__option select2-results__option--highlighted']");
        private IWebElement SaveClass => Library.FindByXPath("//div[@id='class_tab']//button[text()='Save']");
        private IWebElement SuccessfulMessage => Library.FindByXPath("//div[text()='Class booked. ']");



        //private IWebElement ClassCoach =>
        private IWebElement BnRepeat => Library.FindByXPath("//div[@class='toggle btn btn-xs btn-default off']");
        private IWebElement AdvancedSettings => Library.FindByXPath("//div[text()='Advanced Settings']");
        //Class category, class location
        private IWebElement ClassCapacity => Library.FindById("class_max_number");

        //Appointment modal
        private IWebElement ApmTabIsFocused => Library.FindByXPath("//a[@href='#session_tab']//parent::li");
        private IWebElement ApmService => Library.FindByXPath("//span[@Id='select2-session_type_id-container']");
        private IWebElement SaveApm => Library.FindByXPath("//div[@id='session_tab']//button[text()='Save']");
        private IWebElement ApmSuccessfulMessage => Library.FindByXPath("//div[text()='Appointment booked']");
       


        #endregion



        public void CreateClassbyTemplate(string StartTime, string EndTime, string auto)
        {
            //create by using a template 


            _listmenu.GoToSchedule_Calendar();
            BnNewEvent.Click();
            Library.CustomWait(1);
            BnNewClass.Click();
            Library.CustomWait(2);
            string IsClassActive = ClassTabIsFocused.GetAttribute("class");
            Assert.AreEqual(IsClassActive, "active");
            TestContext.Out.WriteLine("Class tab is focused now");

            string todayMMDDYYYY = Library.TodayDate();
            TestContext.Out.WriteLine(todayMMDDYYYY);
            //Check default date = today
            string defaultdate = EventDate.GetAttribute("value");
            TestContext.Out.WriteLine(defaultdate);
            //EventDate.Clear();
            //EventDate.SendKeys(todayMMDDYYYY);

            //Assert.Equals(todayMMDDYYYY, defaultdate);
            //TestContext.Out.WriteLine("default date is today");
            EventStartTime.Clear();
            EventStartTime.SendKeys(StartTime);
            EventEndTime.Clear();
            EventEndTime.SendKeys(EndTime);

            ServiceTemplate.Click();
            SearchService.SendKeys(auto);
            Library.CustomWait(1);
            ServiceFirstOption.Click();
            Library.CustomWait(1);

            SaveClass.Click();
            Library.WaitForElementDisplayed(SuccessfulMessage);


        }


        public void CreateAnAppointmentByTemplate (string name)
        {
            //create by using a template 


            _listmenu.GoToSchedule_Calendar();
            BnNewEvent.Click();
            Library.CustomWait(1);
            BnNewAppointment.Click();
            Library.CustomWait(2);
            string IsAppointmentActive = ApmTabIsFocused.GetAttribute("class");
            Assert.AreEqual(IsAppointmentActive, "active");
            TestContext.Out.WriteLine("Appointment tab is focused now");



            ApmService.Click();
            SearchService.SendKeys(name);
            Library.CustomWait(1);
            ServiceFirstOption.Click();
            Library.CustomWait(1);

            SaveApm.Click();
            Library.WaitForElementDisplayed(ApmSuccessfulMessage);


        }





    }
}
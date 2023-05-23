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
        #region locators

        private IWebElement BnNewEvent => Library.FindByXPath("//div[@aria-labelledby='addEventsButton']");
        private IWebElement BnNewClass => Library.FindById("add-class-icon");
        private IWebElement BnNewAppointment => Library.FindById("add-appointment-icon");
        private IWebElement BnPersonalTime => Library.FindById("add-personal-time-icon");
        private IWebElement BnMVPEvent => Library.FindById("add-event-icon");

        //Class modal
        private IWebElement ClassService => Library.FindById("select2-class_type_id-container");
        private IWebElement ClassProgramType => Library.FindById("select2-programming_type_id-container");
        private IWebElement ClassName => Library.FindById("event_name");
        private IWebElement ClassDescription => Library.FindByXPath("//textarea[@name=\"big_description\"]");
        //private IWebElement ClassCoach =>
        private IWebElement BnRepeat => Library.FindByXPath("//div[@class=\"toggle btn btn-xs btn-default off\"]");
        private IWebElement AdvancedSettings => Library.FindByXPath("//div[text()=\"Advanced Settings\"]");
        //Class category, class location
        private IWebElement ClassCapacity => Library.FindById("class_max_number");


        #endregion



        public void CreateClass()
        {

        }

         
			





    }
}
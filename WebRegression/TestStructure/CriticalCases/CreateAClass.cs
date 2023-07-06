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

	public class CreateAClass: TestBase
    {
		
        private string _currentTestName = "";
        private readonly LogInPage _LoginCoach = new LogInPage();
        private readonly MemberPage _memberPage = new MemberPage();
        private readonly ListMenu _listmenu = new ListMenu();
        private readonly Schedule _schedule = new Schedule();
        private readonly ServicesPage _service = new ServicesPage();

        #region
        #endregion

        [Test, Order(1), Category("Event")]

        public void CreateNewClass()

        {
            UiTest(() =>
            {

                _LoginCoach.LogIntoSite("new@payout.com", "12341234");
                Library.CustomWait(3);

                _service.CreateClass("auto unique", "this class is created from automation toool", "60", "100", "10", "3", "10");

                _schedule.CreateClassbyTemplate("9:00 am", "10:00 am", "auto unique");

                //
            }, _currentTestName);



        }
    }
}


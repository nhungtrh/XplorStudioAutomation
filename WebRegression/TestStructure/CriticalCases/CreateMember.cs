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
	public class CreateMember: TestBase
	{
        private string _currentTestName = "";
        private readonly LogInPage _LoginCoach = new LogInPage();
        private readonly MemberPage _service = new MemberPage();


        #region
        #endregion
        [Test, Order(1), Category("Members")]
        public void CreateAmember()
        {

            UiTest(() =>
            {

                _LoginCoach.LogIntoSite("new@payout.com", "12341234");
                Library.CustomWait(3);
                _service.CreateMember("Fauto","Lauto", "automation123@test.com", "96123423423", "this member is created from automation tool", "30");


            }, _currentTestName);

        }
    }
}


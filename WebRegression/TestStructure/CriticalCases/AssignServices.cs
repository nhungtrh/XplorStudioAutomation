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
	public class AssignServices: TestBase

	{
        private string _currentTestName = "";
        private readonly LogInPage _LoginCoach = new LogInPage();
        private readonly MemberPage _memberPage = new MemberPage();
        private readonly ListMenu _listmenu = new ListMenu();

        #region
        #endregion

        [Test, Order(1), Category("Assign Service")]

        public void AssignPackage()
        {
            UiTest(() =>
            {
                _LoginCoach.LogIntoSite("new@payout.com", "12341234");
                _listmenu.GoToMember();
                _memberPage.SearchAMember("auto@test.com");
                _memberPage.GotoMemberServices();
                _memberPage.AssignPackage();


            }, _currentTestName);
        }
        [Test, Order(2), Category("Assign Service")]

        public void AssignAProduct()
        {
            UiTest(() =>
            {
                _LoginCoach.LogIntoSite("new@payout.com", "12341234");
                _listmenu.GoToMember();
                _memberPage.SearchAMember("auto@test.com");
                _memberPage.GotoMemberServices();
                _memberPage.AssignProduct();


            }, _currentTestName);
        }

    }
}


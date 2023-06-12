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
	public class CreateAnInvoice: TestBase
	{
        private string _currentTestName = "";
        private readonly LogInPage _LoginCoach = new LogInPage();
        private readonly MemberPage _memberPage = new MemberPage();
        private readonly ListMenu _listmenu = new ListMenu();

        private readonly InvoicePage _invoicePage = new InvoicePage();

        #region
        #endregion

        [Test, Order(1), Category("Invoice")]

        public void CreateNewInvoice()
		{
            UiTest(() =>
            {

                _LoginCoach.LogIntoSite("new@payout.com", "12341234");
                Library.CustomWait(3);
                _listmenu.GoToMember();
                Library.WaitForPageLoadCompletely();
                _memberPage.SearchAMember("automation123@test.com");
                _memberPage.GotoMemberInvoice();
                _invoicePage.CreateNewInvoice("2023-06-12", "Auto Item", "99", "10", "9.00", "99");


            }, _currentTestName);


        }
	}
}


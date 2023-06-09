﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WebRegression.PageObjects;
using WebRegression.TestStructure;
using WebRegression.Utilities;
using Keys = OpenQA.Selenium.Keys;

namespace WebRegression.PageObjects
{
	public class MemberPage
    {
        #region
        private readonly LogInPage _loginCoach = new LogInPage();
        private readonly ListMenu _listmenu = new ListMenu();

        private string _currentTestName = "";

        private static readonly IWebDriver Driver = SetUpDriver.GetDriverInstance();
        private static Actions action = new Actions(Driver);


      
        //locators - add new member 
        private IWebElement bnNewMember => Library.FindByXPath("//a[@id='add-client-link']");
		private IWebElement statusList => Library.FindByXPath("//div[@class='add-edit-modal-current-client-status inline-block']");
		private IWebElement statusActive => Library.FindByXPath("//div[@class='bf-dropdown-button-list']//div[@data-status='1']");
		private IWebElement NameFirst => Library.FindByXPath("//input[@Id='first']");
		private IWebElement NameLast => Library.FindByXPath("//input[@Id='last']");
		private IWebElement Email => Library.FindByXPath("//input[@Id='client_email']");
		private IWebElement Mobile => Library.FindByXPath("//div[@class='form-floating']//input[@name='phone1']");
		private IWebElement BirthdayYear => Library.FindByXPath("//select[@name='birthday_year']");
        private IWebElement BirthdayYear1990 => Library.FindByXPath("//select[@name='birthday_year']//option[@value='1990']");
		private IWebElement BirthdayMonth => Library.FindByXPath("//select[@name='birthday_month']");
        private IWebElement BirthdayMonth8 => Library.FindByXPath("//select[@name='birthday_month']//option[@value='8']");
		private IWebElement BirthdayDay => Library.FindByXPath("//select[@name='birthday']");
        private IWebElement BirthdayDay1 => Library.FindByXPath("//select[@name='birthday']//option[@value='1']");
		private IWebElement ImportanceNote => Library.FindByXPath("//input[@id='important_notes']");
		private IWebElement MoreInfo => Library.FindByXPath("//a[@class='more-extended-client-info-block']");
		private IWebElement DefaultCost => Library.FindByXPath("//input[@id='default_session_cost']");
		private IWebElement MemberLogin => Library.FindByXPath("//label[@class='btn btn-default btn-sm active toggle-off']");
		private IWebElement SendActivationEmail => Library.FindByXPath("//label[@for='password_action_send_activation_email']");
		private IWebElement MemberSave => Library.FindByXPath("//button[@id='save-client-add-edit-modal']");
		private IWebElement MemberMessage => Library.FindByXPath("//div[text()='New member added']");


		//Locaters - Delete a member
		private IWebElement SearchMember => Library.FindByXPath("//input[@placeholder='Search' and @class='form-control mandatory']");
		private IWebElement NoMemberFound => Library.FindByXPath("//div[@class='center-block fit-content hide empty-clients-search-result']");
		private IWebElement SelectAllmember => Library.FindByXPath("//label[@for='select-all-client']");
		private IWebElement MassActions => Library.FindByXPath("//div[@class='mass-update-clients-statuses-label']");
		private IWebElement MoveToArchived => Library.FindByXPath("//div[@class='bf-dropdown-button-one-item mass-update-clients-statuses-one-status client-status--archived']");
		private IWebElement BnSetArchiveNow => Library.FindByXPath("//button[text()='Set Archived now']");
		private IWebElement RemoveAllClient => Library.FindByXPath("//div[@class='bf-dropdown-button-one-item mass-remove-clients']");
		private IWebElement bnConfirmRemoveClient => Library.FindByXPath("//div[@class='bootstrap-dialog-footer-buttons']//button[2]");
		private IWebElement MessageRemoved => Library.FindByXPath("//div[text()='Clients removed']");
        private IWebElement NoClient => Library.FindByXPath("//div[@class='select-all-clients-blue-checkbox' and @style='display: none;']");

        //Member profile
        private IWebElement MemberFinance => Library.FindByXPath("//a[@href='#client_payments']");
        private IWebElement MemberFinanceInvoice => Library.FindByXPath("//a[@href='#client_invoices']");
        private IWebElement FirstMember => Library.FindByXPath("//td[@aria-describedby='active-grid-index_first']");

        //Assign package
        private IWebElement MemberService => Library.FindByXPath("//a[@href='#client_services']");
        private IWebElement AssignAPackage => Library.FindByXPath("//button[@class='btn add-memb-pack-prod-btn orange-button ']");
        private IWebElement SelectPackage4084 => Library.FindByXPath("//a[@data-id='4084']");
        private IWebElement SavePackage => Library.FindByXPath("//button[@id='add-package-button']");
        private IWebElement SendAgreement => Library.FindByXPath("//button[@id='btn_ar']");



        //AssignMembership
        private IWebElement AssignAMembership => Library.FindByXPath("//button[@class='btn add-memb-pack-prod-btn orange-button dropdown-toggle ']");
        private IWebElement SelectMembership9737 => Library.FindByXPath("//a[@data-id='9737']");
        private IWebElement MembershipStartDate => Library.FindByXPath("//input[@data-date-format='MM/DD/YYYY']");
        private IWebElement DatePicker => Library.FindByXPath("//table[@class='ui-datepicker-calendar']");
        private IWebElement TodayDate => Library.FindByXPath("//a[@class='ui-state-default ui-state-highlight']");
        private IWebElement SaveMembership => Library.FindByXPath("//button[@id='add-membership-button']");


        //AssignProduct
        private IWebElement AssignAProduct => Library.FindByXPath("//button[@class='btn add-memb-pack-prod-btn  orange-button dropdown-toggle ']");
        private IWebElement SelectProduct23579 => Library.FindByXPath("//a[@data-id = '23579']");
        private IWebElement SaveProduct => Library.FindByXPath("//button[@Id='add-product-button']");


        #endregion
        public void CreateMember(string first, string last, string email, string mobile, string note, string cost)
        {
            _listmenu.GoToMember();
            Library.WaitForPageLoadCompletely();

            //Remove data before creating new one
            SearchMember.SendKeys(email);
            Library.WaitForPageLoadCompletely();
            Library.CustomWait(2);

            Boolean Noclient = NoMemberFound.Displayed;


            if
                //(Library.IsElementVisible(By.XPath("//label[@for='select-all-client']//parent::div[@style='display: none;']")) == true) //no client found
                (Noclient == true) 
            {
              

                //Create a new member after removing existing data
                bnNewMember.Click();
                Library.CustomWait(2);
                statusList.Click();
                Library.CustomWait(1);
                //set Active status
                statusActive.Click();
                NameFirst.SendKeys(first);
                NameLast.SendKeys(last);
                Email.SendKeys(email);
                Library.ScrollToWebElement(Mobile);
                Mobile.SendKeys(mobile);
                BirthdayYear.Click();
                Library.CustomWait(1);
                //select birthday year = 1990 
                BirthdayYear1990.Click();
                BirthdayMonth.Click();
                Library.CustomWait(1);
                //Select Month = 8
                BirthdayMonth8.Click();
                BirthdayDay.Click();
                Library.CustomWait(1);
                //Select day = 1
                BirthdayDay1.Click();
                Library.ScrollToWebElement(ImportanceNote);
                ImportanceNote.SendKeys(note);
                Library.ScrollToWebElement(MoreInfo);
                MoreInfo.Click();
                Library.ScrollToWebElement(DefaultCost);
                DefaultCost.SendKeys(cost);
                Library.ScrollToWebElement(MemberLogin);
                MemberLogin.Click();
                SendActivationEmail.Click();
                MemberSave.Click();
                Library.CustomWait(2);
                Library.WaitForElementDisplayed(MemberMessage);

           
            }


            else
            {
                Library.CustomWait(2);
                //remove existing data
                SelectAllmember.Click();
                Library.CustomWait(1);
                MassActions.Click();
                Library.CustomWait(1);
                MoveToArchived.Click();
                Library.CustomWait(1);
                BnSetArchiveNow.Click();
                Library.CustomWait(1);
                SelectAllmember.Click();
                Library.CustomWait(1);
                MassActions.Click();
                Library.CustomWait(1);
                RemoveAllClient.Click();
                Library.CustomWait(1);
                bnConfirmRemoveClient.Click();
                Library.WaitForElementDisplayed(MessageRemoved);


                bnNewMember.Click();
                Library.CustomWait(2);
                statusList.Click();
                Library.CustomWait(1);
                //set Active status
                statusActive.Click();
                NameFirst.SendKeys(first);
                NameLast.SendKeys(last);
                Email.SendKeys(email);
                Library.ScrollToWebElement(Mobile);
                Mobile.SendKeys(mobile);
                BirthdayYear.Click();
                Library.CustomWait(1);
                //select birthday year = 1990 
                BirthdayYear1990.Click();
                BirthdayMonth.Click();
                Library.CustomWait(1);
                //Select Month = 8
                BirthdayMonth8.Click();
                BirthdayDay.Click();
                Library.CustomWait(1);
                //Select day = 1
                BirthdayDay1.Click();
                Library.ScrollToWebElement(ImportanceNote);
                ImportanceNote.SendKeys(note);
                Library.ScrollToWebElement(MoreInfo);
                MoreInfo.Click();
                Library.ScrollToWebElement(DefaultCost);
                DefaultCost.SendKeys(cost);
                Library.ScrollToWebElement(MemberLogin);
                MemberLogin.Click();
                SendActivationEmail.Click();
                MemberSave.Click();
                Library.CustomWait(2);
                Library.WaitForElementDisplayed(MemberMessage);
            }
               
            


        }

        public void GotoMemberInvoice()
        {
            Library.WaitForPageLoadCompletely();
            MemberFinance.Click();
            Library.WaitForPageLoadCompletely();
            MemberFinanceInvoice.Click();
            Assert.IsTrue(Driver.Url.Contains("/finances/invoices"));
            TestContext.Out.WriteLine(" Member Invoice loaded successfully");
        }

        public void GotoMemberServices()
        {
            Library.WaitForPageLoadCompletely();
            MemberService.Click();
            Library.WaitForPageLoadCompletely();
            Assert.IsTrue(Driver.Url.Contains("/services"));
            TestContext.Out.WriteLine(" Member Services loaded successfully");


        }

        public void SearchAMember(string email)
        {
            Library.WaitForPageLoadCompletely();
            SearchMember.SendKeys(email);
            Library.CustomWait(3);
            FirstMember.Click();
            Library.WaitForPageLoadCompletely();
        }

        public void AssignPackage()
        {
            AssignAPackage.Click();
            Library.CustomWait(1);
            Library.ScrollToWebElement(SelectPackage4084);
            SelectPackage4084.Click();
            Library.CustomWait(2);
            SavePackage.Click();
            Library.CustomWait(1);
            SendAgreement.Click();
            Library.WaitForPageLoadCompletely();


        }

        public void AssignProduct()
        {
            AssignAProduct.Click();
            Library.CustomWait(1);
            Library.ScrollToWebElement(SelectProduct23579);
            SelectProduct23579.Click();
            Library.CustomWait(1);
            SaveProduct.Click();
            Library.CustomWait(1);
            SendAgreement.Click();
            Library.WaitForPageLoadCompletely();


        }

        public void AssignMembership()
        {
            AssignAMembership.Click();
            Library.CustomWait(1);
            Library.ScrollToWebElement(SelectMembership9737);
            SelectMembership9737.Click();
            Library.CustomWait(1);
            MembershipStartDate.Click();
            Library.moveMouseToElement(DatePicker);
            TodayDate.Click();
            Library.CustomWait(1);
            SaveMembership.Click();
            Library.WaitForElementDisplayed(SendAgreement);
            SendAgreement.Click();
            Library.WaitForPageLoadCompletely();

            
        }
    

    }
}


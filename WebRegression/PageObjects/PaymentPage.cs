
using NUnit.Framework;
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
    public class PaymentPage

    {
        private readonly LogInPage _loginCoach = new LogInPage();
        private readonly ListMenu _listmenu = new ListMenu();

        private string _currentTestName = "";

        private static readonly IWebDriver Driver = SetUpDriver.GetDriverInstance();
        private static Actions action = new Actions(Driver);


        #region Page Locators

        //locators
        private IWebElement NewPmSearchMember => Library.FindByXPath("//button[@title='No members selected']//following::input[1]");
        //Member profile
        private IWebElement BnNewPayment => Library.FindByXPath("//button[text()='New payment']");
        private IWebElement NewPayment_Member => Library.FindByXPath("//select[@name='client_id']");
        private IWebElement NewPayment_Invoice => Library.FindByXPath("//label[@for='without_invoice_with']");
        private IWebElement NewPayment_Unassigned => Library.FindByXPath("//div[@class='invoice_without']");
        private IWebElement NewPayment_Stripe => Library.FindByXPath("//label[@for='payment_has_clientpay_checkbox']");
        private IWebElement NewPayment_Date => Library.FindByXPath("//input[@name='date']");
        private IWebElement NewPayment_Amount => Library.FindByXPath("//input[@id='amount']");
        private IWebElement NewPayment_Type => Library.FindByXPath("//select[@id='type']");
        private IWebElement NewPayment_Category => Library.FindByXPath("//select[@id='category_id']");
        private IWebElement NewPayment_Notes => Library.FindByXPath("//textarea[@id='notes']");
        private IWebElement NewPayment_Receipt => Library.FindByXPath("//div[@class='email-receipt-wrap']");
        private IWebElement BnSavePayment => Library.FindByXPath("//button[@id='save-payment-button']");
        private IWebElement BnSavePaymentRecordAnother => Library.FindByXPath("//button[@id='save-payment-button-and-record-another']");


        //app/finances/payments page
        private IWebElement OpenNewPaymentModal => Library.FindByXPath("//button[@data-target='#record-payment-modal']");
        private IWebElement NewPmSelectMember => Library.FindByXPath("//button[@title='No members selected']");

        private IWebElement NewPmSave => Library.FindByXPath("//input[@class = 'btn btn-defaultbtn btn-primary  submit-payment-add']");
        private static IWebElement PmFirstMemberOption => Library.FindByXPath("//label[@for='__uni_el_id__116']");
        private IWebElement PaymentConfirmationModal => Library.FindByXPath("//div[text()='Card payment confirmation']");
        private IWebElement PaymentConfirmation_Yes => Library.FindByXPath("//button[text()='Yes']");
        private IWebElement PaymentSuccessfulMesssage => Library.FindByXPath("//div[text()='Payment has been added']");
        private IWebElement PaymentDateDisabled => Library.FindByXPath("//input[@name='date' and @disabled='disabled']");
        private IWebElement PaymentTypeStripe => Library.FindByXPath("//option[@value='stripe' and @selected='selected']");
        private IWebElement PmTypeCash => Library.FindByXPath("//option[@value='cash']");
        private IWebElement PmCategoryApmt => Library.FindByXPath("//option[text()='Appointments Income']");






        #endregion


        /// <summary>
        /// search for the give WO NUMBER from WO page
        /// </summary>
        /// <param name="WO"></param>


        public void CreateStripePayment(string memberName, string amount, string notes)
        {
            _listmenu.GoToFinances_Payments();
            OpenNewPaymentModal.Click();
            NewPmSelectMember.Click();
            Library.CustomWait(3);
            //NewPmSearchMember.Click();
            //NewPmSearchMember.SendKeys(memberName);
            //PmFirstMemberOption.Click();
            Library.SelectDynamicDropDown(NewPmSearchMember, memberName, PmFirstMemberOption);
            NewPayment_Unassigned.Click();
            //Stripe checkbox is ticked
            //bool Stripecheckbox = NewPayment_Stripe.Selected;
            //Date is disabled = today
            //Library.WaitForElementDisplayed(PaymentDateDisabled);
            //Library.WaitForElementDisplayed(PaymentTypeStripe);
            NewPayment_Amount.SendKeys(amount);
            NewPayment_Notes.SendKeys(notes);
            NewPmSave.Click();
            Library.WaitForElementDisplayed(PaymentConfirmationModal);
            PaymentConfirmation_Yes.Click();
            Library.WaitForElementDisplayed(PaymentSuccessfulMesssage);


        }

        public void CreateCashPayment (string memberName, string date, string amount, string notes )

        {
            _listmenu.GoToFinances_Payments();
            OpenNewPaymentModal.Click();
            NewPmSelectMember.Click();
            Library.CustomWait(3);
            Library.SelectDynamicDropDown(NewPmSearchMember, memberName, PmFirstMemberOption);
            NewPayment_Unassigned.Click();
            NewPayment_Stripe.Click();
            NewPayment_Date.Clear();
            NewPayment_Date.SendKeys(date);
            NewPayment_Amount.SendKeys(amount);
            //
            Library.SelectDropDownBy(NewPayment_Type, "dropdown", "Paypal");
            NewPayment_Notes.SendKeys(notes);
            NewPmSave.Click();
            Library.WaitForElementDisplayed(PaymentSuccessfulMesssage);

        }




    }
}
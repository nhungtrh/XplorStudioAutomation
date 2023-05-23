
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
    public class ServicesPage
    {


        #region

        private readonly LogInPage _loginCoach = new LogInPage();
        private readonly ListMenu _listmenu = new ListMenu();

        private string _currentTestName = "";

        private static readonly IWebDriver Driver = SetUpDriver.GetDriverInstance();
        private static Actions action = new Actions(Driver);

        //Locators
        //Package 
        private IWebElement BnNewPackage => Library.FindByXPath("//button[@rel='add-package']");
        private IWebElement PackageName => Library.FindByXPath("//input[@placeholder='Package name']");
        private IWebElement PackageDescription => Library.FindByXPath("//div[@role='textbox' and@style='height: 120px;']");
        private IWebElement PackageCategory => Library.FindByXPath("//select[@name='service_category_id']");
        private IWebElement PackageDuration => Library.FindByXPath("//input[@name='package_term_count']");
        private IWebElement PackagePeriod => Library.FindByXPath("//select[@name='package_term_period']");
        private IWebElement PackagePrice => Library.FindByXPath("//input[@name='total_cost']");
        private IWebElement PackageFree => Library.FindByXPath("//label[@class='is_package_free']");
        private IWebElement PackagePmCategory => Library.FindByXPath("//select[@name='payment_category']");
        private IWebElement PackageAppointment => Library.FindByXPath("//input[@name='count_sessions']");
        private IWebElement PackageClass => Library.FindByXPath("//input[@name='count_classes']");
        private IWebElement PackageBuyOnline => Library.FindByXPath("//input[@name='allow_purchase']");
        private IWebElement PackageSave => Library.FindByXPath("//button[text()='Save' and @class='btn btn-primary']");

        //Membership
        private IWebElement BnNewMembership => Library.FindByXPath("//button[@rel='add-membership']");
        private IWebElement MembershipName => Library.FindByXPath("//input[@placeholder='Membership name']");
        private IWebElement MembershipDes => Library.FindByXPath("//div[@role='textbox' and@style='height: 120px;']");
        private IWebElement MembershipDuration => Library.FindByXPath("//input[@placeholder='Membership duration']");
        private IWebElement MembershipPrice => Library.FindByXPath("//input[@name='payment_amount']");
        private IWebElement MembershipSetupFee => Library.FindByXPath("//input[@id='setup_fee']//parent::div");
        private IWebElement MembershipSetupAmount => Library.FindByXPath("//input[@name='membership_fee']");
        private IWebElement MembershipAppointment => Library.FindByXPath("//input[@name='count_sessions']");
        private IWebElement MembershipClass => Library.FindByXPath("//input[@name='count_classes']");
        private IWebElement MembershipSave => Library.FindByXPath("//button[@class='btn btn-primary' and text()='Save']");

        //Retail
        private IWebElement bnNewProduct => Library.FindByXPath("//button[@type='button' and @data-toggle='dropdown']");
        private IWebElement bnNewSingle => Library.FindByXPath("//a[@class='add-product-single']");
        private IWebElement ProductName => Library.FindByXPath("//input[@placeholder='Product name']");
        private IWebElement ProductNote => Library.FindByXPath("//div[@class='note-editable' and @style='height: 120px;']");
        private IWebElement ProductPrice => Library.FindByXPath("//input[@name='product_price']");
        private IWebElement ProductSave => Library.FindByXPath("//button[text()='Save' and @class='btn btn-primary']");
        private IWebElement ProductForm => Library.FindByXPath("//form[@id = 'add-product-form']");



        #endregion

        public void CreatePackage(string name, string description, string duration, string price, string Nclass, string Napt)
        {
            _listmenu.GoToServices_Package();
            Library.WaitForPageLoadCompletely();
            BnNewPackage.Click();
            Library.CustomWait(3);
            PackageName.SendKeys(name);
            PackageDescription.SendKeys(description);
            PackageCategory.Click();
            Library.ScrollToWebElement(PackageDuration);
            PackageDuration.SendKeys(duration);
            PackagePeriod.Click();
            Library.ScrollToWebElement(PackagePrice);
            PackagePrice.SendKeys(price);
            Library.ScrollToWebElement(PackageAppointment);
            PackageAppointment.SendKeys(Napt);
            Library.ScrollToWebElement(PackageClass);
            PackageClass.SendKeys(Nclass);
            Library.CustomWait(1);
            PackageSave.Click();
            Library.CustomWait(3);


        }

        public void CreateMembership(string name, string description, string duration, string price, string SetupFee, string Nclass, string Napt)
        {
            _listmenu.GoToServices_MemberShip();
            Library.WaitForPageLoadCompletely();
            BnNewMembership.Click();
            Library.CustomWait(3);
            MembershipName.SendKeys(name);
            MembershipDes.SendKeys(description);
            PackageCategory.Click();
            Library.ScrollToWebElement(MembershipDuration);
            MembershipDuration.SendKeys(duration);
            Library.ScrollToWebElement(MembershipPrice);
            MembershipPrice.SendKeys(price);
            MembershipSetupFee.Click();
            MembershipSetupAmount.SendKeys(SetupFee);
            Library.ScrollToWebElement(MembershipAppointment);
            MembershipAppointment.SendKeys(Napt);
            Library.ScrollToWebElement(MembershipClass);
            MembershipClass.SendKeys(Nclass);
            Library.CustomWait(1);
            MembershipSave.Click();
            Library.CustomWait(3);


        }

        public void CreateProduct(string name, string note, string price)
        {
            _listmenu.GoToServices_Retail();
            Library.WaitForPageLoadCompletely();
            bnNewProduct.Click();
            Library.CustomWait(1);
            bnNewSingle.Click();
            Library.WaitForElementDisplayed(ProductForm);
            ProductName.SendKeys(name);
            ProductNote.SendKeys(note);
            Library.ScrollToWebElement(ProductPrice);
            ProductPrice.SendKeys(price);
            Library.CustomWait(2);
            ProductSave.Click();
            Library.CustomWait(3);
        }
    }
}



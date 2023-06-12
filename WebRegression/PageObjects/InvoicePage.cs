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
	public class InvoicePage
	{
        #region
        private readonly LogInPage _loginCoach = new LogInPage();
        private readonly ListMenu _listmenu = new ListMenu();

        private string _currentTestName = "";

        private static readonly IWebDriver Driver = SetUpDriver.GetDriverInstance();
        private static Actions action = new Actions(Driver);

        //Locator
        //Search a member
        private IWebElement SearchMember => Library.FindByXPath("//input[@placeholder='Search' and @class='form-control mandatory']");


        //Create an invoice under member profile

        private IWebElement bnNewInvoice => Library.FindByXPath("//button[@class='btn btn-primary btn-outline record-invoice-button ml-10']");

        private IWebElement SelectAMember => Library.FindByXPath("//select[@class='clients-multiselect']//following::button[@title='Select member…'][2]");
        private IWebElement EnterMember => Library.FindByXPath("//ul[@class='multiselect-container dropdown-menu']//following::input[@class='form-control multiselect-search'][3]");
        private IWebElement IssueDate => Library.FindByXPath("//div[@id='new-invoices-modal']//input[@name='invoice_date']");
        private IWebElement DueDate => Library.FindByXPath("//div[@id='new-invoices-modal']//input[@name='due_date']");
        private IWebElement AddAnItem => Library.FindByXPath("//div[@id='new-invoices-modal']//div[text()='Add an item...']");
        private IWebElement AddOtherItem => Library.FindByXPath("//div[@id='new-invoices-modal']//div[@id='invoice-custom-products-modal-button']");
        private IWebElement ItemName => Library.FindByXPath("//div[@id='invoice-items-table']//input[@type='text' and @class='invoice-item-description validate validate-notempty']");
        private IWebElement ItemPrice => Library.FindByXPath("//div[@id='invoice-items-table']//input[@type='number' and @class='invoice-item-cost onlyfloat allow-negative']");
        private IWebElement ItemTaxRate => Library.FindByXPath("//div[@id='invoice-items-table']//input[@type='number' and @name='tax_rate']");
        private IWebElement SaveAddAnother => Library.FindByXPath("//button[text()='Save & add another']");
        private IWebElement SaveInvoice => Library.FindByXPath("//button[text()='Save & add another']//following::button");
        private IWebElement SuccessfulMessage => Library.FindByXPath("//div[contains(text(),'created successfully')]");

        // tax
        //private IWebElement ChangeTax => Library.FindByXPath("//div[@class='form-floating tax-deduct-type-wrap ']//parent::div[1]");
        private IWebElement ChangeTax => Library.FindByXPath("//div[@class='form-floating tax-deduct-type-wrap ']//select[@name='tax_deduct_type_invoice']");
        private IWebElement InclusiveTax => Library.FindByXPath("//div[@class='form-floating tax-deduct-type-wrap ']//option[@value='inclusive']");

        //data
        private IWebElement InvModal => Library.FindByXPath("//div[@class='bootstrap-dialog-title' and text()='Invoice']");
        private IWebElement SubTotal => Library.FindByXPath("//div[@class='invoice-sub-total-view']//span[@class='invoice-sub-total']");
        private IWebElement InclTaxTotal => Library.FindByXPath("//span[@class='inclusive-tax ']//span[@class='inovoice-tax-value']");
        private IWebElement InvTotal => Library.FindByXPath("//div[@class='invoice-total-view']//span[@class='invoice-amount-total']");


        #endregion

        public void CreateNewInvoice(string date, string itemName, string itemprice, string tax, string expectedTax, string expectedTotal)
        {
            Library.WaitForPageLoadCompletely();
            bnNewInvoice.Click();
            Library.WaitForElementDisplayed(IssueDate);
            IssueDate.SendKeys(date);
            DueDate.Clear();
            DueDate.SendKeys(date);
            Library.CustomWait(1);
            //ChangeTax.Click();
            //Library.CustomWait(1);
            //InclusiveTax.Click();
            Library.ScrollToWebElement(AddAnItem);
            AddAnItem.Click();
            Library.CustomWait(1);
            AddOtherItem.Click();
            Library.CustomWait(1);
            ItemName.SendKeys(itemName);
            ItemPrice.Clear();
            ItemPrice.SendKeys(itemprice);
            ItemTaxRate.Clear();
            ItemTaxRate.SendKeys(tax);
            SaveInvoice.Click();
            Library.CustomWait(1);
            Library.WaitForElementDisplayed(SuccessfulMessage);

            //Check data
            Library.WaitForElementDisplayed(InvModal);
            String ActualSubtotal = SubTotal.GetAttribute("data-value");
            Assert.AreEqual(itemprice, ActualSubtotal);
            TestContext.Out.WriteLine("Subtotal is correct");

            String ActualTax= InclTaxTotal.Text;

            Assert.AreEqual(expectedTax, ActualTax);
            TestContext.Out.WriteLine("Tax value is correct");

            String ActualTotal = InvTotal.GetAttribute("data-value");
            Assert.AreEqual(expectedTotal, ActualTotal);
            TestContext.Out.WriteLine("total value is correct");



        }
    }
}


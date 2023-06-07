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

        //Locater

        private IWebElement bnNewInvoice => Library.FindByXPath("//a[@data-original-title='New invoice']");

        #endregion
    }
}


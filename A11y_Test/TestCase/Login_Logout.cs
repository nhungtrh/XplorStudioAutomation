using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;



namespace XplorStudio.TestCase
{
	public class Login_Logout
	{
		protected IWebDriver Driver;

		public void BeforeAll()
		{
			Driver = new ChromeDriver();
		}

		public Login_Logout()

		{
			PO_Basic po_Basic = new PO_Basic(Driver);

		}
	}
}


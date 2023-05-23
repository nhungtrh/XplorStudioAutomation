using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using WebRegression.Utilities;

namespace WebRegression.TestStructure
{

    /// <summary>
    /// The Base level test logic class used to create or otherwise support framework testing.
    /// </summary>
    [TestFixture]
    public class TestBase
    {

        //Private member variables.
        protected static IWebDriver Driver = SetUpDriver.GetDriverInstance();
        private static readonly LogTool Logger = new LogTool();
        private static readonly WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(7));

        /// <summary>
        /// Encapsulate the testing 
        /// </summary>
        /// <param name="action"></param>
        protected void UiTest(Action action, string testName)
        {

            //perform the incoming test.
            try
            {
                action();
            }

            //if the test errors out, log it to the file.

            catch (Exception ex)
            {

                //member variables
                var errorMsg = ex.Message;
                var crm_error_str = "unexpected alert";
                var ffx_error_str = "unexpected alert";

                if (errorMsg.Contains(crm_error_str) || errorMsg.Contains(ffx_error_str))
                {
                    Logger.CreateErrorFile("Exception occured at: " + errorMsg);

                    if (errorMsg.Contains("Ajax error:"))
                    {
                        Logger.CreateErrorFile("AJAX ERROR DETECTED!!");
                        Logger.AddToLogFile(testName + " encountered an Ajax error!");
                    }
                    else
                    {
                        TestContext.WriteLine("Saving error to text file.");
                        Logger.CreateErrorFile(errorMsg);
                        Logger.AddToLogFile(testName + " encountered an unknown error!");
                    }
                }
                else
                {
                    Logger.CreateErrorFile(ex.StackTrace);
                    Logger.AddToLogFile(testName + " encountered an error!");
                }

                //CheckForPrompt();
                throw;
            }
        }

        /// <summary>
        /// Common actions for basic test tear down.
        /// </summary>
        /// <param name="currentTestName"></param>
        public void BaseTearDown(string currentTestName)
        {

            var testResult = TestContext.CurrentContext.Result.Outcome;

            if (!Equals(testResult, ResultState.Success))
            {
                Logger.AddToLogFile(currentTestName + " test status: " + testResult);
            }
        }

        /// <summary>
        /// Common actions for basic test set up.
        /// </summary>
        /// <param name="currentTestName"></param>
        public void BaseSetup()
        {

        }


        /// <summary>
        /// Check for any open dialogs previously missed.
        /// </summary>
        public void CheckForPrompt()
        {

            try
            {

                var alert = Driver.SwitchTo().Alert();
                alert.Accept();
                Logger.CreateErrorFile("Cleared the alert!");
            }
            catch (NoAlertPresentException e)
            {

            }
        }
    }


}

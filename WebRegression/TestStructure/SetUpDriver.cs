using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Events;
using System;
using WebRegression.PageObjects;
using WebRegression.Utilities;

namespace WebRegression.TestStructure
{
    /// <summary>
    /// This class creates an instance of a webdriver object.
    /// </summary>
    [SetUpFixture]
    public class SetUpDriver
    {
        protected static IWebDriver WebDriver;
        protected static EventFiringWebDriver FiringDriver;
        //private readonly LogInPage _logIn = new LogInPage();
        private static int _driverWhoIs = 0;
        private readonly LogTool _logger = new LogTool();
        private static string _browserType = "";
        private static string _chosenAddress = "";
        private static string _userName = "";
        private static string _passWord = "";
        private readonly string _driversPath = $@"{AppDomain.CurrentDomain.BaseDirectory}";


        [OneTimeSetUp]
        public void Setup()
        {
            try
            {

                GetTestInput();
            }
            catch (Exception e)
            {

                _logger.CreateErrorFile(e.ToString());
            }
            switch (_browserType)
            {

                case "firefox":
                    WebDriver = new FirefoxDriver(FfService(), FfOptions());
                    _driverWhoIs = 1;
                    _logger.AddToLogFile("Firing up Firefox!");
                    break;

                case "chrome":
                    WebDriver = new ChromeDriver(_driversPath, ChromeProfile());
                    _driverWhoIs = 2;
                    _logger.AddToLogFile("Firing up Chrome!");
                    break;

                default:
                    WebDriver = new ChromeDriver(_driversPath, ChromeProfile());
                    _driverWhoIs = 2;
                    _logger.AddToLogFile("Firing up Chrome!");
                    break;
            }

            //Wrap the driver in an event firing driver to enhance reporting and feedback.  Do basic window and driver config.
            FiringDriver = new EventFiringWebDriver(WebDriver);
            FiringDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(3);
            FiringDriver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
            //  FiringDriver.Manage().Window.Maximize();
            FiringDriver.Navigate().GoToUrl(_chosenAddress);

            //Initially log into the site to begin session.
            //_logIn.LogIntoSite(GetUserName(), GetPassword());
            Library.CustomWait(10);
            Library.RefreshPage();

            // FiringDriver.Navigate().GoToUrl(GetAddress()+ "Account/Login?ReturnUrl=%2F");

        }

        /// <summary>
        /// Returns the current instance of the WebDriver.
        /// </summary>
        /// <returns></returns>
        public static IWebDriver GetDriverInstance()
        {

            return FiringDriver;
        }

        /// <summary>
        /// Returns the web address the driver started with.
        /// </summary>
        /// <returns> Returns web address as a string.</returns>
        public static string GetAddress()
        {

            return _chosenAddress;
        }

        /// <summary>
        /// Returns the type of browser currently open by int.
        /// </summary>
        /// <returns>Returns browser as an int.</returns>
        public static int GetWhoIs()
        {

            return _driverWhoIs;
        }

        /// <summary>
        /// Gets the test data currently set in the Excel file.  Changes strings in SetupDriver accordingly.
        /// </summary>
        private void GetTestInput()
        {

            DateTime date = DateTime.Now;
            _passWord = Properties.Settings.Default.passWord;
            _logger.AddToLogFile("Logging into the " + _userName + " account.");
            _browserType = Properties.Settings.Default.browser;
            _logger.AddToLogFile("------------------------" + date + "-----------------------");

            switch (Properties.Settings.Default.enviroment)
            {



                case "stage":
                    _chosenAddress = Properties.Settings.Default.Stage_Url;
                    _userName = Properties.Settings.Default.StageUserName;
                    _logger.AddToLogFile("Using " + _chosenAddress + " for this session.");
                    break;



                default:
                    Console.WriteLine("The selection in properties-settings is not correct!  Check the string!");
                    break;
            }

        }

        /// <summary>
        /// Sets the firefox service and app settings before startup.
        /// </summary>
        /// <returns> Firefox Service</returns>
        private FirefoxDriverService FfService()
        {

            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(_driversPath);
            service.FirefoxBinaryPath = Properties.Settings.Default.FireFoxBinaryPath;
            return service;
        }

        /// <summary>
        /// Sets the firefox preferences before startup.
        /// </summary>
        /// <returns></returns>
        private static FirefoxOptions FfOptions()
        {

            //new Options object to return.
            FirefoxOptions myFfOptions = new FirefoxOptions();

            //Set all needed options for this driver instance involving downloading files.
            myFfOptions.SetPreference("browser.download.manager.showAlertOnComplete", false);
            myFfOptions.SetPreference("browser.download.manager.alertOnEXEOpen", false);
            myFfOptions.SetPreference("browser.download.manager.focusWhenStarting", false);
            myFfOptions.SetPreference("browser.download.manager.useWindow", false);
            myFfOptions.SetPreference("browser.download.manager.showWhenStarting", false);
            myFfOptions.SetPreference("browser.download.manager.closeWhenDone", false);
            myFfOptions.SetPreference("browser.download.animateNotifications", false);
            myFfOptions.SetPreference("browser.download.folderList", 2);
            myFfOptions.SetPreference("browser.helperApps.alwaysAsk.force", false);
            myFfOptions.SetPreference("browser.helperApps.neverAsk.openFile",
                "text/csv,application/x-msexcel,application/excel,application/x-excel,application/vnd.ms-excel,image/"
                + "png,image/jpeg,text/html,text/plain,application/msword,application/xml");
            myFfOptions.SetPreference("browser.helperApps.neverAsk.saveToDisk",
                "text/csv,application/x-msexcel,application/excel,application/x-excel,application/vnd.ms-excel,image/"
                + "png,image/jpeg,text/html,text/plain,application/msword,application/xml");

            return myFfOptions;
        }

        /// <summary>
        /// Create a custom Chrome profile to allow easy file downloading.
        /// </summary>
        /// <returns></returns>
        private static ChromeOptions ChromeProfile()
        {

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("disable-extensions");
            options.AddArgument("--incognito");
            options.AddArgument("--start-maximized");
            options.AddExcludedArgument("enable-automation");
            // options.AddAdditionalCapability("useAutomationExtension", true);
            options.AddUserProfilePreference("download.default_directory", @"C:\Downloads");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", "true");
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            options.AddUserProfilePreference("safebrowsing.enabled", "true");
            options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-gpu");

            options.PageLoadStrategy = PageLoadStrategy.Eager;
            options.AddUserProfilePreference("safebrowsing.enabled", true);
            options.AddUserProfilePreference("disable-popup-blocking", true);
            options.AddUserProfilePreference("chrome.switches", "--disable-extensions");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            return options;
        }


        /// <summary>
        /// Return the current account username collected from Excel.
        /// </summary>
        /// <returns></returns>
        public static string GetUserName()
        {

            return _userName;
        }


        /// <summary>
        /// Return the current account password collected from Excel.
        /// </summary>
        /// <returns></returns>
        public static string GetPassword()
        {

            return _passWord;
        }

        /// <summary>
        /// Close the web driver object and finish testing.
        /// </summary>
        [OneTimeTearDown]
        public void TearDown()
        {

            _logger.AddToLogFile("------------------------" + "End of Line" + "-----------------------");
            FiringDriver.Close();
            FiringDriver.Quit();
            //}

            //}
        }
    }
}


using NUnit.Framework;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading;
using Keys = OpenQA.Selenium.Keys;
using WebRegression.TestStructure;
using org.apache.pdfbox;
using System.Collections;
using System.Globalization;

namespace WebRegression.Utilities
{
    public static class Library
    {
        private static readonly string DirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static IWebDriver driver = SetUpDriver.GetDriverInstance();
        private static readonly LogTool Logger = new LogTool();
        //public static Boolean EnableSendingEmail = Properties.Settings.Default.SendEmail;
        private static readonly WebDriverWait _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        private static IWebElement FirstElement_inthelist => Library.FindByXPath("//label[@for='__uni_el_id__109']");


        public static void AcceptAlert()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                TestContext.Out.WriteLine("ALert detected" + "{" + alert.Text + "}");
            }
            catch (Exception e)
            {
                TestContext.Error.WriteLine("Error:" + e.ToString());

            }
        }


        public static void SwichToPopUp()
        {
            try
            {
                foreach (string handle in driver.WindowHandles)
                {
                    IWebDriver popup = driver.SwitchTo().Window(handle);
                    if (popup.Title.Contains(popup.Title))
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                TestContext.Error.WriteLine("Error:" + e.ToString());
                Assert.IsTrue(false);
            }
        }

        public static void VerifyPDFDownLoaded(string expectedFilePath, string fileName, string fileFullName)
        {

            // string expectedFilePath = @"C:\Downloads\Equipment+List.pdf";
            bool fileExists = false;

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until<bool>(x => fileExists = File.Exists(expectedFilePath));

                Console.WriteLine("File exists : " + fileExists);

                FileInfo fileInfo = new FileInfo(expectedFilePath);


                Console.WriteLine("File Name : " + fileInfo.Name);
                Console.WriteLine("File Full Name :" + fileInfo.FullName);

                Assert.AreEqual(fileInfo.Name, fileName);
                Assert.AreEqual(fileInfo.FullName, fileFullName);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (File.Exists(expectedFilePath))
                    File.Delete(expectedFilePath);

            }

        }


        public static void ScrollToWebElement(IWebElement elem)
        {
            try
            {
                IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", elem);
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", elem);
                Thread.Sleep(2000);
                TestContext.Out.WriteLine(e);
            }
        }

        public static void ScrollingPage(int x, int y)
        {
            try
            {
                IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                js.ExecuteScript("window.scrollBy(" + x + "," + y + ")");
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                js.ExecuteScript("window.scrollBy(" + x + "," + y + ")");
                Thread.Sleep(2000);
                TestContext.Out.WriteLine(e);
            }
        }


        public static void CaptureScreenshot(IWebDriver driver)
        {
            try
            {
                long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

                string imagePath = DirectoryPath + "//img_" + milliseconds + ".png";
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile(imagePath, ScreenshotImageFormat.Png);
                TestContext.Out.WriteLine("Screen shot is saved at :" + imagePath);
            }
            catch (Exception e)
            {
                TestContext.Error.WriteLine("Error:" + e.ToString());
                Assert.IsTrue(false);
            }
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        #region Find By

        public static IWebElement FindById(string id)
        {
            WaitForElementDisplayedById(id);
            return driver.FindElement(By.Id(id));
        }

        public static IWebElement FindByClassName(string className)
        {

            WaitForElementDisplayedByClassName(className);
            return driver.FindElement(By.ClassName(className));
        }


        public static IWebElement FindByLinkText(string linkText)
        {
            WaitForElementDisplayedByLinkText(linkText);
            return driver.FindElement(By.LinkText(linkText));
        }

        public static IWebElement FindByPartialLinkText(string partialLinkText)
        {
            WaitForElementDisplayedByPartialLinkText(partialLinkText);
            return driver.FindElement(By.PartialLinkText(partialLinkText));
        }

        public static IWebElement FindByXPath(string xpath)
        {
            WaitForElementDisplayedByXpath(xpath);
            return driver.FindElement(By.XPath(xpath));
        }

        public static IList<IWebElement> FindByListByXPath(string xpath)
        {
            WaitForElementDisplayedByXpath(xpath);
            return driver.FindElements(By.XPath(xpath));
        }

        public static IWebElement FindByName(string name)
        {
            WaitForElementDisplayedByName(name);
            return driver.FindElement(By.Name(name));
        }

        public static IWebElement FindByCssSelector(string cssSelector)
        {
            WaitForElementDisplayedByCssSelector(cssSelector);
            return driver.FindElement(By.CssSelector(cssSelector));
        }
        public static IWebElement FindElement(By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
        #endregion Find By

        #region HelperMethods

        public static void RefreshPage()
        {
            try
            {
                driver.Navigate().Refresh();
            }
            catch (Exception e)
            {

                TestContext.Error.WriteLine("Error:" + e.ToString());

            }
        }

        public static String getCurrentWindow()
        {
            try
            {
                return driver.CurrentWindowHandle;
            }
            catch (Exception e)
            {
                TestContext.Error.WriteLine("Error:" + e.ToString());
                Assert.IsTrue(false);
                return null;
            }
        }

        public static void SwitchToParentWindow(String window)
        {
            List<string> lstWindow = driver.WindowHandles.ToList();
            foreach (var handle in lstWindow)
            {
                Console.WriteLine("Switching to window - > " + handle);
                driver.SwitchTo().Window(handle);
            }

            //Switch to the parent window close the parent window
            driver.SwitchTo().Window(window);
            driver.Close();

            //Close the child window 
            // driver.Close();


            //at this point there is no focused window, we have to explicitly switch back to some window.
            driver.SwitchTo().Window(window);

        }
        public static void CloseParentWindow(string parentWindow)
        {

            List<string> lstWindow = driver.WindowHandles.ToList();
            String lastWindowHandle = "";
            foreach (var handle in lstWindow)
            {
                Console.WriteLine("Switching to window - > " + handle);

                //Switch to the desired window first and then execute commands using driver
                driver.SwitchTo().Window(handle);
                lastWindowHandle = handle;
            }
            driver.SwitchTo().Window(parentWindow);
            driver.Close();
            driver.SwitchTo().Window(lastWindowHandle);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("window.focus(); ");

        }
        public static void SelectDropDownBy(IWebElement elem, String terms, dynamic value)
        {
            try
            {
                if (terms is null)
                {
                    throw new ArgumentNullException(nameof(terms));
                }

                SelectElement s = new SelectElement(elem);
                switch (terms)
                {
                    case "text":
                        s.SelectByText(value);
                        break;

                    case "value":
                        s.SelectByValue(value);
                        break;

                    case "index":
                        s.SelectByIndex(value);
                        break;

                }
            }
            catch (Exception e)
            {
                TestContext.Error.WriteLine("Error:" + e.ToString());
                Assert.IsTrue(false);
            }


        }

        internal static void CloseParentWindow(object parentWindowHandle)
        {
            throw new NotImplementedException();
        }

        public static void SelectDynamicDropDown(IWebElement elem, string value, IWebElement elem2)
        {
            try
            {
                Actions action1 = new Actions(driver);
                action1.MoveToElement(elem).ClickAndHold().Build().Perform();
                CustomWait(3);

                Actions action2 = new Actions(driver);
                action2.SendKeys(value).Build().Perform();
                CustomWait(3);
                Actions action3 = new Actions(driver);
                elem2.Click();
                action3.SendKeys(Keys.Enter).Build().Perform();
                CustomWait(3);
            }
            catch (Exception e)
            {
                TestContext.Error.WriteLine("Error:" + e.ToString());
                Assert.IsTrue(false);
            }
        }

        public static IWebElement MultipleElementWithSameLocator(IList<IWebElement> elems, int index)
        {
            try
            {

                TestContext.Out.WriteLine("the numbers of elements are :" + elems.Count);
                return elems[index];
            }
            catch (Exception e)
            {
                TestContext.Error.WriteLine("Test Failed:" + e.ToString());
                return null;
            }
        }

        public static void enterText(IWebElement element, String text)
        {
            try
            {
                element.Clear();
                element.SendKeys(text);
            }
            catch (Exception e)
            {
                TestContext.Error.WriteLine("Error:" + e.ToString());
                Assert.IsTrue(false);
            }
        }


        // * This is a fluent wait,waits dynamically for WebElement and polls the source html

        public static IWebElement fluentWait(By by)
        {
            IWebElement targetElem = null;
            try
            {
                DefaultWait<IWebElement> defaultWait = new DefaultWait<IWebElement>(targetElem);
                DefaultWait<IWebElement> wait = defaultWait;
                wait.Timeout = TimeSpan.FromMinutes(2);
                wait.PollingInterval = TimeSpan.FromMilliseconds(250);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                targetElem = wait.Until(x => x.FindElement(by));
            }
            catch (Exception e)
            {
                TestContext.Error.WriteLine("Error:" + e.ToString());
                Assert.IsTrue(false);
            }
            return targetElem;
        }

        //This method moves mouse to the given element by the locator


        public static IWebElement moveMouseToElement(By by)
        {
            IWebElement element = null;
            try
            {
                element = driver.FindElement(by);
                Actions action = new Actions(driver);
                action.MoveToElement(element).Build().Perform();
            }
            catch (Exception e)
            {
                TestContext.Error.WriteLine("Error:" + e.ToString());
                Assert.IsTrue(false);
            }
            return element;
        }


        //This method moves mouse to given WebElement
        public static void moveMouseToElement(IWebElement element)
        {
            try
            {
                Actions action = new Actions(driver);
                action.MoveToElement(element).Build().Perform();
            }
            catch (Exception e)
            {
                TestContext.Error.WriteLine("Error:" + e.ToString());
                Assert.IsTrue(false);
            }
        }


        public static void clickBtn(By by)
        {
            try
            {
                IWebElement elem = driver.FindElement(by);
                elem.Click();
            }
            catch (Exception e)
            {
                TestContext.Error.WriteLine("Error:" + e.ToString());
                Assert.IsTrue(false);
            }
        }
        #endregion 

        #region Javascript Methods

        public static void jsHoverByClassName(string className)
        {
            string javaScript = "var evObj = document.createEvent('MouseEvents');" +
                    "evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);" +
                    "arguments[0].dispatchEvent(evObj);";

            IWebElement element = FindByClassName(className);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(javaScript, element);
        }

        public static void jsClickById(string id)
        {
            IWebElement element = driver.FindElement(By.Id(id));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", element);
        }

        public static void jsClickByPartiaLinkText(string partialLinkText)
        {
            IWebElement element = driver.FindElement(By.PartialLinkText(partialLinkText));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", element);
        }

        public static void jsClick(IWebElement elem)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", elem);
        }

        public static void SendKeysByJs(string value, IWebElement inputFiled)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('value', '" + value + "')", inputFiled);
        }

        #endregion Javascript Methods

        #region Waits
        // This is a custom hard coded wait using Thread.sleep()

        public static void CustomWait(int Seconds)
        {
            try
            {
                Thread.Sleep(Seconds * 1000);
            }
            catch (Exception e)
            {
                _ = e.StackTrace;
            }

        }


        //wait for elemeny displayes by the element 
        public static void WaitForElementDisplayed(IWebElement elem)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = elem;
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public static void WaitForJQueryToLoad()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).
                ExecuteScript("return !!window.jQuery && window.jQuery.active == 0"));
        }



        public static void WaitForElementDisplayedById(string id)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(By.Id(id));
                    return elementToBeDisplayed.Displayed;
                }
                catch (ElementNotInteractableException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public static void WaitForElementDisplayedByPartialLinkText(string partialLinkText)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(By.PartialLinkText(partialLinkText));
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public static void WaitForElementDisplayedByCssSelector(string cssSelector)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(By.CssSelector(cssSelector));
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public static void WaitForElementDisplayedByLinkText(string linkText)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(By.LinkText(linkText));
                    return elementToBeDisplayed.Displayed;
                }
                catch (TimeoutException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public static void WaitForElementDisplayedByClassName(string className)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(By.ClassName(className));
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public static void WaitForElementDisplayedByXpath(string xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(By.XPath(xpath));
                    return elementToBeDisplayed.Enabled;
                }
                catch (TimeoutException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            });
        }

        public static Boolean IsElementPresent(By locatorKey)
        {
            try
            {
                driver.FindElement(locatorKey);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void WaitForElementDisplayedByName(string name)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(By.Name(name));
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public static void WaitForLoadingBar(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(by);
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public static IWebElement WaitForElementVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            return element;

        }


        public static bool IsElementVisible(By locator)
        {
            bool returnValue;
            try
            {

                returnValue = WaitForElementVisible(locator).Displayed;

            }
            catch (NoSuchElementException e)
            {
                TestContext.Out.WriteLine(e);
                returnValue = false;
            }
            catch (Exception e)
            {
                TestContext.Out.WriteLine(e);
                returnValue = false;
            }
            return returnValue;
        }


        public static double NextRandomRange(double minimum, double maximum)
        {
            Random rand = new Random();
            return rand.NextDouble() * (maximum - minimum) + minimum;
        }

        public static void WaitForPageLoadCompletely()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            for (int i = 0; i < 30; i++)
            {
                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    TestContext.Out.WriteLine(e);
                }
                if (js.ExecuteScript("return document.readyState").ToString().Equals("complete"))
                {
                    TestContext.Out.WriteLine("Page loaded completely");
                    break;
                }
                else
                {
                    TestContext.Out.WriteLine("waiting for the page to load");
                }
            }
        }

        /// <summary>
        /// Halt the test for 15 seconds to manually observe functionality.
        /// </summary>
        public static void TestHalt()
        {
            try
            {
                Thread.Sleep(15000);
            }
            catch (ThreadInterruptedException e)
            {
                Logger.CreateErrorFile(e.ToString());
            }
        }

        #endregion Wait


        /// <summary>
        /// Handle a new tab
        /// </summary>
        /// <param name="driver"></param>
        public static void GoToNewTab(IWebDriver driver)
        {

            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        /// <summary>
        /// Close the first tab if it has no use.
        /// </summary>
        /// <param name="driver"></param>
        public static void KillFirstTab(IWebDriver driver)
        {

            driver.SwitchTo().Window(driver.WindowHandles.First()).Close();
        }

        /// <summary>
        /// Switch to new window
        /// </summary>
        /// <param name="driver"></param>
        public static void SwitchLastWindow(IWebDriver driver)
        {

            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        /// <summary>
        /// Switch to new window
        /// </summary>
        /// <param name="driver"></param>
        public static void CloseLastWindow(IWebDriver driver)
        {

            driver.SwitchTo().Window(driver.WindowHandles.Last()).Close();
        }

        //public static void Send_Report_In_Mail(String subject, String EmailAddressToSend)
        //{
        //    if (EnableSendingEmail == true)
        //    {
        //        MailMessage mail = new MailMessage();
        //        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        //        mail.From = new MailAddress("rebiyaminoie@gmail.com");
        //        mail.To.Add(EmailAddressToSend);
        //        //rminoie@fieldedge.com,arai@fieldedge.com,decheverria@fieldedge.com

        //        StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
        //        TimeAndDate.Replace("/", "_");
        //        TimeAndDate.Replace(":", "_");

        //        mail.Subject = subject + "_" + TimeAndDate;

        //        mail.Body = "Please find the attached Pass/Failed Test report to get details.";

        //        string actualPath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin", "\\TestExecutionReports");

        //        var mostRecentlyModified = Directory.GetFiles(actualPath, "*.html")
        //        .Select(f => new FileInfo(f))
        //        .OrderByDescending(fi => fi.LastWriteTime)
        //        .First()
        //        .FullName;

        //        Attachment attachment;
        //        attachment = new Attachment(mostRecentlyModified);
        //        mail.Attachments.Add(attachment);

        //        SmtpServer.Port = 587;
        //        SmtpServer.Credentials = new System.Net.NetworkCredential("qa.testing.rabia@gmail.com", "Qa2393008673!");
        //        SmtpServer.EnableSsl = true;

        //        SmtpServer.Send(mail);
        //    }
        //    else
        //    {
        //        //do nothing 
        //    }
        //}
        public static string CurrentDate()
        {

            return DateTime.Now.ToString("MM/dd/yyyy");
        }

        public static string CurrentTime()
        {

            return DateTime.Now.ToString("hh:mm");
        }


        public static string CurrentDate_Canadian()
        {

            return DateTime.Now.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Creates a string in yyyMMddhh format for the current day.
        /// </summary>
        public static string CurrentDateFileNameShort()
        {

            return DateTime.Now.ToString("yyyyMMddhh");
        }

        /// <summary>
        /// Creates a string in MM/dd/yyyy format for tomorrow.
        /// </summary>
        public static string TomorrowDate()
        {

            return DateTime.Today.AddDays(1).ToString("MM/dd/yyyy");
        }

        public static string TodayDate()
        {

            return DateTime.Today.ToString("MM/dd/yyyy");
        }

        /// <summary>
        /// Creates a string in MM/dd/yyyy format for yesterday
        /// </summary>
        public static string YesterdayDate()
        {

            return DateTime.Today.AddDays(-1).ToString("MM/dd/yyyy");
        }

        /// <summary>
        /// Creates a string in MM/dd/yyyy format for the the first day of this year.
        /// </summary>
        public static string BeginYearDate()
        {

            //Set a date object for the begining of this year.
            DateTime dt = new DateTime(2018, 1, 1);

            //Return date
            return dt.ToString("MM/dd/yyyy");
        }

        public static string LastYearToday()
        {

            return DateTime.Now.AddYears(-1).ToString("MM/dd/yyyy");
        }

        public static string LastDayThisYear()
        {

            var lastDay = new DateTime(DateTime.Now.Year, 12, 31);
            return lastDay.ToString("MM/dd/yyyy");
        }

        public static DateTime Next(this DateTime from, DayOfWeek dayOfWeek)
        {
            int start = (int)from.DayOfWeek;
            int target = (int)dayOfWeek;
            if (target <= start)
                target += 7;
            return from.AddDays(target - start);
        }

        //this is a function that will grab text from the clipboard
        public static string GetTextFromClipboard()
        {
            string output = string.Empty;
            System.Windows.Forms.IDataObject idat = null;
            Exception threadEx = null;
            Thread staThread = new Thread(
                delegate ()
                {
                    try
                    {
                        idat = Clipboard.GetDataObject();
                        output = idat.GetData(DataFormats.Text).ToString();

                    }
                    catch (Exception ex)
                    {
                        threadEx = ex;
                    }
                });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();
            return output;
        }

        public static string Capture(IWebDriver driver, string ScreenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot ss = ts.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string uptobinpath = path.Substring(0, path.LastIndexOf("bin")) + "ScreenShots\\" + ScreenShotName + ".png";
            string localPath = new Uri(uptobinpath).LocalPath;
            ss.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            return localPath;
        }

        public static void Verify_PDF_File_Downloaded(string rootPath, string reportName)
        {
            string expectedFilePath = rootPath + reportName + ".pdf";
            bool fileExists = false;

            try
            {
                _wait.Until<bool>(x => fileExists = File.Exists(expectedFilePath));

                Console.WriteLine("File exists : " + fileExists);
                FileInfo fileInfo = new FileInfo(expectedFilePath);

                Console.WriteLine("File Name : " + fileInfo.Name);
                Console.WriteLine("File Full Name :" + fileInfo.FullName);

                Assert.AreEqual(fileInfo.Name, reportName + ".pdf");
                Assert.AreEqual(fileInfo.FullName, expectedFilePath);


            }
            catch (Exception e)
            {
                TestContext.Error.WriteLine("Test Failed:" + e.ToString());

            }
            finally
            {
                if (File.Exists(expectedFilePath))

                    File.Delete(expectedFilePath);

            }

        }
        /// <summary>
        /// This method checks weather the dropdown options are sorted in alphbatic order
        /// </summary>
        /// <param name="elems"></param>
        /// <returns></returns>
        public static bool IsDropDownSorted(IList<IWebElement> elems)
        {
            ArrayList originalList = new ArrayList();
            ArrayList tempList = new ArrayList();

            foreach (IWebElement e in elems)
            {
                originalList.Add(e.Text);
                tempList.Add(e.Text);
            }

            Console.WriteLine("this is originalList before Sorting" + originalList);
            Console.WriteLine("this is tempList before Sorting" + tempList);

            tempList.Sort();

            if (originalList == tempList)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// helper method
        /// </summary>
        /// <param name="dateValue"></param>
        /// <returns></returns>
        public static bool DateFormatValidation(string dateValue, string dateFormats)
        {
            DateTime tempDate;
            bool validDate = DateTime.TryParseExact(dateValue, dateFormats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out tempDate);
            if (validDate)
                return true;
            else
                return false;
        }

        /// <summary>
        /// add attachment using IJavaScriptExecutor
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="attachmentFilePath"></param>    

        public static void AddAttachmentUsingJS(IWebElement elem, string attachmentFilePath)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                // Setting value for "style" attribute to make textbox visible
                js.ExecuteScript("arguments[0].style.display='block';", elem);
                //elem.SendKeys(attachmentFilePath);
                js.ExecuteScript("arguments[0].value ='" + attachmentFilePath + "'", elem);
            }
            catch (Exception e)
            {
                TestContext.Error.WriteLine("Error:" + e.ToString());
                Assert.IsTrue(false);
            }
        }

        public static void DragAndDrop(IWebElement source, IWebElement target)
        {
            Actions act1 = new Actions(driver);
            act1.ClickAndHold(source).Build().Perform();
            Actions act2 = new Actions(driver);
            act2.DragAndDropToOffset(source, 0, -200).Build().Perform();



        }

        //internal static void IsElementVisible(IWebElement paymentDateDisabled)
        //{
        //    throw new NotImplementedException();
        //}

        //public static void CheckOptionSelected(IWebElement elem)
        //{
        //    bool CheckSelected = elem.Selected;
        //    Console.WriteLine(CheckSelected);

        //}


    }
    }

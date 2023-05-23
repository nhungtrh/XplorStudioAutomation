using NUnit.Framework;
using System.IO;

namespace WebRegression.Utilities
{
    /// <summary>
    /// This class handles logging and saving to a file
    /// </summary>
    class LogTool
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public LogTool()
        {

        }

        /// <summary>
        /// Collect error string from a source.  Will be put into a folder on the C: drive.
        /// </summary>
        /// <param name="errorMessage"></param>
        public void CreateErrorFile(string errorMessage)
        {

            var errorFileString = Properties.Settings.Default.ErrorFileName;
            var errorFileDirectory = Properties.Settings.Default.ErrorFileDir;
            var fullFilePath = errorFileDirectory + errorFileString;

            try
            {

                if (!Directory.Exists(errorFileDirectory))
                {

                    Directory.CreateDirectory(errorFileDirectory);
                }

                using (StreamWriter sw = new StreamWriter(fullFilePath, true))
                {

                    sw.WriteLine("------------------------");
                    sw.WriteLine(errorMessage);
                    sw.Flush();
                    sw.Close();

                    TestContext.WriteLine(errorMessage);
                }
            }
            catch (IOException e)
            {

                TestContext.WriteLine("There was a problem trying to write to the error file.  Check the " + errorFileDirectory + " Directory!");
                throw;
            }
        }

        /// <summary>
        /// Collect useful messages to a file.  Will be put into a folder on the C: drive.
        /// </summary>
        /// <param name="logMsg"></param>
        public void AddToLogFile(string logMsg)
        {

            //path to file to open
            var logFileFileString = Properties.Settings.Default.LogFileName;
            var logFileDirectory = Properties.Settings.Default.LogFileDir;
            var fullFilePath = logFileDirectory + logFileFileString;

            //log the message to the console
            TestContext.WriteLine(logMsg);

            //save the message to a file
            try
            {
                if (!Directory.Exists(logFileDirectory))
                {

                    Directory.CreateDirectory(logFileDirectory);
                }

                using (StreamWriter sw = new StreamWriter(fullFilePath, true))
                {

                    sw.WriteLine(logMsg);
                    sw.Flush();
                    sw.Close();
                }
                TestContext.WriteLine(logMsg);
            }
            catch (IOException e)
            {

                TestContext.WriteLine("There was a problem trying to write to the log file.  Check the " + logFileDirectory + " Directory!");
                throw;
            }
        }
    }
}
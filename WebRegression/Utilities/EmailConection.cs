using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Search;
using MailKit.Security;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace WebRegression.Utilities
{
    public class EmailConection
    {
        private string emailAddress = "fieldedge.qa@gmail.com";
        private string emailPassword = "Test2393008673$";
        private string imapHost = "imap.gmail.com";
        private int imapPort = 993;
        private string smtpHost = "smtp.gmail.com";
        private int smtpPort = 465;

        /// <summary>
        ///  IMAP client for reading emails.
        /// </summary>
        /// <returns></returns>
        private ImapClient ImapClientConnection()
        {
            var client = new ImapClient(new ProtocolLogger("imap.log"));
            client.Connect(imapHost, imapPort, SecureSocketOptions.SslOnConnect);
            client.Authenticate(emailAddress, emailPassword);
            return client;
        }

        /// <summary>
        /// SMTP client for sending emails
        /// </summary>
        /// <returns></returns>
        private SmtpClient SmtpClientConnection()
        {
            var client = new SmtpClient(new ProtocolLogger("smtp.log"));
            client.Connect(smtpHost, smtpPort, SecureSocketOptions.SslOnConnect);
            client.Authenticate(emailAddress, emailPassword);
            return client;
        }

        /// <summary>
        /// to connect to the client, open the Inbox folder, then use MailKit’s built-in search methods to query all emails within the Inbox folder. While iterating through all of the messages, 
        /// we can do a string comparison on the subject, or any other part of the Mime Message, then set that message’s body to a variable to be returned.
        /// </summary>
        /// <param name="subjectToSearch"></param>
        /// <returns></returns>
        public string GetMessageBody(string subjectToSearch)
        {
            string body = string.Empty;
            using (var client = ImapClientConnection())
            {
                client.Inbox.Open(FolderAccess.ReadOnly);
                var uids = client.Inbox.Search(SearchQuery.All);

                foreach (var uid in uids)
                {
                    var message = client.Inbox.GetMessage(uid);
                    if (message.Subject == (subjectToSearch))
                    {
                        body = message.Body.ToString();
                    }
                }
                client.Disconnect(true);
            }
            return body;
        }


    }
}
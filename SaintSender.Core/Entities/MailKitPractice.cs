using MailKit.Net.Pop3;
using MailKit;
using MimeKit;
using System.Collections.Generic;

namespace SaintSender.Core.Entities
{
    public class MailKitPractice
    {
        private readonly string mailServer, login, password;
        private readonly int port;
        private readonly bool ssl;



        public MailKitPractice(string mailServer, int port, bool ssl, string login, string password)
        {
            this.mailServer = mailServer;
            this.port = port;
            this.ssl = ssl;
            this.login = login;
            this.password = password;
        }




        public IEnumerable<string> GetAllMails()
        {
            var mails = new List<string>();
            using (var client = new Pop3Client())
            {
                client.Connect("pop.gmail.com", 993, true);
                client.Authenticate(login, password);
                for (int i = 0; i < 10; i++)
                {
                   mails.Add(client.GetMessage(i).ToString());
                }
                client.Disconnect(true);
            }
            return mails;
        }
    }



            /* public async void GetAllMails()
             {
                 var messages = new List<string>();

                 using (var client = new ImapClient())
                 {
                     client.Connect(mailServer, port, SecureSocketOptions.SslOnConnect);
                     client.AuthenticationMechanisms.Remove("XOAUTH2");
                     client.Authenticate(login, password);

                     // Note: since we don't have an OAuth2 token, disable
                     // the XOAUTH2 authentication mechanism.

                     // client.Authenticate(login, password);

                     // The Inbox folder is always available on all IMAP servers...

                     var inbox = client.Inbox;
                     inbox.Open(FolderAccess.ReadOnly);
                     var results = inbox.Search(SearchOptions.All, SearchQuery.NotSeen);
                     foreach (var uniqueId in results.UniqueIds)
                     {
                         var message = inbox.GetMessage(uniqueId);

                         messages.Add(message.HtmlBody);

                         //Mark message as read
                         //inbox.AddFlags(uniqueId, MessageFlags.Seen, true);
                     }

                     client.Disconnect(true);
                 }

                 //return messages;
             }
             */
        }

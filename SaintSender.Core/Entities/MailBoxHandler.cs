﻿using System;
using System.Collections.Generic;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using MailKit.Search;
using MimeKit;
using MailKit.Net.Smtp;

namespace SaintSender.Core.Entities
{
    public class MailBoxHandler
    {
        private string _address;
        private string _password;

        public MailBoxHandler(string address, string password)
        {
            _address = address;
            _password = password;
        }

        public MailBoxHandler()
        {

        }

        public List<MimeMessage> DownloadMessages()
        {
            List<MimeMessage> messages = new List<MimeMessage>();

            using (var client = new ImapClient())
            {
                client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);

                client.Authenticate(_address, _password);

                client.Inbox.Open(FolderAccess.ReadOnly);

                var uids = client.Inbox.Search(SearchQuery.All);

                foreach (var uid in uids)
                {
                    //var letter = System.Text.RegularExpressions.Regex.Replace(message.HtmlBody, "<[^>]*>", "");

                    messages.Add(client.Inbox.GetMessage(uid));
                }
                client.Disconnect(true);
                return messages;
            }
        }

        public void SetNewCredentials(string address, string password)
        {
            _address = address;
            _password = password;
        }
        
        //Refactor to store data in a dictionary instead of a long param list.
        public void SendEmail(string senderName,
                              string senderEmail,
                              string recipient,
                              string recipientEmail,
                              string subject,
                              string bodyText,
                              string userName,
                              string password)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(senderName, senderEmail));
            message.To.Add(new MailboxAddress(recipient, recipientEmail));
            message.Subject = subject;

            var builder = new BodyBuilder();

            builder.TextBody = bodyText;

            message.Body = builder.ToMessageBody();

            try
            {
                var client = new SmtpClient();

                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(userName, password);
                client.Send(message);
                client.Disconnect(true);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Email sending failed! Reason: {e.Message}");
                Console.ReadLine();
            }
        }
    }
}
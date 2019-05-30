using System;
using SaintSender.Core.Entities;
using System.Collections.ObjectModel;
using MimeKit;

namespace SaintSender.DesktopUI.ViewModels
{
    public class MainViewModel
    {
        public MailBoxHandler mailBoxHandler;
        public MainViewModel()
        {
            mailBoxHandler = new MailBoxHandler();
        }

        public void SendEmail(
                              string recipientEmail,
                              string subject,
                              string bodyText
                              )
        {
            mailBoxHandler.SendEmail(recipientEmail, subject, bodyText);
        }

        public bool IsEmailValid(string emailaddress)
        {
            return mailBoxHandler.ValidateEmail(emailaddress);
        }

        public ObservableCollection<MimeMessage> GetUserEmails()
        {
            try
            {
                return mailBoxHandler.DownloadMessages();
            }
            catch (MailKit.Security.AuthenticationException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public void SetNewUser(string email, string password)
        {
            mailBoxHandler.SetNewCredentials(email, password);
        }
    }
}

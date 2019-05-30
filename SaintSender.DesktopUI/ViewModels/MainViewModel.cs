using SaintSender.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MimeKit;

namespace SaintSender.DesktopUI.ViewModels
{
    public class MainViewModel
    {
        public MailBoxHandler mailBoxHandler;
        public ObservableCollection<MimeMessage> emails;

        public MainViewModel()
        {
            mailBoxHandler = new MailBoxHandler();
            mailBoxHandler.SetNewCredentials("csharpservererror@gmail.com", "s3rv3r3rr0r");
        }

        public void SendEmail(
                              string recipientEmail,
                              string subject,
                              string bodyText
                              )
        {
            mailBoxHandler.SendEmail(recipientEmail, subject, bodyText);
        }

        public ObservableCollection<MimeMessage> GetUserEmails()
        {
            return mailBoxHandler.DownloadMessages();
        }

    }
}

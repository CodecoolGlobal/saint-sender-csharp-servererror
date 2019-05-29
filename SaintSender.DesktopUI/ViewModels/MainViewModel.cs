using SaintSender.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.DesktopUI.ViewModels
{
    class MainViewModel
    {
        public MailBoxHandler mailBoxHandler;

        public MainViewModel()
        {
            mailBoxHandler = new MailBoxHandler();
            mailBoxHandler.SetNewCredentials("codekingzotya1993@gmail.com", "ServerError2019");
        }

        public void SendEmail(string senderName,
                              string senderEmail,
                              string recipient,
                              string recipientEmail,
                              string subject,
                              string bodyText,
                              string userName,
                              string password)
        {
            mailBoxHandler.SendEmail(senderName, senderEmail, recipient, recipientEmail, subject, bodyText, userName, password);
        }
    }
}

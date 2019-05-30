using SaintSender.Core.Entities;
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

        public void SetNewUser(string email, string password)
        {
            mailBoxHandler.SetNewCredentials(email, password);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MimeKit;

namespace SaintSender.DesktopUI.Views.MailModal
{
    /// <summary>
    /// Interaction logic for MailCheck.xaml
    /// </summary>
    public partial class MailCheck : Window
    {
        public MailCheck()
        {
            InitializeComponent();
        }

        public MailCheck(MimeMessage mail)
        {
            InitializeComponent();
            SenderBox.Text = mail.From.ToString();
            SubjectBox.Text = mail.Subject;
            BodyText.Text = mail.GetTextBody(MimeKit.Text.TextFormat.Plain);
        }
    }
}

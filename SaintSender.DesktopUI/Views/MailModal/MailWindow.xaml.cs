using SaintSender.DesktopUI.ViewModels;
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

namespace SaintSender.DesktopUI.Views.MailModal
{
    /// <summary>
    /// Interaction logic for MailWindow.xaml
    /// </summary>
    public partial class MailWindow : Window
    {
        private MainViewModel _mVM;

        public MailWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _mVM = mainViewModel;
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            string senderEmail = ToField.Text;
            string subject = SubjectBox.Text;
            string text = BodyBox.Text;
            _mVM.SendEmail(senderEmail, subject, text);
        }
    }
}

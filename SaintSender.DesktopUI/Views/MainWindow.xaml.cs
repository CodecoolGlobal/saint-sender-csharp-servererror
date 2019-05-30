using System.Windows;
using SDKSample;
using SaintSender.DesktopUI.Views.MailModal;
using SaintSender.DesktopUI.ViewModels;
using System.Collections.ObjectModel;
using MimeKit;
using System;
using SaintSender.DesktopUI.Views.WarningPopup;

namespace SaintSender.DesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _mVM = new MainViewModel();
        public ObservableCollection<MimeMessage> emails;

        public MainWindow()
        {
            InitializeComponent();
            var dialog = new DialogBox(_mVM);
            dialog.ShowDialog();
            emails = _mVM.GetUserEmails();
            //while (emails == null)
            //{
            //    var errorMessage = new InvalidEmailOrPassword();
            //    errorMessage.ShowDialog();

            //    var optionsPopUp = new DialogBox(_mVM);
            //    optionsPopUp.ShowDialog();
            //    emails = _mVM.GetUserEmails();
            //}
        }

        private void OptionBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new DialogBox(_mVM);
            dialog.ShowDialog();
        }

        private void ComposeBtn_Click(object sender, RoutedEventArgs e)
        {
            var mailWindow = new MailWindow(_mVM);
            mailWindow.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mailCheckWindow = new MailCheck();
            mailCheckWindow.ShowDialog();
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            emails = _mVM.GetUserEmails();
        }
    }
}

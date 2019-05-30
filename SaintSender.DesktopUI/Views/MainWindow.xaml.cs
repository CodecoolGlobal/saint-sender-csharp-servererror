using MimeKit;
using SaintSender.DesktopUI.ViewModels;
using SaintSender.DesktopUI.Views.MailModal;
using SDKSample;
using System.Collections.ObjectModel;
using System;
using System.Windows;
using System.Windows.Controls;

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
            InboxElements.DataContext = emails;
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

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            emails = _mVM.GetUserEmails();
            InboxElements.DataContext = emails;
        }


        private void InboxElements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                MimeMessage email;
                email = (MimeMessage)InboxElements.SelectedItem;
                var mailCheckWindow = new MailCheck(email);
                mailCheckWindow.ShowDialog();
            }
            catch (NullReferenceException c)
            {
                Console.WriteLine(c);
            }
        }
    }
}

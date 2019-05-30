using System.Windows;
using SDKSample;
using SaintSender.DesktopUI.Views.MailModal;
using SaintSender.DesktopUI.ViewModels;
using System.Collections.ObjectModel;
using MimeKit;

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
        }

        private void OptionBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new DialogBox(_mVM);
            if (dialog.ShowDialog() == true)
            {
                
            }
        }

        private void ComposeBtn_Click(object sender, RoutedEventArgs e)
        {
            var mailWindow = new MailWindow(_mVM);
            if (mailWindow.ShowDialog() == true)
            {
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mailCheckWindow = new MailCheck();
            if (mailCheckWindow.ShowDialog()==true)
            {
                
            }

        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            emails = _mVM.GetUserEmails();
        }
    }
}

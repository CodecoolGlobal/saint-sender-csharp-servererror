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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SaintSender.Core.Services;
using SDKSample;
using SaintSender.DesktopUI.Views.MailModal;
using SaintSender.DesktopUI.ViewModels;

namespace SaintSender.DesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _mVM = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OptionBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new DialogBox();
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
    }
}

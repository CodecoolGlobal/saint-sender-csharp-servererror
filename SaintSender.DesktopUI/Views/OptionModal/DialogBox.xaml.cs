using SaintSender.DesktopUI.ViewModels;
using SaintSender.DesktopUI.Views.WarningPopup;
using System.Windows;

namespace SDKSample
{
    /// <summary>
    /// Dialog box
    /// </summary>
    public partial class DialogBox : Window
    {

        private MainViewModel _mvm;

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogBox"/> class.
        /// Dialog box
        /// </summary>
        public DialogBox(MainViewModel mvm)
        {
            InitializeComponent();
            _mvm = mvm;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            string emailAddress = emailBox.Text;
            string password = passwordBox.Password;
            _mvm.SetNewUser(emailAddress, password);
            if (_mvm.IsEmailValid(emailAddress) && _mvm.GetUserEmails() != null)
            {   
                Close();
            }
            else
            {
                InvalidEmailOrPassword errorPopup = new InvalidEmailOrPassword();
                errorPopup.Show();
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
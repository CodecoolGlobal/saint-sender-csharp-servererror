using SaintSender.DesktopUI.ViewModels;
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
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
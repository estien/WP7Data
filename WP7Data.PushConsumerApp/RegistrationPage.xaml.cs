using Microsoft.Phone.Controls;
using WP7Data.Push.ConsumerApp.ViewModel;

namespace WP7Data.Push.ConsumerApp
{
    public partial class RegistrationPage : PhoneApplicationPage
    {
        public RegistrationViewModel ViewModel { get { return (RegistrationViewModel)DataContext; } }

        // Constructor
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewModel.CreateSubscriptionInfo();
            NavigationService.GoBack();
        }
    }
}

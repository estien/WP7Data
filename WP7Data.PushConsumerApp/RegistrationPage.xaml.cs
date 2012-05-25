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

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.CreateSubscriptionInfo();
        }
    }
}

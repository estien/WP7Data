using System;
using Microsoft.Phone.Controls;
using WP7Data.Push.ConsumerApp.ViewModel;

namespace WP7Data.Push.ConsumerApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainViewModel ViewModel { get { return (MainViewModel) DataContext; } }

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void DeleteSubscriptionButton_Clicked(object sender, EventArgs e)
        {
            ViewModel.DeleteCurrentSubscriptionInfo();
            NavigationService.Navigate(new Uri("/RegistrationPage.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.Act();
        }
    }
}

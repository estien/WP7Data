using System;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;

namespace WP7Data.Push.ConsumerApp.ViewModel
{
    public class WP7DataViewModelBase : ViewModelBase
    {
        public string ApplicationTitle {
            get { return "WP7Data CONSUMER"; }
        }

        protected void SendNavigationRequestMessage(Uri uri)
        {
            Messenger.Default.Send<Uri>(uri, "NavigationRequest");
        }

        public void Navigate(string uri)
        {
            var root = Application.Current.RootVisual as PhoneApplicationFrame;
            root.Navigate(new Uri(uri, UriKind.Relative));
        }
    }
}

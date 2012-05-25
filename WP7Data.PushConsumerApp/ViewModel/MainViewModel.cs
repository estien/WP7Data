using System.Windows.Navigation;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Info;
using Microsoft.Phone.Notification;
using WP7Data.Push.ConsumerApp.Model;
using WP7Data.Push.ConsumerApp.Persistance;
using WP7Data.Push.ConsumerApp.PushService;


namespace WP7Data.Push.ConsumerApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : WP7DataViewModelBase
    {

        #region Members

        public string PageName
        {
            get { return "Wait for a msg"; }
        }

        private string _subscriptionStatus;
        public string SubscriptionStatus { get { return _subscriptionStatus; }
            set
            {
                if(_subscriptionStatus != value)
                {
                    _subscriptionStatus = value;
                    RaisePropertyChanged("SubscriptionStatus");
                }
            } 
        }

        private HttpNotificationChannel _pushChannel;
        private readonly PushRegistrationClient _serviceClient;
        private readonly ISHelper _storageHelper;
        private SubscriptionInfo _subscriptionInfo;
        private readonly Dispatcher _dispatcher;

        #endregion




        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            _storageHelper = new ISHelper();
            _dispatcher = Deployment.Current.Dispatcher;
            _serviceClient = new PushRegistrationClient();
        }

        public void Act()
        {
            SetSubscriptionInfo();
            if (_subscriptionInfo != null)
            {
                InitPushChannel();
            }
        }

        // Load or create the subscription that will is current for the device and application installation to the MS push service and our web service
        private void SetSubscriptionInfo()
        {
            if (_storageHelper.SubscriptionInfoExists())
                _subscriptionInfo = _storageHelper.GetSubscriptionInfo();
            else
            {
                NavigateToRegistrationPage();
            }
        }

        private void InitPushChannel()
        {
            _pushChannel = HttpNotificationChannel.Find("channel");
            if (_pushChannel == null)
            {
                _pushChannel = new HttpNotificationChannel("channel");
                BindChannelEvents();
                _pushChannel.Open();
            }
            else
                BindChannelEvents();
        }

        private void BindChannelEvents()
        {
            //if error, print onscreen
            _pushChannel.ErrorOccurred += myPushChannel_ErrorOccurred;

            //ChannelUriUpdated fires when channel is first created or the channel URI changes 
            _pushChannel.ChannelUriUpdated += myPushChannel_ChannelUriUpdated;

            //Handle raw push notifications, which are received only while app is running.
            _pushChannel.HttpNotificationReceived += myPushChannel_HttpNotificationReceived;
        }


        private void serviceClient_SubscribePhoneCompleted(object sender, SubscribePhoneCompletedEventArgs subscribePhoneCompletedEventArgs)
        {
            int position = subscribePhoneCompletedEventArgs.Result;
            _dispatcher.BeginInvoke(() => MessageBox.Show("Thank you sir.  You subscribed as number " + position));
        }

        private void myPushChannel_HttpNotificationReceived(object sender, HttpNotificationEventArgs e)
        {
            _dispatcher.BeginInvoke(() => MessageBox.Show("Hello sir, you received: " + e.Notification.Body));
        }

        //ChannelUriUpdated fires when channel is first created or the channel URI changes 
        private void myPushChannel_ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e)
        {
            _subscriptionInfo.ChannelURI = e.ChannelUri.ToString();
            _storageHelper.SaveSubscriptionInfo(_subscriptionInfo);

            CheckIfPhoneIsRegisteredWithWS();
        }

        private void CheckIfPhoneIsRegisteredWithWS()
        {
            _serviceClient.IsPhoneSubscribedCompleted += serviceClient_IsPhoneSubscribedCompleted;
            _serviceClient.IsPhoneSubscribedAsync(_subscriptionInfo.Guid, _subscriptionInfo.ChannelURI);
        }

        private void serviceClient_IsPhoneSubscribedCompleted(object sender, IsPhoneSubscribedCompletedEventArgs e)
        {
            var subscribedPosition = e.Result;
            if (subscribedPosition == -1)
            {
                if(string.IsNullOrWhiteSpace(_subscriptionInfo.ChannelURI))
                {
                    NavigateToRegistrationPage();
                }
                else
                {
                    _serviceClient.SubscribePhoneCompleted += serviceClient_SubscribePhoneCompleted;
                    _serviceClient.SubscribePhoneAsync(_subscriptionInfo.Guid, _subscriptionInfo.ChannelURI, _subscriptionInfo.Nick, _subscriptionInfo.Device);       
                }
            }
            else
            {
                _dispatcher.BeginInvoke(
                    () =>
                    SubscriptionStatus = "Thanks Sir.\nYou are subscribed as number " + subscribedPosition);
            }
        }

        private void NavigateToRegistrationPage()
        {
            Navigate("/RegistrationPage.xaml");
        }

        private void myPushChannel_ErrorOccurred(object sender, NotificationChannelErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void DeleteCurrentSubscriptionInfo()
        {
            _storageHelper.DeleteSubscriptionInfo();
        }
    }
}
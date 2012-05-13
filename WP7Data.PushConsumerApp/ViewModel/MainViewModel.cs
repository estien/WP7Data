using System.ComponentModel;
using System.Diagnostics;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Notification;
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
    public class MainViewModel : ViewModelBase
    {

        #region Members

        public string PageName
        {
            get { return "hello Eirik"; }
        }

        private HttpNotificationChannel _pushChannel;
        private readonly PushRegistrationClient _serviceClient;
        private readonly Subscriber _subscriber;

        #endregion




        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            // Load or create the device's guid that will identify the current device and application installation to the MS push service and our web service
            _deviceGuid = Guid.NewGuid();

            // init push channel and webservice
            _serviceClient = new PushRegistrationClient();
            InitPushChannel();

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
            {
                BindChannelEvents();
                _serviceClient.SubscribePhoneAsync(_deviceGuid, _pushChannel.ChannelUri.ToString());
            }
        }

        private void BindChannelEvents()
        {
            //if error, print onscreen
            _pushChannel.ErrorOccurred += new EventHandler<NotificationChannelErrorEventArgs>(myPushChannel_ErrorOccurred);

            //ChannelUriUpdated fires when channel is first created or the channel URI changes 
            _pushChannel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(myPushChannel_ChannelUriUpdated);

            //Handle raw push notifications, which are received only while app is running.
            _pushChannel.HttpNotificationReceived += new EventHandler<HttpNotificationEventArgs>(myPushChannel_HttpNotificationReceived);

            //On successful subscription
            _serviceClient.SubscribePhoneCompleted += serviceClient_SubscribePhoneCompleted;
        }


        private void serviceClient_SubscribePhoneCompleted(object sender, SubscribePhoneCompletedEventArgs subscribePhoneCompletedEventArgs)
        {
            int position = subscribePhoneCompletedEventArgs.Result;

            var dispatcher = Deployment.Current.Dispatcher;
            dispatcher.BeginInvoke(() => MessageBox.Show("Thank you sir.  You subscribed as number " + position));
        }

        private void myPushChannel_HttpNotificationReceived(object sender, HttpNotificationEventArgs e)
        {
            throw new NotImplementedException();
        }

        //ChannelUriUpdated fires when channel is first created or the channel URI changes 
        private void myPushChannel_ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e)
        {
            _serviceClient.SubscribePhoneAsync(_deviceGuid, _pushChannel.ChannelUri.ToString());
        }

        private void myPushChannel_ErrorOccurred(object sender, NotificationChannelErrorEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
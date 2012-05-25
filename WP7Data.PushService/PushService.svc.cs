using System;
using System.Diagnostics;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using WP7Data.Push.Service.Interfaces;
using WP7Data.Push.Service.Model;
using WP7Data.Push.Service.Persistance;

namespace WP7Data.Push.Service
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class PushService : IPushRegistration, IPushProvider
    {
        private ObjectStore _store;

        private static class OutputWindow
        {
             public static void Show(string value)
             {
                 System.Diagnostics.Debug.WriteLine(value);
             }
        }

        public PushService()
        {
            _store = new ObjectStore();
        }

        public int IsPhoneSubscribed(Guid guid, string channelURI)
        {
            var subscriber = new Subscriber { ChannelURI = channelURI, Guid = guid};
            return _store.IsSubscribed(subscriber) ? _store.GetSubscriberPosition(subscriber) : -1;
        }

        public int SubscribePhone(Guid guid, string channelURI, string nick, string device)
        {
            var subscriber = new Subscriber {ChannelURI = channelURI, Guid = guid, Device = device, Nick = nick};

            #region If in developer mode
            if (System.Diagnostics.Debugger.IsAttached)
            {
                OutputWindow.Show(string.Format("Phone with GUID {0} has been subscribed on channel {1}", subscriber.Guid.ToString(), subscriber.ChannelURI));
            }
            #endregion

            
            subscriber.Created = DateTime.Now;

            int position = _store.IsSubscribed(subscriber) ? _store.GetSubscriberPosition(subscriber) : _store.AddSubscriber(subscriber);
            return position;
        }

        public void SendToastMessageToAllUsers(string message)
        {           
            var store = new ObjectStore();
            var subscribers = store.GetSubscribers();
            var messageBytes = Encoding.UTF8.GetBytes(message);

            foreach (var subscriber in subscribers)
                SendMessage(new Uri(subscriber.ChannelURI, UriKind.Absolute), messageBytes,
                            Notification.NotificationType.Toast);
        }

        public void SendRawMessageToAllUsers(string message)
        {
            var store = new ObjectStore();
            var subscribers = store.GetSubscribers();
            var messageBytes = Encoding.UTF8.GetBytes(message);

            foreach (var subscriber in subscribers)
                SendMessage(new Uri(subscriber.ChannelURI, UriKind.Absolute), messageBytes,
                            Notification.NotificationType.Raw);
        }

        private static void SendMessage(Uri uri, byte[] message, Notification.NotificationType notificationType)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Post;
            request.Accept = "text/xml";
            request.ContentType = "text/xml";
            request.ContentLength = message.Length;
            request.Credentials = CredentialCache.DefaultCredentials;

            request.Headers.Add("X-MessageID", Guid.NewGuid().ToString());

            switch (notificationType)
            {
                case Notification.NotificationType.Toast:
                    request.Headers["X-WindowsPhone-Target"] = "toast";
                    request.Headers.Add("X-NotificationClass", ((int)Notification.BatchingInterval.ToastImmediately).ToString());
                    break;
                case Notification.NotificationType.Tile:
                    request.Headers["X-WindowsPhone-Target"] = "token";
                    request.Headers.Add("X-NotificationClass", ((int)Notification.BatchingInterval.TileImmediately).ToString());
                    break;
                default:
                    request.Headers.Add("X-NotificationClass", ((int)Notification.BatchingInterval.RawImmediately).ToString());
                    break;
            }

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(message, 0, message.Length);
            }
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                
                var notificationStatus = response.Headers["X-NotificationStatus"];
                var subscriptionStatus = response.Headers["X-SubscriptionStatus"];
                var deviceConnectionStatus = response.Headers["X-DeviceConnectionStatus"];

                Debug.WriteLine(string.Format("Device Connection Status: {0}", deviceConnectionStatus));
                Debug.WriteLine(string.Format("Notification Status: {0}", notificationStatus));
                Debug.WriteLine(string.Format("Subscription Status: {0}", subscriptionStatus));
            }
            catch (WebException ex)
            {
                Debug.WriteLine(string.Format("ERROR: {0}", ex.Message));
            }
        }
    }
}

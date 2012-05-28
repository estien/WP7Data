using System;
using System.Collections.Generic;
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
        private readonly ObjectStore _store;

        private static class OutputWindow
        {
             public static void Show(string value)
             {
                 Debug.WriteLine(value);
             }
        }

        private static string _debugString = string.Empty;

        public PushService()
        {
            _store = new ObjectStore();
        }

        public int IsPhoneSubscribed(string deviceId, string channelURI)
        {
            var subscriber = new Subscriber { ChannelURI = channelURI, DeviceId = deviceId};
            return _store.IsSubscribed(subscriber) ? _store.GetSubscriberPosition(subscriber) : -1;
        }

        public int SubscribePhone(string deviceId, string channelURI, string nick, string device)
        {
            var subscriber = new Subscriber {ChannelURI = channelURI, DeviceId = deviceId, Device = device, Nick = nick};

            #region If in developer mode
            if (Debugger.IsAttached)
            {
                OutputWindow.Show(string.Format("Phone with DeviceId {0} has been subscribed on channel {1}", subscriber.DeviceId.ToString(), subscriber.ChannelURI));
            }
            #endregion

            
            subscriber.Created = DateTime.Now;
            
            int position = _store.IsSubscribed(subscriber) ? _store.GetSubscriberPosition(subscriber) : _store.AddSubscriber(subscriber);
            SendRawMessageToAllUsers(string.Format("[{0}] {1} ({2}) registered as number {3}",DateTime.Now.ToString("HH:mm:ss"), subscriber.Nick, subscriber.Device, position)); 

            return position;
        }

        public void UnsubscribePhone(string deviceId)
        {
            _store.RemovePhoneSubscription(deviceId);
        }

        public string GetErrorLog()
        {
            return _debugString;
        }

        public void SendTileMessageToAllUsers(string message)
        {
            var subscribers = _store.GetSubscribers();
            
            const string tileMessage = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                                       "<wp:Notification xmlns:wp=\"WPNotification\">" +
                                       "<wp:Tile>" +
                                       "<wp:BackgroundImage>{0}</wp:BackgroundImage>" +
                                       "<wp:Count>{1}</wp:Count>" +
                                       "<wp:Title>{2}</wp:Title>" +
                                       "</wp:Tile> " +
                                       "</wp:Notification>";

            string formattedTileMessage = string.Format(tileMessage, "http://wp7pushservice.apphb.com/images/funny-monkey-2.jpg", 42, message);

            byte[] messageBytes = Encoding.UTF8.GetBytes(formattedTileMessage);

            foreach (var subscriber in subscribers)
                SendMessage(new Uri(subscriber.ChannelURI, UriKind.Absolute), messageBytes,
                            Notification.NotificationType.Tile);
        }

        public void SendToastMessageToAllUsers(string message)
        {           
            var store = new ObjectStore();
            var subscribers = store.GetSubscribers();

            var xml = string.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?><wp:Notification xmlns:wp=\"WPNotification\"><wp:Toast><wp:Text1>From admin:</wp:Text1><wp:Text2>{0}</wp:Text2></wp:Toast></wp:Notification>", message);

            var messageBytes = Encoding.UTF8.GetBytes(xml);

            foreach (var subscriber in subscribers)
                SendMessage(new Uri(subscriber.ChannelURI, UriKind.Absolute), messageBytes,
                            Notification.NotificationType.Toast);
        }

        public void SendRawMessageToAllUsers(string message)
        {
            var store = new ObjectStore();
            var subscribers = store.GetSubscribers();

            SendMessageToUsers(message, subscribers);
        }

        private static void SendMessageToUsers(string message, List<Subscriber> subscribers)
        {
            var messageBytes = Encoding.UTF8.GetBytes(message);

            foreach (var subscriber in subscribers)
                SendMessage(new Uri(subscriber.ChannelURI, UriKind.Absolute), messageBytes,
                            Notification.NotificationType.Raw);
        }

        private static void SendMessage(Uri uri, byte[] message, Notification.NotificationType notificationType)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "text/xml";
            request.ContentLength = message.Length;

            switch (notificationType)
            {
                case Notification.NotificationType.Toast:
                    request.Headers["X-WindowsPhone-Target"] = "toast";
                    request.Headers["X-NotificationClass"] = ((int)Notification.BatchingInterval.ToastImmediately).ToString();
                    break;
                case Notification.NotificationType.Tile:
                    request.Headers["X-WindowsPhone-Target"] = "token";
                    request.Headers["X-NotificationClass"] = ((int)Notification.BatchingInterval.TileImmediately).ToString();
                    break;
                default:
                    request.Headers["X-NotificationClass"] = ((int)Notification.BatchingInterval.RawImmediately).ToString();
                    break;
            }

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(message, 0, message.Length);
            }
            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                #region If in developer mode
                if (Debugger.IsAttached)
                {
                    var notificationStatus = response.Headers["X-NotificationStatus"];
                    var subscriptionStatus = response.Headers["X-SubscriptionStatus"];
                    var deviceConnectionStatus = response.Headers["X-DeviceConnectionStatus"];
                    OutputWindow.Show(string.Format("Device Connection Status: {0}", deviceConnectionStatus));
                    OutputWindow.Show(string.Format("Notification Status: {0}", notificationStatus));
                    OutputWindow.Show(string.Format("Subscription Status: {0}", subscriptionStatus));
                }
                #endregion
            }
            catch (WebException ex)
            {
                if (Debugger.IsAttached) 
                    OutputWindow.Show(string.Format("ERROR: {0}", ex.Message));
                _debugString += string.Format("\n{0} Request failed:{1} with status code {2}", DateTime.Now, ex.Message, ex.Status.ToString());
            }
        }
    }
}

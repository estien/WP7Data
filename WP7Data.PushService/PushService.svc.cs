using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using WP7Data.Push.Service.Interfaces;
using WP7Data.Push.Service.Model;
using WP7Data.Push.Service.Persistance;

namespace WP7Data.Push.Service
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class PushService : IPushRegistration, IPushProvider
    {

        private static class OutputWindow
        {
             public static void Show(string value)
             {
                 System.Diagnostics.Debug.WriteLine(value);
             }
        }

        public int SubscribePhone(Subscriber subscriber)
        {
            #region If in developer mode
            if (System.Diagnostics.Debugger.IsAttached)
            {
                OutputWindow.Show(string.Format("Phone with GUID {0} has been subscribed on channel {1}", deviceId.ToString(), channelURI));
            }
            #endregion

            var store = new ObjectStore();
            int position = 1;
            subscriber.Created = DateTime.Now;

            if(!store.IsSubscribed(subscriber))
            {
                position = store.AddSubscriber(subscriber);
            }
            return position;
        }

        public void SendToastMessageToAllUsers(string message)
        {
            throw new NotImplementedException();
        }
    }
}

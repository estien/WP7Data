using System.IO.IsolatedStorage;
using WP7Data.Push.ConsumerApp.Model;

namespace WP7Data.Push.ConsumerApp.Persistance
{
    public class ISHelper
    {
        private readonly IsolatedStorageSettings _storage;

        public ISHelper()
        {
            _storage = IsolatedStorageSettings.ApplicationSettings;
        }

        public SubscriptionInfo GetSubscriptionInfo()
        {
            if(SubscriptionInfoExists())
            {
                SubscriptionInfo info;
                _storage.TryGetValue("info", out info);
                return info;
            }
            return null;
        }

        private bool SubscriptionInfoExists()
        {
            return _storage.Contains("info");
        }

        public void SaveSubscriptionInfo(SubscriptionInfo info)
        {
            if(SubscriptionInfoExists())
                _storage.Remove("info");
            AddSubscriptionInfo(info);
        }

        private void AddSubscriptionInfo(SubscriptionInfo info)
        {
            _storage.Add("info", info);
        }
    }
}

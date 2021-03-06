﻿using System.IO.IsolatedStorage;
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

        public bool SubscriptionInfoExists()
        {
            return _storage.Contains("info");
        }

        public void SaveSubscriptionInfo(SubscriptionInfo info)
        {
            RemoveSubscriptionInfo();
            AddSubscriptionInfo(info);
        }

        private void RemoveSubscriptionInfo()
        {
            if (SubscriptionInfoExists())
                _storage.Remove("info");
        }

        private void AddSubscriptionInfo(SubscriptionInfo info)
        {
            _storage.Add("info", info);
            _storage.Save();
        }

        public void DeleteSubscriptionInfo()
        {
            RemoveSubscriptionInfo();
        }
    }
}

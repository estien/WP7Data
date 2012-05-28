using System;
using System.Collections.Generic;
using System.Configuration;
using MongoDB.Driver;
using WP7Data.Push.Service.Model;
using System.Linq;

namespace WP7Data.Push.Service.Persistance
{
    public class ObjectStore
    {
        private const string SubscribersKey = "subscribers";
        private readonly MongoDatabase _database;
        
        public ObjectStore()
        {
            var connectionString = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
            var server = MongoServer.Create(connectionString);
            _database = server.GetDatabase("appharbor_a6a88884-0e19-42c8-92ed-6ec23821b99d");

            var exists = _database.CollectionExists(SubscribersKey);
            if (!exists)
            {
                _database.CreateCollection(SubscribersKey);
            }
        }

        public int AddSubscriber(Subscriber subscriber)
        {
            var coll = _database.GetCollection<Subscriber>(SubscribersKey);
            RemovePhoneSubscription(subscriber.DeviceId);
            coll.Save(subscriber);
            return (int) coll.Count();
        }

        public Subscriber GetSubscriber(string deviceId)
        {
            var coll = _database.GetCollection<Subscriber>(SubscribersKey);
            var query = new QueryDocument("DeviceId", deviceId);
            var subscriber = coll.FindOne(query);

            return subscriber;
        }

        public List<Subscriber> GetSubscribers()
        {
            var coll = _database.GetCollection<Subscriber>(SubscribersKey);
            var subscribers = coll.FindAll();

            return subscribers.ToList();
        }

        public bool IsSubscribed(Subscriber subscriber)
        {
            var subscriberInStore = GetSubscriber(subscriber.DeviceId);
            return subscriberInStore != null;
        }

        public int GetSubscriberPosition(Subscriber subscriber)
        {
            var subscribers = GetSubscribers();
            return subscribers.FindIndex(y => y.DeviceId == subscriber.DeviceId) + 1;
        }

        public void RemovePhoneSubscription(string deviceId)
        {
            var coll = _database.GetCollection<Subscriber>(SubscribersKey);
            var subscriber = new QueryDocument("DeviceId", deviceId);
            coll.Remove(subscriber);
        }
    }
}
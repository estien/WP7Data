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
            _database = server.GetDatabase("test");

            var exists = _database.CollectionExists(SubscribersKey);
            if (!exists)
            {
                _database.CreateCollection(SubscribersKey);
            }
        }

        public int AddSubscriber(Subscriber subscriber)
        {
            var coll = _database.GetCollection<Subscriber>(SubscribersKey);
            coll.Save(subscriber);
            return (int) coll.Count();
        }

        public Subscriber GetSubscriber(Guid guid)
        {
            var coll = _database.GetCollection<Subscriber>(SubscribersKey);
            var query = new QueryDocument("Guid", guid);
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
            var subscriberInStore = GetSubscriber(subscriber.Guid);
            return subscriberInStore != null;
        }
    }
}
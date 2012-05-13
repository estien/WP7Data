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
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            _database = server.GetDatabase("test");

            var exists = _database.CollectionExists(SubscribersKey);
            if (!exists)
            {
                _database.CreateCollection(SubscribersKey);
            }
        }

        public void AddSubscriber(Subscriber subscriber)
        {

            

            var coll = _database.GetCollection<Subscriber>(SubscribersKey);

            coll.Insert(subscriber);

            var hekki = ";";

        }

        public Subscriber GetSubscriber(Guid guid)
        {
            var coll = _database.GetCollection<Subscriber>(SubscribersKey);

            var query = new QueryDocument("Guid", guid.ToString());
            var subscriber = coll.FindOne(query);

            return subscriber;
        }

        public List<Subscriber> GetSubscribes()
        {
            var coll = _database.GetCollection<Subscriber>(SubscribersKey);
            var subscribers = coll.FindAll();

            return subscribers.ToList();
        }
    }
}
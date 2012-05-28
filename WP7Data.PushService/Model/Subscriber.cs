using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using MongoDB.Bson;

namespace WP7Data.Push.Service.Model
{
    [DataContract]
    public class Subscriber
    {
        public ObjectId Id { get; set; }

        [DataMember]
        public string DeviceId { get; set; }

        [DataMember]
        public string ChannelURI { get; set; }

        [DataMember]
        public string Nick { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public string Device { get; set; }
    }
}
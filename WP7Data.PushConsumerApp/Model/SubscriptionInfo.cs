using System;

namespace WP7Data.Push.ConsumerApp.Model
{
    public class SubscriptionInfo
    {
        public Guid Guid { get; set; }
        public string ChannelURI { get; set; }
        public string Nick { get; set; }
        public string Device { get; set; }
    }
}

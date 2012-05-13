using System;
using System.ServiceModel;

namespace WP7Data.Push.Service.Interfaces
{
    [ServiceContract]
    public interface IPushService
    {

        [OperationContract]
        void SubscripePhone(Guid deviceId, string channelURI);

    }
}

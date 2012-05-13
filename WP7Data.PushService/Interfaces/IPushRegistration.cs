using System;
using System.ServiceModel;

namespace WP7Data.Push.Service.Interfaces
{
    [ServiceContract]
    public interface IPushRegistration
    {

        [OperationContract]
        int SubscribePhone(Guid deviceId, string channelURI);

    }
}

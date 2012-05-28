using System;
using System.ServiceModel;

namespace WP7Data.Push.Service.Interfaces
{
    [ServiceContract]
    public interface IPushRegistration
    {

        [OperationContract]
        int IsPhoneSubscribed(Guid guid, string channelURI);

        [OperationContract]
        int SubscribePhone(Guid guid, string channelURI, string nick, string device);

        [OperationContract]
        string GetErrorLog();

    }
}

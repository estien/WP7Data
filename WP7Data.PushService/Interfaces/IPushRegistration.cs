using System;
using System.ServiceModel;

namespace WP7Data.Push.Service.Interfaces
{
    [ServiceContract]
    public interface IPushRegistration
    {

        [OperationContract]
        int IsPhoneSubscribed(string deviceId, string channelURI);

        [OperationContract]
        int SubscribePhone(string deviceId, string channelURI, string nick, string device);

        [OperationContract]
        void UnsubscribePhone(string deviceId);

        [OperationContract]
        string GetErrorLog();

    }
}

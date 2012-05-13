using System;
using System.ServiceModel;
using WP7Data.Push.Service.Model;

namespace WP7Data.Push.Service.Interfaces
{
    [ServiceContract]
    public interface IPushRegistration
    {

        [OperationContract]
        int SubscribePhone(Subscriber subscriber);

    }
}

using System.ServiceModel;

namespace WP7Data.Push.Service.Interfaces
{
    [ServiceContract]
    public interface IPushProvider
    {
        [OperationContract]
        void SendToastMessageToAllUsers(string message);
    }
}

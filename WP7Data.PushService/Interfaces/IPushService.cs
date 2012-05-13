using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WP7Data.Push.Service.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPushService
    {

        #region Methods samples
        /* Samples of both objects and strings that can be returned from the service */

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        
        #endregion



        [OperationContract]
        void SubscripePhone(Guid deviceId, string channelURI);


    }


    #region Data classes samples
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
    #endregion  
}

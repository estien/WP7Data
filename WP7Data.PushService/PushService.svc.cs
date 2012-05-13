using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using WP7Data.Push.Service.Interfaces;

namespace WP7Data.Push.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class PushService : IPushService
    {

        private static class OutputWindow
        {
             public static void Show(string value)
             {
                 System.Diagnostics.Debug.WriteLine(value);
             }
        }
     
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public void SubscripePhone(Guid deviceId, string channelURI)
        {


            #region If in developer mode
            if (System.Diagnostics.Debugger.IsAttached)
            {
                OutputWindow.Show(string.Format("Phone with GUID {0} has been subscribed on channel {1}", deviceId.ToString(), channelURI));
            }
            #endregion
        }
    }
}

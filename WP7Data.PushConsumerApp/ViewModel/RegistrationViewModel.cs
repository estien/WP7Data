using System;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Info;
using WP7Data.Push.ConsumerApp.Model;
using WP7Data.Push.ConsumerApp.Persistance;

namespace WP7Data.Push.ConsumerApp.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class RegistrationViewModel : WP7DataViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the RegistrationViewModel class.
        /// </summary>
        /// 
        public string PageName
        {
            get { return "Registration"; }
        }

        private string _nick;

        public string Nick
        {
            get { return _nick; }
            set
            {
                if (_nick != value)
                {
                    _nick = value;
                    RaisePropertyChanged("Nick");
                }
            }
        }

        private SubscriptionInfo _subscriptionInfo;
        private readonly ISHelper _storageHelper;
        
        public RegistrationViewModel()
        {
            _storageHelper = new ISHelper();
        }

        public void CreateSubscriptionInfo()
        {
            string deviceId;
            if (IsolatedStorageSettings.ApplicationSettings.Contains("DeviceId"))
                deviceId = IsolatedStorageSettings.ApplicationSettings["DeviceId"].ToString();
            else
            {
                deviceId = Guid.NewGuid().ToString();
                IsolatedStorageSettings.ApplicationSettings["DeviceId"] = deviceId;
            }
            _subscriptionInfo = new SubscriptionInfo
            {
                DeviceId = deviceId,
                Device = DeviceExtendedProperties.GetValue("DeviceName").ToString(),
                Nick = Nick
            };
            _storageHelper.SaveSubscriptionInfo(_subscriptionInfo);
        }
    }
}
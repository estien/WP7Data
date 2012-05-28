using System;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WP7Data.Push.TriggerApp.PushService;

namespace WP7Data.Push.TriggerApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand<string> SendRawMessageRelayCommand { get; private set; }
        public RelayCommand<string> SendToastMessageRelayCommand { get; private set; }
        public RelayCommand<string> SendTileMessageRelayCommand { get; private set; }

        private PushService.PushProviderClient _pushClient;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            SendRawMessageRelayCommand = new RelayCommand<string>(param => SendRawMessageToService(param));
            SendToastMessageRelayCommand = new RelayCommand<string>(param => SendToastMessageToService(param)); 
            SendTileMessageRelayCommand = new RelayCommand<string>(param => SendTileMessageToService(param));
            _pushClient = new PushProviderClient();
        }

        private void SendRawMessageToService(string message)
        {
            _pushClient.SendRawMessageToAllUsersAsync(message);
        }

        private void SendToastMessageToService(string message)
        {
            _pushClient.SendToastMessageToAllUsersAsync(message);
        }

        private void SendTileMessageToService(string message)
        {
            _pushClient.SendTileMessageToAllUsersAsync(message);
        }
    }
}
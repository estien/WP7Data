using System;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

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
        public RelayCommand<string> SendMessageRelayCommand { get; private set; }  
        
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        
            SendMessageRelayCommand = new RelayCommand<string>(param => SendMessageToService(param));
        
        }

        private void SendMessageToService(string message)
        {
            MessageBox.Show("Thank you sir. Your message was: " + Environment.NewLine + Environment.NewLine + message);
        }
    }
}
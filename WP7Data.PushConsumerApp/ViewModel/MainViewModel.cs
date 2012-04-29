using System.Diagnostics;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using WP7Data.Push.ConsumerApp.PushService;


namespace WP7Data.Push.ConsumerApp.ViewModel
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

        public string PageName
        {
            get { return "hello Eirik"; }
        }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            var client = new PushServiceClient();

            client.GetDataCompleted += (object sender, GetDataCompletedEventArgs args) =>
                                           {
                                               Debug.WriteLine(args.Result.ToString());

                                           };

            client.GetDataAsync(1337);

            client.CloseAsync();
        }
    }
}
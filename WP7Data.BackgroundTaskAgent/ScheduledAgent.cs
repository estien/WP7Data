using System;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;

namespace WP7Data.BackgroundTaskAgent
{
    public class ScheduledAgent : ScheduledTaskAgent
    {
        private static volatile bool _classInitialized;
        private static readonly string _pictureUrl = "http://2.bp.blogspot.com/_JP9OiUP__qY/TOvdF0vZpaI/AAAAAAAAAlA/5EEo_gIifD0/s1600/funny-monkey-2.jpg";


        /// <remarks>
        /// ScheduledAgent constructor, initializes the UnhandledException handler
        /// </remarks>
        public ScheduledAgent()
        {
            if (!_classInitialized)
            {
                _classInitialized = true;
                // Subscribe to the managed exception handler
                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    Application.Current.UnhandledException += ScheduledAgent_UnhandledException;
                });
            }
        }

        /// Code to execute on Unhandled Exceptions
        private void ScheduledAgent_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        /// <summary>
        /// Agent that runs a scheduled task
        /// </summary>
        /// <param name="task">
        /// The invoked task
        /// </param>
        /// <remarks>
        /// This method is called when a periodic or resource intensive task is invoked
        /// </remarks>
        protected override void OnInvoke(ScheduledTask task)
        {
            var tileToFind = ShellTile.ActiveTiles.FirstOrDefault();

            if(tileToFind != null)
            {
                var tileData = new StandardTileData
                                   {
                                       BackTitle = "Jeg lever!",
                                       BackBackgroundImage = new Uri(_pictureUrl, UriKind.Absolute)
                                   };

                tileToFind.Update(tileData);
            }

            NotifyComplete();
        }
    }
}
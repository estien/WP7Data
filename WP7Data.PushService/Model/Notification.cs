using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WP7Data.Push.Service.Model
{
    public class Notification
    {
        public enum NotificationType
        {
            Toast, Tile, Raw
        }

        public enum BatchingInterval
        {
            TileImmediately = 1,
            ToastImmediately = 2,
            RawImmediately = 3,
            TileWait450 = 11,
            ToastWait450 = 12,
            RawWait450 = 13,
            TileWait900 = 21,
            ToastWait900 = 22,
            RawWait900 = 23
        }
    }
}
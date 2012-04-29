using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WP7Data.Push.ConsumerApp.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
    }
}

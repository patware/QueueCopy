using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueueCopy.Services
{
    public interface IDataService
    {
        void GetData(Action<Model.DataItem, Exception> callback);
    }
}

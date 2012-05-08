using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public interface IQueuingSystem
    {
        long CountRequestInSystem { get; }

        ISystemDevices Devices { get; }

        int CountHandledRequest { get; }

        void OnRequestHandled(object sender, EventArgs e);

        int Time { get; }

        bool AreRequests { get; }
    }
}

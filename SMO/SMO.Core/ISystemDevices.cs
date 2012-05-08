using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public interface ISystemDevices
    {
        bool ThereIsFreeDevice { get; }

        void Add(IDevice device);

        event EventHandler<EventArgs> HandledRequestEvent;

        void TakeFreeDevice(IRequest request);
    }
}

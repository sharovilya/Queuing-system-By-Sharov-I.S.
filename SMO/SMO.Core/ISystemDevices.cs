using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public interface ISystemDevices
    {
        bool ThereIsFreeDevice { get; }
        List<Device> Children { get; }
        int Count { get; set; }
        void Add(Device device);
        
        event EventHandler<RequestEventArg> RequestHandledEvent;
        void TakeFreeDevice(Request request);
        void Reset();
    }
}

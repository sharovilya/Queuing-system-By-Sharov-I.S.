using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public interface IDevice
    {
        event EventHandler<RequestEventArg> RequestHandledEvent;
        bool IsFree { get; }
        void Take(Request r);

        void Release();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public interface IDevice
    {
        event EventHandler<EventArgs> RequestHandledEvent;
        bool IsFree { get; }
        void Take(IRequest r);
    }
}

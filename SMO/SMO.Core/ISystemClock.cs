using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public interface ISystemClock
    {
        void Tick();
        event EventHandler<EventArgs> TickEvent;
    }
}

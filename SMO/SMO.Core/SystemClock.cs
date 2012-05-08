using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public class SystemClock : ISystemClock
    {
        public event EventHandler<EventArgs> TickEvent;

        public void Tick()
        {
            var e = TickEvent;
            e.Raise(this, EventArgs.Empty);
        }
    }
}

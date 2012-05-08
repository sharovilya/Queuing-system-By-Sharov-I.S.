using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core.Tests
{
    class MockSystemComponent
    {
        public MockSystemComponent(ISystemClock clock)
        {
            clock.TickEvent += OnTickEvent;       
        }

        public void OnTickEvent(object sender, EventArgs e)
        {
            Time++;
        }

        public int Time
        {
            get;
            private set;
        }
    }
}

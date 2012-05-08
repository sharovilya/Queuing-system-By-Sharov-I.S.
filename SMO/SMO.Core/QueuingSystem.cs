using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public class QueuingSystem : IQueuingSystem
    {
        private IEngine engine;
        private ISystemDevices devices;
        private IDisciplineQueuingSystem discipline;

        public ISystemDevices Devices
        {
            get
            {
                return devices;
            }
        }

        public QueuingSystem(ISystemClock clock, 
                             IEngine engine, 
                             ISystemDevices devices, 
                             IDisciplineQueuingSystem discipline)
        {
            this.engine = engine;
            this.devices = devices;
            this.discipline = discipline;

            devices.HandledRequestEvent += OnRequestHandled;
            engine.NewRequestEvent += OnNewRequest;
            clock.TickEvent += OnTickEvent;
        }
        
        private void OnNewRequest(object sender, NewRequestEventArg e)
        {
            if (devices.ThereIsFreeDevice)
            {
                devices.TakeFreeDevice(Request.New(e.TimeBorn));
                CountRequestInSystem++;
            }
            else  if (!discipline.IsFull)
            {
                discipline.Put(Request.New(e.TimeBorn));
                CountRequestInSystem++;
            }
        }

        public long CountRequestInSystem
        {
            get;
            private set;
        }

        public int Time
        {
            get;
            private set;
        }

        public void OnTickEvent(object @this, EventArgs e)
        {
            Time++;

            if (!discipline.IsEmpty)
            {
                if (devices.ThereIsFreeDevice)
                {
                    var request = discipline.PullOut();
                    devices.TakeFreeDevice(request);
                }
            }
        }

        public int CountHandledRequest
        {
            get;
            private set;
        }

        public void OnRequestHandled(object sender, EventArgs e)
        {
            CountHandledRequest++;
            CountRequestInSystem--;
        }

        public bool AreRequests
        {
            get
            {
                Console.WriteLine(CountRequestInSystem);
                return CountRequestInSystem > 0;
            }
        }
    }
}

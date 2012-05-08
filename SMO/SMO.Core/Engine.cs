using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public class Engine : IEngine
    {
        private IRandomGenerator generator;
        
        public bool Running
        {
            get;
            private set;
        }

        public Engine(ISystemClock clock, IRandomGenerator generator)
        {
            this.generator = generator;
            clock.TickEvent += OnTickEvent;
            Running = true;
        }

        public void GenerateNewRequest()
        {
            var args = new NewRequestEventArg(Time);
            NewRequestEvent.Raise(this, args);

            NextTimeForNewRequest = generator.Next;
            Time = 0;
            CountGeneratedRequest++;
        }

        public event EventHandler<NewRequestEventArg> NewRequestEvent;

        public int Time
        {
            get;
            private set;
        }

        public void OnTickEvent(object @this, EventArgs e)
        {
            if (Running)
            {
                if (NextTimeForNewRequest == Time++)
                {
                    GenerateNewRequest();
                }
            }
        }

        public int NextTimeForNewRequest
        {
            get;
            private set;
        }

        public int CountGeneratedRequest
        {
            get;
            private set;
        }

        public void Stop()
        {
            Running = false;    
        }
    }
}

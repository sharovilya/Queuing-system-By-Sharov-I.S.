using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public class Engine : IEngine
    {
        private ISystemGenerator generator;
        private AverageScore scorer = new AverageScore();

        public double AverageInterval
        {
            get
            {
                return scorer.Result;
            }
        }

        public bool Running
        {
            get;
            private set;
        }

        public Engine(ISystemClock clock, ISystemGenerator generator)
        {
            this.generator = generator;
            clock.TickEvent += OnTickEvent;
            Running = true;
        }

        public void GenerateNewRequest()
        {
            NextTimeForNewRequest = generator.NextIntervalTime;
            CountGeneratedRequest++;
            var args = new RequestEventArg(-1, NextTimeForNewRequest, CountGeneratedRequest);
            NewRequestEvent.Raise(this, args);
            TimeToNextRequestBorn = 0;
        }

        public event EventHandler<RequestEventArg> NewRequestEvent;

        public int TimeToNextRequestBorn
        {
            get;
            private set;
        }

        public void OnTickEvent(object @this, EventArgs e)
        {
            if (Running)
            {
                if (NextTimeForNewRequest == TimeToNextRequestBorn++)
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

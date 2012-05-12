using System;
using SMO.Core.Tests;

namespace SMO.Core
{
    public class QueuingSystem : IQueuingSystem
    {
        public QueuingSystem(ISystemConfiguration configuration, ISystemClock clock, IEngine engine, ISystemStatistics statistics)
        {
            Statistics = statistics;
            Configuration = configuration;

            Configuration.Devices.RequestHandledEvent += OnRequestHandled;
            engine.NewRequestEvent += OnNewRequest;
            clock.TickEvent += OnTickEvent;
        }

        public ISystemConfiguration Configuration { get; private set; }

        public ISystemStatistics Statistics { get; private set; }

        public int CountRejectedRequests { get; private set; }

        #region IQueuingSystem Members
        
        public bool AreRequests
        {
            get { return CountRequestInSystem > 0; }
        }

        public long CountRequestInSystem { get; private set; }

        public int Time { get; private set; }

        public int CountHandledRequest { get; private set; }

        public void OnRequestHandled(object sender, RequestEventArg e)
        {
            CountHandledRequest++;
            CountRequestInSystem--;

            Statistics.WaitingTimeInSystem.Score(Time - e.TimeBorn);
        }

        public void Reset()
        {
            Statistics.Reset();

            Configuration.Generator.Reset();
            Configuration.Devices.Reset();
            Configuration.Discipline.Reset();

            CountHandledRequest = 0;
            CountRequestInSystem = 0;
            Time = 0;
        }

        #endregion

        private void OnNewRequest(object sender, RequestEventArg e)
        {
            Statistics.IntervalTime.Score(e.NextTimeForNewRequest);
            Request newRequest = MakeNewRequest(e);

            if (Configuration.Devices.ThereIsFreeDevice)
            {
                Configuration.Devices.TakeFreeDevice(newRequest);
                CountRequestInSystem++;
            }
            else if (!Configuration.Discipline.IsFull)
            {
                Configuration.Discipline.Put(newRequest);
                CountRequestInSystem++;
            }
            else
            {
                CountRejectedRequests++;
                Statistics.UpdateRelativeBandwidth(CountRejectedRequests, e.CountRequestsCaughtInSystem);
            }
        }

        private Request MakeNewRequest(RequestEventArg e)
        {
            int processingTime = Configuration.Generator.NextProcessingTime;
            Statistics.ServiceTime.Score(processingTime);
            return Request.New(Time, processingTime, e.CountRequestsCaughtInSystem);
        }

        public void OnTickEvent(object @this, EventArgs e)
        {
            Tick();

            if (!Configuration.Discipline.IsEmpty)
            {
                Statistics.NumberOfRequestsInQueue.Score(Configuration.Discipline.CountRequestsInQueue);
                if (Configuration.Devices.ThereIsFreeDevice)
                {
                    var request = Configuration.Discipline.PullOut();
                    Configuration.Devices.TakeFreeDevice(request);
                    Statistics.WaitingTimeInQueue.Score(Time - request.TimeBorn);
                }
            }
        }

        private void Tick()
        {
            Time++;
            Statistics.NumberOfRequestsInSystem.Score(CountRequestInSystem);
        }
    }
}
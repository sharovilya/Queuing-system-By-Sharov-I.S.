using System;

namespace SMO.Core
{
    public class QueuingSystem : IQueuingSystem
    {
        public QueuingSystem(ISystemGenerator generator,
                             ISystemClock clock,
                             IEngine engine,
                             ISystemDevices devices,
                             IDisciplineQueuingSystem discipline,
                             ISystemStatistics statistics)
        {
            Devices = devices;
            Generator = generator;
            Discipline = discipline;
            Statistics = statistics;

            devices.RequestHandledEvent += OnRequestHandled;
            engine.NewRequestEvent += OnNewRequest;
            clock.TickEvent += OnTickEvent;
        }

        public ISystemGenerator Generator { get; private set; }

        public ISystemStatistics Statistics { get; private set; }

        public IDisciplineQueuingSystem Discipline { get; private set; }

        public int CountRejectedRequests { get; private set; }

        #region IQueuingSystem Members

        public ISystemDevices Devices { get; private set; }

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
            Generator.Reset();
            Devices.Reset();
            Discipline.Reset();
            CountHandledRequest = 0;
            CountRequestInSystem = 0;
            Time = 0;
        }

        #endregion

        private void OnNewRequest(object sender, RequestEventArg e)
        {
            Statistics.IntervalTime.Score(e.NextTimeForNewRequest);
            IRequest newRequest = MakeNewRequest(e);

            if (Devices.ThereIsFreeDevice)
            {
                Devices.TakeFreeDevice(newRequest);
                CountRequestInSystem++;
            }
            else if (!Discipline.IsFull)
            {
                Discipline.Put(newRequest);
                CountRequestInSystem++;
            }
            else
            {
                CountRejectedRequests++;
                Statistics.UpdateRelativeBandwidth(CountRejectedRequests, e.CountRequestsCaughtInSystem);
            }
        }

        private IRequest MakeNewRequest(RequestEventArg e)
        {
            int processingTime = Generator.NextProcessingTime;
            Statistics.ServiceTime.Score(processingTime);
            return Request.New(Time, processingTime, e.CountRequestsCaughtInSystem);
        }

        public void OnTickEvent(object @this, EventArgs e)
        {
            Tick();

            if (!Discipline.IsEmpty)
            {
                Statistics.NumberOfRequestsInQueue.Score(Discipline.CountRequestsInQueue);
                if (Devices.ThereIsFreeDevice)
                {
                    var request = Discipline.PullOut();
                    Devices.TakeFreeDevice(request);
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
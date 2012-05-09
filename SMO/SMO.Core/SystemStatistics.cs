using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMO.Core
{
    public class SystemStatistics : ISystemStatistics
    {
        private int countRequestsCaughtInSystem = 1;
        private int countRejectedRequests;

        public SystemStatistics()
        {
            IntervalTime = new AverageScore();
            ServiceTime = new AverageScore();
            NumberOfRequestsInQueue = new AverageScore();
            WaitingTimeInQueue = new AverageScore();
            NumberOfRequestsInSystem = new AverageScore();
            WaitingTimeInSystem = new AverageScore();
        }

        public AverageScore IntervalTime
        {
            get;
            private set;
        }

        public AverageScore ServiceTime
        {
            get;
            private set;
        }

        public AverageScore NumberOfRequestsInQueue
        {
            get;
            private set;
        }

        public AverageScore WaitingTimeInQueue
        {
            get;
            private set;
        }

        public AverageScore NumberOfRequestsInSystem
        {
            get;
            private set;
        }

        public AverageScore WaitingTimeInSystem
        {
            get;
            private set;
        }

        public double AbsolutBandwidth
        {
            get { return RelativeBandwidth / IntervalTime.Result; }
        }

        public double RelativeBandwidth
        {
            get { return 1 - countRejectedRequests/(double) countRequestsCaughtInSystem; }

        }

        public double UtilizationFactorOfSystem
        {
            get { return IntervalTime.Result / ServiceTime.Result; }
        }

        public void UpdateRelativeBandwidth(int countRejectedRequests, int countRequestsCaughtInSystem)
        {
            this.countRejectedRequests = countRejectedRequests;
            this.countRequestsCaughtInSystem = countRequestsCaughtInSystem;
        }

        public void Reset()
        {
            IntervalTime.Reset();
            ServiceTime.Reset();
            NumberOfRequestsInQueue.Reset();
            WaitingTimeInQueue.Reset();
            NumberOfRequestsInSystem.Reset();
            WaitingTimeInSystem.Reset();
            countRejectedRequests = 0;
            countRequestsCaughtInSystem = 1;
        }
    }
}

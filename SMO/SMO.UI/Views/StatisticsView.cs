using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMO.Core;

namespace SMO.UI.Views
{
    public class StatisticsView : BaseView
    {
        private ISystemStatistics statistics;
        private double intervalTime;
        private double serviceTime;
        private double numberOfRequestsInQueue;
        private double waitingTimeInQueue;
        private double numberOfRequestsInSystem;
        private double waitingTimeInSystem;
        private double absolutBandwidth;
        private double relativeBandwidth;
        private double utilizationFactorOfSystem;

        public StatisticsView()
        {
            statistics = IoC.Resolve<ISystemStatistics>();

            IntervalTime = 0.0;
        }

        public double IntervalTime
        {
            get { return intervalTime; }
            set
            {
                if(intervalTime != value)
                {
                    intervalTime = value;
                    Fire("IntervalTime");
                }
            }
        }

        public double ServiceTime
        {
            get { return serviceTime; }
            set
            {
                if (serviceTime != value)
                {
                    serviceTime = value;
                    Fire("ServiceTime");
                }
            }
        }

        public double NumberOfRequestsInQueue
        {
            get { return numberOfRequestsInQueue; }
            set
            {
                if (numberOfRequestsInQueue != value)
                {
                    numberOfRequestsInQueue = value;
                    Fire("NumberOfRequestsInQueue");
                }
            }
        }

        public double WaitingTimeInQueue
        {
            get { return waitingTimeInQueue; }
            set
            {
                if (waitingTimeInQueue != value)
                {
                    waitingTimeInQueue = value;
                    Fire("WaitingTimeInQueue");
                }
            }
        }

        public double NumberOfRequestsInSystem
        {
            get { return numberOfRequestsInSystem; }
            set
            {
                if (numberOfRequestsInSystem != value)
                {
                    numberOfRequestsInSystem = value;
                    Fire("NumberOfRequestsInSystem");
                }
            }
        }

        public double WaitingTimeInSystem
        {
            get { return waitingTimeInSystem; }
            set
            {
                if (waitingTimeInSystem != value)
                {
                    waitingTimeInSystem = value;
                    Fire("WaitingTimeInSystem");
                }
            }
        }

        public double AbsolutBandwidth
        {
            get { return absolutBandwidth; }
            set
            {
                if (absolutBandwidth != value)
                {
                    absolutBandwidth = value;
                    Fire("AbsolutBandwidth");
                }
            }
        }

        public double RelativeBandwidth
        {
            get { return relativeBandwidth; }
            set
            {
                if (relativeBandwidth != value)
                {
                    relativeBandwidth = value;
                    Fire("RelativeBandwidth");
                }
            }
        }

        public double UtilizationFactorOfSystem
        {
            get { return utilizationFactorOfSystem; }
            set
            {
                if (utilizationFactorOfSystem != value)
                {
                    utilizationFactorOfSystem = value;
                    Fire("UtilizationFactorOfSystem");
                }
            }
        }
       
        public void UpdateStatistics()
        {
            UtilizationFactorOfSystem = statistics.UtilizationFactorOfSystem;
            WaitingTimeInQueue = statistics.WaitingTimeInQueue.Result;
            WaitingTimeInSystem = statistics.WaitingTimeInSystem.Result;
            ServiceTime = statistics.ServiceTime.Result;
            RelativeBandwidth = statistics.RelativeBandwidth;
            AbsolutBandwidth = statistics.AbsolutBandwidth;
            IntervalTime = statistics.IntervalTime.Result;
            NumberOfRequestsInQueue = statistics.NumberOfRequestsInQueue.Result;
            NumberOfRequestsInSystem = statistics.NumberOfRequestsInSystem.Result;
        }
    }
}

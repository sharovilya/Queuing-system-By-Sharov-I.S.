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
       
        public StatisticsView(ISystemStatistics statistics, ISystemClock clock)
        {
            this.statistics = statistics;
            clock.TickEvent += ClockTickEvent;
        }

        void ClockTickEvent(object sender, EventArgs e)
        {
            GetType()
                .GetProperties()
                .ToList()
                .ForEach(p=> Fire(p.Name));
        }

        public double IntervalTime
        {
            get { return statistics.IntervalTime.Result; }
        }

        public double ServiceTime
        {
            get { return statistics.ServiceTime.Result; }
        }

        public double NumberOfRequestsInQueue
        {
            get { return statistics.NumberOfRequestsInQueue.Result; }
        }

        public double WaitingTimeInQueue
        {
            get { return statistics.WaitingTimeInQueue.Result; }
        }

        public double NumberOfRequestsInSystem
        {
            get { return statistics.NumberOfRequestsInSystem.Result; }
        }

        public double WaitingTimeInSystem
        {
            get { return statistics.WaitingTimeInSystem.Result; }
        }

        public double AbsolutBandwidth
        {
            get { return statistics.AbsolutBandwidth; }
        }

        public double RelativeBandwidth
        {
            get { return statistics.RelativeBandwidth; }
        }

        public double UtilizationFactorOfSystem
        {
            get { return statistics.UtilizationFactorOfSystem; }
        }
    }
}

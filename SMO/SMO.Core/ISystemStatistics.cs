using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public interface ISystemStatistics
    {
        AverageScore IntervalTime { get; }
        AverageScore ServiceTime { get; }
        AverageScore NumberOfRequestsInQueue { get; }
        AverageScore WaitingTimeInQueue { get; }
        AverageScore NumberOfRequestsInSystem { get; }
        AverageScore WaitingTimeInSystem { get; }

        double AbsolutBandwidth { get; }
        double RelativeBandwidth { get; }
        double UtilizationFactorOfSystem { get; }

        void UpdateRelativeBandwidth(int countRejectedRequests, int countRequestsCaughtInSystem);

        void Reset();
    }
}

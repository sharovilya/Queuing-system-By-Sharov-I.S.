using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public interface ISystemGenerator
    {
        int NextProcessingTime { get; }
        int NextIntervalTime { get; }

        int GetTimeFor(int countRequest);

        void SetAvgProcessingTime(int processingTime);

        void SetAvgIntervalTime(int intervalTime);
        void Reset();
    }
}

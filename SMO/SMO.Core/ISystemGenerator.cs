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
        int AvgIntervalTime { get; set; }
        int AvgProcessingTime { get; set; }

        int GetTimeFor(int countRequest);
        void Reset();
    }
}

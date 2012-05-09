using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core.Tests
{
    public class MockSystemGenerator : ISystemGenerator
    {
        public int NextProcessingTime { get; private set; }

        public int NextIntervalTime { get; private set; }


        public int GetTimeFor(int countRequest)
        {
            return NextProcessingTime * countRequest + countRequest;
        }

        public void SetAvgProcessingTime(int processingTime)
        {
            NextProcessingTime = processingTime;
        }

        public void SetAvgIntervalTime(int intervalTime)
        {
            NextIntervalTime = intervalTime;
        }

        public void Reset()
        {
            
        }
    }
}

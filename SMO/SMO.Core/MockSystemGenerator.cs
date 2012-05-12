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

        public int AvgIntervalTime
        {
            get { return NextIntervalTime; }
            set { NextIntervalTime = value; }
        }

        public int AvgProcessingTime
        {
            get { return NextProcessingTime; }
            set { NextProcessingTime = value; }
        }

        public int GetTimeFor(int countRequest)
        {
            return NextProcessingTime * countRequest + countRequest;
        }

        public void Reset()
        {
            
        }
    }
}

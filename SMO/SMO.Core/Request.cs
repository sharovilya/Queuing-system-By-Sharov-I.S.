using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public class Request : IRequest
    {
        public Request(int timeBorn, int processingTime, int countInSystem)
        {
            TimeBorn = timeBorn;
            ProcessingTime = processingTime;
            CountInSystem = countInSystem;
        }
        
        public override int GetHashCode()
        {
            return TimeBorn.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }

        public int TimeBorn
        {
            get;
            private set;
        }

        public static IRequest New(int timeBorn, int processingTime, int countInSystem)
        {
            return new Request(timeBorn, processingTime, countInSystem);
        }

        public int ProcessingTime
        {
            get;
            private set;
        }

        public int CountInSystem
        {
            get;
            private set;
        }
    }
}

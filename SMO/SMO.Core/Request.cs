using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public class Request : IRequest
    {
        public Request(int timeBorn)
        {
            TimeBorn = timeBorn;
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

        public static IRequest New(int timeBorn)
        {
            return new Request(timeBorn);
        }
    }
}

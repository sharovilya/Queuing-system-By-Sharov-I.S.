using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMO.Core
{
    public class RequestEventArg : EventArgs
    {
        public RequestEventArg(int timeBorn, int nextTimeForNewRequest, int countGeneratedRequest)
        {
            TimeBorn = timeBorn;
            NextTimeForNewRequest = nextTimeForNewRequest;
            CountRequestsCaughtInSystem = countGeneratedRequest;
        }

        public int TimeBorn { get; private set; }
        public int NextTimeForNewRequest { get; private set; }
        public int CountRequestsCaughtInSystem { get; private set; }
    }
}

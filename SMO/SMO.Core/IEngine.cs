using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    
    public interface IEngine
    {
        void GenerateNewRequest();

        event EventHandler<RequestEventArg> NewRequestEvent;

        int NextTimeForNewRequest { get; }

        int CountGeneratedRequest { get; }
        
        double AverageInterval { get; }

        void Stop();
    }
}

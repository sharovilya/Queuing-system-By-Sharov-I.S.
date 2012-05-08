using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    
    public interface IEngine
    {
        void GenerateNewRequest();

        event EventHandler<NewRequestEventArg> NewRequestEvent;

        int NextTimeForNewRequest { get; }

        int CountGeneratedRequest { get; }

        void Stop();
    }
}

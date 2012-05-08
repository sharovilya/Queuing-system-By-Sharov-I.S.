using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public interface IRandomGenerator
    {
        int Next { get; }

        int GetTimeFor(int countRequest);
    }
}

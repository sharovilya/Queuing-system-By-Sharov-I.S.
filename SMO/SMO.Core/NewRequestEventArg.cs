using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMO.Core
{
    public class NewRequestEventArg : EventArgs
    {
        public NewRequestEventArg(int timeBorn)
        {
            TimeBorn = timeBorn;
        }

        public int TimeBorn { get; private set; }
    }
}

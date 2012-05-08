using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMO.Core
{
    public class RandomGenerator : IRandomGenerator
    {
        private Random random = new Random();

        public int Next
        {
            get
            {
               return random.Next(10);
            }
        }

        public int GetTimeFor(int countRequest)
        {
            return -1;
            //throw new NotImplementedException();
        }
    }
}

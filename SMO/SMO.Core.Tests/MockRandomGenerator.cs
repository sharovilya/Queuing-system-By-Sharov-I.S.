using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core.Tests
{
    public class MockRandomGenerator : IRandomGenerator
    {
        public int Next
        {
            get { return 2; }
        }


        public int GetTimeFor(int countRequest)
        {
            return Next * countRequest + countRequest;
        }
    }
}

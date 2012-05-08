using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public interface IDisciplineQueuingSystem
    {
        void Put(IRequest r1);

        IRequest PullOut();

        bool IsFull { get; }

        long CountRequestsInQueue { get; }

        bool IsEmpty { get; }
    }
}

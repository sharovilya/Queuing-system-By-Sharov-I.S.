using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public interface ISystemDiscipline
    {
        void Put(Request r1);
        Request PullOut();
        bool IsFull { get; }
        int CountRequestsInQueue { get; }
        bool IsEmpty { get; }
        int TotalSize { get; set; }
        List<Request> Children { get; }
        void Reset();
    }
}

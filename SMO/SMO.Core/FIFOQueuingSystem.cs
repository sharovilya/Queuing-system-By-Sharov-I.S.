using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public class FIFOQueuingSystem : IDisciplineQueuingSystem   
    {
        private LinkedList<IRequest> requests = new LinkedList<IRequest>();

        public int TotalSize
        {
            get;
            set;
        }

        public void Reset()
        {
           requests.Clear();
        }

        public long CountRequestsInQueue
        {
            get { return requests.Count; }
        }
        
        public FIFOQueuingSystem()
        {
            // TODO переделать
            TotalSize = 10;
        }

        public void Put(IRequest r)
        {
            if (CountRequestsInQueue > TotalSize)
                throw new InvalidOperationException("Queue is full!");
            requests.AddLast(r);
        }

        public IRequest PullOut()
        {
            IRequest request = requests.First();
            requests.RemoveFirst();
            return request;
        }

        public bool IsFull
        {
            get
            {
                return TotalSize == CountRequestsInQueue;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return CountRequestsInQueue == 0;
            }
        }
    }
}

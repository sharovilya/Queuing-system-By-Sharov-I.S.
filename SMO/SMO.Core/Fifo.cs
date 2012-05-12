using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public class Fifo : ISystemDiscipline   
    {
        private readonly LinkedList<Request> requests = new LinkedList<Request>();

        public int TotalSize
        {
            get;
            set;
        }

        public List<Request> Children
        {
            get { return requests.ToList(); }
        }

        public void Reset()
        {
           requests.Clear();
        }

        public int CountRequestsInQueue
        {
            get { return requests.Count; }
        }
        
        public Fifo()
        {
            // TODO переделать
            TotalSize = 10;
        }

        public void Put(Request r)
        {
            if (CountRequestsInQueue > TotalSize)
                throw new InvalidOperationException("Queue is full!");
            requests.AddLast(r);
        }

        public Request PullOut()
        {
            Request request = requests.First();
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

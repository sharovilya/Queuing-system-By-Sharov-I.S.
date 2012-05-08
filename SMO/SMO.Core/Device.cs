using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public class Device : IDevice
    {
        static int id = 0;

        private int currentRequestProcessingTime;
        private int requestProcessingTime;
        private IRequest processingRequest;
        private IRandomGenerator generator;
        
        int i;

        public Device(ISystemClock clock, IRandomGenerator generator)
        {
            this.generator = generator;
            clock.TickEvent += OnTickEvent;
        
            i = id++;
        }

        private void OnTickEvent(object sender, EventArgs e)
        {
            if (!IsFree)
            {
                if (requestProcessingTime == currentRequestProcessingTime++)
                {
                    RequestHandledEvent.Raise(this, e);
                    Release();
                    Console.WriteLine(i + " Event handled " + requestProcessingTime);
                }
            }
        }

        public event EventHandler<EventArgs> RequestHandledEvent;

        public bool IsFree
        {
            get { return processingRequest == null; }
        }

        public void Take(IRequest request)
        {
            processingRequest = request;
            currentRequestProcessingTime = 0;
            requestProcessingTime = generator.Next;
        }

        public void Release()
        {
            processingRequest = null;
        }

        public int Time
        {
            get { return 0; }
        }
    }
}

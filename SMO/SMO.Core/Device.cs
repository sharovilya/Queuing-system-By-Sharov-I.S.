using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMO.Core
{
    public class Device : IDevice
    {
        private int currentRequestProcessingTime;
        private IRequest processingRequest;

        public Device(ISystemClock clock)
        {
            clock.TickEvent += OnTickEvent;
        }

        private void OnTickEvent(object sender, EventArgs e)
        {
            if (!IsFree)
            {
                if (processingRequest.ProcessingTime == currentRequestProcessingTime++)
                {
                    var evetArgs = new RequestEventArg(
                        processingRequest.TimeBorn, 
                        processingRequest.ProcessingTime, 
                        processingRequest.CountInSystem
                        );
                    RequestHandledEvent.Raise(this, evetArgs);
                    Release();
                }
            }
        }

        public event EventHandler<RequestEventArg> RequestHandledEvent;

        public bool IsFree
        {
            get { return processingRequest == null; }
        }

        public void Take(IRequest request)
        {
            processingRequest = request;
            currentRequestProcessingTime = 0;
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

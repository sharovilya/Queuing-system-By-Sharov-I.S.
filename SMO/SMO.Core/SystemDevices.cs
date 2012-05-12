using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMO.Core
{
    public class SystemDevices : ISystemDevices
    {
        private List<Device> devices = new List<Device>();
        private ISystemClock clock;

        public SystemDevices(ISystemClock clock)
        {
            this.clock = clock;
        }

        public void Add(Device device)
        {
            devices.Add(device);
            device.RequestHandledEvent += OnRequestHandled;
        }

        private void OnRequestHandled(object sender, RequestEventArg e)
        {
            var handler = RequestHandledEvent;
            handler.Raise(sender, e);
        }

        public void TakeFreeDevice(Request request)
        {
            var device = devices.Find(d => d.IsFree);
            if (device != null)
            {
                device.Take(request);
            }
        }

        
        public bool ThereIsFreeDevice
        {
            get
            {
                return devices.Any(d => d.IsFree);
            }
        }

        public List<Device> Children
        {
            get { return devices; }
        }

        public int Count
        {
            get { return Children.Count; }
            set
            {
                devices.Clear();
                for (int i = 0; i < value; i++)
                {
                    Device newDevice = new Device(clock);
                    devices.Add(newDevice);
                    newDevice.RequestHandledEvent += OnRequestHandled;
                }
            }
        }

        public event EventHandler<RequestEventArg> RequestHandledEvent;

        public void Reset()
        {
            devices.ForEach(d => d.Release());
        }
    }
}

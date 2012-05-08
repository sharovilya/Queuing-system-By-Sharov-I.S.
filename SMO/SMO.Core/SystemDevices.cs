using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMO.Core
{
    public class SystemDevices : ISystemDevices
    {
        private List<IDevice> devices = new List<IDevice>();

        public void Add(IDevice device)
        {
            devices.Add(device);
            device.RequestHandledEvent += OnRequestHandled;
        }

        private void OnRequestHandled(object sender, EventArgs e)
        {
            var handler = HandledRequestEvent;
            handler.Raise(sender, e);
        }

        public void TakeFreeDevice(IRequest request)
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

        public event EventHandler<EventArgs> HandledRequestEvent;
    }
}

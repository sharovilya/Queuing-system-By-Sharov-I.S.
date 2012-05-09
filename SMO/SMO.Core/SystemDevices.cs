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

        private void OnRequestHandled(object sender, RequestEventArg e)
        {
            var handler = RequestHandledEvent;
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

        public event EventHandler<RequestEventArg> RequestHandledEvent;


        public void SetCountDevices(int countDevices)
        {
            devices.Clear();
            for (int i = 0; i < countDevices; i++)
            {
                IDevice newDevice = IoC.Resolve<IDevice>();
                devices.Add(newDevice);
                newDevice.RequestHandledEvent += OnRequestHandled;
            }
        }

        public void Reset()
        {
            devices.ForEach(d => d.Release());
        }
    }
}

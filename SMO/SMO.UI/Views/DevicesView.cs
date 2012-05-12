using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media;
using SMO.Core;

namespace SMO.UI.Views
{
    public class DevicesView : BaseView
    {
        private ISystemDevices devices;
        private ISystemClock clock;

        public DevicesView(ISystemClock clock, ISystemDevices devices)
        {
            this.devices = devices;
            this.clock = clock;

            Update();
        }

        public ObservableCollection<DeviceView> Devices
        {
            get; private set;
        }

        public void Update()
        {
            Devices = new ObservableCollection<DeviceView>(devices.Children.Select(d => new DeviceView(d, clock)));
            Fire("Devices");
        }
    }

    public class DeviceView : BaseView
    {
        private Device device;
        
        public DeviceView(Device device, ISystemClock clock)
        {
            this.device = device;
            clock.TickEvent += ClockTickEvent;
        }

        void ClockTickEvent(object sender, EventArgs e)
        {
            GetType()
                .GetProperties()
                .ToList()
                .ForEach(p => Fire(p.Name));
        }

        public int DeviceId
        {
            get { return device.Id; }
        }

        public SolidColorBrush IsFree

        {
            get { return new SolidColorBrush(device.IsFree ? Color.FromArgb(100, 255, 69, 0) : Color.FromRgb(255, 255, 0)); }
        }
 
        public int CurrentRequestState
        {
            get { return device.RequestState; }
        }

        public int CurrentRequestId
        {
            get { return device.RequestId; }
        }
    } 
}

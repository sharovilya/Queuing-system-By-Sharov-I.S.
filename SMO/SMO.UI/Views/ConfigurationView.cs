using System;
using System.Linq;
using Microsoft.Practices.Unity;
using SMO.Core;

namespace SMO.UI.Views
{
    public class ConfigurationView : BaseView
    {
        private readonly ISystemConfiguration configuration;

        public DevicesView DevicesView { get; set; }

        public ConfigurationView(ISystemConfiguration configuration, DevicesView view)
        {
            this.configuration = configuration;
            this.DevicesView = view;

            DefaultConfigure();
        }

        private void DefaultConfigure()
        {
            DeviceCount = 1;
            SizeQueue = 32;
            AvgIntervalTime = 10;
            AvgProcessingTime = 25;
        }

        public int SizeQueue
        {
            get { return configuration.Discipline.TotalSize; }
            set
            {
                configuration.Discipline.TotalSize = value;
                Fire("SizeQueue");
            }
        }

        public int AvgIntervalTime
        {
            get { return configuration.Generator.AvgIntervalTime; }
            set
            {
                configuration.Generator.AvgIntervalTime = value;
                Fire("AvgIntervalTime");
            }
        }

        public int AvgProcessingTime
        {
            get { return configuration.Generator.AvgProcessingTime; }
            set
            {
                configuration.Generator.AvgProcessingTime = value;
                Fire("AvgProcessingTime");
            }
        }

        public int DeviceCount
        {
            get { return configuration.Devices.Count; }

            set
            {
                configuration.Devices.Count = value;
                DevicesView.Update();
                Fire("DeviceCount");
            }
        }
    }
}
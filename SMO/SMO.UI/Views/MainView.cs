using System;
using System.ComponentModel;
using SMO.Core;
using SMO.UI.Views;

namespace SMO.UI
{
    public class BaseView : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void Fire(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class MainView : BaseView
    {
        private IQueuingSystem system;

        private string countDevice;
        private string countQueue;
        private string intervalTime;
        private string processingTime;

        public string CountDevice
        {
            get { return countDevice; } 
            set
            {
                if (countDevice != value)
                {
                    countDevice = value;
                    system.Devices.SetCountDevices(Int32.Parse(countDevice));
                    Fire("CountDevice");
                }

            }
        }

        public string CountQueue
        {
            get { return countQueue; }
            set
            {
                if (countQueue != value)
                {
                    countQueue = value;
                    system.Discipline.TotalSize = Int32.Parse(countQueue);
                    Fire("CountQueue");
                }
            }
        }

        public string IntervalTime
        {
            get { return intervalTime; }
            set
            {
                if (intervalTime != value)
                {
                    intervalTime = value;
                    system.Generator.SetAvgIntervalTime(Int32.Parse(intervalTime));
                    Fire("IntervalTime");
                }
            }
        }

        public string ProcessingTime
        {
            get { return processingTime; }
            set
            {
                if (processingTime != value)
                {
                    processingTime = value;
                    system.Generator.SetAvgProcessingTime(Int32.Parse(processingTime));
                    Fire("ProcessingTime");
                }
            }
        }

        public RunView RunView
        {
            get; set;
        }

        public StatisticsView StatisticsView { get; set; }

        public MainView()
        {
            system = IoC.Resolve<IQueuingSystem>();
            StatisticsView = new StatisticsView(); 
            RunView = new RunView(StatisticsView);

            CountDevice = "1";
            CountQueue = "32";
            IntervalTime = "10";
            ProcessingTime = "25";
        }
    }
}
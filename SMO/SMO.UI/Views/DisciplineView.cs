using System;
using System.Collections.ObjectModel;
using System.Linq;
using SMO.Core;

namespace SMO.UI.Views
{
    public class DisciplineView : BaseView
    {
        private readonly ISystemDiscipline discipline;

        public DisciplineView(ISystemDiscipline discipline, ISystemClock clock)
        {
            this.discipline = discipline;

            clock.TickEvent += ClockTickEvent;
            UpdateProperties();
        }

        public int CountRequest
        {
            get { return discipline.CountRequestsInQueue; }
        }

        public bool IsFull
        {
            get { return discipline.IsFull; }
        }

        public ObservableCollection<RequestView> Requests { get; private set; }

        private void ClockTickEvent(object sender, EventArgs e)
        {
            UpdateProperties();
        }

        private void UpdateProperties()
        {
            Requests = new ObservableCollection<RequestView>(discipline.Children.Select(r => new RequestView(r)).Take(20));

            GetType()
                .GetProperties()
                .ToList()
                .ForEach(p => Fire(p.Name));
        }
    }

    public class RequestView
    {
        private readonly Request request;

        public RequestView(Request request)
        {
            this.request = request;
        }

        public int Id
        {
            get { return request.CountInSystem; }
        }

        public int TimeBorn
        {
            get { return request.TimeBorn; }
        }
    }
}
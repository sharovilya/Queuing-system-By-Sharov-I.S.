using System;
using System.Threading.Tasks;
using System.Windows.Input;
using SMO.Core;
using SMO.UI.Views;

namespace SMO.UI
{
    public class RunView : BaseView
    {
        private readonly StatisticsView StatisticsView;
        private readonly ISystemClock clock;
        private readonly RelayCommand runCommand;
        private readonly IQueuingSystem system;

        private int modelingTime;
        private bool notRunning;

        private double progress;

        public RunView(StatisticsView statisticsView)
        {
            StatisticsView = statisticsView;

            ModelingTime = 10000;
            NotRunning = true;

            clock = IoC.Resolve<ISystemClock>();
            system = IoC.Resolve<IQueuingSystem>();

            runCommand = new RelayCommand(Run);
        }

        public int ModelingTime
        {
            get { return modelingTime; }
            set
            {
                if (modelingTime != value)
                {
                    modelingTime = value;
                    Fire("ModelingTime");
                }
            }
        }

        public double Progress
        {
            get { return progress; }
            set
            {
                if (progress != value)
                {
                    progress = value;
                    Fire("Progress");
                }
            }
        }

        public bool NotRunning
        {
            get { return notRunning; }
            set
            {
                if (notRunning != value)
                {
                    notRunning = value;
                    Fire("NotRunning");
                }
            }
        }

        public RelayCommand RunCommand
        {
            get { return runCommand; }
        }

        private void Run(object obj)
        {
            system.Reset();
            NotRunning = false;
            Task.Factory.StartNew(
                () =>
                    {
                        int time = 0;
                        while (modelingTime != time++)
                        {
                            clock.Tick();
                            Progress = time / (double)modelingTime * 100;
                            StatisticsView.UpdateStatistics();
                        }
                    }
                );

            NotRunning = true;
        }
    }


    public class RelayCommand : ICommand
    {
        #region Fields

        private readonly Predicate<object> canExecute;
        private readonly Action<object> execute;

        #endregion

        #region Constructors

        public RelayCommand(Action<object> execute) : this(execute, o => true)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this.execute = execute;
            this.canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        #endregion
    }
}
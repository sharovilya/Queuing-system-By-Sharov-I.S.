using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using SMO.Core;
using SMO.UI.Views;

namespace SMO.UI
{
    public class RunView : BaseView
    {
        private readonly ISystemClock clock;
        private readonly IQueuingSystem system;
        private readonly RelayCommand runCommand;
        private readonly RelayCommand stopCommand;
        private readonly RelayCommand continueCommand;
        private readonly RelayCommand resetCommand;
        
        private bool stopped;
        

        public RunView(IQueuingSystem system, ISystemClock clock)
        {
            this.clock = clock;
            this.system = system;
            runCommand = new RelayCommand(Run);
            stopCommand = new RelayCommand(Stop);
            continueCommand = new RelayCommand(Continue);
            resetCommand = new RelayCommand(Reset);
        }

        private void Reset(object obj)
        {
            stopped = true;
            system.Reset();
        }

        private void Continue(object obj)
        {
            stopped = false;
        }

        private void Stop(object obj)
        {
            stopped = true;
        }

        public RelayCommand ContinueCommand
        {
            get { return continueCommand; }
        }

        public RelayCommand ResetCommand
        {
            get { return resetCommand; }
        }

        public RelayCommand RunCommand
        {
            get { return runCommand; }
        }

        public RelayCommand StopCommand
        {
            get { return stopCommand; }
        }

        private void Run(object obj)
        {
            system.Reset();
            stopped = false;
            Task.Factory.StartNew(
                () => {
                        while (!stopped)
                        {
                            clock.Tick();
                            Thread.Sleep(10);
                        }
                    }
                );
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WebCrawler_WPF.AsyncCommands
{
    public class AsynchronousCommand : ICommand
    {

        private readonly Func<Task> command;
        private bool canExecute = true;
        public event EventHandler CanExecuteChanged;
        public bool CanExecute
        {
            get { return canExecute; }
            set
            {
                if (canExecute != value)
                {
                    canExecute = value;
                    EventHandler canExecuteChanged = CanExecuteChanged;
                    if (canExecuteChanged != null)
                    {
                        canExecuteChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public AsynchronousCommand(Func<Task> command)
        {
            this.command = command;
        }

        async void ICommand.Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }
        
        public Task ExecuteAsync(object parameter)
        {
            return command();
        }

        
        bool ICommand.CanExecute(object parameter)
        {
            return canExecute;
        }
        
    }
}

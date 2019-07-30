using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace INAH.Commands
{
    public class RelayCommand : ICommand
    {
        readonly Action<object> action;
        readonly Predicate<object> canExecute;

        public RelayCommand(Action<object> action, Predicate<object> canExecute = null)
        {
            if (action == null)
                throw new NullReferenceException("action");

            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            action.Invoke(parameter);
        }
    }
}

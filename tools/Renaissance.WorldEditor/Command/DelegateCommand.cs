using System;
using System.Windows.Input;

namespace Renaissance.WorldEditor.Command
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _executeAction;
        private readonly Func<object, bool> _canExecuteAction;
        public event EventHandler CanExecuteChanged;


        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }


        public DelegateCommand(Action<object> executeAction)
            : this(executeAction, (commandParameter) => true) { }


        public void Execute(object parameter)
            => _executeAction(parameter);

        public bool CanExecute(object parameter)
            => _canExecuteAction?.Invoke(parameter) ?? true;

        public void InvokeCanExecuteChanged()
            => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}

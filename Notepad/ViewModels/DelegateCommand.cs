using System.Windows.Input;

namespace Notepad.ViewModels
{
    class DelegateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private Action<object?>? _executeAction;

        private Func<object?, bool>? _canExecuteFunc;

        public DelegateCommand(Action<object?> executeAction)
        {
            _executeAction = executeAction;
        }

        public DelegateCommand(Action<object?> executeAction, Func<object?, bool> canExecuteFunc)
        {
            _executeAction = executeAction;
            _canExecuteFunc = canExecuteFunc;
        }

        public bool CanExecute(object? parameter)
        {
            if (_canExecuteFunc == null)
            {
                return true;
            }
            return _canExecuteFunc(parameter);
        }

        public void Execute(object? parameter)
        {
            _executeAction?.Invoke(parameter);
        }
    }
}

using System;
using System.Windows.Input;

namespace Win10TileEditor.Tree.Interaction {
    public class Command : ICommand {
        public event EventHandler CanExecuteChanged;

        private bool canExecute;
        private readonly Action<object> execute;

        public Command(bool canExecute, Action<object> execute) {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public Command(Action<object> execute)
            : this(true, execute) {
        }

        private void OnCanExecuteChanged() {
            var handler = CanExecuteChanged;
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecuteCommand {
            get { return canExecute; }
            set {
                if (value == canExecute)
                    return;

                canExecute = value;
                OnCanExecuteChanged();
            }
        }

        public bool CanExecute(object parameter) {
            return canExecute;
        }

        public void Execute(object parameter) {
            if (!CanExecute(parameter))
                throw new InvalidOperationException("Invalid command execution requested");

            execute(parameter);
        }
    }
}

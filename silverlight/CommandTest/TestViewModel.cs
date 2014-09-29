using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace CommandTest {

    public class TestViewModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        private string inputMessage;
        private string resultMessage;

        private ICommand testCommand;

        public string ResultMessage {
            get {
                return resultMessage;
            }
            set {
                resultMessage = value;
                OnPropertyChanged("ResultMessage");
            }
        }

        public string InputMessage {
            get {
                return inputMessage;
            }
            set {
                inputMessage = value;
                OnPropertyChanged("InputMessage");
            }
        }

        public void TestMethod() {
            ResultMessage = "Hello, " + InputMessage;
        }

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand Test {
            get {
                return testCommand ?? (testCommand = new TestCommand(this));
            }
        }
    }

    public class TestCommand : ICommand {
        
        private readonly TestViewModel viewModel;

        private bool canExecute = false;

        public TestCommand(TestViewModel viewModel) {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter) {
            var parameterIsNotNullOrEmpty = !string.IsNullOrEmpty((string)parameter);
            
            if (parameterIsNotNullOrEmpty != canExecute) {
                canExecute = parameterIsNotNullOrEmpty;
                OnCanExecuteChanged();
            }
            return canExecute;
        }

        public void Execute(object parameter) {
            viewModel.TestMethod();
        }

        public event EventHandler CanExecuteChanged;

        protected virtual void OnCanExecuteChanged() {
            var handler = CanExecuteChanged;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }
    }

}
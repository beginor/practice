using System.ComponentModel;

namespace Beginor.X2048.Models {

    public abstract class BaseModel : INotifyPropertyChanged {

        public virtual event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            var handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
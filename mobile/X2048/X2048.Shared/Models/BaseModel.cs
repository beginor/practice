using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Beginor.X2048.Models {

    public abstract class BaseModel : INotifyPropertyChanged {

        public virtual event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            var handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
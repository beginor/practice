using System.ComponentModel;

namespace Beginor.X2048.Models {

    public class TileViewModel : BaseModel {

        private int x;
        private int y;
        private int value;

        public int X {
            get {
                return x;
            }
            set {
                x = value;
                OnPropertyChanged("X");
            }
        }

        public int Y {
            get {
                return y;
            }
            set {
                y = value;
                OnPropertyChanged("Y");
            }
        }

        public int Value {
            get {
                return value;
            }
            set {
                this.value = value;
                OnPropertyChanged("Value");
            }
        }

        public TileViewModel(int x, int y, int value = 2) {
            X = x;
            Y = y;
            Value = value;
        }

    }
}

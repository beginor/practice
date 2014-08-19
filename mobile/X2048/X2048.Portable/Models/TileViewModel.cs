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

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != this.GetType()) {
                return false;
            }
            return Equals((TileViewModel)obj);
        }

        protected bool Equals(TileViewModel other) {
            return x == other.x && y == other.y && value == other.value;
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ Value;
                return hashCode;
            }
        }
    }
}

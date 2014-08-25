namespace Beginor.X2048.Models {

    public class TileViewModel : BaseModel {

        private Position position;
        private int value;

        public Position Position {
            get {
                return position;
            }
            set {
                position = value;
                OnPropertyChanged("Position");
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

        public TileViewModel(int x, int y, int value = 2) : this(new Position { X = x, Y = y }, value) {
        }

        public TileViewModel(Position position, int value = 2) {
            this.position = position;
            this.value = value;
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
            return position.Equals(other.position) && value == other.value;
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = position.GetHashCode();
                hashCode = (hashCode * 397) ^ Value;
                return hashCode;
            }
        }

        public override string ToString() {
            return string.Format("[TileViewModel: Position={0}, Value={1}]", Position, Value);
        }
    }
}

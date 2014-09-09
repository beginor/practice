namespace Beginor.X2048.Models {

    public class Position {

        public int X { get; set; }

        public int Y { get; set; }

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
            return Equals((Position)obj);
        }

        protected bool Equals(Position other) {
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode() {
            unchecked {
                return (X * 397) ^ Y;
            }
        }

        public Position Clone() {
            return new Position { X = X, Y = Y };
        }

        public override string ToString() {
            return string.Format("[X={0}, Y={1}]", X, Y);
        }
    }
}

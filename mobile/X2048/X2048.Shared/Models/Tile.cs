using System.ComponentModel;

namespace Beginor.X2048.Models {

    public class Tile : BaseModel {

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

        public Position PreviousPosition { get; set; }

        public Tile MergedFrom { get; set; }

        public Tile(Position position, int value = 2) {
            X = position.X;
            Y = position.Y;
            Value = value;

            PreviousPosition = null;
            MergedFrom = null;
        }

        public void SavePosition() {
            PreviousPosition = new Position { X = X, Y = Y };
        }

        public void UpdatePosition(Position position) {
            X = position.X;
            Y = position.Y;
        }

        public string Serialize() {
            return ""; //Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

    }
}

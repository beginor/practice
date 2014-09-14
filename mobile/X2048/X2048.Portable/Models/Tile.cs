using System;namespace Beginor.X2048.Models {

    public class Tile : BaseModel {

        public int X { get; private set; }

        public int Y { get; private set; }

        private Cell previousPosition;

        private int value;

        public int Value {
            get {
                return value;
            }
            set {
                this.value = value;
                OnPropertyChanged("Value");
            }
        }

        public Tile[] MergedFrom { get; set; }

        public event EventHandler PositionUpdated;

        public Tile(int x, int y, int value = 2) {
            this.X = x;
            this.Y = y;
            this.value = value;
        }

        public Tile(Cell cell, int value = 2) {
            X = cell.X;
            Y = cell.Y;
            this.value = value;
        }

        public void UpdatePosition(Cell cell) {
            X = cell.X;
            Y = cell.Y;
            OnPositionUpdated(EventArgs.Empty);
        }

        protected virtual void OnPositionUpdated(EventArgs e) {
            var handler = PositionUpdated;
            if (handler != null) {
                handler(this, e);
            }
        }

        public void SavePosition() {
            previousPosition = new Cell { X = X, Y = Y };
        }

        public bool PositionsEqual(Cell cell) {
            return cell.X == this.X &&
                   cell.Y == this.Y;
        }

        public override string ToString() {
            return string.Format("[Tile: X={0}, Y={1}, Value={2}]", X, Y, value);
        }
    }
}

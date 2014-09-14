namespace Beginor.X2048.Models {

    public class Cell {

        public int X { get; set; }

        public int Y { get; set; }

        public override string ToString() {
            return string.Format("[X={0}, Y={1}]", X, Y);
        }
    }
}

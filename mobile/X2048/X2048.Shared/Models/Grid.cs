namespace Beginor.X2048.Models {

    public class Grid {

        public int Size { get; set; }

        public Tile[] Cells { get; set; }

        public Grid(int size, Tile[] state = null) {
            Size = size;
            Cells = state != null ? FromState(state) : Empty();
        }

        private Tile[] Empty() {
            return new Tile[Size * Size];
        }

        private Tile[] FromState(Tile[] state) {
            var cells = new Tile[Size * Size];
            for (var x = 0; x < Size * Size; x++) {
                cells[x] = state[x];
            }
            return cells;
        }

        public bool CellOccupied(Tile cell) {
            return CellContent(cell) != null;
        }

        public Tile CellContent(Tile cell) {
            if (WithinBounds(new Position {X = cell.X, Y = cell.Y})) {
                return Cells[cell.X * Size + cell.Y];
            }
            return null;
        }

        public void InsertTile(Tile tile) {
            Cells[tile.X * Size + tile.Y] = tile;
        }

        public void RemoveTile(Position position) {
            Cells[position.X * Size + position.Y] = null;
        }

        public bool WithinBounds(Position position) {
            return position.X >= 0 && position.X <= Size &&
                   position.Y >= 0 && position.Y <= Size;
        }
    }

}

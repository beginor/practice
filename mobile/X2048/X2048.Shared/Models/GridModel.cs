namespace Beginor.X2048.Models {

    public class GridModel {

        public int Size { get; set; }

        public TileViewModel[] Cells { get; set; }

        public GridModel(int size, TileViewModel[] state = null) {
            Size = size;
            Cells = state != null ? FromState(state) : Empty();
        }

        private TileViewModel[] Empty() {
            return new TileViewModel[Size * Size];
        }

        private TileViewModel[] FromState(TileViewModel[] state) {
            var cells = new TileViewModel[Size * Size];
            for (var x = 0; x < Size * Size; x++) {
                cells[x] = state[x];
            }
            return cells;
        }

        public bool CellOccupied(TileViewModel cell) {
            return CellContent(cell) != null;
        }

        public TileViewModel CellContent(TileViewModel cell) {
            if (WithinBounds(new Position {X = cell.X, Y = cell.Y})) {
                return Cells[cell.X * Size + cell.Y];
            }
            return null;
        }

        public void InsertTile(TileViewModel tileViewModel) {
            Cells[tileViewModel.X * Size + tileViewModel.Y] = tileViewModel;
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

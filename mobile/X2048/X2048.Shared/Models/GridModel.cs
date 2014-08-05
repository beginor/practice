namespace Beginor.X2048.Models {

    public class GridModel {

        public int Size { get; set; }

        public TileModel[] Cells { get; set; }

        public GridModel(int size, TileModel[] state = null) {
            Size = size;
            Cells = state != null ? FromState(state) : Empty();
        }

        private TileModel[] Empty() {
            return new TileModel[Size * Size];
        }

        private TileModel[] FromState(TileModel[] state) {
            var cells = new TileModel[Size * Size];
            for (var x = 0; x < Size * Size; x++) {
                cells[x] = state[x];
            }
            return cells;
        }

        public bool CellOccupied(TileModel cell) {
            return CellContent(cell) != null;
        }

        public TileModel CellContent(TileModel cell) {
            if (WithinBounds(new Position {X = cell.X, Y = cell.Y})) {
                return Cells[cell.X * Size + cell.Y];
            }
            return null;
        }

        public void InsertTile(TileModel tileModel) {
            Cells[tileModel.X * Size + tileModel.Y] = tileModel;
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

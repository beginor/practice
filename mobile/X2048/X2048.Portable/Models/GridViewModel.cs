using System;
using System.Collections.Generic;

namespace Beginor.X2048.Models {

    public class GridViewModel : BaseModel {

        private Tile[][] cells;
        readonly int size;

        public event EventHandler TileChanged;

        public GridViewModel(int size) {
            this.size = size;
            Empty();
        }

        protected virtual void OnTileChanged(EventArgs e) {
            var handler = TileChanged;
            if (handler != null) {
                handler(this, e);
            }
        }

        public void Empty() {
            cells = new Tile[size][];
            for (var x = 0; x < size; x++) {
                Tiles[x] = new Tile[size];
            }
            OnTileChanged(EventArgs.Empty);
        }

        public void EachCell(Action<int, int, Tile> callback) {
            for (var x = 0; x < size; x++) {
                for (var y = 0; y < size; y++) {
                    callback(x, y, Tiles[x][y]);
                }
            }
        }

        public Cell RandomAvailableCell() {
            var availableCells = AvailableCells();
            if (availableCells.Count > 0) {
                return availableCells[(int)Math.Floor(AppConsts.Random.NextDouble() * availableCells.Count)];
            }
            return null;
        }

        public IList<Cell> AvailableCells() {
            var availableCells = new List<Cell>();
            EachCell((x, y, p) => {
                         if (p == null) {
                             availableCells.Add(new Cell {X = x, Y = y});
                         }
                     });
            return availableCells;
        }

        public bool CellsAvailable {
            get {
                return AvailableCells().Count > 0;
            }
        }

        public Tile[][] Tiles {
            get {
                return cells;
            }
        }

        public bool CellAvailable(Cell cell) {
            return !CellOccupied(cell);
        }

        bool CellOccupied(Cell cell) {
            return CellContent(cell) != null;
        }

        public Tile CellContent(Cell cell) {
            if (WithinBounds(cell)) {
                return Tiles[cell.X][cell.Y];
            }
            return null;
        }

        public void InsertTile(Tile tile) {
            Tiles[tile.X][tile.Y] = tile;
            OnTileChanged(EventArgs.Empty);
        }

        public void RemoveTile(Tile tile) {
            Tiles[tile.X][tile.Y] = null;
            OnTileChanged(EventArgs.Empty);
        }

        public bool WithinBounds(Cell cell) {
            return cell.X >= 0 && cell.X < size &&
                   cell.Y >= 0 && cell.Y < size;
        }

        public void MoveTile(Tile tile, Cell cell) {
            if (!tile.PositionsEqual(cell)) {
                cells[tile.X][tile.Y] = null;
                cells[cell.X][cell.Y] = tile;
                tile.UpdatePosition(cell);
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace Beginor.X2048.Models {

    public class GridViewModel : BaseModel {

        Position[][] cells;
        readonly int size;

        public GridViewModel(int size) {
            this.size = size;
            Empty();
        }

        void Empty() {
            cells = new Position[size][];
            for (var x = 0; x < size; x++) {
                cells[x] = new Position[size];
            }
        }

        void EachCell(Action<int, int, Position> callback) {
            for (var x = 0; x < size; x++) {
                for (var y = 0; y < size; y++) {
                    callback(x, y, cells[x][y]);
                }
            }
        }

        public IList<Position> AvailableCells {
            get {
                var availableCells = new List<Position>();
                EachCell((x, y, p) => {
                    if (p == null) {
                        availableCells.Add(new Position { X = x, Y = y });
                    }
                });
                return availableCells;
            }
        }

        bool CellsAvailable {
            get {
                return AvailableCells.Count > 0;
            }
        }

        bool CellAvailable(Position cell) {
            return !CellOccupied(cell);
        }

        bool CellOccupied(Position cell) {
            return CellContent(cell) != null;
        }

        Position CellContent(Position cell) {
            if (WithinBounds(cell)) {
                return cells[cell.X][cell.Y];
            }
            return null;
        }

        void InsertTile(Position tile) {
            cells[tile.X][tile.Y] = tile;
        }

        void RemoveTile(Position tile) {
            cells[tile.X][tile.Y] = null;
        }

        bool WithinBounds(Position position) {
            return position.X >= 0 && position.X < size &&
                   position.Y >= 0 && position.Y < size;
        }
    }
}
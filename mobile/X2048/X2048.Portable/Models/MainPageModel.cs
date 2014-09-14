using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Beginor.X2048.Models {

    public class MainPageModel : BaseModel {

        private static readonly int StartTiles = 2;

        private readonly Random random = new Random(Environment.TickCount);

        private int score;
        private int best;
        private ICommand newGameCommand;
        private bool won;
        private bool over;

        private GridViewModel grid;

        public GridViewModel Grid {
            get {
                return grid;
            }
        }

        public bool Over {
            get {
                return over;
            }
            set {
                over = value;
                OnPropertyChanged("Over");
            }
        }

        public bool Won {
            get {
                return won;
            }
            set {
                won = value;
                OnPropertyChanged("Won");
            }
        }

        public int Best {
            get {
                return best;
            }
            set {
                best = value;
                OnPropertyChanged("Best");
            }
        }

        public int Score {
            get {
                return score;
            }
            set {
                score = value;
                OnPropertyChanged("Score");
            }
        }

        public ICommand NewGameCommand {
            get {
                return newGameCommand ?? (newGameCommand = new Command(StartNewGame));
            }
        }

        public MainPageModel() {
            grid = new GridViewModel(AppConsts.TileCount);
            score = 0;
            over = false;
            won = false;
        }

        public void StartNewGame() {
            grid.Empty();
            for (var i = 0; i < StartTiles; i++) {
                AddRandomTile();
            }
        }

        private void AddRandomTile() {
            if (grid.CellsAvailable) {
                var val = random.NextDouble() < 0.9 ? 2 : 4;
                var tile = new Tile(grid.RandomAvailableCell(), val);
                grid.InsertTile(tile);
            }
        }

        void PrepareTiles() {
            grid.EachCell((x, y, tile) => {
                if (tile != null) {
                    tile.MergedFrom = null;
                    tile.SavePosition();
                }
            });
        }



        public void Move(Vector vector) {
            // if (this.isGameTerminated()) return;

            var traversals = Traversals.FromVector(vector);
            var moved = false;

            PrepareTiles();

            foreach (var x in traversals.X) {
                foreach (var y in traversals.Y) {
                    var cell = new Cell { X = x, Y = y };
                    var tile = grid.CellContent(cell);

                    if (tile != null) {
                        var positions = FindFarthestPosition(cell, vector);
                        var next = grid.CellContent(positions.Next);

                        if (next != null && next.Value == tile.Value && next.MergedFrom == null) {


                            //grid.RemoveTile(tile);
                            // Converge the two tiles' positions
                            //tile.UpdatePosition(positions.Next);
                            grid.RemoveTile(tile);
                            grid.RemoveTile(next);

                            var merged = new Tile(next.X, next.Y, tile.Value * 2);
                            merged.MergedFrom = new[] { tile, next };
                            grid.InsertTile(merged);

                            Score += merged.Value;

                            if (merged.Value == 2048) {
                                Won = true;
                            }
                        }
                        else {
                            grid.MoveTile(tile, positions.Farthest);
                        }

                        if (!tile.PositionsEqual(cell)) {
                            moved = true;
                        }
                    }
                }
            }

            if (moved) {
                AddRandomTile();
                if (!MovesAvailable()) {
                    Over = true; // game over;
                }
            }

            //this.actuate();
        }

        private FarthestPosition FindFarthestPosition(Cell p, Vector v) {
            Cell cell = p;
            Cell prev;

            do {
                prev = cell;
                cell = new Cell { X = prev.X + v.X, Y = prev.Y + v.Y };
            }
            while (grid.WithinBounds(cell) && grid.CellAvailable(cell));

            return new FarthestPosition {
                Farthest = prev,
                Next = cell
            };
        }

        private bool MovesAvailable() {
            var cellsAvailable = grid.CellsAvailable;
            var matchesAvailable = TileMatchesAvailable();
            return cellsAvailable || matchesAvailable;
        }

        private bool TileMatchesAvailable() {
            for (var x = 0; x < AppConsts.TileCount; x++) {
                for (var y = 0; y < AppConsts.TileCount; y++) {
                    var tile = grid.CellContent(new Cell { X = x, Y = y });
                    if (tile != null) {
                        var p1 = tile;
                        for (var idx = 0; idx < 4; idx++) {
                            var v = Vector.FromInt(idx);
                            var p2 = new Cell {
                                X = p1.X + v.X,
                                Y = p1.Y + v.Y
                            };
                            var other = grid.CellContent(p2);
                            if (other != null && other.Value == tile.Value) {
                                return true; // These two tiles can be merged
                            }
                        }
                    }
                }
            }
            return false;
        }

    }
}

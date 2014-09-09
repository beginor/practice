using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Beginor.X2048.Models {

    public class MainPageModel : BaseModel {

        private static readonly int InitTileCount = 2;

        private readonly Random random = new Random(Environment.TickCount);
        private readonly TileViewModel[,] tiles = new TileViewModel[AppConsts.TileCount, AppConsts.TileCount];
        private readonly Position[,] positions = new Position[AppConsts.TileCount, AppConsts.TileCount];

        public event EventHandler TileChanged;

        private int score;
        private int best;
        private ICommand newGameCommand;
        private bool won;
        private bool over;

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

        protected virtual void OnTileChanged() {
            var handler = TileChanged;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private IList<Position> AvailableCells() {
            var cells = new List<Position>();
            EachCell((x, y, p) => {
                if (p != null) {
                    cells.Add(p);
                }
            });
            return cells;
        }

        private void EachTile(Action<int, int, TileViewModel> callback) {
            for (var x = 0; x < AppConsts.TileCount; x++) {
                for (var y = 0; y < AppConsts.TileCount; y++) {
                    callback(x, y, tiles[x, y]);
                }
            }
        }

        public IList<TileViewModel> AvailableTiles() {
            var avaiableTiles = new List<TileViewModel>();
            EachTile((x, y, t) => {
                if (t != null) {
                    avaiableTiles.Add(t);
                }
            });
            return avaiableTiles;
        }

        private void EachCell(Action<int, int, Position> callback) {
            for (var x = 0; x < AppConsts.TileCount; x++) {
                for (var y = 0; y < AppConsts.TileCount; y++) {
                    callback(x, y, positions[x, y]);
                }
            }
        }

        public void StartNewGame() {
            InitEmptyCells();

            for (var i = 0; i < InitTileCount; i++) {
                var val = random.NextDouble() > 0.9 ? 4 : 2;
                GenerateRandomTile(val);
            }

            OnTileChanged();
        }

        private void InitEmptyCells() {
            EachTile((x, y, t) => {
                tiles[x, y] = null;
            });

            EachCell((x, y, p) => {
                positions[x, y] = new Position {
                    X = x, Y = y
                };
            });
        }

        private TileViewModel GenerateRandomTile(int value) {
            var availableCells = AvailableCells();
            if (availableCells.Count == 0) {
                return null;
            }
            var cell = availableCells[random.Next(0, availableCells.Count)];

            var tile = new TileViewModel(cell.X, cell.Y, value);

            positions[tile.Position.X, tile.Position.Y] = null;
            tiles[tile.Position.X, tile.Position.Y] = tile;

            return tile;
        }

        private void MoveTile(TileViewModel tile, Position cell) {
            positions[cell.X, cell.Y] = null;
            tiles[cell.X, cell.Y] = tile;

            positions[tile.Position.X, tile.Position.Y] = tile.Position.Clone();
            tiles[tile.Position.X, tile.Position.Y] = null;

            tile.Position = cell;
        }

        public void Move(Vector vector) {
            // if (this.isGameTerminated()) return;
            Position cell;
            TileViewModel tile;

            var traversals = Traversals.FromVector(vector);
            var moved = false;

            //this.prepareTiles();

            foreach (var x in traversals.X) {
                foreach (var y in traversals.Y) {
                    cell = new Position { X = x, Y = y };
                    tile = CellContent(cell);

                    if (tile != null) {
                        var farthest = FindFarthestPosition(cell, vector);
                        var next = CellContent(farthest.Next);

                        if (next != null && next.Value == tile.Value /* && !next.mergedFrom */) {
                            var merged = new TileViewModel(next.Position, tile.Value * 2);

                            tiles[tile.Position.X, tile.Position.Y] = null;
                            positions[tile.Position.X, tile.Position.Y] = tile.Position.Clone();
                            tiles[next.Position.X, tile.Position.Y] = null;
                            positions[next.Position.X, next.Position.Y] = next.Position.Clone();

                            tiles[merged.Position.X, merged.Position.Y] = merged;
                            positions[merged.Position.X, merged.Position.Y] = null;

                            OnTileChanged();

                            if (tile.Value == 2048) {
                                Won = true;
                            }
                        }
                        else {
                            MoveTile(tile, farthest.Farthest);
                        }

                        if (!PositionsEqual(cell, tile)) {
                            moved = true;
                        }
                    }
                }
            }

            if (moved) {
                AddRandomTile();
                if (!MovesAvailable()) {
                    this.Over = true; // game over;
                }
            }

            //this.actuate();
        }

        private void AddRandomTile() {
            var tile = GenerateRandomTile(random.NextDouble() > 0.9 ? 4 : 2);
            if (tile != null) {
                OnTileChanged();
            }
        }

        private bool PositionsEqual(Position cell, TileViewModel tile) {
            return cell.X == tile.Position.X &&
                   cell.Y == tile.Position.Y;
        }

        private FarthestPosition FindFarthestPosition(Position p, Vector v) {
            Position cell = p;
            Position prev;

            do {
                prev = cell;
                cell = new Position { X = prev.X + v.X, Y = prev.Y + v.Y };
            }
            while (WithinBounds(cell) && PositionAvailable(cell));

            return new FarthestPosition {
                Farthest = prev,
                Next = cell
            };
        }

        private bool PositionAvailable(Position p) {
            return positions[p.X, p.Y] != null;
        }

        private bool MovesAvailable() {
            return AvailableCells().Count > 0 && TileMatchesAvailable();
        }

        private bool TileMatchesAvailable() {
            for (var x = 0; x < AppConsts.TileCount; x++) {
                for (var y = 0; y < AppConsts.TileCount; y++) {
                    var tile = tiles[x, y];
                    if (tile != null) {
                        var p1 = tile.Position;
                        for (var idx = 0; idx < 4; idx++) {
                            var v = Vector.FromInt(idx);
                            var p2 = new Position {
                                X = p1.X + v.X,
                                Y = p1.Y + v.Y
                            };
                            var other = CellContent(p2);
                            if (other != null && other.Value == tile.Value) {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool WithinBounds(Position p) {
            return p.X >= 0 && p.X < AppConsts.TileCount &&
                   p.Y >= 0 && p.Y < AppConsts.TileCount;
        }

        private TileViewModel CellContent(Position p) {
            if (WithinBounds(p)) {
                return tiles[p.X, p.Y];
            }
            return null;
        }
    }
}

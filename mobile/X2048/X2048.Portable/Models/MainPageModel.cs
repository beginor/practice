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
            var cell = availableCells[random.Next(0, availableCells.Count)];

            var tile = new TileViewModel(cell.X, cell.Y, value);

            positions[tile.Position.X, tile.Position.Y] = null;
            tiles[tile.Position.X, tile.Position.Y] = tile;

            return tile;
        }

        private void MoveTile(TileViewModel tile, Position cell) {
            positions[cell.X, cell.Y] = null;
            tiles[tile.Position.X, tile.Position.Y] = null;
            tiles[cell.X, cell.Y] = tile;
            tile.Position = cell;
        }

        public void Move(Vector vector) {

        }
    }

    public class Vector {

        public int X { get; private set; }
        public int Y { get; private set; }

        public Vector(int x, int y) {
            X = x;
            Y = y;
        }

    }
}

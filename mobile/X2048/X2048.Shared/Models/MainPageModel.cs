using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Beginor.X2048.Models {

    public class MainPageModel : BaseModel {

        private static readonly int InitTileCount = 2;
        
        private IList<Position> emptyCells;
        private Random random = new Random(Environment.TickCount);

        private readonly ObservableCollection<TileViewModel> tiles = new ObservableCollection<TileViewModel>();
        private int score;
        private int highest;
        private ICommand newGameCommand;

        public int Highest {
            get {
                return highest;
            }
            set {
                highest = value;
                OnPropertyChanged("Highest");
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

        public ObservableCollection<TileViewModel> Tiles {
            get {
                return tiles;
            }
        }

        public ICommand NewGameCommand {
            get {
                return newGameCommand ?? (newGameCommand = new Command(StartNewGame));
            }
        }

        public void StartNewGame() {
            while (Tiles.Count > 0) {
                Tiles.RemoveAt(0);
            }

            InitEmptyCells();

            var rand = new Random();
            for (int i = 0; i < InitTileCount; i++) {
                Tiles.Add(GenerateRandomTile(rand.NextDouble() > 0.9 ? 4 : 2));
            }
        }

        private void InitEmptyCells() {
            if (emptyCells != null) {
                emptyCells.Clear();
            }
            emptyCells = new List<Position>();
            for (var x = 0; x < App.Consts.TileCount; x++) {
                for (var y = 0; y < App.Consts.TileCount; y++) {
                    var p = new Position {X = x, Y = y};
                    emptyCells.Add(p);
                }
            }
        }

        private TileViewModel GenerateRandomTile(int value) {
            var cell = emptyCells[random.Next(0, emptyCells.Count)];
            emptyCells.Remove(cell);

            var tile = new TileViewModel(cell.X, cell.Y, value);
            return tile;
        }

    }
}

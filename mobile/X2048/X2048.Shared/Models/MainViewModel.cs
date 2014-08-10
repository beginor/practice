using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Beginor.X2048.Models {

    public class MainPageModel : BaseModel {

        private static readonly int InitTileCount = 2;

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
            Tiles.Clear();
            var rand = new Random();
            for (int i = 0; i < InitTileCount; i++) {
                Tiles.Add(GenerateRandomTile(rand.NextDouble() > 0.9 ? 4 : 2));
            }
        }

        private TileViewModel GenerateRandomTile(int value) {
            var tile = new TileViewModel(0, 0, value);
            return tile;
        }

    }
}

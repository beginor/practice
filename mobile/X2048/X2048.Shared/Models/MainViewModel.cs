using System.Collections.ObjectModel;

namespace Beginor.X2048.Models {

    public class MainPageModel : BaseModel {

        private readonly ObservableCollection<TileViewModel> tiles = new ObservableCollection<TileViewModel>();
        private int score;
        private int highest;

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
    }
}

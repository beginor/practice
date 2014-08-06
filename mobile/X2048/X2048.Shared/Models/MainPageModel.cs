using System.Collections.ObjectModel;

namespace Beginor.X2048.Models {

    public class MainPageModel : BaseModel {

        private readonly ObservableCollection<TileViewModel> tiles = new ObservableCollection<TileViewModel>();

        public ObservableCollection<TileViewModel> Tiles {
            get {
                return tiles;
            }
        }
    }
}

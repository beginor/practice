using Xamarin.Forms;
using Beginor.X2048.Models;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Beginor.X2048.Views {

    public partial class TileView : ContentView {

        public Tile ViewModel {
            get {
                return BindingContext as Tile;
            }
            set {
                BindingContext = value;
            }
        }

        protected override void OnBindingContextChanged() {
            base.OnBindingContextChanged();
            if (ViewModel != null) {
                UpdateBounds();
                ViewModel.PositionUpdated += OnViewModelPositionUpdated;
            }
        }

        public TileView() {
            InitializeComponent();
        }

        async void OnViewModelPositionUpdated(object sender, System.EventArgs e) {
            await UpdateBoundsAsync();
        }

        private void UpdateBounds() {
            var pos = (Tile)BindingContext;
            var rect = new Rectangle(pos.X * AppConsts.TileSize, pos.Y * AppConsts.TileSize, AppConsts.TileSize, AppConsts.TileSize);
            AbsoluteLayout.SetLayoutBounds(this, rect);
        }

        private async Task UpdateBoundsAsync() {
            var pos = (Tile)BindingContext;
            var rect = new Rectangle(pos.X * AppConsts.TileSize, pos.Y * AppConsts.TileSize, AppConsts.TileSize, AppConsts.TileSize);
            await this.LayoutTo(rect);
            AbsoluteLayout.SetLayoutBounds(this, rect);
        }
    }
}


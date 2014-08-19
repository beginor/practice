using Xamarin.Forms;
using Beginor.X2048.Models;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Beginor.X2048.Views {

    public partial class TileView : ContentView {

        public TileView() {
            InitializeComponent();
            var viewModel = BindingContext as TileViewModel;
            if (viewModel != null) {
                UpdateBounds();
                viewModel.PropertyChanged += OnViewModelPropertyChanged;
            }
        }

        private async void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (e.PropertyName == "X" || e.PropertyName == "Y") {
                await UpdateBoundsAsync();
            }
        }

        private void UpdateBounds() {
            var model = (TileViewModel)BindingContext;
            var rect = new Rectangle(model.X * AppConsts.TileSize, model.Y * AppConsts.TileSize, AppConsts.TileSize, AppConsts.TileSize);
            AbsoluteLayout.SetLayoutBounds(this, rect);
        }

        private async Task UpdateBoundsAsync() {
            var model = (TileViewModel)BindingContext;
            var rect = new Rectangle(model.X * AppConsts.TileSize, model.Y * AppConsts.TileSize, AppConsts.TileSize, AppConsts.TileSize);
            await this.LayoutTo(rect);
            AbsoluteLayout.SetLayoutBounds(this, rect);
        }
    }
}


using Xamarin.Forms;
using Beginor.X2048.Models;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Beginor.X2048.Views {

    public partial class TileView : ContentView {

        public TileViewModel ViewModel {
            get {
                return BindingContext as TileViewModel;
            }
            set {
                BindingContext = value;
            }
        }

        protected override void OnBindingContextChanged() {
            base.OnBindingContextChanged();
            if (ViewModel != null) {
                UpdateBounds();
                ViewModel.PropertyChanged += OnViewModelPropertyChanged;
            }
        }

        public TileView() {
            InitializeComponent();
        }

        private async void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (e.PropertyName == "Position") {
                await UpdateBoundsAsync();
            }
        }

        private void UpdateBounds() {
            var model = (TileViewModel)BindingContext;
            var pos = model.Position;
            var rect = new Rectangle(pos.X * AppConsts.TileSize, pos.Y * AppConsts.TileSize, AppConsts.TileSize, AppConsts.TileSize);
            AbsoluteLayout.SetLayoutBounds(this, rect);
        }

        private async Task UpdateBoundsAsync() {
            var model = (TileViewModel)BindingContext;
            var pos = model.Position;
            var rect = new Rectangle(pos.X * AppConsts.TileSize, pos.Y * AppConsts.TileSize, AppConsts.TileSize, AppConsts.TileSize);
            await this.LayoutTo(rect);
            AbsoluteLayout.SetLayoutBounds(this, rect);
        }
    }
}


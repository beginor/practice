using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Beginor.X2048.Models;
using Xamarin.Forms;
using Beginor.X2048.Converters;

namespace Beginor.X2048.Views {

    public class TileView : ContentView {

        private static readonly IValueConverter TextColorConverter = new TileTextColorConverter();
        private static readonly IValueConverter BackgroundColorConverter = new TileBackgroundColorConverter();

        public TileView() {
            var label = new Label {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold)
            };
            label.SetBinding(Label.TextProperty, "Value");
            label.SetBinding(Label.TextColorProperty, "Value", BindingMode.Default, TextColorConverter);

            var frame = new ContentView {
                Content = label
            };

            frame.SetBinding(BackgroundColorProperty, "Value", BindingMode.Default, BackgroundColorConverter);
            Content = frame;

            Padding = new Thickness(2);
        }

        protected override void OnBindingContextChanged() {
            base.OnBindingContextChanged();
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
            var rect = new Rectangle(model.X * App.Consts.TileSize, model.Y * App.Consts.TileSize, App.Consts.TileSize, App.Consts.TileSize);
            AbsoluteLayout.SetLayoutBounds(this, rect);
        }

        private async Task UpdateBoundsAsync() {
            var model = (TileViewModel)BindingContext;
            var rect = new Rectangle(model.X * App.Consts.TileSize, model.Y * App.Consts.TileSize, App.Consts.TileSize, App.Consts.TileSize);
            await this.LayoutTo(rect);
            AbsoluteLayout.SetLayoutBounds(this, rect);
        }
    }
}

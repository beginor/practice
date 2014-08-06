using System;
using Beginor.X2048.Models;
using Xamarin.Forms;
using Beginor.X2048.Converters;

namespace Beginor.X2048.Views {

    public class TileView : Button {

        private static readonly IValueConverter TextColorConverter = new TileTextColorConverter();
        private static readonly IValueConverter BackgroundColorConverter = new TileBackgroundColorConverter();

        public TileView() {
            this.Clicked += OnClicked;
        }

        private void OnClicked(object sender, EventArgs e) {
            var tile = (TileModel)BindingContext;
            tile.Value = tile.Value * 2;
        }

        protected override void OnBindingContextChanged() {
            base.OnBindingContextChanged();
            this.SetBinding(TextProperty, "Value");
            this.SetBinding(Grid.ColumnProperty, "X");
            this.SetBinding(Grid.RowProperty, "Y");

            this.SetBinding(BackgroundColorProperty, "Value", BindingMode.Default, BackgroundColorConverter);
            this.SetBinding(TextColorProperty, "Value", BindingMode.Default, TextColorConverter);

            this.ApplyBindings();
        }

    }
}

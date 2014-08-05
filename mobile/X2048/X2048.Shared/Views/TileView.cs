using System;
using Beginor.X2048.Models;
using Xamarin.Forms;

namespace Beginor.X2048.Views {

    public class TileView : Button {

        private int index;

        public TileView() {
            this.Clicked += OnClicked;
        }

        private void OnClicked(object sender, EventArgs e) {
            var tile = (TileModel)BindingContext;
            tile.Value = tile.Value * 2;
            index++;
            index = index % 16;
            tile.Y = index / 4;
            tile.X = index % 4;
        }

        protected override void OnBindingContextChanged() {
            base.OnBindingContextChanged();
            this.SetBinding(TextProperty, "Value");
            this.SetBinding(Xamarin.Forms.Grid.ColumnProperty, "X");
            this.SetBinding(Xamarin.Forms.Grid.RowProperty, "Y");
            this.ApplyBindings();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Beginor.X2048.Models;
using Xamarin.Forms;

namespace Beginor.X2048.Views {

    public class TileView : Button {

        public TileView() {
            this.Clicked += OnClicked;
        }

        private void OnClicked(object sender, EventArgs e) {
            var tile = (Tile)BindingContext;
            tile.Value = tile.Value * 2;
        }

        protected override void OnBindingContextChanged() {
            base.OnBindingContextChanged();
            var tile = (Tile)BindingContext;
            tile.PropertyChanged += OnTilePropertyChanged;
            this.SetBinding(TextProperty, "Value", BindingMode.OneWay);
            this.ApplyBindings();
        }

        private void OnTilePropertyChanged(object sender, PropertyChangedEventArgs e) {
            var tile = (Tile)BindingContext;
            if (e.PropertyName == "X") {
                Xamarin.Forms.Grid.SetColumn(this, tile.X);
            }
            if (e.PropertyName == "Y") {
                Xamarin.Forms.Grid.SetRow(this, tile.Y);
            }
        }
    }
}

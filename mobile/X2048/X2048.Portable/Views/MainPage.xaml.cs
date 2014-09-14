using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Beginor.X2048.Models;
using System.ComponentModel;

namespace Beginor.X2048.Views {

    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
            BindingContext = viewModel;
            viewModel.PropertyChanged += OnViewModelPropertyChanged;

            layoutRoot.SizeChanged += OnLayoutRootSizeChanged;
            actionButton.Clicked += OnActionButtonClick;
            gameView.Swipe += OnGameViewSwip;
        }

        private async void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (e.PropertyName == "Over") {
                await DisplayAlert("Alert", "Game over!", "OK");
            }
        }

        void OnGameViewSwip(object sender, SwipeEventArgs e) {
            Vector vector = null;
            switch (e.Direction) {
            case SwipDirection.Up:
                vector = new Vector(x: 0, y: -1);
                break;
            case SwipDirection.Left:
                vector = new Vector(x: -1, y: 0);
                break;
            case SwipDirection.Down:
                vector = new Vector(x: 0, y: 1);
                break;
            case SwipDirection.Right:
                vector = new Vector(x: 1, y: 0);
                break;
            }
            if (vector != null) {
                viewModel.Move(vector);
            }
        }

        void OnLayoutRootSizeChanged (object sender, EventArgs e) {
            var width = layoutRoot.Width;
            var height = layoutRoot.Height;
            if (width <= 0 || height <= 0) {
                return;
            }

            var tileSize = Math.Min(width, height) / AppConsts.TileCount;
            gameView.WidthRequest = tileSize * AppConsts.TileCount;
            gameView.HeightRequest = tileSize * AppConsts.TileCount;
            AppConsts.SetTileSize(tileSize);

            viewModel.StartNewGame();

            foreach (var t in gameView.Tiles) {
                var pos = t.ViewModel;
                AbsoluteLayout.SetLayoutBounds(t, new Rectangle(pos.X * tileSize, pos.Y * tileSize, tileSize, tileSize));
            }
        }

        private async void OnActionButtonClick(object sender, EventArgs e) {
            var confirm = await DisplayAlert("Confirm", "Sure to start new game?", "OK", "Cancel");
            if (confirm) {
                viewModel.StartNewGame();
            }
        }
    }
}


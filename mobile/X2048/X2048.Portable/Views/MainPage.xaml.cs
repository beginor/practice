using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Beginor.X2048.Models;
using System.Linq;

namespace Beginor.X2048.Views {

    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
            BindingContext = viewModel;
            viewModel.TileChanged += OnViewModelTileChanged;
            layoutRoot.SizeChanged += OnLayoutRootSizeChanged;
            actionButton.Clicked += OnActionButtonClick;
            gameView.Swipe += OnGameViewSwip;
        }

        void OnGameViewSwip(object sender, SwipeEventArgs e) {
            Vector vector = null;
            switch (e.Direction) {
            case SwipDirection.Up:
                vector = new Vector(x: 0, y: -1);
                break;
            case SwipDirection.Left:
                vector = new Vector(x: 1, y: 0);
                break;
            case SwipDirection.Down:
                vector = new Vector(x: 0, y: 1);
                break;
            case SwipDirection.Right:
                vector = new Vector(x: -1, y: 0);
                break;
            }
            if (vector != null) {
                viewModel.Move(vector);
            }
        }

        void OnViewModelTileChanged (object sender, EventArgs e) {
            var tileModels = viewModel.AvailableTiles();
            // remove old items;
            var tmpViews = new List<TileView>();
            foreach (var tileView in gameView.Tiles) {
                var found = false;
                foreach (var tileModel in tileModels) {
                    if (tileModel == tileView.ViewModel) {
                        found = true;
                        break;
                    }
                }
                if (!found) {
                    tmpViews.Add(tileView);
                }
            }
            foreach (var v in tmpViews) {
                gameView.RemoveTile(v);
            }
            tmpViews.Clear();

            // add new items;
            var tmpModels = new List<TileViewModel>();
            foreach (var tileModel in tileModels) {
                bool found = false;
                foreach (var tileView in gameView.Tiles) {
                    if (tileView.ViewModel == tileModel) {
                        found = true;
                        break;
                    }
                }
                if (!found) {
                    tmpModels.Add(tileModel);
                }
            }
            foreach (var tileModel in tmpModels) {
                var tileView = new TileView();
                tileView.ViewModel = tileModel;
                gameView.AddTile(tileView);
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
                var model = t.ViewModel;
                var pos = model.Position;
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


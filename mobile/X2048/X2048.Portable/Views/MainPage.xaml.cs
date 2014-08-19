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
        }

        void OnViewModelTileChanged (object sender, EventArgs e) {
            var tiles = viewModel.AvailableTiles();
            var toRemove = gameView.Children.Where(v => !tiles.Contains(((TileViewModel)v.BindingContext))).ToList();
            foreach (var view in toRemove) {
                gameView.Children.Remove(view);
            }
            toRemove.Clear();

            var exists = gameView.Children.Select(v => v.BindingContext).Cast<TileViewModel>().ToArray();
            //if (e.NewItems != null) {
            //    foreach (TileViewModel newItem in e.NewItems) {
            //        gameView.Children.Add(new TileView { BindingContext = newItem });
            //    }
            //}
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

            foreach (var child in gameView.Children) {
                var model = (TileViewModel)child.BindingContext;
                var pos = model.Position;
                AbsoluteLayout.SetLayoutBounds(child, new Rectangle(pos.X * tileSize, pos.Y * tileSize, tileSize, tileSize));
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


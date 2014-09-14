using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using Beginor.X2048.Models;

namespace Beginor.X2048.Views {

    public class GridView : AbsoluteLayout {

        public event EventHandler<SwipeEventArgs> Swipe;

        public virtual void OnSwipe(SwipDirection direction) {
            var handler = Swipe;
            if (handler != null) {
                handler(this, new SwipeEventArgs(direction));
            }
        }

        protected override void OnBindingContextChanged() {
            base.OnBindingContextChanged();
            var viewModel = BindingContext as GridViewModel;
            if (viewModel == null) {
                return;
            }

            SyncTiles();
            viewModel.TileChanged += OnViewModelTileChanged;
        }

        void OnViewModelTileChanged(object sender, EventArgs e) {
            SyncTiles();
        }

        void SyncTiles() {
            var viewModel = (GridViewModel)BindingContext;
            viewModel.EachCell((x, y, tile) => {
                var view = Tiles.FirstOrDefault(v => v.ViewModel.X == x && v.ViewModel.Y == y);
                if (tile == null && view != null) {
                    Children.Remove(view);
                }
                if (tile != null && view == null) {
                    Children.Add(new TileView { ViewModel = tile });
                }
            });
        }

        public IEnumerable<TileView> Tiles {
            get {
                return Children.Cast<TileView>();
            }
        }

    }

    public class SwipeEventArgs : EventArgs {

        public SwipDirection Direction { get; private set; }

        public SwipeEventArgs(SwipDirection direction) {
            Direction = direction;
        }

    }

    public enum SwipDirection {
        Right = 1,
        Left = 2,
        Up = 4,
        Down = 8,
    }
}

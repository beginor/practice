using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace Beginor.X2048.Views {

    public class GridView : AbsoluteLayout {

        public event EventHandler<SwipeEventArgs> Swipe;

        public virtual void OnSwipe(SwipDirection direction) {
            var handler = Swipe;
            if (handler != null) {
                handler(this, new SwipeEventArgs(direction));
            }
        }

        public IEnumerable<TileView> Tiles {
            get {
                return Children.Cast<TileView>();
            }
        }

        public void RemoveTile(TileView tile) {
            Children.Remove(tile);
        }

        public void AddTile(TileView tile) {
            Children.Add(tile);
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

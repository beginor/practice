using System;
using Xamarin.Forms;

namespace Beginor.X2048.Views {

    public class GameView : AbsoluteLayout {

        public event EventHandler<SwipeEventArgs> Swipe;

        public virtual void OnSwipe(SwipDirection direction) {
            var handler = Swipe;
            if (handler != null) {
                handler(this, new SwipeEventArgs(direction));
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

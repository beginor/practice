using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beginor.X2048.Models;
using Xamarin.Forms;

namespace Beginor.X2048.Views {

    public class GameView : AbsoluteLayout {

        public event EventHandler<SwipeEventArgs> Swipe;

        public GameView() {
            Swipe += OnSwipe;
        }

        private async void OnSwipe(object sender, SwipeEventArgs e) {
            //Console.WriteLine("User swipe " + direction);
            var tile = (TileView)Children[0];
            
            var rect = (tile.Bounds);
            
            var newRect = rect;
            switch (e.Direction) {
                case SwipDirection.Right:
                    newRect = new Rectangle(rect.X + rect.Width, rect.Y, rect.Width, rect.Height);
                    break;
                case SwipDirection.Left:
                    newRect = new Rectangle(rect.X - rect.Width, rect.Y, rect.Width, rect.Height);
                    break;
                case SwipDirection.Down:
                    newRect = new Rectangle(rect.X, rect.Y + rect.Height, rect.Width, rect.Height);
                    break;
                case SwipDirection.Up:
                    newRect = new Rectangle(rect.X, rect.Y - rect.Height, rect.Width, rect.Height);
                    break;
            }

            Console.WriteLine("layout from {0} to: {1}", rect, newRect);

            await tile.LayoutTo(newRect);
            SetLayoutBounds(tile, newRect);


            var tileModel = (TileViewModel)tile.BindingContext;
            if (tileModel.Value < 2048) {
                tileModel.Value *= 2;
            }
        }

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

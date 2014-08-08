using System;
using System.Collections.Generic;
using System.Text;
using Beginor.X2048.Models;
using Xamarin.Forms;

namespace Beginor.X2048.Views {

    public class GameView : AbsoluteLayout {

        public virtual void OnSwipe(SwipDirection direction) {
            //Console.WriteLine("User swipe " + direction);
            var tile = (TileView)Children[0];
            var tileModel = (TileViewModel)tile.BindingContext;
            var rect = GetLayoutBounds(tile);
            Rectangle newRect = rect;
            switch (direction) {
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
            this.Animate("Swipe", i => SetLayoutBounds(tile, newRect), 16U, 250U, Easing.Linear, (d, b) => {
                //if (b) {
                    if (tileModel.Value < 2048) {
                        tileModel.Value *= 2;
                    }
                //}
            });
        }

    }

    public enum SwipDirection {
        None,
        Up,
        Down,
        Left,
        Right
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beginor.X2048.Views {

    public class GameView : AbsoluteLayout {

        public virtual void OnSwipe(SwipDirection direction) {
            Console.WriteLine("User swipe " + direction);
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

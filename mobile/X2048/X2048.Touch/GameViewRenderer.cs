using System.ComponentModel;
using Beginor.X2048.Views;
using MonoTouch.UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Beginor.X2048 {

    public class GameViewRenderer : VisualElementRenderer<GridView> {

        protected override void OnElementChanged(ElementChangedEventArgs<GridView> e) {
            base.OnElementChanged(e);
            SetBackgroundColor(Element.BackgroundColor);
            AddGestureRecognizer(new UISwipeGestureRecognizer(SwipeGestureHandler));
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName) {
                SetBackgroundColor(Element.BackgroundColor);
            }
        }

        private void SwipeGestureHandler(UISwipeGestureRecognizer sgr) {
            var direction = (SwipDirection) sgr.Direction;
            Element.OnSwipe(direction);
        }
    }
}
using System;
using System.ComponentModel;
using Android.Graphics;
using Android.Views;
using Beginor.X2048.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Beginor.X2048 {

    public class GameViewRenderer : VisualElementRenderer<GridView> {

        protected override void OnElementChanged(ElementChangedEventArgs<GridView> e) {
            base.OnElementChanged(e);
            SetBackgroundColor(Element.BackgroundColor.ToAndroid());
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName) {
                SetBackgroundColor(Element.BackgroundColor.ToAndroid());
            }
        }

        private float startX, startY;

        public override bool DispatchTouchEvent(MotionEvent e) {
            if (e.Action == MotionEventActions.Down) {
                startX = e.GetX();
                startY = e.GetY();
                return true;
            }
            if (e.Action == MotionEventActions.Up) {
                var deltaX = e.GetX() - startX;
                var deltaY = e.GetY() - startY;
                if (Math.Abs(deltaX) > 10 || Math.Abs(deltaY) > 10) {
                    if (Math.Abs(deltaX) > Math.Abs(deltaY)) {
                       Element.OnSwipe(deltaX > 0 ? SwipDirection.Right : SwipDirection.Left);
                    }
                    else {
                       Element.OnSwipe(deltaY > 0 ? SwipDirection.Down : SwipDirection.Up);
                    }
                }
                return true;
            }
            return base.DispatchTouchEvent(e);
        }
    }

}
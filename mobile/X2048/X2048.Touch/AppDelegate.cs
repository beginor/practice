using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Beginor.X2048 {

    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate {

        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options) {
            // create a new window instance based on the screen size
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            // If you have defined a view, add it here:
            // window.RootViewController  = navigationController;

            // make the window visible
            Window.MakeKeyAndVisible();

            return true;
        }
    }
}
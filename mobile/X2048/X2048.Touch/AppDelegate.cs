using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;

namespace Beginor.X2048 {

    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate {

        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions) {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            Forms.Init();
            Window.RootViewController = App.GetMainPage().CreateViewController();

            Window.MakeKeyAndVisible();

            return true;
        }
    }
}
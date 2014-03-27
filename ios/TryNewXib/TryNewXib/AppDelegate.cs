using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TryNewXib.Views;

namespace TryNewXib {

    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate {

        UIWindow window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options) {
            window = new UIWindow(UIScreen.MainScreen.Bounds);

            window.RootViewController = NewViewController.Create();
            window.MakeKeyAndVisible();
            
            return true;
        }
    }
}


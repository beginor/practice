using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace CustomNavigationBar.Touch {

    partial class RootViewController : UIViewController {

        public RootViewController(IntPtr handle)
            : base(handle) {
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender) {
            if (segue.Identifier == "ToRed") {
                segue.DestinationViewController.View.BackgroundColor = UIColor.Red;
            }
            if (segue.Identifier == "ToGreen") {
                segue.DestinationViewController.View.BackgroundColor = UIColor.Green;
            }
            if (segue.Identifier == "ToBlue") {
                segue.DestinationViewController.View.BackgroundColor = UIColor.Blue;
            }
            Console.WriteLine(segue.Identifier);
            base.PrepareForSegue(segue, sender);
        }

        public override UIStatusBarStyle PreferredStatusBarStyle() {
            return UIStatusBarStyle.LightContent;
        }
    }
}

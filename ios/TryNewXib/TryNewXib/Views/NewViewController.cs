using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TryNewXib.Views {

    public partial class NewViewController : UIViewController {

        public NewViewController(IntPtr handle) : base(handle) {
        }

        public override void DidReceiveMemoryWarning() {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
            
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public static NewViewController Create() {
            var objects = UINib.FromName("NewViewController", null).Instantiate(null, null);
            return (NewViewController)objects[0];
        }
    }
}


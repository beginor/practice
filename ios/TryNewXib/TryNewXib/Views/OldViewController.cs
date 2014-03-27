using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TryNewXib.Views {

    [RegisterAttribute("OldViewController")]
    public class OldViewController : UIViewController {

        public OldViewController() : base("OldViewController", null) {
        }

    }
}


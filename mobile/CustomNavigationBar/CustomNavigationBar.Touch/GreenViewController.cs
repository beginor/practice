using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace CustomNavigationBar.Touch
{
	partial class GreenViewController : UIViewController
	{
		public GreenViewController (IntPtr handle) : base (handle)
		{
		}

        public override UIStatusBarStyle PreferredStatusBarStyle() {
            return UIStatusBarStyle.LightContent;
        }
	}
}

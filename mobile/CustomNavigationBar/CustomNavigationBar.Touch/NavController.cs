using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace CustomNavigationBar.Touch
{
	partial class NavController : UINavigationController
	{
		public NavController (IntPtr handle) : base (handle)
		{
		}

	    public override UIStatusBarStyle PreferredStatusBarStyle() {
	        return UIStatusBarStyle.Default;
	    }
	}
}

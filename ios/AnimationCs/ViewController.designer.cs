// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace AnimationCs
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIView FirstView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView SecondView { get; set; }

		[Action ("SwitchBarItemClick:")]
		partial void SwitchBarItemClick (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (SecondView != null) {
				SecondView.Dispose ();
				SecondView = null;
			}

			if (FirstView != null) {
				FirstView.Dispose ();
				FirstView = null;
			}
		}
	}
}

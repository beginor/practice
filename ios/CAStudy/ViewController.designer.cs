// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace CAStudy
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIToolbar Toolbar { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Toolbar != null) {
				Toolbar.Dispose ();
				Toolbar = null;
			}
		}
	}
}

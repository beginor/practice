// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace MultiThreadTestApp
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField ThreadCountTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton SwithchButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIProgressView CompleteProgressView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel ProgressMessageLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField RequestCountLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton OpenSqliteButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ThreadCountTextField != null) {
				ThreadCountTextField.Dispose ();
				ThreadCountTextField = null;
			}

			if (SwithchButton != null) {
				SwithchButton.Dispose ();
				SwithchButton = null;
			}

			if (CompleteProgressView != null) {
				CompleteProgressView.Dispose ();
				CompleteProgressView = null;
			}

			if (ProgressMessageLabel != null) {
				ProgressMessageLabel.Dispose ();
				ProgressMessageLabel = null;
			}

			if (RequestCountLabel != null) {
				RequestCountLabel.Dispose ();
				RequestCountLabel = null;
			}

			if (OpenSqliteButton != null) {
				OpenSqliteButton.Dispose ();
				OpenSqliteButton = null;
			}
		}
	}
}

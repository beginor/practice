using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace AnimationCs
{
	public partial class ViewController : UIViewController
	{
		public ViewController () : base ("ViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		partial void SwitchBarItemClick (NSObject sender)
		{
			UIView.Animate(
				1.0,
				1.0,
				UIViewAnimationOptions.CurveEaseIn,
				() => {
					this.FirstView.Alpha = 0.0;
					UIView.Animate(
						1.0,
						1.0,
						UIViewAnimationOptions.OverrideInheritedCurve |
						UIViewAnimationOptions.CurveLinear |
						UIViewAnimationOptions.OverrideInheritedDuration |
						UIViewAnimationOptions.Repeat |
						UIViewAnimationOptions.Autoreverse,
						() => {
							UIView.SetAnimationRepeatCount(2.f);
							this.SecondView.Alpha = 0.0;
						},
						null
					);
				},
				null
			);
		}
	}
}


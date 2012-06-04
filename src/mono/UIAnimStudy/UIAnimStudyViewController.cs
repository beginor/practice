using MonoTouch.UIKit;
using System.Drawing;
using System;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.CoreAnimation;

namespace UIAnimStudy {

	public partial class UIAnimStudyViewController : UIViewController {
		
		private const float Duration = 0.7f;
		
		public int TypeId {
			get;
			set;
		}
		
		public UIAnimStudyViewController() : base ("UIAnimStudyViewController", null) {
		}
		
		public override void DidReceiveMemoryWarning() {
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad() {
			base.ViewDidLoad();
			
			//any additional setup after loading the view, typically from a nib.
		}
		
		public override void ViewDidUnload() {
			base.ViewDidUnload();
			
			// Release any retained subviews of the main view.
			// e.g. myOutlet = null;
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation) {
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
		
		partial void Button1click(MonoTouch.Foundation.NSObject sender) {
			var btn = (UIButton)sender;
			var btnTag = btn.Tag;
			
			UIView.BeginAnimations(string.Empty);
			UIView.SetAnimationCurve(UIViewAnimationCurve.EaseInOut);
			UIView.SetAnimationDuration(Duration);
			
			switch (btnTag) {
				case 101:
					UIView.SetAnimationTransition(UIViewAnimationTransition.CurlUp, this.View, true);
					break;
				case 102:
					UIView.SetAnimationTransition(UIViewAnimationTransition.CurlDown, this.View, true);
					break;
				case 103:
					UIView.SetAnimationTransition(UIViewAnimationTransition.FlipFromRight, this.View, true);
					break;
				case 104:
					UIView.SetAnimationTransition(UIViewAnimationTransition.FlipFromLeft, this.View, true);
					break;
			}
			
			var greenImageViewIndex = Array.IndexOf(this.View.Subviews, this.GreenImageView);
			var redImageViewIndex = Array.IndexOf(this.View.Subviews, this.RedImageView);
			
			this.View.ExchangeSubview(greenImageViewIndex, redImageViewIndex);
			
			UIView.SetAnimationDelegate(this);
			UIView.CommitAnimations();
		}
		
		partial void Button2click(MonoTouch.Foundation.NSObject sender) {
			var btn = (UIButton)sender;
			var btnTag = btn.Tag;
			
			CATransition trans = CATransition.CreateAnimation();
			trans.Duration = Duration;
			//transition.Delegate = new AnimationDelegate();
			trans.AnimationStarted += delegate {
				Console.WriteLine("Animation Started");
			};
			trans.AnimationStopped += (s, e) => {
				Console.WriteLine("Animation stopped");
			};
			
			trans.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut.ToString());
			switch (btnTag) {
				case 201:
					trans.Type = CATransition.TransitionFade;
					break;
				case 202:
					trans.Type = CATransition.TransitionPush;
					break;
				case 203:
					trans.Type = CATransition.TransitionReveal;
					break;
				case 204:
					trans.Type = CATransition.TransitionMoveIn;
					break;
				case 205:
					trans.Type = "cube";
					break;
				case 206:
					trans.Type = "suckEffect";
					break;
				case 207:
					trans.Type = "oglFlip";
					break;
				case 208:
					trans.Type = "rippleEffect";
					break;
				case 209:
					trans.Type = "pageCurl";
					break;
				case 210:
					trans.Type = "pageUnCurl";
					break;
				case 211:
					trans.Type = "cameraIrisHollowOpen";
					break;
				case 212:
					trans.Type = "cameraIrisHollowClose";
					break;
			}
			
			switch (this.TypeId) {
				case 0:
					trans.Subtype = CATransition.TransitionFromLeft;
					break;
				case 1:
					trans.Subtype = CATransition.TransitionFromTop;
					break;
				case 2:
					trans.Subtype = CATransition.TransitionFromRight;
					break;
				case 3:
					trans.Subtype = CATransition.TransitionFromBottom;
					break;
			}
			
			this.TypeId += 1;
			if (this.TypeId > 3) {
				this.TypeId = 0;
			}
			
			var greenImageViewIndex = Array.IndexOf(this.View.Subviews, this.GreenImageView);
			var redImageViewIndex = Array.IndexOf(this.View.Subviews, this.RedImageView);
			
			this.View.ExchangeSubview(greenImageViewIndex, redImageViewIndex);
			this.View.Layer.AddAnimation(trans, "animation");
		}
	}
}

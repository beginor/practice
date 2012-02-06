using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using MonoTouch.CoreGraphics;

namespace CAStudy {

	public partial class ViewController : UIViewController {
		
		public ViewController() : base ("ViewController", null) {
		}
		
		public override void DidReceiveMemoryWarning() {
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad() {
			base.ViewDidLoad();
			
			// Perform any additional setup after loading the view, typically from a nib.
			this.AddToolbarItems();
		}
		
		private void AddToolbarItems() {
			var items = new List<UIBarButtonItem>{
				new UIBarButtonItem("Setup", UIBarButtonItemStyle.Bordered, (s, e) => { this.SetupLayer(); }),
				new UIBarButtonItem("Move", UIBarButtonItemStyle.Bordered, (s, e) => { this.MoveLayer(); }),
				new UIBarButtonItem("Resize", UIBarButtonItemStyle.Bordered, (s, e) => { this.ResizeLayer(); })
			};
			this.Toolbar.SetItems(items.ToArray(), true);
		}
		
		private void SetupLayer() {
			var layer = new CALayer {
				Name = "TestLayer",
				Position = new PointF(160f, 200f),
				Bounds = new RectangleF(0f, 0f, 100f, 100f),
				BorderWidth = 1f,
				BorderColor = new CGColor(1f, 0f, 0f, 1f),
				Contents = UIImage.FromFile("monotouch.jpg").CGImage,
				CornerRadius = 4f,
				//ShadowOffset = new SizeF(0f, 0f),
				ShadowColor = new CGColor(0f, 0f, 0f, 1f),
				ShadowOpacity = 1f,
				ShadowRadius = 8f
			};
			
			this.View.Layer.AddSublayer(layer);
		}

		private void MoveLayer() {
			var layer = this.View.Layer.Sublayers.FirstOrDefault(l => l.Name == "TestLayer");
			if (layer == null) {
				return;
			}
			var pos = layer.Position;
			pos.X = pos.X == 50f ? 270f : 50f;
			layer.Position = pos;
		}
		
		private void ResizeLayer() {
			var layer = this.View.Layer.Sublayers.FirstOrDefault(l => l.Name == "TestLayer");
			if (layer == null) {
				return;
			}
			var rect = layer.Bounds;
			rect.Width = rect.Width == 100f ? 200f : 100f;
			layer.Bounds = rect;
		}
		
		public override void ViewDidUnload() {
			base.ViewDidUnload();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation) {
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}


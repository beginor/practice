using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using MonoTouch.CoreAnimation;

namespace CAStudy {
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.

	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate {
		// class-level declarations
		UIWindow window;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options) {
			// create a new window instance based on the screen size
			window = new UIWindow(UIScreen.MainScreen.Bounds);
			
			// If you have defined a view, add it here:
			// window.AddSubview (navigationController.View);
			CALayer layerA = CALayer.Create();
			layerA.Name = "LayerA";
			layerA.Bounds = new System.Drawing.RectangleF(0f, 0f, 100f, 25f);
			layerA.BorderWidth = 2.0f;
			layerA.BorderColor = new CGColor(1.0f, 0f, 0f, 1f);
			layerA.ContentsGravity = CALayer.GravityCenter;
			layerA.Position = new System.Drawing.PointF(100f, 100f);
			
			window.RootViewController = new UIViewController();
			window.RootViewController.View.Layer.AddSublayer(layerA);
			
			// make the window visible
			window.MakeKeyAndVisible();
			
			return true;
		}
	}
}


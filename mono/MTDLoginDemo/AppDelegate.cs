using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace MTDLoginDemo {

	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate {

		UIWindow window;
		private EntryElement usernameElement;
		private EntryElement passwordElement;
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options) {
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			// If you have defined a view, add it here:
			// window.AddSubview (navigationController.View);
			window.RootViewController = new DialogViewController(BuildLoginElement());
			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}

		private RootElement BuildLoginElement() {
			var loginElement = new RootElement("Login");

			var credSection = new Section("Credentials");
			usernameElement = new EntryElement("Username:", "Enter username", string.Empty, false);
			credSection.Add(usernameElement);
			passwordElement = new EntryElement("Password:", string.Empty, string.Empty, true);
			credSection.Add(passwordElement);

			loginElement.Add(credSection);

			var btnSection = new Section();
			btnSection.Add(new StringElement("Login", delegate {
				Console.WriteLine("Login btn clicked");
				Console.WriteLine("username={0}&password={1}", usernameElement.Value, passwordElement.Value);
			}));

			loginElement.Add(btnSection);

			return loginElement;
		}
	}
}


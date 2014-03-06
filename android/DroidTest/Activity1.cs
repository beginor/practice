using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TouchTest;

namespace DroidTest {

	[Activity (Label = "DroidTest", MainLauncher = true)]
	public class Activity1 : Activity {
		int count = 1;

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format("{0} clicks!", count++);
			};

			var cat = new Cat { Name = "Tom" };
			var cat2 = new Cat { Name = "cat" };
			cat.MakeFriends(cat2);
			var dog = new Dog { Name = "Tigger" };
			dog.MakeFriends(cat);
			dog.MakeFriends(cat2);
		}
	}
}



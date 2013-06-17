using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace AppRetainState {

	[Activity (Label = "AppRetainState", MainLauncher = true)]
	public class MainActivity : Activity {

		int count = 1;
		Button _myButton;

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.activity_main);

			// Get our button from the layout resource,
			// and attach an event to it
			_myButton = FindViewById<Button>(Resource.Id.myButton);
			
			_myButton.Click += delegate {
				_myButton.Text = string.Format("{0} clicks!", count++);
			};

			var pref = this.GetPreferences(FileCreationMode.Private);
			count = pref.GetInt("main_activity_click_count", count);
			_myButton.Text = pref.GetString("main_activity_button_text", "Nothing in state.");
		}

		protected override void OnPause() {
			base.OnPause();
			var pref = this.GetPreferences(FileCreationMode.Private);
			var editor = pref.Edit();
			editor.PutInt("main_activity_click_count", count);
			editor.PutString("main_activity_button_text", _myButton.Text);
			editor.Commit();
		}
	}
}



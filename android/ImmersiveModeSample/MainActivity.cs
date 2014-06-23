using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections;
using System.Runtime.InteropServices;

namespace ImmersiveModeSample {

    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher")]
    public class MainActivity : Android.Support.V4.App.FragmentActivity {

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Window.DecorView.SystemUiVisibilityChange += (sender, e) => {
                var layout = FindViewById<LinearLayout>(Resource.Id.sample_main_layout);
                Console.WriteLine("Current height: {0}", layout.Height);
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu) {
            MenuInflater.Inflate(Resource.Menu.main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {
            ToggleImmersiveMode(item.TitleFormatted.ToString().ToLower());
            return true;
        }

        private void ToggleImmersiveMode(string title) {
            Console.WriteLine("Item title: {0}", title);
            SystemUiFlags uiOpts = SystemUiFlags.Visible;
            if (title.StartsWith("fullscreen")) {
                uiOpts = SystemUiFlags.Fullscreen | SystemUiFlags.HideNavigation;
            }
            if (title.StartsWith("immersive")) {
                uiOpts = SystemUiFlags.Fullscreen | SystemUiFlags.HideNavigation | SystemUiFlags.Immersive;
            }
            if (title.StartsWith("sticky")) {
                uiOpts = SystemUiFlags.Fullscreen | SystemUiFlags.HideNavigation | SystemUiFlags.ImmersiveSticky;
            }
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOpts;
        }
    }
}


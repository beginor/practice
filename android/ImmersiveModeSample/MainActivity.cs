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

    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher", Theme = "@style/CustomActionBarTheme")]
    public class MainActivity : Android.Support.V4.App.FragmentActivity {

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
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
            SystemUiFlags uiOpts = SystemUiFlags.Visible;
            Console.WriteLine(item.TitleFormatted);

            if (item.ItemId == Resource.Id.action_fullscreen) {
                uiOpts = SystemUiFlags.LayoutStable
                    | SystemUiFlags.LayoutHideNavigation
                    | SystemUiFlags.LayoutFullscreen
                    | SystemUiFlags.Fullscreen
                    | SystemUiFlags.HideNavigation;
            }
            if (item.ItemId == Resource.Id.action_immersive) {
                uiOpts = SystemUiFlags.LayoutStable
                    | SystemUiFlags.LayoutHideNavigation
                    | SystemUiFlags.LayoutFullscreen
                    | SystemUiFlags.Fullscreen
                    | SystemUiFlags.HideNavigation
                    | SystemUiFlags.Immersive;
            }
            if (item.ItemId == Resource.Id.action_immersive_stick) {
                uiOpts = SystemUiFlags.LayoutStable
                    | SystemUiFlags.LayoutHideNavigation
                    | SystemUiFlags.LayoutFullscreen
                    | SystemUiFlags.Fullscreen
                    | SystemUiFlags.HideNavigation
                    | SystemUiFlags.ImmersiveSticky;
            }
            if (item.ItemId == Resource.Id.action_reset) {
                uiOpts = SystemUiFlags.LayoutStable
                    | SystemUiFlags.LayoutHideNavigation
                    | SystemUiFlags.LayoutFullscreen;
            }
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOpts;
            return true;
        }
    }
}


using System;
using Android.OS;
using Android.Views;

namespace ImmersiveModeSample {

    public class ImmersiveModeFragment : Android.Support.V4.App.Fragment {

        public override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            HasOptionsMenu = true;
        }

        public override void OnActivityCreated(Bundle savedInstanceState) {
            base.OnActivityCreated(savedInstanceState);
            var decorView = Activity.Window.DecorView;
            decorView.SystemUiVisibilityChange += (sender, args) => {
                int height = decorView.Height;
                Console.WriteLine("Current height: {0}", height);
            };
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {
            if (item.ItemId == Resource.Id.sample_action) {
                ToggleHideyBar();
            }
            return true;
        }

        private void ToggleHideyBar() {
            
        }
    }
}
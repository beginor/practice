using Android.App;
using Android.OS;

namespace Beginor.X2048 {

    [Activity(Label = "X2048", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Xamarin.Forms.Platform.Android.AndroidActivity {

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            SetPage(App.GetMainPage());
        }
    }
}


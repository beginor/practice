using Android.App;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Beginor.X2048 {

    [Activity(Label = "X2048", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AndroidActivity {

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            SetPage(App.GetMainPage());
        }
    }
}


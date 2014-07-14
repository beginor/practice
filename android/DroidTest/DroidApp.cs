using System;
using Android.Runtime;

namespace DroidTest {

    [Android.App.Application]
    public class DroidApp : Android.App.Application {

        public DroidApp(IntPtr javaRef, JniHandleOwnership transfer) : base(javaRef, transfer) {
            Android.Util.Log.Info("DroidApp", "DroidApp Constructor");
        }

        public override void OnCreate() {
            Android.Util.Log.Info("DroidApp", "DroidApp OnCreate");
            base.OnCreate();
        }
    }
}


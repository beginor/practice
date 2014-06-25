using System;
using Android.App;
using Android.Runtime;

namespace ImmersiveModeSample {

    [Application(Icon = "@drawable/ic_launcher")]
    public class App : Android.App.Application {

        public App(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) {
            
        }
    }
}
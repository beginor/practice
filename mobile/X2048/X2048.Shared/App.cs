using System;
using System.Collections.Generic;
using System.Text;
using Beginor.X2048.Views;
using Xamarin.Forms;

namespace Beginor.X2048 {

    public static class App {

        public static Page GetMainPage() {
            return new MainPage();
        }

        public static class Styles {

            public readonly static Color MainPageBackGroundColor = Color.FromHex("#FAF8EF");
            public readonly static Color GridBackGroundColor = Color.FromHex("#BBADA0");

            public static readonly Color DebugGray = Color.FromHex("#CCCCCC");

            public static readonly Color TextColor = Color.FromHex("#776e65");

            public static readonly double CellPadding = Device.OnPlatform(8, 8, 8);

        }
    }
}

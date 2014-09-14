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
    }

    public static class AppConsts {

        public readonly static Color MainPageBackgroundColor = Color.FromHex("#FAF8EF");
        public static readonly Thickness MainPagePadding = new Thickness(8, Device.OnPlatform(20, 0, 0), 8, 8);

        public static readonly Color TitleTextColor = Color.FromHex("#776e65");
        public static readonly Font TitleFont = Font.SystemFontOfSize(50d, FontAttributes.Bold);

        public static readonly Color ScoreLayoutBackgroundColor = Color.FromHex("#BBADA0");
        public static readonly double ScoreLayoutWidth = 60;
        public static readonly Color ScoreTextColor = Color.FromHex("#FFFFFF");

        public readonly static Color GridBackGroundColor = Color.FromHex("#BBADA0");

        public static readonly double CellPadding = Device.OnPlatform(8, 8, 8);

        public static readonly int TileCount = 4;

        public static readonly Random Random = new Random(Environment.TickCount);

        private static double tileSize = 50;

        public static double TileSize {
            get {
                return tileSize;
            }
        }

        public static void SetTileSize(double newSize) {
            tileSize = newSize;
        }

    }
}

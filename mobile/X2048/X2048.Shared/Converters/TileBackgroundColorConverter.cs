using System;
using Xamarin.Forms;
using System.Globalization;

namespace Beginor.X2048.Converters {

    public class TileBackgroundColorConverter : IValueConverter {

        private static string[] colors = new [] { "#eee4da", "#ede0c8", "#f2b179", "#f59563", "#f67c5f", "#f65e3b", "#edcf72", "#edcc61", "#edc850", "#edc53f", "#edc22e" };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var val = (int)value;
            if (val < 2) {
                return Color.FromHex("#CCCCCC");
            }
            var index = -1;
            while (val > 1) {
                val = val / 2;
                index++;
            }
            if (index > colors.Length - 1) {
                index = colors.Length - 1;
            }

            return Color.FromHex(colors[index]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

    }
}

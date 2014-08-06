using System;
using Xamarin.Forms;
using System.Globalization;

namespace Beginor.X2048.Converters {

    public class TileTextColorConverter : IValueConverter {

        private static string[] colors =       new [] { "#776e65", "#776e65", "#f9f6f2", "#f9f6f2", "#f9f6f2", "#f9f6f2", "#f9f6f2", "#f9f6f2", "#f9f6f2", "#f9f6f2", "#f9f6f2" };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var val = (int)value;
            if (val < 2) {
                return Color.FromHex("#CCCCCC");
            }
            var index = 0;
            while (val > 1) {
                val = val / 2;
                index++;
            }
            if (index > colors.Length - 1) {
                index = colors.Length - 1;
            }

            return Color.FromHex(colors[index - 1]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

    }

}


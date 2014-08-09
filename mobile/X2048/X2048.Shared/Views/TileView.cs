using Xamarin.Forms;
using Beginor.X2048.Converters;

namespace Beginor.X2048.Views {

    public class TileView : ContentView {

        private static readonly IValueConverter TextColorConverter = new TileTextColorConverter();
        private static readonly IValueConverter BackgroundColorConverter = new TileBackgroundColorConverter();

        public TileView() {
            var label = new Label {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold)
            };
            label.SetBinding(Label.TextProperty, "Value");
            label.SetBinding(Label.TextColorProperty, "Value", BindingMode.Default, TextColorConverter);

            var frame = new Frame {
                OutlineColor = Color.Black,
                Content = label
            };

            frame.SetBinding(BackgroundColorProperty, "Value", BindingMode.Default, BackgroundColorConverter);
            Content = frame;

            Padding = new Thickness(2);
        }

    }
}

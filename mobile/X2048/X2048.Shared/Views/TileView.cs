using Beginor.X2048.Models;
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
            Content = label;

            this.SetBinding(Grid.ColumnProperty, "X");
            this.SetBinding(Grid.RowProperty, "Y");
            this.SetBinding(BackgroundColorProperty, "Value", BindingMode.Default, BackgroundColorConverter);

            

            var tap = new TapGestureRecognizer();
            tap.Command = new Command(() => {
                var tile = (TileViewModel)BindingContext;
                tile.Value *= 2;
            });
            GestureRecognizers.Add(tap);
        }

    }
}

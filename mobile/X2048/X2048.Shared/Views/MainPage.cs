using System;
using System.Collections.Generic;
using System.Text;
using Beginor.X2048.Models;
using Xamarin.Forms;

namespace Beginor.X2048.Views {

    public class MainPage : ContentPage {

        public MainPage() {
            var grid = new Grid {
                RowSpacing = Device.OnPlatform(4, 4, 4),
                ColumnSpacing = Device.OnPlatform(4, 4, 4),
                RowDefinitions = new RowDefinitionCollection {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions = new ColumnDefinitionCollection {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };

            var tileButton = new TileView {
                BindingContext = new TileModel(new Position { X = 0, Y = 0 }, value: 2)
            };
            
            grid.Children.Add(tileButton);

            Content = grid;
            BackgroundColor = Color.FromHex("#FAF8EF");
        }

    }
}

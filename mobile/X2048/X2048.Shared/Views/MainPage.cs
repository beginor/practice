using System;
using System.Collections.Generic;
using System.Text;
using Beginor.X2048.Models;
using Xamarin.Forms;
using Grid = Xamarin.Forms.Grid;

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
                BindingContext = new Tile(new Position { X = 1, Y = 1 }, 2)
            };

            grid.Children.Add(tileButton);

            Content = grid;
        }

    }
}

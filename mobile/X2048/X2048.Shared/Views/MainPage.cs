using System;
using System.Collections.Generic;
using System.Text;
using Beginor.X2048.Models;
using Xamarin.Forms;

namespace Beginor.X2048.Views {

    public partial class MainPage : ContentPage {

        public MainPage() {
            BackgroundColor = App.Styles.MainPageBackGroundColor;

            var head = new RelativeLayout();

            var title = new Label {
                Text = "2048",
                TextColor = Color.FromHex("#776e65"),
                Font = Font.SystemFontOfSize(60, FontAttributes.Bold)
            };
            head.Children.Add(title, Constraint.Constant(0), Constraint.Constant(0));

            var score = new StackLayout {
                Orientation = StackOrientation.Horizontal,
                Children = {
                    new StackLayout {
                        Orientation = StackOrientation.Vertical,
                        BackgroundColor = App.Styles.GridBackGroundColor,
                        WidthRequest = 60,
                        Children = {
                            new Label {
                                Text = "SCORE",
                                HorizontalOptions = LayoutOptions.Center,
                                TextColor = Color.White
                                
                            },
                            new Label {
                                Text = "0",
                                HorizontalOptions = LayoutOptions.Center,
                                TextColor = Color.White
                            }
                        }
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Vertical,
                        BackgroundColor = App.Styles.GridBackGroundColor,
                        WidthRequest = 60,
                        Children = {
                            new Label { Text = "BEST",
                                HorizontalOptions = LayoutOptions.Center,
                                TextColor = Color.White
                            },
                            new Label {
                                Text = "0",
                                HorizontalOptions = LayoutOptions.Center,
                                TextColor = Color.White
                            }
                        }
                    }
                }
            };
            head.Children.Add(score,
                Constraint.RelativeToParent(p => p.Width - 130),
                Constraint.Constant(0)
            );

            var actionLabel = new Label {
                FormattedText = new FormattedString {
                    Spans = {
                        new Span {
                            Text = "Join the numbers and get to the ",
                            Font = Font.SystemFontOfSize(NamedSize.Medium, FontAttributes.None)
                        },
                        new Span {
                            Text = "2048 tile!",
                            Font = Font.SystemFontOfSize(NamedSize.Medium, FontAttributes.Bold)
                        }
                    }
                },
                TextColor = Color.FromHex("#776e65"),
                LineBreakMode = LineBreakMode.WordWrap
            };
            Grid.SetColumn(actionLabel, 0);

            var actionButton = new Button {
                Text = "New Game",
                BackgroundColor = Color.FromHex("#8f7a66"),
                TextColor = Color.FromHex("#f9f6f2")
            };
            actionButton.Clicked += async (s, e) => {
                await DisplayAlert("Alert:", "Start a new Game?", "OK");
            };
            Grid.SetColumn(actionButton, 1);

            var actions = new Grid {
                ColumnDefinitions = new ColumnDefinitionCollection {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) }
                },
                Children = {
                    actionLabel,
                    actionButton
                }
            };

            var grid = new Grid {
                BackgroundColor = App.Styles.GridBackGroundColor,
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
                },
                Children = {
                    new TileView {
                        BindingContext = new TileModel(new Position { X = 0, Y = 0 }, value: 2)
                    },
                    new TileView {
                        BindingContext = new TileModel(new Position { X = 1, Y = 0 }, value: 4)
                    }
                }
            };

            Grid.SetRow(head, 0);
            Grid.SetRow(actions, 1);
            Grid.SetRow(grid, 2);

            Content = new Grid {
                Padding = Device.OnPlatform(8, 8, 8),
                RowDefinitions = new RowDefinitionCollection {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                Children = {
                    head, actions, grid
                }
            };
        }

    }
}

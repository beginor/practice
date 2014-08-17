using System;
using System.Linq;
using Beginor.X2048.Models;
using Xamarin.Forms;

namespace Beginor.X2048.Views {

    public partial class MainPage : ContentPage {

        private readonly MainPageModel viewModel;

        public MainPage() {
            viewModel = new MainPageModel();

            BackgroundColor = App.Consts.MainPageBackGroundColor;

            var head = new StackLayout {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Horizontal
            };

            var title = new Label {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "2048",
                TextColor = Color.FromHex("#776e65"),
                Font = Font.SystemFontOfSize(60, FontAttributes.Bold)
            };
            head.Children.Add(title);

            var score = new StackLayout {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = {
                    new StackLayout {
                        Orientation = StackOrientation.Vertical,
                        BackgroundColor = App.Consts.GridBackGroundColor,
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
                        BackgroundColor = App.Consts.GridBackGroundColor,
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
            head.Children.Add(score);

            var actionLabel = new Label {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
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


            var actionButton = new Button {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "New Game",
                BackgroundColor = Color.FromHex("#8f7a66"),
                TextColor = Color.FromHex("#f9f6f2")
            };

            actionButton.Clicked += async (s, e) => {
                var confirm = await DisplayAlert("Confirm", "Sure to start new game?", "OK", "Cancel");
                if (confirm) {
                    viewModel.StartNewGame();
                }
            };

            var actions = new StackLayout {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    actionLabel,
                    actionButton
                }
            };

            var gameView = new GameView {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = App.Consts.GridBackGroundColor
            };

            viewModel.TileChanged += (s, e) => {
                var tiles = viewModel.AvailableTiles();
                var toRemove = gameView.Children.Where(v => tiles.Contains(((TileViewModel)v.BindingContext))).ToList();
                foreach (var view in toRemove) {
                    gameView.Children.Remove(view);
                }
                toRemove.Clear();

                if (e.NewItems != null) {
                    foreach (TileViewModel newItem in e.NewItems) {
                        gameView.Children.Add(new TileView { BindingContext = newItem });
                    }
                }
            };

            var stack = new StackLayout {
                Children = { 
                    new StackLayout {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Children = { head, actions }
                    },
                    gameView
                }
            };

            stack.SizeChanged += (s, e) => {
                var width = stack.Width;
                var height = stack.Height;
                if (width <= 0 || height <= 0) {
                    return;
                }

                var tileSize = Math.Min(width, height) / App.Consts.TileCount;
                gameView.WidthRequest = tileSize * App.Consts.TileCount;
                gameView.HeightRequest = tileSize * App.Consts.TileCount;
                App.Consts.SetTileSize(tileSize);

                viewModel.StartNewGame();

                foreach (var child in gameView.Children) {
                    var model = (TileViewModel)child.BindingContext;
                    AbsoluteLayout.SetLayoutBounds(child, new Rectangle(model.X * tileSize, model.Y * tileSize, tileSize, tileSize));
                }
            };

            Content = stack;
            Padding = new Thickness(8, Device.OnPlatform(20, 0, 0), 8, 8);
            BindingContext = viewModel;
        }

    }
}

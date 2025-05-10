using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using eWarranty.Core.Models;
using eWarranty.ViewModels.Customer.Inquiry;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eWarranty.Controls
{
    public partial class ChatBotRightCell : ContentView
    {
        ChatBotViewModel chatBotViewModel;
        public ChatBotRightCell()
        {
            InitializeComponent();
            gridLayout.BindingContextChanged += ChatBotListChanged;

        }
        void ChatBotListChanged(object sender, EventArgs e)
        {
            chatBotViewModel = BindingContext as ChatBotViewModel;
            var grid = sender as Grid;
            var bindingcontect = grid.BindingContext;
            if (bindingcontect != null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var list = (ChatBot)bindingcontect;
                    prepareGrid(grid, list);
                });
            }
        }

        void prepareGrid(Grid grid, ChatBot players)
        {

            var chatBotValue = (ChatBot)players;
            grid.Children.Clear();
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();
            if (chatBotValue != null)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
                var resultIndex = 0;
                Grid row = new Grid()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.White,
                    Padding = new Thickness(0, 0, 0, 0),
                    RowSpacing = 15,
                    Margin = new Thickness(10, 0, 0, 0),
                    ColumnSpacing = 5,
                    VerticalOptions = LayoutOptions.Start,
                };
                row.ColumnDefinitions = new ColumnDefinitionCollection()
                            {
                            new ColumnDefinition(){ Width = GridLength.Star },
                            new ColumnDefinition(){ Width = GridLength.Auto },
                            new ColumnDefinition(){ Width = 40 }
                             };

                row.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                Image iconframe = new Image()
                {
                    HeightRequest = 35,
                    WidthRequest = 35,
                    Source = "chatuser",
                    Aspect = Aspect.AspectFit


                };
                row.Children.Add(iconframe, 2, 0);

                Frame chatbgframe = new Frame()
                {
                    BackgroundColor = Color.FromHex("#EA1D24"),
                    CornerRadius = 5,
                    Padding = 0,
                    HasShadow = false,
                };
                row.Children.Add(chatbgframe, 1, resultIndex);

                Label chatcontentLabel = new Label()
                {
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    VerticalTextAlignment = TextAlignment.Center,
                    Margin = new Thickness(10, 10, 10, 10),
                    IsVisible = true,
                    FontSize = 14,
                    TextColor = Color.White,
                    FontAttributes = FontAttributes.Bold,
                    LineBreakMode = LineBreakMode.WordWrap,
                    Text = chatBotValue.EventName,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontFamily = "calibribold",
                    Opacity = 100


                };
                row.Children.Add(chatcontentLabel, 1, resultIndex);

                for (int homerowIndex = 0; homerowIndex < chatBotValue.listEvents.Count; homerowIndex++)
                {
                    resultIndex++;

                    if (homerowIndex >= chatBotValue.listEvents.Count)
                    {
                        break;
                    }
                    var player1 = chatBotValue.listEvents[homerowIndex];

                    row.RowDefinitions.Add(new RowDefinition() { Height = 40 });
                    Frame bgEventframe = new Frame()
                    {
                        BackgroundColor = Color.White,
                        CornerRadius = 5,
                        Padding = 0,
                        HasShadow = false,
                        BorderColor = Color.Black
                    };
                    row.Children.Add(bgEventframe, 1, resultIndex);

                    Label eventLabel = new Label()
                    {
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        Margin = new Thickness(10, 0, 0, 0),
                        IsVisible = true,
                        FontSize = 14,
                        TextColor = Color.Blue,
                        FontAttributes = FontAttributes.Bold,
                        LineBreakMode = LineBreakMode.NoWrap,
                        Text = chatBotValue.listEvents[homerowIndex].qadescription,
                        FontFamily = "calibribold",
                        Opacity = 100

                    };

                    row.Children.Add(eventLabel, 1, resultIndex);

                    var tapgesture = new TapGestureRecognizer();
                    tapgesture.Tapped += (o, e) =>
                    {

                        var eventname = (e as TappedEventArgs).Parameter as ChatBot;
                        chatBotViewModel.SelectedEventCommand.Execute(eventname);

                    };
                    tapgesture.CommandParameter = chatBotValue.listEvents[homerowIndex].id;
                    bgEventframe.GestureRecognizers.Add(tapgesture);
                    eventLabel.GestureRecognizers.Add(tapgesture);

                }
                grid.Children.Add(row, 0, 0);
            }
        }

        void selectedChat(object sender, EventArgs e)
        {
            if (null != chatBotViewModel)
            {

            }

        }
    }
}
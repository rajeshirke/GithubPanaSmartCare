using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using eWarranty.Core.Models;
using eWarranty.ViewModels.Customer.Inquiry;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eWarranty.Controls
{
    public partial class ChatBotLeftCell : ContentView
    {
        public ChatBotViewModel chatBotViewModel;

        public ChatBotLeftCell()
        {
            InitializeComponent();
            gridLayout.BindingContextChanged += ChatBotListChanged;
        }
        void ChatBotListChanged(object sender, EventArgs e)
        {
            // chatBotViewModel = BindingContext as ChatBotViewModel;
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

        void prepareGrid(Grid grid, ChatBot player)
        {

            var chatbotValue = (ChatBot)player;
            grid.Children.Clear();
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();

            if (chatbotValue != null)
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
                    ColumnSpacing = 10,
                    VerticalOptions = LayoutOptions.Start,
                };
                row.ColumnDefinitions = new ColumnDefinitionCollection()
                            {
                            new ColumnDefinition(){ Width = new GridLength(10, GridUnitType.Star)},
                            new ColumnDefinition(){ Width = new GridLength(75, GridUnitType.Star)},
                            new ColumnDefinition(){ Width = new GridLength(15, GridUnitType.Star)}
                             };

                row.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                Image iconChat = new Image()
                {
                    //BackgroundColor = Color.Red,
                    HeightRequest = 35,
                    WidthRequest = 35,
                    Source = "chatbotuser",
                    Aspect = Aspect.AspectFit


                };
                row.Children.Add(iconChat, 0, 0);

                Frame chatbgcontentframe = new Frame()
                {
                    BackgroundColor = (Color)Application.Current.Resources["BlueColor"],
                    CornerRadius = 5,
                    Padding = 0,
                    HasShadow = false,
                };
                row.Children.Add(chatbgcontentframe, 1, resultIndex);

                Label chatcontent = new Label()
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    VerticalTextAlignment = TextAlignment.Center,
                    Margin = new Thickness(10, 10, 10, 10),
                    IsVisible = true,
                    FontSize = 14,
                   // TextDecorations= TextDecorations.Underline,
                    TextColor = Color.White,
                   // TextType = TextType.Html,
                    FontAttributes = FontAttributes.Bold,
                    LineBreakMode = LineBreakMode.WordWrap,
                    Text = chatbotValue.EventName,
                    HorizontalTextAlignment = TextAlignment.Start,
                    FontFamily = "calibribold",
                    Opacity = 100

                };
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += async (s, e) =>
                {
                    if (!string.IsNullOrEmpty(chatbotValue.ContentLink))
                    {
                        try
                        {
                            await Browser.OpenAsync(chatbotValue.ContentLink, BrowserLaunchMode.SystemPreferred);
                        }
                        catch (Exception ex)
                        {
                            // An unexpected error occured. No browser may be installed on the device.
                        }
                    }
                };
                chatcontent.GestureRecognizers.Add(tapGestureRecognizer);

                row.Children.Add(chatcontent, 1, resultIndex);
                for (int homerowIndex = 0; homerowIndex < chatbotValue.listEvents.Count; homerowIndex++)
                {
                    resultIndex++;

                    if (homerowIndex >= chatbotValue.listEvents.Count)
                    {
                        break;
                    }
                    var chatEvent = chatbotValue.listEvents[homerowIndex];

                    row.RowDefinitions.Add(new RowDefinition() { Height = 40 });
                    Frame eventbgframe = new Frame()
                    {
                        BackgroundColor = Color.White,
                        CornerRadius = 5,
                        Padding = 0,
                        HasShadow = false,
                        BorderColor = Color.Gray
                    };
                    row.Children.Add(eventbgframe, 1, resultIndex);

                    Label eventLabel = new Label()
                    {
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        Margin = new Thickness(10, 0, 0, 0),
                        IsVisible = true,
                        FontSize = 15,
                        TextColor = (Color)Application.Current.Resources["BlueColor"],
                        FontAttributes = FontAttributes.Bold,
                        LineBreakMode = LineBreakMode.NoWrap,
                        Text = chatEvent.qadescription,
                        FontFamily = "calibribold",
                        Opacity = 100

                    };

                    row.Children.Add(eventLabel, 1, resultIndex);

                    var tapgesture = new TapGestureRecognizer();
                    tapgesture.CommandParameter = chatEvent;
                    tapgesture.Tapped += (o, e) =>
                    {
                        var eventname = (e as TappedEventArgs).Parameter as Root;
                        chatBotViewModel.SelectedEventCommand.Execute(eventname);
                        MessagingCenter.Send<string>("called", "called");

                    };
                    eventbgframe.GestureRecognizers.Add(tapgesture);
                    eventLabel.GestureRecognizers.Add(tapgesture);

                }
                grid.Children.Add(row, 0, 0);
            }

        }

    }
}

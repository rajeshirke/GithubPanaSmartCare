using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using eWarranty.Controls;
using eWarranty.Core.Models;
using eWarranty.ViewModels.Customer.Inquiry;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.InquiryView
{
    public partial class ChatBotViewPage : ContentPage
    {
        ChatBotViewModel chatBotViewModel;

        public ChatBotViewPage()
        {
            InitializeComponent();
            //lblSmart.TextColor = Color.FromHex("#5a42f5");
            BindingContext = new ChatBotViewModel(Navigation);
            chatBotGrid.BindingContextChanged += ChatBotListChanged;

        }
        void ChatBotListChanged(object sender, EventArgs e)
        {
            chatBotViewModel = BindingContext as ChatBotViewModel;
            var grid = sender as Grid;
            var bindingcontect = grid.BindingContext;
            if (bindingcontect != null)
            {
                Device.BeginInvokeOnMainThread(() => {
                    var list = (ObservableCollection<ChatBot>)bindingcontect;
                    prepareGrid(grid, list);
                    Device.StartTimer(TimeSpan.FromMilliseconds(70), () => {
                        Device.BeginInvokeOnMainThread(() => {
                            scrollview.ScrollToAsync(bvSpace, ScrollToPosition.End, true);
                        });
                        return false;
                    });
                });
               


            }
        }
        void prepareGrid(Grid grid, ObservableCollection<ChatBot> players)
        {

            grid.Children.Clear();
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();
            if (players != null && players.Count > 0)
            {

                var resultIndex = 0;

                for (int rowIndex = 0; rowIndex < players.Count; rowIndex++)
                {
                    if (resultIndex >= players.Count)
                    {
                        break;
                    }
                    ChatBot stat = players[resultIndex];
                    resultIndex++;
                    grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                    //  grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
                    if (stat.DataAlignment == "LEFT")
                    {
                        ChatBotLeftCell chatBotleftCell = new ChatBotLeftCell()
                        {
                            BindingContext = stat,
                            chatBotViewModel = chatBotViewModel

                        };
                        grid.Children.Add(chatBotleftCell, 0, rowIndex);

                    }
                    else
                    {
                        ChatBotRightCell chatBotRightCell = new ChatBotRightCell()
                        {
                            BindingContext = stat
                        };
                        grid.Children.Add(chatBotRightCell, 0, rowIndex);

                    }

                }
            }

        }
    }
}
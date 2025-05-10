using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.Inquiry;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.InquiryView
{
    public partial class ChatBotHistoryPage : ContentPage
    {
        public ChatBotHistoryPage()
        {
            InitializeComponent();
            BindingContext = new ChatBotHistoryViewModel(Navigation);
        }
    }
}

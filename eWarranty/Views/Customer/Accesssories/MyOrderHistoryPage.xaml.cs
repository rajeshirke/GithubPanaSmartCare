using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.Accesssories;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.Accesssories
{
    public partial class MyOrderHistoryPage : ContentPage
    {
        public MyOrderHistoryViewModel viewModel { get; set; }
        public MyOrderHistoryPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MyOrderHistoryViewModel(Navigation);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await viewModel.BindingData();
                IsBusy = false;
            });
        }
    }
}

using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.SRDetails;
using eWarranty.ViewModels.Supervisor;
using Xamarin.Forms;

namespace eWarranty.Views.Supervisor
{
    public partial class AccessoryRequestsListPage : ContentPage
    {
        public AccessoryRequestsViewModel viewModel { get; set; }

        public AccessoryRequestsListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AccessoryRequestsViewModel(Navigation, null);

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, "RefreshAccessoryList", async (obj) =>
            {
                if (obj == "Refresh")
                {
                    await viewModel.GetOrders();
                }
            });
        }
    }
}

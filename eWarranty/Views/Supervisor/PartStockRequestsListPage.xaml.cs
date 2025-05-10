using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.SRDetails;
using eWarranty.ViewModels.Supervisor;
using Xamarin.Forms;

namespace eWarranty.Views.Supervisor
{
    public partial class PartStockRequestsListPage : ContentPage
    {
        public PartStockRequestsViewModel viewModel { get; set; }
        public PartStockRequestsListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new PartStockRequestsViewModel(Navigation);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, "RefreshPartList", async (obj) =>
            {
                if (obj == "Refresh")
                {
                    await viewModel.GetPartRequests();
                }
            });
        }
    }
}

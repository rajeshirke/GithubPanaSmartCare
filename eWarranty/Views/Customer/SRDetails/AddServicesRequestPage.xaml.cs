using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.SRDetails;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.SRDetails
{
    public partial class AddServicesRequestPage : ContentPage
    {
        public AddServicesRequestViewModel viewModel { get; set; }
        public AddServicesRequestPage()
        {
            InitializeComponent();
            BindingContext = viewModel=new AddServicesRequestViewModel(Navigation);
        }
        protected async override void OnAppearing()
        {
         //   await viewModel.BindingData();
            base.OnAppearing();
        }
    }
}

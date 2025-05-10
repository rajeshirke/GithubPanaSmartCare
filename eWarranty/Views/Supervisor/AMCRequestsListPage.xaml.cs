using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.SRDetails;
using eWarranty.ViewModels.Supervisor;
using Xamarin.Forms;

namespace eWarranty.Views.Supervisor
{
    public partial class AMCRequestsListPage : ContentPage
    {
        public AMCRequestsViewModel viewModel { get; set; }
        public AMCRequestsListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AMCRequestsViewModel(Navigation);
        }


    }
}

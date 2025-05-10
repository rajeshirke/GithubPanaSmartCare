using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Supervisor;
using Xamarin.Forms;

namespace eWarranty.Views.Supervisor
{
    public partial class ServiceRequestDetails : ContentPage
    {
        public ServiceRequestDetailsViewModel viewModel { get; set; }
        public ServiceRequestDetails(int SelectedSRreq)
        {
            InitializeComponent();
            BindingContext = viewModel = new ServiceRequestDetailsViewModel(Navigation, SelectedSRreq);
        }
    }
}

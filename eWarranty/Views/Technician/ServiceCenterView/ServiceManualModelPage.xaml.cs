using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Technician.ServiceCenterView;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.ServiceCenterView
{
    public partial class ServiceManualModelPage : ContentPage
    {
        public ServiceManualModelViewModel viewModel { get; set; }
        public ServiceManualModelPage()
        {
            InitializeComponent();
            BindingContext = viewModel=new ServiceManualModelViewModel(Navigation);
        }
        protected override void OnAppearing()
        {
            viewModel.isfileview = true;
            base.OnAppearing();
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            viewModel.ModelNumber = "";
            viewModel.ModelServiceManualResponse = new List<Core.ResponseModels.ModelServiceManualResponse>();
        }
    }
}

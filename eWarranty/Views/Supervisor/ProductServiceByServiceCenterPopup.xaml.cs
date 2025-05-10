using System;
using System.Collections.Generic;
using eWarranty.Core.ResponseModels;
using eWarranty.ViewModels.Supervisor;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.Views.Supervisor
{
    public partial class ProductServiceByServiceCenterPopup
    {
        public TechnicianAssignmentViewModel viewModel { get; set; }

        public ProductServiceByServiceCenterPopup(ServiceRequestResponceSupervisor serviceRequestResponceSupervisor)
        {
            InitializeComponent();
            BindingContext = viewModel = new TechnicianAssignmentViewModel(Navigation, serviceRequestResponceSupervisor);

        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}

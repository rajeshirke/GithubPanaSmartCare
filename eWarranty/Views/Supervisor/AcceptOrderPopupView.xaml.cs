using System;
using System.Collections.Generic;
using eWarranty.Core.RequestModels;
using eWarranty.ViewModels.Supervisor;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.Views.Supervisor
{
    public partial class AcceptOrderPopupView
    {
        public AccessoryRequestsViewModel viewModel { get; set; }

        public AcceptOrderPopupView(AssignDeliveryRequest assignDeliveryRequest)
        {
            InitializeComponent();
            BindingContext = viewModel = new AccessoryRequestsViewModel(Navigation, assignDeliveryRequest);
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}

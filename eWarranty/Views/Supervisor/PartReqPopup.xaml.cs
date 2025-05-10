using System;
using System.Collections.Generic;
using eWarranty.Core.Models;
using eWarranty.ViewModels.Supervisor;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.Views.Supervisor
{
    public partial class PartReqPopup
    {
        public PartStockRequestsViewModel viewModel { get; set; }

        public PartReqPopup(PartRequestView partRequestView)
        {
            InitializeComponent();
            BindingContext = viewModel = new PartStockRequestsViewModel(Navigation, partRequestView);
        }
        
        async void TapGestureRecognizer_Tapped_1(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}

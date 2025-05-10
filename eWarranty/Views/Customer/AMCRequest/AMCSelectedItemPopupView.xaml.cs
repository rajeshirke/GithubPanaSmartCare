using System;
using System.Collections.Generic;
using eWarranty.Core.ResponseModels;
using eWarranty.ViewModels.Customer.AMCRequest;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.AMCRequest
{
    public partial class AMCSelectedItemPopupView
    {
        public AMCSelectedItemPopupViewModel viewModel { get; set; }
        public AMCSelectedItemPopupView(AmcRequestCustomerLimitedResponse amcRequestCustomerLimitedResponse)
        {
            InitializeComponent();
            BindingContext = viewModel = new AMCSelectedItemPopupViewModel(Navigation, amcRequestCustomerLimitedResponse);
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using eWarranty.Core.ResponseModels;
using eWarranty.ViewModels.Customer.Accesssories;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.Accesssories
{
    public partial class TrackOrderPopupPage
    {
        public TrackOrderPopupPage(OrderDetailResponse orderDetailResponse)
        {
            InitializeComponent();
            BindingContext = new MyOrderDetailsViewModel(Navigation, orderDetailResponse);
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }
    }
}

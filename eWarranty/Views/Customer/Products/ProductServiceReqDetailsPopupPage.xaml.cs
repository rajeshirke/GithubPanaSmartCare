using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.SRDetails;
using eWarranty.Views.Customer.SRDetails;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.Products
{
    public partial class ProductServiceReqDetailsPopupPage : PopupPage
    {
        public long S_ID { get; set; }
        public ProductServiceReqDetailsPopupPage(string Msg,long sID)
        {
            InitializeComponent();
            LblMsg.Text = Msg.ToString();
            S_ID = sID;
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SREditDetailsPage(S_ID, 1));
            await PopupNavigation.Instance.PopAsync();

        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await PopupNavigation.Instance.PopAsync();
        }
    }
}

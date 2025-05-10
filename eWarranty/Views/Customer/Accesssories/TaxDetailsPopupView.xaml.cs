using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.Accesssories;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.Accesssories
{
    public partial class TaxDetailsPopupView 
    {
        public FinalCheckoutViewModel ViewModel { get; set; }

        public TaxDetailsPopupView(decimal TaxAmount)
        {
            InitializeComponent();
            BindingContext = new FinalCheckoutViewModel(Navigation);
            lblTaxAmount.Text = TaxAmount.ToString();
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}

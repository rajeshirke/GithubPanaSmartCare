using System;
using System.Collections.Generic;
using eWarranty.Core.ResponseModels;
using eWarranty.Resx;
using eWarranty.ViewModels.Customer.Accesssories;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.Accesssories
{
    public partial class FinalCheckoutPage : ContentPage
    {
        public FinalCheckoutViewModel ViewModel { get; set; }
        public FinalCheckoutPage(AddressResponse address)
        {
            InitializeComponent();
            BindingContext = ViewModel= new FinalCheckoutViewModel(Navigation, address);
        }

        void PromoCode_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if(e.NewTextValue!=null && e.NewTextValue != string.Empty && e.NewTextValue != "")
            {
                //ViewModel.PromoCodeCommand.Execute(e.NewTextValue);
            }
            else
            {
                ViewModel.PromomsgColor = Color.Red;
                ViewModel.Promomsg = AppResources.lblEnterPromoCode;
                ViewModel.PercentDiscount = "";
                // await ErrorDisplayAlert("Please enter promoCode.");                        
                ViewModel.PromoDiscountAmount = 0;

                decimal OnlySubTotal = ViewModel.SubTotalAmount;
                ViewModel.TaxAmount = Math.Round((ViewModel.TaxRate / 100) * ((OnlySubTotal)), 2);
                ViewModel.TotalAmount = Math.Round(OnlySubTotal + ViewModel.TaxAmount + ViewModel.ShippingFee, 2);
            }
        }
        //void PromoCode_Unfocused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        //{
        //    if (PromoCode.Text == null || PromoCode.Text == string.Empty)
        //    {
        //        lblPromoCodeMessage.Text = "";
        //    }
        //    else
        //    {
        //        lblPromoCodeMessage.Text = ViewModel.Promomsg;
        //    }
        //}
    }
}

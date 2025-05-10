using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using eWarranty.Core.Enums;
using eWarranty.Core.ResponseModels;
using eWarranty.Resx;
using eWarranty.ViewModels;
using eWarranty.ViewModels.Customer.AMCRequest;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.AMCRequest
{
    public partial class AddAMCRequestPage : ContentPage
    {
        BaseViewModel BaseViewModel { get; set; }
        AddAMCRequestViewModel viewModel { get; set; }
        public AddAMCRequestPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AddAMCRequestViewModel(Navigation);

        }

        async void OnlyService_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            if (viewModel.IsOnlyService == true)
            {
                if (viewModel.SelectedddServiceCentor == null)
                {
                    await DisplayAlert("",AppResources.lblErrorSelectServiceCenter, AppResources.lblCancel);                    
                }
                else
                {
                    viewModel.OnlyService();
                }
            }
                      
        }


        async void PartsandService_CheckedChanged_1(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            
            if (viewModel.IsPartsandServices == true)
            {
                if (viewModel.SelectedddServiceCentor == null)
                {
                    await DisplayAlert("", AppResources.lblErrorSelectServiceCenter, AppResources.lblCancel);

                }
                else
                {
                    viewModel.PartsandService();
                }
            }
        }

        Grid lastElementSelected;
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            if (lastElementSelected != null)
                VisualStateManager.GoToState(lastElementSelected, "UnSelected");

            VisualStateManager.GoToState((Grid)sender, "Selected");

            lastElementSelected = (Grid)sender;
        }

        void EntryContent_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (e.NewTextValue != null && e.NewTextValue != string.Empty && e.NewTextValue != "")
            {
                //viewModel.PromoCodeCommand.Execute(e.NewTextValue);
            }
            else
            {
                viewModel.PromomsgColor = Color.Red;
                viewModel.Promomsg = AppResources.lblEnterPromoCode;
                // await ErrorDisplayAlert("Please enter promoCode.");
                viewModel.PercentDiscount = ""; viewModel.PromoDiscountAmount = 0;
                viewModel.TaxAmount = Math.Round((viewModel.TaxRate / 100) * viewModel.SubTotalAmount, 2);
                viewModel.TotalAmount = viewModel.SubTotalAmount + viewModel.TaxAmount;
            }
        }
    }
}

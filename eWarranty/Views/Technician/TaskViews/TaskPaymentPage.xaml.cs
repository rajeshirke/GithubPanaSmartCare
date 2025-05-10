using System;
using System.Collections.Generic;
using System.IO;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.ViewModels.Technician.TasksView;
using SignaturePad.Forms;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.TaskViews
{
    public partial class TaskPaymentPage : ContentPage
    {
        public TaskPaymentViewModel viewModel { get; set; }
        public TaskPaymentPage(decimal TotalAmount)
        {
            InitializeComponent();
            BindingContext = viewModel = new TaskPaymentViewModel(Navigation, TotalAmount);
            viewModel.SignaturePadViewItem += ViewModel_SignaturePadViewItem;


        }

        public TaskPaymentPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new TaskPaymentViewModel(Navigation);
            viewModel.SignaturePadViewItem += ViewModel_SignaturePadViewItem;
        }

        private async void ViewModel_SignaturePadViewItem(object sender, EventArgs e)
        {
            if (!spForms.IsBlank)
            {

                var img = await spForms.GetImageStreamAsync(SignatureImageFormat.Png);
                var signatureMemoryStream = new MemoryStream();
                img.CopyTo(signatureMemoryStream);
                byte[] data = signatureMemoryStream.ToArray();
                viewModel.signatureBase64string = Convert.ToBase64String(data);
            }
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            SignaturePadView signaturePad = spForms;

            // Navigation.PushAsync(new PaymentSuccessfulPage());
        }


        //async void Entry_Unfocused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        //{
        //    if(Convert.ToDecimal(txtPaidAmount.Text) >viewModel.Rate)
        //    {
        //        await DisplayAlert("Error", "Paid amount should be less than total amount.", AppResources.btnCancel);
        //        txtPaidAmount.Text = "";
        //    }
        //}

        void swPayment_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (swPayment.IsToggled == true)
            {

                txtPaidAmount.Text = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode + " " +  Math.Round(viewModel.AmountToBePaid, 2).ToString();
            }
            else
            {
                txtPaidAmount.Text = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode + " " + "0.0";
            }
                
        }
    }
}

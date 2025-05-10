using System;
using System.Collections.Generic;
using eWarranty.Resx;
using eWarranty.ViewModels.Technician.SparePartsView;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.TaskViews
{
    public partial class EstimateTaskPage : ContentPage
    {
        public EstimateTaskViewModel viewModel { get; set; }
        public EstimateTaskPage()
        {
            InitializeComponent();
            BindingContext = viewModel=new EstimateTaskViewModel(Navigation);
            //shtype.Toggled += Shtype_Toggled;
        }

        //private void Shtype_Toggled(object sender, ToggledEventArgs e)
        //{
        //    if (shtype.IsToggled)
        //    {

        //        gdDiscountType.IsVisible = true;
        //        dtLabel.Text = "%";
        //    }
        //    else
        //    {
        //        dtLabel.Text = "";
        //        gdDiscountType.IsVisible = false;
        //    }
        //}


        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, "EstimationDone", async (obj) =>
            {
                if (obj == "EstimationSuccess")
                {
                    await Navigation.PushAsync(new TaskDetailsPage());
                    //await Navigation.PopAsync();

                }
            });

        }

        //void Button_Clicked(System.Object sender, System.EventArgs e)
        //{
        //    Navigation.PushAsync(new TaskPaymentPage());
        //}

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            if (!viewModel.partTab)
            {
                viewModel.partTab = true;
            }
            else
            {
                viewModel.partTab = false;
            }
        }

        //void ICCast_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        //{
        //    if (e.NewTextValue != null && e.NewTextValue!= string.Empty && e.NewTextValue!= "")
        //    {
        //        viewModel.ICCast = Convert.ToDecimal(e.NewTextValue);
        //    }
        //    else
        //    {
        //        viewModel.ICCast = 0;
        //    }
        //}

        //void SCCast_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        //{
        //    if (e.NewTextValue != null && e.NewTextValue != string.Empty && e.NewTextValue != "")
        //    {
        //        if (e.NewTextValue.EndsWith(".") && !viewModel.SCCast.ToString().Contains(".") && !e.NewTextValue.Contains(".."))
        //        {
        //            return;
        //        }

        //        decimal newvalue;
        //        decimal.TryParse(e.NewTextValue,out newvalue);
        //        viewModel.SCCast = newvalue;
        //    }
        //    else
        //    {
        //        viewModel.SCCast = 0;
        //    }
        //}

        //void TPCCast_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        //{
        //    if (e.NewTextValue != null && e.NewTextValue != string.Empty && e.NewTextValue != "")
        //    {
        //        viewModel.TPCCast = Convert.ToDecimal(e.NewTextValue);
        //    }
        //    else
        //    {
        //        viewModel.TPCCast = 0;
        //    }
        //}

        //void DiscountAmount_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        //{
        //    if (e.NewTextValue != null && e.NewTextValue != string.Empty && e.NewTextValue != "")
        //    {
        //        viewModel.DiscountAmount = Convert.ToDecimal(e.NewTextValue);
        //    }
        //    else
        //    {
        //        viewModel.DiscountAmount = 0;
        //    }
        //}

        void Entry_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (e.NewTextValue != null && e.NewTextValue != string.Empty && e.NewTextValue != "")
            {
                //viewModel.PromoCodeCommand.Execute(e.NewTextValue);
            }
            else
            {
                viewModel.PromomsgColor = Color.Red;
                viewModel.Promomsg = AppResources.lblEnterPromoCode;
                viewModel.SelectedPromoCode = null;
                // await ErrorDisplayAlert("Please enter promoCode.");
                viewModel.PercentDiscount = ""; viewModel.PromoDiscountAmount = 0;
                viewModel.calculateTotalAmount();
            }
        }

        void SCCast_Unfocused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if (SCCast.Text != null && SCCast.Text != string.Empty && SCCast.Text != "")
            {
                if (SCCast.Text.EndsWith(".") && !viewModel.SCCast.ToString().Contains(".") && !SCCast.Text.Contains(".."))
                {
                    return;
                }

                decimal newvalue;
                decimal.TryParse(SCCast.Text, out newvalue);
                viewModel.SCCast = newvalue;
            }
            else
            {
                viewModel.SCCast = 0;
            }
        }

        void ICCast_Unfocused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if (ICCast.Text != null && ICCast.Text != string.Empty && ICCast.Text != "")
            {
                if (ICCast.Text.EndsWith(".") && !viewModel.ICCast.ToString().Contains(".") && !ICCast.Text.Contains(".."))
                {
                    return;
                }

                decimal newvalue;
                decimal.TryParse(ICCast.Text, out newvalue);
                viewModel.ICCast = newvalue;
            }
            else
            {
                viewModel.ICCast = 0;
            }
        }

        void TPCCast_Unfocused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if (TPCCast.Text != null && TPCCast.Text != string.Empty && TPCCast.Text != "")
            {
                if (TPCCast.Text.EndsWith(".") && !viewModel.TPCCast.ToString().Contains(".") && !TPCCast.Text.Contains(".."))
                {
                    return;
                }

                decimal newvalue;
                decimal.TryParse(TPCCast.Text, out newvalue);
                viewModel.TPCCast = newvalue;
            }
            else
            {
                viewModel.TPCCast = 0;
            }
        }

        void DiscountAmount_Unfocused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            //if (DiscountAmount.Text != null && DiscountAmount.Text != string.Empty && DiscountAmount.Text != "")
            //{
            //    if (DiscountAmount.Text.EndsWith(".") && !viewModel.DiscountAmount.ToString().Contains(".") && !DiscountAmount.Text.Contains(".."))
            //    {
            //        return;
            //    }

            //    decimal newvalue;
            //    decimal.TryParse(DiscountAmount.Text, out newvalue);
            //    viewModel.DiscountAmount = newvalue;
            //}
            //else
            //{
            //    viewModel.DiscountAmount = 0;
            //}
        }
    }
}

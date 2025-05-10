using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotMorten.Xamarin.Forms;
using eWarranty.Controls;
using eWarranty.Hepler;
using eWarranty.ViewModels.Customer.Products;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.Products
{
    public partial class AddProductPage : ContentPage
    {
        public AddProductViewModel viewModel { get; set; }
        public AutoSuggestBox autoSuggestBox { get; set; }
        public AutoSuggestBox autoSuggestBoxSR { get; set; }
        public AddProductPage()
        {
            InitializeComponent();
            //lblmsg.IsVisible = false;
            //  gdDealer.IsVisible = false;
            BindingContext = viewModel = new AddProductViewModel(Navigation);
            
            //< dm:AutoSuggestBox x:Name = "SuggestBox1" Grid.Row = "2"
            //              PlaceholderText = "Enter a country"
            //              TextChanged = "SuggestBox_TextChanged"
            //              QuerySubmitted = "SuggestBox_QuerySubmitted" />



            //  slAutoSuggestBoxSR.Children.Add(autoSuggestBoxSR);

        }

       
        protected async override void OnAppearing()
        {
            // await viewModel.BindingData();
            base.OnAppearing();
        }
        void TitledDateTimePicker_ItemTapped(System.Object sender, System.EventArgs e)
        {
            var dp = sender as DatePicker;
            viewModel.SelectedDate = dp.Date;
            viewModel.DealerRequried = false;
            Device.BeginInvokeOnMainThread(async () =>
            {


              await  viewModel.DateandDealerValid();
            });
            //if (SerialNumberValide == false || ModelNumberValide == false || value < DateTime.Now.AddYears(-1))
            //{
            //    DealerRequried = true;
            //}
            //ValidateModelandSerialNumber
        }
        private async Task<List<string>> GetSuggestionsAsync(string text)
        {
            return await Hepler.Extensions.GetDataAsync(text);
        }
        private void SuggestBox_QuerySubmitted(object sender, AutoSuggestBoxQuerySubmittedEventArgs e)
        {
            if (e.ChosenSuggestion != null)
            {

                AutoSuggestBox box = (AutoSuggestBox)sender;
                if (box.PlaceholderText.Contains("Model"))
                {
                    box.ItemsSource = null;
                    box.IsSuggestionListOpen = false;
                    viewModel.ModelNo = e.QueryText;
                }
                else
                {
                    viewModel.SerialNo = e.QueryText;
                }
                box.Unfocus();

            }
            //    status.Text = "Query submitted: " + e.QueryText;
            //else
            //    status.Text = "Suggestion chosen: " + e.ChosenSuggestion;

            ////Move focus to the next control or stop focus
            if (sender == autoSuggestBox)
                autoSuggestBox.Unfocus();
            else if (sender == autoSuggestBoxSR)
                autoSuggestBoxSR.Unfocus();
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            viewModel.IsBusy = true;
            DropDownPopupPage dropDownPopup = new DropDownPopupPage();
            dropDownPopup.Title = "Model Number";

            if (!string.IsNullOrEmpty(viewModel.ModelNo))
                await dropDownPopup.GetModelNumber(viewModel.ModelNo);
            //else
            //  await  dropDownPopup.GetModelNumber("a");
            dropDownPopup.DropDownSelectedItem += DropDownPopup_DropDownSelectedItem;
            viewModel.IsBusy = false;
            PopupNavigation.PushAsync(dropDownPopup);
        }

        private void DropDownPopup_DropDownSelectedItem(object sender, EventArgs e)
        {

            DropDownPopupPage control = sender as DropDownPopupPage;
            viewModel.ModelNo = control.SelectedItem.Title;
            viewModel.ModelNumberValide = false;
            if (!viewModel.ModelNumberValide)
                viewModel.DealerRequried = true;
            else if (!viewModel.SerialNumberValide)
                viewModel.DealerRequried = true;
            else if (viewModel.ModelNumberValide && viewModel.SerialNumberValide)
                viewModel.DealerRequried = false;

            viewModel.modelNumberSearchResponse = new Core.ResponseModels.ModelNumberSearchResponse() { ProductClassificationId = control.SelectedItem.Id, ModelName = control.SelectedItem.Title };
        }

        void TapGestureRecognizer_Tapped_1(System.Object sender, System.EventArgs e)
        {
        }

       //async void txtSerialNo_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
       // {
       //     //if (string.IsNullOrEmpty(viewModel.ModelNo))
       //     //{
       //     //   await this.DisplayAlert("Error!", "Please enter model number","Okay");
       //     //}
       //    // await viewModel.ValidateSerialNumber();
       // }

       //async void txtSerialNo_Completed(System.Object sender, System.EventArgs e)
       // {
       //     //if (string.IsNullOrEmpty(viewModel.ModelNo))
       //     //{
       //     //    await this.DisplayAlert("Error!", "Please enter model number", "Okay");
       //     //}
           

       // }

       async void ImageEntry_Completed(System.Object sender, System.EventArgs e)
        {
            //if (string.IsNullOrEmpty(viewModel.ModelNo))
            //{
            //    await this.DisplayAlert("Error!", "Please enter model number", "Okay");
            //}
            await viewModel.ValidateModelNumber();
        }

       async void ImageEntry_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            //if (string.IsNullOrEmpty(viewModel.ModelNo))
            //{
            //    await this.DisplayAlert("Error!", "Please enter model number", "Okay");
            //}
            await viewModel.ValidateModelNumber();
        }

        async void ImageEntry_Completed_1(System.Object sender, System.EventArgs e)
        {
            await viewModel.ValidateModelNumber();
        }

        async void AutoSuggestBox_TextChanged(System.Object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            AutoSuggestBox box = (AutoSuggestBox)sender;
            // Filter the list based on text input
            box.ItemsSource = await GetSuggestionsAsync(box.Text);
            await viewModel.ValidateModelNumber();
        }

        void AutoSuggestBox_SuggestionChosen(System.Object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            AutoSuggestBox box = (AutoSuggestBox)sender;
            // Filter the list based on text input
            viewModel.ModelNo = box.Text.ToString();
        }

        void autoComplete_ValueChanged(System.Object sender, Syncfusion.SfAutoComplete.XForms.ValueChangedEventArgs e)
        {
            if(! string.IsNullOrEmpty(e.Value.ToString()))
            {
                string ModelNo = e.Value.ToString();
                viewModel.ModelNo = e.Value.ToString();
            }
        }

        async void autoComplete_FocusChanged(System.Object sender, Syncfusion.SfAutoComplete.XForms.FocusChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(autoComplete.Text.ToString()))
            {
                string ModelNo = autoComplete.Text.ToString();
                viewModel.ModelNo = autoComplete.Text.ToString();
                var yesno = await viewModel.CheckInvalidModelNo(ModelNo);
                if (yesno == "yes")
                {
                    viewModel.ModelNo = "";
                    autoComplete.Text = "";
                }
            }
        }

        async void TapGestureRecognizer_Tapped_2(System.Object sender, System.EventArgs e)
        {
            try
            {
                var qrcode = await Extensions.QrScanning();
                if (qrcode != null)
                {

                    viewModel.ModelNo = qrcode;
                    autoComplete.Text = qrcode;
                    string ModelNo = autoComplete.Text.ToString();
                    var yesno = await viewModel.CheckInvalidModelNo(ModelNo);
                    if (yesno == "yes")
                    {
                        viewModel.ModelNo = "";
                        autoComplete.Text = "";
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
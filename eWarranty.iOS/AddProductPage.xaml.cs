using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotMorten.Xamarin.Forms;
using eWarranty.Controls;
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
          //  lblmsg.IsVisible = false;
          ////  gdDealer.IsVisible = false;
          //  BindingContext = viewModel= new AddProductViewModel(Navigation);
          //  //< dm:AutoSuggestBox x:Name = "SuggestBox1" Grid.Row = "2"
          //  //              PlaceholderText = "Enter a country"
          //  //              TextChanged = "SuggestBox_TextChanged"
          //  //              QuerySubmitted = "SuggestBox_QuerySubmitted" />


          //   autoSuggestBox = new AutoSuggestBox();
          //  autoSuggestBox.TextColor = Color.FromHex("#707070");
          //  autoSuggestBox.PlaceholderText = "Search Model Number";
          //  autoSuggestBox.TextChanged += SuggestBox_TextChanged;
          //  autoSuggestBox.QuerySubmitted += SuggestBox_QuerySubmitted;
          ////  slAutoSuggestBox.Children.Add(autoSuggestBox);

          //   autoSuggestBoxSR = new AutoSuggestBox();
          //  autoSuggestBox.TextColor = Color.FromHex("#707070");
          //  autoSuggestBoxSR.PlaceholderText = "Search Serial Number";
          //  autoSuggestBoxSR.TextChanged += AutoSuggestBoxSR_TextChanged; ;
          //  autoSuggestBoxSR.QuerySubmitted += SuggestBox_QuerySubmitted;

          //  slAutoSuggestBoxSR.Children.Add(autoSuggestBoxSR);

        }

        //private async void AutoSuggestBoxSR_TextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        //{
        //    //SelectedCategory.Id
        //    if (viewModel.ModelNo == null)
        //    {
        //        await viewModel.ErrorDisplayAlert("Please enter model number.");
        //        return;
        //    }
        //    AutoSuggestBox box = (AutoSuggestBox)sender;
        //    if (box.Text == viewModel.SerialNo)
        //    {
        //        box.IsSuggestionListOpen = false;
        //        return;
        //    }
            
        //    // Filter the list based on text input
        //    if (!string.IsNullOrEmpty(box.Text) && box.Text.Length >= 4)
        //    {
        //        if (box.Text == viewModel.SerialNo)
        //        {
        //            return;
        //        }
        //        viewModel.SerialNo = string.Empty;
        //        List<string> ItemSourse = await viewModel.GetSerialNumber(box.Text);// GetSuggestions(box.Text);
        //        if (ItemSourse?.Count > 0)
        //        {
        //            box.TextColor = Color.FromHex("#A6A6A6");
        //            box.ItemsSource = ItemSourse;
        //        }
        //        else
        //        {
        //            lblmsg.IsVisible = true;
        //  //  gdDealer.IsVisible = true;
        //         //   viewModel.ModelNumberValide = false;
        //            box.TextColor = Color.Red;
        //            viewModel.SerialNo = box.Text;
        //        }
        //    }
        //}

        //protected async override void OnAppearing()
        //{
        //  // await viewModel.BindingData();
        //    base.OnAppearing();
        //}
        //private async void SuggestBox_TextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        //{
        //    lblmsg.IsVisible = false;
        //   // gdDealer.IsVisible = false;
        //    //SelectedCategory.Id
        //    //if (viewModel.SelectedCategory==null)
        //    //{
        //    //    await viewModel.ErrorDisplayAlert("Please select product category.");
        //    //    return;
        //    //}
        //    AutoSuggestBox box = (AutoSuggestBox)sender;
           
        //    // Filter the list based on text input
        //    if (!string.IsNullOrEmpty(box.Text) && box.Text.Length >= 4)
        //    {
        //        if(box.Text == viewModel.ModelNo)
        //        {
        //            box.IsSuggestionListOpen = false;
        //            return;
        //        }
                
        //        List<string> ItemSourse = await viewModel.GetProductNumbers(box.Text);// GetSuggestions(box.Text);
        //        if (ItemSourse?.Count > 0)
        //        {
        //           // viewModel.ModelNo = string.Empty;
        //           // viewModel.IsBusy = false;
        //            box.TextColor = Color.FromHex("#A6A6A6");
        //            box.ItemsSource = ItemSourse;
        //            viewModel.ModelNumberValide = false;
        //        }
        //        else
        //        {
        //            box.TextColor = Color.Red;
        //            lblmsg.IsVisible = true;
        //          //  gdDealer.IsVisible = true;
        //            viewModel.ModelNo = box.Text;
        //            viewModel.ModelNumberValide = true;
        //        }
        //       // viewModel.IsBusy = false;
        //    }
        //}
        //void TitledDateTimePicker_ItemTapped(System.Object sender, System.EventArgs e)
        //{
        //    var dp = sender as DatePicker;
        //    viewModel.SelectedDate = dp.Date;
        //}
        //private List<string> GetSuggestions(string text)
        //{
        //    return eWarranty.Hepler.Extensions.GetData(text);
        //}
        //private void SuggestBox_QuerySubmitted(object sender, AutoSuggestBoxQuerySubmittedEventArgs e)
        //{
        //    if (e.ChosenSuggestion != null)
        //    {
                
        //        AutoSuggestBox box = (AutoSuggestBox)sender;
        //        if (box.PlaceholderText.Contains("Model"))
        //        {
        //            box.ItemsSource = null;
        //            box.IsSuggestionListOpen = false;
        //            viewModel.ModelNo = e.QueryText;
        //        }
        //        else
        //        {
        //            viewModel.SerialNo = e.QueryText;
        //        }
        //        box.Unfocus();
                
        //    }
        //    //    status.Text = "Query submitted: " + e.QueryText;
        //    //else
        //    //    status.Text = "Suggestion chosen: " + e.ChosenSuggestion;

        //    ////Move focus to the next control or stop focus
        //    if (sender == autoSuggestBox)
        //        autoSuggestBox.Unfocus();
        //    else if (sender == autoSuggestBoxSR)
        //        autoSuggestBoxSR.Unfocus();
        //}

        //void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        //{
        //    viewModel.IsBusy = true;
        //    DropDownPopupPage dropDownPopup = new DropDownPopupPage();
        //    dropDownPopup.Title = "Model Number";

        //    //if (!string.IsNullOrEmpty(viewModel.ModelNo))
        //    //  await  dropDownPopup.GetModelNumber(viewModel.ModelNo);
        //    //else
        //    //  await  dropDownPopup.GetModelNumber("a");
        //    dropDownPopup.DropDownSelectedItem += DropDownPopup_DropDownSelectedItem;
        //    viewModel.IsBusy = false;
        //     PopupNavigation.PushAsync(dropDownPopup);
        //}

        //private void DropDownPopup_DropDownSelectedItem(object sender, EventArgs e)
        //{

        //    DropDownPopupPage control = sender as DropDownPopupPage;
        //    viewModel.ModelNo = control.SelectedItem.Title;
        //    viewModel.ModelNumberValide = false;
        //    viewModel.modelNumberSearchResponse = new Core.ResponseModels.ModelNumberSearchResponse() { ProductClassificationId= control.SelectedItem .Id, ModelName= control.SelectedItem .Title};
        //}

        //void TapGestureRecognizer_Tapped_1(System.Object sender, System.EventArgs e)
        //{
        //}
    }
}

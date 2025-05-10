using System;
using System.Collections.Generic;
using eWarranty.Core.ResponseModels;
using eWarranty.ViewModels.Customer.CommonPages;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.CommonPages
{
    public partial class PickAddressesPage : ContentPage
    {
        public AddressesViewModel viewModel { get; set; }
        public PickAddressesPage()
        {
            InitializeComponent();
            BindingContext = viewModel= new AddressesViewModel(Navigation);
        }
        public event EventHandler SelectedAddress;
        void ListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as AddressResponse;
            //  Navigation.PopAsync();
            //  MessagingCenter.Send<AddressesPage, Address>(this, "Address", item);
            EventHandler handler = SelectedAddress;
            if (handler != null)
            {
                NavigationPage.SetHasBackButton(this, false);
                NavigationPage.SetBackButtonTitle(this, "");
                handler(item, e);
                //handler.Invoke(item, e);
            }
        }
        ViewCell lastCell;
        void ViewCell_Tapped(System.Object sender, System.EventArgs e)
        {
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.Transparent;
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = (Color)Application.Current.Resources["BlueColor"];
                lastCell = viewCell;
            }
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            EventHandler handler = SelectedAddress;
            if (handler != null)
            {
                NavigationPage.SetHasBackButton(this, false);
                NavigationPage.SetBackButtonTitle(this, "");
                handler(viewModel.SelectedAddress, e);
                //handler.Invoke(item, e);
            }
        }
    }
}

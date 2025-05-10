using System;
using System.Collections.Generic;
using eWarranty.Core.Models;
using eWarranty.ViewModels.Customer.CommonPages;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.CommonPages
{
    public partial class SelectAddressesPage : ContentPage
    {
        public SelectAddressesPage()
        {
            InitializeComponent();
            BindingContext = new AddressesViewModel(Navigation);
        }
        public event EventHandler SelectedAddress;
        void ListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Address;
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
    }
}

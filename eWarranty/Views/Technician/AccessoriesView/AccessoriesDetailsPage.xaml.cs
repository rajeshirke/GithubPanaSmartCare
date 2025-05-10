using System;
using System.Collections.Generic;
using eWarranty.Views.Technician.TaskViews;
using Xamarin.Forms;
using eWarranty.Hepler;

namespace eWarranty.Views.Technician.AccessoriesView
{
    public partial class AccessoriesDetailsPage : ContentPage
    {
        public AccessoriesDetailsPage()
        {
            InitializeComponent();
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new CustomerLocationPage());
        }

        void TapGestureRecognizer_Tapped_1(System.Object sender, System.EventArgs e)
        {
             Extensions.PlacePhoneCall("0525665713");
        }
    }
}

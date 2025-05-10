using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace eWarranty.Views.Customer.AMCRequest
{
    public partial class AMCReqSuccessPage : ContentPage
    {
        public AMCReqSuccessPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            var item = Navigation.NavigationStack[2];
             Navigation.RemovePage(item);
           
             Navigation.PopAsync();

        }
    }
}

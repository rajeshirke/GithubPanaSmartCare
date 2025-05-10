using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace eWarranty.Views.Customer.Accesssories
{
    public partial class AccesssoriesSuccessPage : ContentPage
    {
        public AccesssoriesSuccessPage()
        {
            InitializeComponent();
        }
        void Back_Clicked(System.Object sender, System.EventArgs e)
        {
            var item = Navigation.NavigationStack[2];
            Navigation.RemovePage(item);

            Navigation.PopAsync();
        }
    }
}

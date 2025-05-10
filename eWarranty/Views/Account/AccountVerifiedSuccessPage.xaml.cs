using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace eWarranty.Views.Account
{
    public partial class AccountVerifiedSuccessPage : ContentPage
    {
        public AccountVerifiedSuccessPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SingUpProfileUpdatePage());
        }
    }
}

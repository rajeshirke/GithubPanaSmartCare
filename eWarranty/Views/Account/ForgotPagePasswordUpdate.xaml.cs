using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Account;
using Xamarin.Forms;

namespace eWarranty.Views.Account
{
    public partial class ForgotPagePasswordUpdate : ContentPage
    {
        public ForgotPagePasswordUpdate()
        {
            InitializeComponent(); //new
            NavigationPage.SetHasBackButton(this, false);// = "False"
            BindingContext = new ForgotPagePasswordViewModel(Navigation);
        }
    }
}

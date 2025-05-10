using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Account;
using Xamarin.Forms;

namespace eWarranty.Views.Account
{
    public partial class UserPasswordSetupPage : ContentPage
    {
        public UserPasswordSetupPage()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = (Color)Application.Current.Resources["BlueColor"];
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
            BindingContext = new PasswordSetupViewModel(Navigation);
        }
    }
}

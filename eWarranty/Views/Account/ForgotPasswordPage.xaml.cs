using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Account;
using Xamarin.Forms;

namespace eWarranty.Views.Account
{
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordViewModel viewModel { get; set; }
        public ForgotPasswordPage(string email)
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = (Color)Application.Current.Resources["BlueColor"];
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
            BindingContext = viewModel= new ForgotPasswordViewModel(Navigation);
            viewModel.Email = email;
        }
    }
}

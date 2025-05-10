using System;
using System.Collections.Generic;
using eWarranty.Hepler;
using eWarranty.ViewModels.Account;
using Xamarin.Forms;

namespace eWarranty.Views.Account
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpViewModel viewModel { get; set; }
        public SignUpPage()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = (Color)Application.Current.Resources["BlueColor"];
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
            BindingContext = viewModel= new SignUpViewModel(Navigation);
        }
        protected async override void OnAppearing()
        {
          
            base.OnAppearing();
           // CommonAttribute.UserLocation = await Extensions.GetGeolocation();
        }
    }
}

using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.ProfileView;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.UserProfile
{
    public partial class ChnagePasswordPage : ContentPage
    {
        public ChnagePasswordPage()
        {
            InitializeComponent();
            BindingContext = new ChnagePasswordViewModel(Navigation);
        }
    }
}

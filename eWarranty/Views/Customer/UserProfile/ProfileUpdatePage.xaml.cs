﻿using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.ProfileView;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.UserProfile
{
    public partial class ProfileUpdatePage : ContentPage
    {
        public ProfileUpdatePage()
        {
            InitializeComponent();
            BindingContext = new MyProfileViewModel(Navigation);
        }
    }
}

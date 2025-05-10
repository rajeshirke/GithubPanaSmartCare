using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.ProfileView;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.UserProfile
{
    public partial class PromotionPage : ContentPage
    {
        public PromotionsViewModel viewModel { get; set; }

        public PromotionPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new PromotionsViewModel(Navigation);
        }
    }
}

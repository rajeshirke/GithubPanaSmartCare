using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Technician.ServiceCenterView;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.ServiceCenterView
{
    public partial class TipsAndFAQPage : ContentPage
    {
        public TipsAndFAQViewModel viewModel { get; set; }
        public TipsAndFAQPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new TipsAndFAQViewModel(Navigation);
        }
    }
}

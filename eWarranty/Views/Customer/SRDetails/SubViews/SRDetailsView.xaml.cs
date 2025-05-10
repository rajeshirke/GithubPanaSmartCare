using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.SRDetails.SubViews;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.SRDetails.SubViews
{
    public partial class SRDetailsView : ContentView
    {
        public SRDetailsView()
        {
            InitializeComponent();
            BindingContext = new SRDetailsViewModel(Navigation);
        }
    }
}

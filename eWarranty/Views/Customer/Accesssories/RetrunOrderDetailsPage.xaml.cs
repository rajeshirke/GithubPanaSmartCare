using System;
using System.Collections.Generic;
using eWarranty.Core.ResponseModels;
using eWarranty.ViewModels.Customer.Accesssories;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.Accesssories
{
    public partial class RetrunOrderDetailsPage : ContentPage
    {
        public RetrunOrderDetailsPage(OrderDetailResponse order)
        {
            InitializeComponent();
            BindingContext = new RetrunOrderDetailsViewModel(Navigation, order);
        }
    }
}

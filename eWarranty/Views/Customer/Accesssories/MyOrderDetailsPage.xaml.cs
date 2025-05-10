using System;
using System.Collections.Generic;
using eWarranty.Core.ResponseModels;
using eWarranty.ViewModels.Customer.Accesssories;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.Accesssories
{
    public partial class MyOrderDetailsPage : ContentPage
    {
        public MyOrderDetailsPage(OrderListResponse order)
        {
            InitializeComponent();
            BindingContext = new MyOrderDetailsViewModel(Navigation, order);
        }
    }
}

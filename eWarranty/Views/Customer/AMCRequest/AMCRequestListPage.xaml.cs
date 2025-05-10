using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.AMCRequest;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.AMCRequest
{
    public partial class AMCRequestListPage : ContentPage
    {
        public AMCRequestListPage()
        {
            InitializeComponent();
            BindingContext = new AMCRequestListViewModel(Navigation);
        }
    }
}

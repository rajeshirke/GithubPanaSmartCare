using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.Accesssories;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.Accesssories
{
    public partial class AccesssoriesOderHistoryPage : ContentPage
    {
        public AccesssoriesOderHistoryPage()
        {
            InitializeComponent();
            BindingContext = new AccesssoriesOderHistoryViewModel(Navigation);
        }
    }
}

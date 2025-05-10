using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.Inquiry;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.InquiryView
{
    public partial class InquiryPage : ContentPage
    {
        public InquiryPage()
        {
            InitializeComponent();
            BindingContext = new InquiryViewModel(Navigation);
        }
    }
}

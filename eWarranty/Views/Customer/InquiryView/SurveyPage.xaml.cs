using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.Inquiry;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.InquiryView
{
    public partial class SurveyPage : ContentPage
    {
        public SurveyPage()
        {
            InitializeComponent();
            BindingContext = new SurveyViewModel(Navigation);
        }
    }
}

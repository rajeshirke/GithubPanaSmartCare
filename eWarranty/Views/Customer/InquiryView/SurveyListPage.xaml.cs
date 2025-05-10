using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.Inquiry;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.InquiryView
{
    public partial class SurveyListPage : ContentPage
    {
        public SurveyListPage()
        {
            InitializeComponent();
            BindingContext = new SurveyListViewModel(Navigation);
        }
    }
}

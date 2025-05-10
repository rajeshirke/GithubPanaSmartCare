using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.Inquiry;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.InquiryView
{
    public partial class FeedBackPage : ContentPage
    {
        public FeedBackViewModel viewModel { get; set; }
        public FeedBackPage(long sid,long ServiceRequestTypeId)
        {
            InitializeComponent();
            BindingContext = viewModel= new FeedBackViewModel(Navigation,sid, ServiceRequestTypeId);
        }

        void TapGestureRecognizer1_Tapped(System.Object sender, System.EventArgs e)
        {
            Label label = sender as Label;
            viewModel.SetupColorCode(Convert.ToInt16(label.Text));
        }
    }
}

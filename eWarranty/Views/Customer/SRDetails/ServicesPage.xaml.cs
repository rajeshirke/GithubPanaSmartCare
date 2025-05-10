using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eWarranty.Controls;
using eWarranty.ViewModels.Customer.SRDetails;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.SRDetails
{
    public partial class ServicesPage : ContentPage
    {
        public ServicesViewModel viewModel { get; set; }
        public ServicesPage()
        {
            InitializeComponent();
          
            BindingContext = viewModel= new ServicesViewModel(Navigation);
            
        }
        protected async  override void OnAppearing()
        {
          
            base.OnAppearing();
        }
        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            var control = sender as SegmentedTabControl;
            if (control.SelectedSegment == 1)
            {
                viewModel.FilteData(1);
            }
            else
            {
                viewModel.FilteData(2);
            }
        }
    }
}

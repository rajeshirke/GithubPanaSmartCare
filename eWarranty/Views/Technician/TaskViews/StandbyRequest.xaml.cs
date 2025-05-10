using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.Products;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.TaskViews
{
    public partial class StandbyRequest : ContentPage
    {
        ProductDetailsViewModel productDetailsView;
        public StandbyRequest()
        {
            InitializeComponent();
            //BindingContext = productDetailsView = new ProductDetailsViewModel(Navigation, pmid);
        }

        protected async override void OnAppearing()
        {          
            base.OnAppearing();
        }
    }
}

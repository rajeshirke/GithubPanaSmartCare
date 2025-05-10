using System;
using System.Collections.Generic;
using eWarranty.Hepler;
using eWarranty.ViewModels.Customer.Products;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.Products
{
    public partial class ProductDetailsPage : ContentPage
    {

        ProductDetailsViewModel productDetailsView;
        public ProductDetailsPage(long pmid)
        {
            InitializeComponent();
            BindingContext = productDetailsView= new ProductDetailsViewModel(Navigation, pmid);
        }
        protected async override void OnAppearing()
        {
            //if(productDetailsView.ProductFiles != null)
            //{
            //    lvImages.ItemsSource = null;
            //    lvImages.ItemsSource = productDetailsView.ProductFiles;
            //}
            
            base.OnAppearing();
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            productDetailsView.AddSRCommand.Execute(null);


        }
    }
}

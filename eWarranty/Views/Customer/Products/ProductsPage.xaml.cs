using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.Products;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.Products
{
    public partial class ProductsPage : ContentPage
    {
        public ProductsViewModel viewModel { get; set; }
        public ProductsPage()
        {
            InitializeComponent();
            BindingContext = viewModel= new ProductsViewModel(Navigation);
        }
        protected async override void OnAppearing()
        {
           
       //  await  viewModel.BindingData();
          
            base.OnAppearing();
        }

        void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            string sKey = string.Empty;
            if (!string.IsNullOrEmpty(e.NewTextValue))
                sKey = e.NewTextValue.Trim();
                viewModel.SearchModelNumber(sKey);
            
        }

        void SearchBar_SearchButtonPressed(System.Object sender, System.EventArgs e)
        {
            var btn = sender as SearchBar;
            if (!string.IsNullOrEmpty(btn.Text))
            {
                viewModel.SearchModelNumber(btn.Text.Trim());
            }
        }
    }
}

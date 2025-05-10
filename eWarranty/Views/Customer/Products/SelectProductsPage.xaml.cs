using System;
using System.Collections.Generic;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Models;
using eWarranty.ViewModels.Customer.Products;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.Products
{
    public partial class SelectProductsPage : ContentPage
    {
        public SelectProductsViewModel viewModel { get; set; }
        public SelectProductsPage(string pageType)
        {
            try
            {
                InitializeComponent();
                BindingContext = viewModel = new SelectProductsViewModel(Navigation, pageType);
            }
            catch(Exception ex)
            {

            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.RefreshData();

        }

        void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {

           
            viewModel.SearchModelNumber(e.NewTextValue);
        }        //void ListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
                 //{

        //    var item = e.SelectedItem as ProductModelWarrantyResponse;

        //    viewModel.SelectedProductCommand.Execute(item);
        //}

        //void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        //{
        //   //// var selectedItems = e.CurrentSelection;
        //   //// if (selectedItems.Count > 0)
        //   //// {
        //   ////     var item = selectedItems[0] as ProductModelWarrantyResponse;

        //   ////     viewModel.SelectedProductCommand.Execute(item);
        //   //// }
        //   //// //viewModel.SelectProductModel.SelectedItem = true;
        //   //((CollectionView)sender).SelectedItem = null;
        //}
    }
}

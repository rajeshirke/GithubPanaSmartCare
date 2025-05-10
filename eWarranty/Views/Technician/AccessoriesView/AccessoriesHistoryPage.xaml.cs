using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Technician.AccessoriesView;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.AccessoriesView
{
    public partial class AccessoriesHistoryPage : ContentPage
    {
        public AccessoriesViewModel viewModel { get; set; }
        public AccessoriesHistoryPage()
        {
            try
            {
                InitializeComponent();
                BindingContext = viewModel = new AccessoriesViewModel(Navigation);
            }
            catch (Exception ex)
            {

            }
        }

        //void SearchBar_SearchButtonPressed(System.Object sender, System.EventArgs e)
        //{
        //    var btn = sender as SearchBar;
        //    if (!string.IsNullOrEmpty(btn.Text))
        //    {
        //        viewModel.SearchModelNumber(btn.Text.Trim());
        //    }
        //}

        //void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        //{
        //    string sKey = string.Empty;
        //    if (!string.IsNullOrEmpty(e.NewTextValue))
        //        sKey = e.NewTextValue.Trim();
        //    viewModel.SearchModelNumber(sKey);
        //}

    }
}

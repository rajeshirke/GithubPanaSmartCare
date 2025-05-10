using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Technician.SupportViews;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.SupportViews
{
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage()
        {
            InitializeComponent();
            BindingContext = new TechProductsViewModel(Navigation);
        }

        void ListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            string url = "http://panasonic.ae/en/manuals/A12PKD.pdf";
            Navigation.PushAsync(new PDFViewerPage(url));
        }
    }
}

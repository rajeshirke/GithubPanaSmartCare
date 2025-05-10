using System;
using System.Collections.Generic;
using eWarranty.Hepler;
using eWarranty.ViewModels.Customer.Products;
using eWarranty.ViewModels.Customer.SRDetails.SubViews;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.SRDetails.SubViews
{
    public partial class ProductDetailsSubView : ContentView
    {
        public ProductDetailsSubView(long pmid)
        {
            InitializeComponent();
           //  BindingContext = new SRDetailsViewModel(Navigation);
            BindingContext = new ProductDetailsViewModel(Navigation,pmid);

        }
        
    }
}

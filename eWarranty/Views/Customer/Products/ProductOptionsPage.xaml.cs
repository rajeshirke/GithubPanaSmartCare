using System;
using System.Collections.Generic;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.Views.Customer.Accesssories;
using eWarranty.Views.Customer.AMCRequest;
using eWarranty.Views.Customer.CommonPages;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.Products
{
    public partial class ProductOptionsPage : PopupPage
    {
       
        public ProductModelWarrantyResponse Product { get; set; }
        [Obsolete]
        public ProductOptionsPage(ProductModelWarrantyResponse product)
        {
            Product = product;
            InitializeComponent();
        }

        void TapOnServiceReq_Tapped(System.Object sender, System.EventArgs e)
        {
            if (CommonAttribute.SRInputModel == null)
                CommonAttribute.SRInputModel = new ServiceRequest();

            CommonAttribute.SRInputModel.ProductModelWarrantyResponse = Product;
            PopupNavigation.PopAsync();
            Navigation.PushAsync(new ServicecenterPage());
        }

        void TapAMC_Tapped(System.Object sender, System.EventArgs e)
        {
            if (CommonAttribute.SRInputModel == null)
                CommonAttribute.SRInputModel = new ServiceRequest();

            CommonAttribute.SRInputModel.ProductModelWarrantyResponse = Product;
            PopupNavigation.PopAsync();
            Navigation.PushAsync(new AddAMCRequestPage());
        }

        void TapAccessory_Tapped(System.Object sender, System.EventArgs e)
        {
            PopupNavigation.PopAsync();
            Navigation.PushAsync(new AccesssoriesPage());
        }

        async void TapDelete_Tapped(System.Object sender, System.EventArgs e)
        {
            var res= await Application.Current.MainPage.DisplayAlert("Confirmation", "Are you sure want to delete?", AppResources.lblOk, AppResources.lblCancel);
            if (res)
            {
                MessagingCenter.Send<ProductOptionsPage, long>(this, "Deleteproducts", Product.ProductModelID);
                MessagingCenter.Unsubscribe<ProductOptionsPage, long>(this, "Deleteproducts");
            }
            PopupNavigation.PopAsync();
        }

        void DetailsGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            if (CommonAttribute.EditServiceRequest == null)
                CommonAttribute.EditServiceRequest = new ServiceRequestDetailsNewResponse();

            CommonAttribute.EditServiceRequest.ProductModelId = Product.ProductModelID;
            PopupNavigation.PopAsync();
            Navigation.PushAsync(new ProductDetailsPage(Product.ProductModelID));
        }
    }
}

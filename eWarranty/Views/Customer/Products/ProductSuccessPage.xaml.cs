using System;
using System.Collections.Generic;
using System.Linq;
using eWarranty.Resx;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.Products
{
    public partial class ProductSuccessPage : ContentPage
    {
        public ProductSuccessPage()
        {
            InitializeComponent();
           
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Navigation.NavigationStack.Count > 3)
                btnBack.Text = AppResources.lblGotoMyProducts;
            else
                btnBack.Text = AppResources.lblGotoMyProducts;
        }
        void Back_Clicked(System.Object sender, System.EventArgs e)
        {
            var _navigation = Application.Current.MainPage.Navigation;
            var _lastPage = _navigation.NavigationStack.LastOrDefault();

            _navigation.RemovePage(_lastPage);

            var _lastPage2 = _navigation.NavigationStack.LastOrDefault();
            //Remove last page
            _navigation.RemovePage(_lastPage2);

            if (_navigation.NavigationStack.Count >1)
            {
                var _lastPage3 = _navigation.NavigationStack.LastOrDefault();
                //Remove last page
                _navigation.RemovePage(_lastPage3);
              //  MessagingCenter.Send<ProductSuccessPage>(this, "Updateproducts");
                _navigation.PushAsync(new ProductsPage());
            }
            else {

              
                _navigation.PushAsync(new ProductsPage());
            }
        }
    }
}

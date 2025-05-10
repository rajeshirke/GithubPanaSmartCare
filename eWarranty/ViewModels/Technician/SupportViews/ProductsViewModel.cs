using System;
using System.Collections.Generic;
using System.Windows.Input;
using eWarranty.Core.Models;
using eWarranty.Models;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Technician.SupportViews
{
    public class TechProductsViewModel : BaseViewModel
    {
        public TechProductsViewModel(INavigation navigation) : base(navigation)
        {
            BindingData();
        }
        public void BindingData()
        {
            //if (ProductModels == null)
            //    ProductModels = new List<ProductModel>();

            //ProductModels.Add(new ProductModel() { Category = "Electronics", CategoryId = 1, ModelNumber = "PN354345", Pid = 1, POD = new DateTime(2019, 11, 20), ProductName = "Refrigerator", SerialNumber = "SN34546456", warrantyDate = new DateTime(2020, 11, 19), ProductStatusColor = Color.Green });
            //ProductModels.Add(new ProductModel() { Category = "Electronics", CategoryId = 1, ModelNumber = "45645645", Pid = 1, POD = new DateTime(2020, 11, 20), ProductName = "Washing Machine", SerialNumber = "SN7654554", warrantyDate = new DateTime(2021, 11, 19), ProductStatusColor = Color.Red });
            //ProductModels.Add(new ProductModel() { Category = "Electronics", CategoryId = 1, ModelNumber = "4353453", Pid = 1, POD = new DateTime(2019, 11, 20), ProductName = "Camera", SerialNumber = "CM3453453", warrantyDate = new DateTime(2020, 11, 19), ProductStatusColor = Color.Green });
            //ProductModels.Add(new ProductModel() { Category = "Electronics", CategoryId = 1, ModelNumber = "PN354345", Pid = 1, POD = new DateTime(2019, 11, 20), ProductName = "Refrigerator", SerialNumber = "SN3455643564", warrantyDate = new DateTime(2020, 11, 19), ProductStatusColor = Color.Green });


            SelectedProductCommand = new Command(() =>
            {
              //  Navigation.PushAsync(new AddProductPage());
            });
        }
        #region events
        //AddProductPage
        public ICommand SelectedProductCommand { get; set; }
       
        #endregion
        #region Properties
        private List<ProductModel> _ProductModels;
        public List<ProductModel> ProductModels
        {
            get { return _ProductModels; }
            set
            {
                _ProductModels = value;
                OnPropertyChanged("ProductModels");
            }
        }
        #endregion
    }
}

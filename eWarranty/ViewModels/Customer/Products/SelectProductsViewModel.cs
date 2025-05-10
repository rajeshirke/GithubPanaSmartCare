using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Views.Customer.AMCRequest;
using eWarranty.Views.Customer.CommonPages;
using eWarranty.Views.Customer.Products;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.Products
{
    public class SelectProductsViewModel : BaseViewModel
    {
        public SelectProductsViewModel(INavigation navigation,string pageType) : base(navigation)
        {
            IsBusy = true;
            pageTypeNavigation = pageType;
            DataBinding();
        }
        public string pageTypeNavigation { get; set; }
        public Command AddProductCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new AddProductPage());
                });
            }
        }
        #region method
        public async Task DataBinding()
        {
            try
            {
                if (ProductModels == null)
                    ProductModels = new ObservableCollection<ProductModelWarrantyResponse>();

                if (MasterProductModels == null)
                    MasterProductModels = new ObservableCollection<ProductModelWarrantyResponse>();

                ProductsManagementSL productsManagement = new ProductsManagementSL();

                List<ProductModelWarrantyResponse> resproductModels = await productsManagement.GetCustomerProducts(CommonAttribute.CustomeProfile.PersonId);
                if (resproductModels != null)
                {

                    //ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(resproductModels.OrderBy(u => u.PurchaseDate));
                    ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(resproductModels);
                    MasterProductModels = new ObservableCollection<ProductModelWarrantyResponse>(resproductModels);
                }

                if (CommonAttribute.SRInputModel == null)
                    CommonAttribute.SRInputModel = new ServiceRequest();

            }
            catch(Exception ex)
            {
                IsBusy = true;
            }
            IsBusy = false;
        }
        #endregion

        #region Properties
        private ObservableCollection<ProductModelWarrantyResponse> _ProductModels;
        public ObservableCollection<ProductModelWarrantyResponse> ProductModels
        {
            get { return _ProductModels; }
            set
            {
                _ProductModels = value;
                OnPropertyChanged("ProductModels");
            }
        }
        private ObservableCollection<ProductModelWarrantyResponse> _MasterProductModels;
        public ObservableCollection<ProductModelWarrantyResponse> MasterProductModels
        {
            get { return _MasterProductModels; }
            set
            {
                _MasterProductModels = value;
                OnPropertyChanged(nameof(MasterProductModels));
            }
        }
        private ProductModelWarrantyResponse _SelectProductModel;
        public ProductModelWarrantyResponse SelectProductModel
        {
            get { return _SelectProductModel; }
            set
            {

                _SelectProductModel = value;
                
                OnPropertyChanged("SelectProductModel");
               // CommonAttribute.SRInputModel.SelectedProduct = value;
              //  Navigation.PushAsync(new ServicecenterPage());
            }
        }
        private double _RowHeight;
        public double RowHeight
        {
            get { return _RowHeight; }
            set
            {

                _RowHeight = value;

                OnPropertyChanged("RowHeight");
                // CommonAttribute.SRInputModel.SelectedProduct = value;
                //  Navigation.PushAsync(new ServicecenterPage());
            }
        }
        #endregion

        #region events
        //SelectedItemCommand
        public Command SelectedItemCommand
        {
            get
            {
                return new Command<ProductModelWarrantyResponse>((item) =>
                {
                   
                });
            }
        }
        //AddProductPage
        // public ICommand SelectedProductCommand { get; set; }
        public Command SelectedProductCommand
        {
            get
            {
                return new Command<ProductModelWarrantyResponse>(async (item) =>
                {
                    try
                    {
                        IsBusy = true;
                        SelectProductModel = item;
                        SelectProductModel.SelectedItem = true;
                        CommonAttribute.SRInputModel.ProductModelWarrantyResponse = SelectProductModel;
                        RefreshData();
                        if (pageTypeNavigation == "Product")
                        {
                            ProductsManagementSL productsManagement = new ProductsManagementSL();
                            var aPIResponse  = await productsManagement.ServiceRequestCheck(item.ProductModelID);
                            if (aPIResponse.Status == 0)
                            {
                                await ErrorDisplayAlert(aPIResponse.ErrorMessage);
                            }
                            else
                            {
                                await Navigation.PushAsync(new ServicecenterPage());
                            }
                        }
                        else if (pageTypeNavigation == "AddAMCRequestPage")
                            await Navigation.PushAsync(new AddAMCRequestPage());

                        IsBusy = false;
                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                   
                });
            }
        }
        public void  RefreshData()
        {
            try
            {
                var TempProductModels = ProductModels;
                List<ProductModelWarrantyResponse> newData = new List<ProductModelWarrantyResponse>();
                if (MasterProductModels == null)
                    MasterProductModels = new ObservableCollection<ProductModelWarrantyResponse>();
                foreach (var item in TempProductModels)
                {
                    if (SelectProductModel?.ProductModelID == item.ProductModelID)
                        item.SelectedItem = true;
                    else
                        item.SelectedItem = false;
                    newData.Add(item);
                    MasterProductModels.Add(item);
                }
                ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(newData);
                //  MsaterProductModels = ProductModels;
                RowHeight = ProductModels.Count * 200;
            }
            catch (Exception ex)
            {

            }
           
        }
        public void SearchModelNumber(string mno)
        {
            try
            {
                ////kumar code
                //var mData = MsaterProductModels.ToList();
                //if (!string.IsNullOrEmpty(mno))
                //{

                //    var filterData = mData.Where(u => u.ModelNumber.ToLower().Contains(mno.ToLower())).ToList();
                //    ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(filterData);
                //}
                //else
                //{
                //    ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(mData);
                //}

                var ProductModelWarrantyResponseList = new List<ProductModelWarrantyResponse>();

                if (ProductModels != null && ProductModels.Count > 0)
                {
                    ProductModelWarrantyResponseList = new List<ProductModelWarrantyResponse>(ProductModels);
                }

                if (!string.IsNullOrEmpty(mno))
                {
                    if (mno.Count() >= 2)
                    {
                        var FilteredList = ProductModelWarrantyResponseList.FindAll
                                            (u => ((!string.IsNullOrEmpty(u.ModelNumber)) && u.ModelNumber.ToLower().Contains(mno.ToLower()))
                                            || ((!string.IsNullOrEmpty(u.ProductClassification)) && u.ProductClassification.ToLower().Contains(mno.ToLower())));

                        ////code by kumar
                        //var Modelnumberitems = MasterProductModels.Where(u => u.ModelNumber.ToLower().Contains(skey.ToLower())
                        //|| u.ProductClassification.ToLower().Contains(skey.ToLower()) || u.WarrantyTypeName.ToLower().Contains(skey.ToLower()));

                        //ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(Modelnumberitems);
                        ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(FilteredList);
                    }

                }
                else
                    ProductModels = MasterProductModels;
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}

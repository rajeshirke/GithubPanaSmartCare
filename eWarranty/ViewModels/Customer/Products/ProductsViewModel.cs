using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.Views.Customer.AMCRequest;
using eWarranty.Views.Customer.CommonPages;
using eWarranty.Views.Customer.InquiryView;
using eWarranty.Views.Customer.Products;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace eWarranty.ViewModels.Customer.Products
{
    public class ProductsViewModel:BaseViewModel
    {
        public ProductsViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
            Device.BeginInvokeOnMainThread( async() => {
           await BindingData();
            IsBusy = false;
            });

        }
        #region events
        //RefreshProductCommand
        public ICommand RefreshProductCommand { get; set; }
        public ICommand warrantyCommand { get; set; }
        public ICommand SRommand { get; set; }
        public ICommand DetailsCommand { get; set; }
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
        public Command DeleteProductCommand
        {
            get
            {
                return new Command<ProductModelWarrantyResponse>((item) =>
                {
                    Navigation.PushAsync(new AddProductPage());
                });
            }
        }
        public Command MoreOptionCommand
        {
            get
            {
                return new Command<ProductModelWarrantyResponse>(async (item) =>
                {
                    Isdeledted = false;
                    ProductOptionsPage productOptions =new ProductOptionsPage(item);
                    await PopupNavigation.Instance.PushAsync(productOptions);
                });
            }
        }
        public bool Isdeledted { get; set; }
        #endregion
        #region Methods
        public async Task BindingData()
        {
            try
            {
                RefreshProductCommand = new Command(async () =>
                {
                    //ProductsManagementSL productsManagement = new ProductsManagementSL();
                    //List<ProductModel> resproductModels = await productsManagement.GetCustomerProducts(CommonAttribute.CustomeProfile.PersonId);
                    //if (resproductModels != null)
                    //    ProductModels = new ObservableCollection<ProductModel>(resproductModels);
                });
                MessagingCenter.Unsubscribe<ProductOptionsPage, long>(this, "Deleteproducts");

                MessagingCenter.Subscribe<ProductOptionsPage, long>(this, "Deleteproducts", async (sender, arg) =>
                {
                    if (!Isdeledted)
                    {
                        Isdeledted = true;
                        IsBusy = true;
                        ProductsManagementSL productsManagement1 = new ProductsManagementSL();
                        //ReceiveContext<ResponseWithID> delereRes = await productsManagement1.DeleteCustomerProduct(arg);
                        APIResponse delereRes = await productsManagement1.DeleteCustomerProduct(arg);
                        if (delereRes != null && delereRes.Status == Convert.ToInt16(APIResponseEnum.Success))
                        {
                            await DisplayAlert("", AppResources.lblProductDetailsDeleted);
                        }
                        else if (delereRes != null)
                        {
                            string msg = CommonFunctions.GetMessagesByLanguage(delereRes, CommonAttribute.selectedLang.lid);
                            if (delereRes != null)
                                await ErrorDisplayAlert(msg);
                            else
                                await ErrorDisplayAlert(Resx.AppResources.servererror);
                        }
                        List<ProductModelWarrantyResponse> resproductModels1 = await productsManagement1.GetCustomerProductsWithWarranty(CommonAttribute.CustomeProfile.CountryId, CommonAttribute.CustomeProfile.PersonId);
                        if (resproductModels1 != null)
                            ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(resproductModels1);
                        MessagingCenter.Unsubscribe<ProductOptionsPage, long>(this, "Deleteproducts");
                    }
                    IsBusy = false;
                });
                MessagingCenter.Subscribe<ProductSuccessPage>(this, "Updateproducts", async (sender) =>
                {
                    IsBusy = true;
                    ProductsManagementSL productsManagement1 = new ProductsManagementSL();
                    List<ProductModelWarrantyResponse> resproductModels1 = await productsManagement1.GetCustomerProductsWithWarranty(CommonAttribute.CustomeProfile.CountryId, CommonAttribute.CustomeProfile.PersonId);
                    if (resproductModels1 != null)
                        ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(resproductModels1);

                    IsBusy = false;
                });
                MessagingCenter.Unsubscribe<ProductDetailsViewModel>(this, "Updateproducts");
                MessagingCenter.Subscribe<ProductDetailsViewModel>(this, "Updateproducts", async (sender) =>
                {
                    IsBusy = true;
                    ProductsManagementSL productsManagement1 = new ProductsManagementSL();
                    List<ProductModelWarrantyResponse> resproductModels1 = await productsManagement1.GetCustomerProductsWithWarranty(CommonAttribute.CustomeProfile.CountryId, CommonAttribute.CustomeProfile.PersonId);
                    if (resproductModels1 != null)
                        ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(resproductModels1);
                    MessagingCenter.Unsubscribe<ProductDetailsViewModel>(this, "Updateproducts");
                    IsBusy = false;
                });
                warrantyCommand = new Command<ProductModelWarrantyResponse>((item) =>
                {
                    if (CommonAttribute.SRInputModel == null)
                        CommonAttribute.SRInputModel = new ServiceRequest();
                    CommonAttribute.SRInputModel.ProductModelWarrantyResponse = item;

                    Navigation.PushAsync(new AddAMCRequestPage());
                });

                SRommand = new Command<ProductModelWarrantyResponse>(async (item) =>
                {
                    //if (CommonAttribute.SRInputModel == null)
                    //    CommonAttribute.SRInputModel = new SRInputModel();

                    ProductsManagementSL productmanagementSL = new ProductsManagementSL();
                    APIResponse aPIResponse = await productmanagementSL.GetIsServiceRequestRaiseAllowedForProduct(item.ProductModelID);

                    if (aPIResponse.Status != (int)(APIResponseEnum.Success))
                    {


                        long sID = (long)aPIResponse.Data;
                        //string msg = aPIResponse.ErrorMessage;
                        string msg = aPIResponse.Message.ToString(); //CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                        IsBusy = false;
                        //await ErrorDisplayAlert(msg);
                        await PopupNavigation.Instance.PushAsync(new ProductServiceReqDetailsPopupPage(msg, sID));
                        return;
                    }



                    if (CommonAttribute.SRInputModel == null)
                        CommonAttribute.SRInputModel = new ServiceRequest();

                    CommonAttribute.SRInputModel.ProductModelWarrantyResponse = item;
                    await Navigation.PushAsync(new ServicecenterPage());
                });

                DetailsCommand = new Command<ProductModelWarrantyResponse>((item) =>
                {


                    Navigation.PushAsync(new ProductDetailsPage(item.ProductModelID));
                });
                if (MasterProductModels == null)
                    MasterProductModels = new ObservableCollection<ProductModelWarrantyResponse>();
                if (ProductModels == null)
                    ProductModels = new ObservableCollection<ProductModelWarrantyResponse>();
                ProductsManagementSL productsManagement = new ProductsManagementSL();

                List<ProductModelWarrantyResponse> resproductModels = await productsManagement.GetCustomerProductsWithWarranty(CommonAttribute.CustomeProfile.CountryId, CommonAttribute.CustomeProfile.PersonId);
                if (resproductModels != null)
                    MasterProductModels = new ObservableCollection<ProductModelWarrantyResponse>(resproductModels);

                ProductModels = MasterProductModels;
                //  MasterProductModels = ProductModels;

                //ProductModels.ForEach(x =>
                //{
                //    if (x.WarrantyTypeName.Contains("Domestic"))
                //        x.WarrantyTypeName = AppResources.lblDomestic;
                //    else if (x.WarrantyTypeName.Contains("Extended"))
                //        x.WarrantyTypeName = AppResources.lblExtended;
                //    else if (x.WarrantyTypeName.Contains("International"))
                //        x.WarrantyTypeName = AppResources.lblInternational;
                //    else if (x.WarrantyTypeName.Contains("Out"))
                //        x.WarrantyTypeName = AppResources.lblOutwarranty;
                //    else if (x.WarrantyTypeName.Contains("Awaiting"))
                //        x.WarrantyTypeName = AppResources.lblAwaitingconfirmation;

                //});


            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
           

        }
        public void SearchModelNumber(string skey)
        {
            try
            {
                IsBusy = true;
                var ProductModelWarrantyResponseList = new List<ProductModelWarrantyResponse>();

                if (ProductModels != null && ProductModels.Count > 0)
                {
                    ProductModelWarrantyResponseList = new List<ProductModelWarrantyResponse>(ProductModels);
                }

                if (!string.IsNullOrEmpty(skey))
                {
                    if (skey.Count() >= 2)
                    {
                        var FilteredList = ProductModelWarrantyResponseList.FindAll
                                            (u => ((!string.IsNullOrEmpty(u.ModelNumber)) && u.ModelNumber.ToLower().Contains(skey.ToLower()))
                                            ||((!string.IsNullOrEmpty(u.ProductClassification)) && u.ProductClassification.ToLower().Contains(skey.ToLower())));

                        ////code by kumar
                        //var Modelnumberitems = MasterProductModels.Where(u => u.ModelNumber.ToLower().Contains(skey.ToLower())
                        //|| u.ProductClassification.ToLower().Contains(skey.ToLower()) || u.WarrantyTypeName.ToLower().Contains(skey.ToLower()));

                        //ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(Modelnumberitems);
                        ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(FilteredList);
                    }
                   
                }
                else
                    ProductModels = MasterProductModels;

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            
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
                OnPropertyChanged("MasterProductModels");
            }
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.DependencyServices;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.Views.Account;
using eWarranty.Views.Customer.AMCRequest;
using eWarranty.Views.Customer.CommonPages;
using eWarranty.Views.Customer.Products;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Extensions = eWarranty.Hepler.Extensions;

namespace eWarranty.ViewModels.Customer.Products
{
    public class ProductDetailsViewModel : BaseViewModel
    {

        public long ProductModelId { get; set; }
        public ProductDetailsViewModel(INavigation navigation,long pnid) : base(navigation)
        {
            ProductModelId = pnid;
             IsBusy = true;
            Device.BeginInvokeOnMainThread(async () => {
                await BindingData();
                IsBusy = false;
            });
            //ProductsManagementSL
            //	ProductClassificationName	"Washing Machine"
            //	EndDate	{3/6/2022 12:00:00 AM}	
            // ProductModel = CommonAttribute.SRInputModel.ProductModelWarrantyResponse;
            //RegistrationNumber = ProductModel.RegistrationNumber;
            //ModelNumber = ProductModel.ModelNumber;
            //SerialNumber = ProductModel.SerialNumber;
            //PurchaseInvoiceDate = Convert.ToDateTime(ProductModel.PurchaseInvoiceDate).ToString("MMM:dd:yyyy");
            //PurchaseInvoiceNumber = ProductModel.PurchaseInvoiceNumber;
        }

        public async Task BindingData()
        {
            try
            {
                IsBusy = true;
                ProductsManagementSL ProductsManagementSL = new ProductsManagementSL();
                ProductModelResponse responses = await ProductsManagementSL.GetCustomerProductModelByModelId(ProductModelId);
                if (responses != null)
                {

                    ProductModel = responses;


                    if (ProductModel.ActiveWarrantyCustomerProduct != null)
                    {
                        if (!string.IsNullOrEmpty(ProductModel.ActiveWarrantyCustomerProduct.WarrantyTypeName) && ProductModel.ActiveWarrantyCustomerProduct.WarrantyTypeName.ToLower() != "Awaiting confirmation".ToLower())
                        {
                            IsVisibleDownload = true;
                        }
                    }
                    else
                    {
                        IsVisibleDownload = false;
                    }


                    // ProductModel
                    int eprdays = (ProductModel.ActiveWarrantyCustomerProduct.EndDate - DateTime.Now).Days;
                    if (eprdays > 0)
                    {
                        ExpiresIn = eprdays.ToString() + AppResources.lblDays;
                    }
                    else
                    {
                        ExpiresIn = "";
                    }
                    if (ProductModel.ActiveWarrantyCustomerProduct.EndDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                    {
                        ExpiredOn = null;
                    }
                    else
                    {
                        ExpiredOn = ProductModel.ActiveWarrantyCustomerProduct.EndDate;
                    }
                    if (ProductModel.ProductFiles.Count > 0)
                    {
                        if (ProductFiles == null)
                            ProductFiles = new ObservableCollection<ProductFileResponse>();//  List<ProductFileResponse>();

                        var Item1 = ProductModel.ProductFiles.ToList()[0];
                        if (Item1.FileInfo?.FileTypeId == Convert.ToInt16(FileTypeEnum.ProductImage))
                        {
                            ProductImagePath1 = new Uri(CommonAttribute.ImageBaseUrl + Item1.FileInfo?.FileName);
                        }
                        else if (Item1.FileInfo?.FileTypeId == Convert.ToInt16(FileTypeEnum.ProductInvoice))
                        {
                            InvoiceImagePath1 = new Uri(CommonAttribute.ImageBaseUrl + Item1.FileInfo?.FileName);
                        }

                        if (ProductModel.ProductFiles.Count > 1)
                        {
                            var Item2 = ProductModel.ProductFiles.ToList()[1];
                            if (Item2.FileInfo?.FileTypeId == Convert.ToInt16(FileTypeEnum.ProductImage))
                            {
                                ProductImagePath1 = new Uri(CommonAttribute.ImageBaseUrl + Item2.FileInfo?.FileName);
                            }
                            else if (Item2.FileInfo?.FileTypeId == Convert.ToInt16(FileTypeEnum.ProductInvoice))
                            {
                                InvoiceImagePath1 = new Uri(CommonAttribute.ImageBaseUrl + Item2.FileInfo?.FileName);
                            }
                        }
                        //    foreach (var item in ProductModel.ProductFiles)
                        //{
                        //    item.ImagePath =new Uri(CommonAttribute.ImageBaseUrl + item.FileInfo.FileName);
                        //    if(item.FileInfo?.FileTypeId == Convert.ToInt16(FileTypeEnum.ProductImage))
                        //    {
                        //        item.ImageLabelName = "Product Image Label";
                        //    }
                        //    else if (item.FileInfo?.FileTypeId == Convert.ToInt16(FileTypeEnum.ProductInvoice))
                        //    {
                        //        item.ImageLabelName = "Product Invoice";
                        //    }
                        //    ProductFiles.Add(item);
                        //}


                    }
                    {
                        //  ProductImagePath1 = new Uri("http://devsrv01.panasonic.ae:83/images/productImages/defaultprod.png");
                        //  InvoiceImagePath1 = new Uri("http://devsrv01.panasonic.ae:83/images/productImages/defaultprod.png");
                    }
                    // ExpiresIn=
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            

        }
        public Command AddSRCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (CommonAttribute.SRInputModel == null)
                            CommonAttribute.SRInputModel = new ServiceRequest();
                        ProductModelWarrantyResponse productModelWarranty = new ProductModelWarrantyResponse();
                        productModelWarranty.ProductModelID = ProductModel.ProductModelId;
                        productModelWarranty.ModelNumber = ProductModel.ModelNumber;
                        productModelWarranty.ProductClassificationID = ProductModel.ProductCategoryId;
                        CommonAttribute.SRInputModel.ProductModelWarrantyResponse = productModelWarranty;

                        ProductsManagementSL productmanagementSL = new ProductsManagementSL();
                        APIResponse aPIResponse = await productmanagementSL.GetIsServiceRequestRaiseAllowedForProduct(productModelWarranty.ProductModelID);

                        if (aPIResponse.Status != (int)(APIResponseEnum.Success))
                        {
                            //string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                            long sID = (long)aPIResponse.Data;
                            //string msg = aPIResponse.ErrorMessage;
                            string msg = aPIResponse.Message.ToString(); //CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                            IsBusy = false;
                            //await ErrorDisplayAlert(msg);
                            await PopupNavigation.Instance.PushAsync(new ProductServiceReqDetailsPopupPage(msg, sID));
                            return;

                            //await ErrorDisplayAlert(msg);
                            return;
                        }
                        await Navigation.PushAsync(new ServicecenterPage());
                    }
                    catch (Exception ex)
                    {

                    }
                    

                });
            }
        }
        public Command TermsConditionCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (ProductModel.ActiveWarrantyCustomerProduct == null)
                        {

                        }
                        else if (ProductModel.ActiveWarrantyCustomerProduct.WarrantyTypeId == Convert.ToInt16(WarrantyTypeEnum.InternationalWarranty))
                        {
                            ProductsManagementSL productmanagementSL = new ProductsManagementSL();
                            string InternationalWarrantyTC = await productmanagementSL.GetWarrantyTC((int)WarrantyTypeEnum.InternationalWarranty);

                            await Navigation.PushModalAsync(new TermsofServicePage("https://mastcgroup.com/privacy-policy/"));

                        }
                        else if (ProductModel.ActiveWarrantyCustomerProduct.WarrantyTypeId == Convert.ToInt16(WarrantyTypeEnum.LocalWarranty))
                        {
                            ProductsManagementSL productmanagementSL = new ProductsManagementSL();
                            string LocalWarrantyTC = await productmanagementSL.GetWarrantyTC((int)WarrantyTypeEnum.LocalWarranty);

                            await Navigation.PushModalAsync(new TermsofServicePage("https://mastcgroup.com/privacy-policy/"));
                        }

                        else if (ProductModel.ActiveWarrantyCustomerProduct.WarrantyTypeId == Convert.ToInt16(WarrantyTypeEnum.ExtendedWarranty))
                        {
                            ProductsManagementSL productmanagementSL = new ProductsManagementSL();
                            string ExtendedWarrantyTC = await productmanagementSL.GetWarrantyTC((int)WarrantyTypeEnum.ExtendedWarranty);

                            await Navigation.PushModalAsync(new TermsofServicePage("https://mastcgroup.com/privacy-policy/"));
                        }
                        else if (ProductModel.ActiveWarrantyCustomerProduct.WarrantyTypeId == Convert.ToInt16(WarrantyTypeEnum.AMC))
                        {
                            ProductsManagementSL productmanagementSL = new ProductsManagementSL();
                            string AMCTC = await productmanagementSL.GetWarrantyTC((int)WarrantyTypeEnum.AMC);
                            if (!string.IsNullOrEmpty(AMCTC))
                                await Navigation.PushModalAsync(new TermsofServicePage("https://mastcgroup.com/privacy-policy/")); //by akash sir

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    //if(ProductModel.ActiveWarrantyCustomerProduct == null)
                    //{

                    //}
                    //else if (ProductModel.ActiveWarrantyCustomerProduct.WarrantyTypeId ==Convert.ToInt16(WarrantyTypeEnum.InternationalWarranty) )
                    //    await Navigation.PushModalAsync(new TermsofServicePage(International));
                    //else if (ProductModel.ActiveWarrantyCustomerProduct.WarrantyTypeId == Convert.ToInt16(WarrantyTypeEnum.LocalWarranty))
                    //    await Navigation.PushModalAsync(new TermsofServicePage(Domestic));
                    //else if (ProductModel.ActiveWarrantyCustomerProduct.WarrantyTypeId == Convert.ToInt16(WarrantyTypeEnum.ExtendedWarranty))
                    //    await Navigation.PushModalAsync(new TermsofServicePage(ExtendedWarranty));

                    //else if (ProductModel.ActiveWarrantyCustomerProduct.WarrantyTypeId == Convert.ToInt16(WarrantyTypeEnum.AMC))
                    //    await Navigation.PushModalAsync(new TermsofServicePage(Domestic)); //by akash sir

                   

                });
            }
        }
        public Command DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        var res = await Application.Current.MainPage.DisplayAlert(AppResources.lblConfirmation, AppResources.lblDoYouWantToDelete, AppResources.lblOk, AppResources.lblCancel);
                        if (res)
                        {
                            IsBusy = true;
                            ProductsManagementSL productsManagement1 = new ProductsManagementSL();
                            //ReceiveContext<ResponseWithID> delereRes = await productsManagement1.DeleteCustomerProduct(ProductModel.ProductModelId);
                            APIResponse delereRes = await productsManagement1.DeleteCustomerProduct(ProductModel.ProductModelId);
                            if (delereRes != null && delereRes.Status == Convert.ToInt16(APIResponseEnum.Success))
                            {
                                await DisplayAlert("", AppResources.lblProductDetailsDeleted);
                                MessagingCenter.Send<ProductDetailsViewModel>(this, "Updateproducts");
                                await Navigation.PopAsync();
                            }
                            else if (delereRes != null)
                            {
                                string msg = CommonFunctions.GetMessagesByLanguage(delereRes, CommonAttribute.selectedLang.lid);
                                if (delereRes != null)
                                    await ErrorDisplayAlert(msg);
                                else
                                    await ErrorDisplayAlert(Resx.AppResources.servererror);
                            }
                            IsBusy = false;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                });
            }
        }
        public Command ScreenShotCommand
        {
            get
            {
                return new Command<string>(async (item) =>
                {
                    try
                    {
                        IsBusy = true;
                        UserManagementSL userManagementSL = new UserManagementSL();
                        APIResponse aPIResponse =await userManagementSL.GetWarrantyCard(ProductModel.ProductModelId);
                        if(aPIResponse?.Status == Convert.ToInt16(APIResponseEnum.Success))
                        {
                            string imgUrl = aPIResponse.Data.ToString();
                            byte[] bytes = await Extensions.DownloadImageAsync(imgUrl);
                            if (bytes != null)
                            {
                                var hud = DependencyService.Get<IMediaService>();
                                if (hud != null)
                                {
                                    string filename = System.IO.Path.GetFileName(imgUrl);

                                    hud.SaveImageFromByte(bytes, filename);
                                    await DisplayAlert(AppResources.lblSuccess, AppResources.lblWarrantycarddownloaded);
                                }
                               
                            }
                            else
                            {
                                await ErrorDisplayAlert(AppResources.lblYourwarrantycardnotyetready);
                            }
                        }
                        else
                        {
                            if(aPIResponse != null)
                            {
                                string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                                await ErrorDisplayAlert(msg);
                            }
                            else
                            {
                               await ErrorDisplayAlert(AppResources.lblAPIError);
                            }
                        }
                        // string strUrl = "http://devsrv01.panasonic.ae:82/api/Products/GetWarrantyCard/" + ProductModel.ProductModelId;
                        IsBusy = false;

                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                });
            }
        }


        public Command ViewCommand
        {
            get
            {
                return new Command<string>(async (item) =>
                {
                    try
                    {
                        IsBusy = true;
                        UserManagementSL userManagementSL = new UserManagementSL();
                        APIResponse aPIResponse = await userManagementSL.GetWarrantyCard(ProductModel.ProductModelId);
                        if (aPIResponse?.Status == Convert.ToInt16(APIResponseEnum.Success))
                        {
                            string imgUrl = aPIResponse.Data.ToString();
                            //string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);

                            await Navigation.PushModalAsync(new ImagePopupView(imgUrl), true);
                            IsBusy = false;
                        }
                        else
                        {
                            if (aPIResponse != null)
                            {
                                string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                                await ErrorDisplayAlert(msg);
                            }
                            else
                            {
                                await ErrorDisplayAlert(AppResources.lblAPIError);
                            }
                        }

                        IsBusy = false;

                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                });
            }
        }


        public string Domestic { get; set; } = "https://mastcgroup.com/privacy-policy/";
        public string International { get; set; } = "https://mastcgroup.com/privacy-policy/";
        public string ExtendedWarranty { get; set; } = "https://mastcgroup.com/privacy-policy/";

        private Boolean _IsVisibleDownload;
        public Boolean IsVisibleDownload
        {
            get { return _IsVisibleDownload; }
            set
            {
                _IsVisibleDownload = value;
                OnPropertyChanged("IsVisibleDownload");
            }
        }

        private ProductModelResponse _ProductModel;
        public ProductModelResponse ProductModel
        {
            get { return _ProductModel; }
            set
            {
                _ProductModel = value;
                OnPropertyChanged("ProductModel");
            }
        }
        private ObservableCollection<ProductFileResponse> _ProductFiles;
        public ObservableCollection<ProductFileResponse> ProductFiles
        {
            get { return _ProductFiles; }
            set
            {
                _ProductFiles = value;
                OnPropertyChanged("ProductFiles");
            }
        }
        private DateTime? _ExpiredOn;
        public DateTime? ExpiredOn
        {
            get { return _ExpiredOn; }
            set
            {
                _ExpiredOn = value;
                OnPropertyChanged("ExpiredOn");
            }
        }
        private string _ProductImage;
        public string ProductImage
        {
            get { return _ProductImage; }
            set
            {
                _ProductImage = value;
                OnPropertyChanged("ProductImage");
            }
        }
        private string _ProductInvoice;
        public string ProductInvoice
        {
            get { return _ProductInvoice; }
            set
            {
                _ProductInvoice = value;
                OnPropertyChanged("ProductInvoice");
            }
        }
        private string _RegistrationNumber;
        public string RegistrationNumber
        {
            get { return _RegistrationNumber; }
            set
            {
                _RegistrationNumber = value;
                OnPropertyChanged("RegistrationNumber");
            }
        }
        private string _ExpiresIn;
        public string ExpiresIn
        {
            get { return _ExpiresIn; }
            set
            {
                _ExpiresIn = value;
                OnPropertyChanged("ExpiresIn");
            }
        }
        private string _ModelNumber;
        public string ModelNumber
        {
            get { return _ModelNumber; }
            set
            {
                _ModelNumber = value;
                OnPropertyChanged("ModelNumber");
            }
        }
        private string _SerialNumber;
        public string SerialNumber
        {
            get { return _SerialNumber; }
            set
            {
                _SerialNumber = value;
                OnPropertyChanged("SerialNumber");
            }
        }
        private string _PurchaseInvoiceDate;
        public string PurchaseInvoiceDate
        {
            get { return _PurchaseInvoiceDate; }
            set
            {
                _PurchaseInvoiceDate = value;
                OnPropertyChanged("PurchaseInvoiceDate");
            }
        }
        private string _PurchaseInvoiceNumber;
        public string PurchaseInvoiceNumber
        {
            get { return _PurchaseInvoiceNumber; }
            set
            {
                _PurchaseInvoiceNumber = value;
                OnPropertyChanged("PurchaseInvoiceNumber");
            }
        }
        private string _ProductLabelName;
        public string ProductLabelName
        {
            get { return _ProductLabelName; }
            set
            {
                _ProductLabelName = value;
                OnPropertyChanged("ProductLabelName");
            }
        }
        private Uri _ProductImagePath1;
        public Uri ProductImagePath1
        {
            get { return _ProductImagePath1; }
            set
            {
                _ProductImagePath1 = value;
                OnPropertyChanged("ProductImagePath1");
            }
        }
       
        private Uri _InvoiceImagePath1;
        public Uri InvoiceImagePath1
        {
            get { return _InvoiceImagePath1; }
            set
            {
                _InvoiceImagePath1 = value;
                OnPropertyChanged("InvoiceImagePath1");
            }
        }
        //ImagePath
        //RegistrationNumber
    }
}

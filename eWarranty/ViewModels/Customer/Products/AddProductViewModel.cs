using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Controls;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.DependencyServices;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Customer.Products;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using Xamarin.Forms;



namespace eWarranty.ViewModels.Customer.Products
{
    public class AddProductViewModel:BaseViewModel
    {
        public AddProductViewModel(INavigation navigation) : base(navigation)
        {

            try
            {
                SelectedDate = DateTime.Now;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await BindingData();
                    GetAllModelNumbers();
                });
            }
            catch (Exception ex)
            {

            }
        }
      

        #region Method
        public async Task BindingData()
        {
            try
            {
                IsBusy = true;

                // ModelNumberValide = true;
                DealerRequried = true;


                CategoryChangeCommand = new Command<DropDownModel>((val) =>
                {
                    SelectedCategory = val;
                });
                ////SerialNoCommand = new Command(async () =>
                ////{
                ////    ModelNo = await Extensions.QrScanning();
                ////});

                //UploadInvoiceCommand = new Command(async () =>
                //{
                //    try
                //    {
                //        // IsBusy = true;
                //        FileData fileData = await TakePhotoAsync();
                //        InvoiceUploadFile = new FilesToUpload();
                //        InvoiceUploadFile.fileName = fileData.FileName;
                //        InvoiceUploadFile.mimeType = fileData.FileType;
                //        InvoiceUploadFile.path = fileData.FileName;
                //        InvoiceUploadFile.fileTypeId = 2;// Convert.ToInt16(FileTypeEnum.ProductInvoice);
                //        InvoiceUploadFile.base64StringImage = fileData.string64baseData;
                //        //  ProductsManagementSL productsManagement = new ProductsManagementSL();
                //        //  var resp =await productsManagement.ProductFileUplod(fileData.string64baseData);

                //        InvoiceFile = fileData?.FileName;
                //    }
                //    catch(Exception ex)
                //    {

                //    }
                //    //IsBusy = false;
                //});

                UploadWarrantyInvoiceCommand = new Command(async () =>
                {
                    FileData fileData = await TakePhotoAsync();
                    WarrantyInvoice = fileData?.FileName;
                });



                MasterDataManagementSL masterDataManagement = new MasterDataManagementSL();

                List<CountryResponse> countryResponses = await masterDataManagement.GetAllCountries();
                if (AllCountries == null)
                    AllCountries = new ObservableCollection<DropDownModel>();
                if (countryResponses != null && countryResponses.Count > 0)
                {
                    foreach (var item in countryResponses)
                    {

                        DropDownModel dropDownModel = new DropDownModel();
                        dropDownModel.Id = item.CountryId;
                        dropDownModel.Title = item.Name;
                        if (item.Iso.ToLower() == CommonAttribute.UserLocation?.CountryCode?.ToLower())
                        {
                            SelectCountry = dropDownModel;
                        }
                        else if (item.CountryId == CommonAttribute.CustomeProfile.CountryId)
                        {
                            SelectCountry = dropDownModel;
                        }
                        AllCountries.Add(dropDownModel);

                    }
                }
                

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            


            //Upload Invoice
        }

        public async void GetAllModelNumbers()
        {
            try
            {
                AllmodelNumbers = new List<ModelNumberSearchResponse>();
                AllModelNos = new List<string>();
                MasterDataManagementSL dataManagementSL = new MasterDataManagementSL();
                AllmodelNumbers = await dataManagementSL.SearchAllModelNumber();
                if (AllmodelNumbers != null && AllmodelNumbers.Count > 0)
                {
                    foreach (var item in AllmodelNumbers)
                    {
                        AllModelNos.Add(item.ModelName);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        public async Task<List<string>> GetProductNumbers(string key)
        {
            List<string> productNumbers = new List<string>();

            try
            {
                MasterDataManagementSL dataManagementSL = new MasterDataManagementSL();

                modelNumberSearchResponses = await dataManagementSL.SearchModelNumberByInitials(key, 0);
                if (modelNumberSearchResponses != null && modelNumberSearchResponses.Count > 0)
                {
                    foreach (var item in modelNumberSearchResponses)
                    {
                        productNumbers.Add(item.ModelName);
                    }
                }
            }
            catch (Exception ex)
            {

            }
           
            return productNumbers;
        }
        public async Task<List<string>> GetSerialNumber(string key)
        {
            List<string> productNumbers = new List<string>();

            try
            {
                MasterDataManagementSL dataManagementSL = new MasterDataManagementSL();

                List<SerialNoSerchResponse> responses = await dataManagementSL.SearchSerialNumberByInitials(key, ModelNo);
                foreach (var item in responses)
                {
                    productNumbers.Add(item.SerialNo);
                }
                
            }
            catch (Exception ex)
            {

            }
            return productNumbers;
        }
        public async Task<bool> ValidateModelandSerialNumber()
        {
            bool ValidData = false;
            try
            {
                bool modelValid = false;
                List<string> productNumbers = new List<string>();
                MasterDataManagementSL dataManagementSL = new MasterDataManagementSL();
                List<string> ModelnumberValidation = await GetProductNumbers(ModelNo);
                if (ModelnumberValidation != null && ModelnumberValidation.Contains(ModelNo))
                    modelValid = true;
                if (await ValidateSerialNumber() && modelValid)
                {
                    ValidData = true;
                }

            }
            catch (Exception ex)
            {

            }
            return ValidData;
        }
        public async Task<bool> DateandDealerValid()
        {
            if (string.IsNullOrEmpty(ModelNo))
            {
                await ErrorDisplayAlert(AppResources.lblEnterModelNumber);
                return false;
            }
            if (string.IsNullOrEmpty(SerialNo))
            {
               await  ErrorDisplayAlert(AppResources.lblEnterSerialNumber);
                return false;
            }
            if (SelectedDate == default(DateTime))
            {
               await  ErrorDisplayAlert(AppResources.lblSelectPurchaseDate);
                return false;
            }
            if (SelectedDate > DateTime.Now.AddYears(-1))
            {
                
                    bool res = await ValidateModelandSerialNumber();
                    if (res)
                    {
                        DealerRequried = false;
                    }
                    else
                    {
                        DealerRequried = true;
                    }
                

                InvoiceDocumentRequried = true;
            }
            else
            {
                DealerRequried = false;
                InvoiceDocumentRequried = false;

            }
            return true;
        }
        public async Task<bool> ProductValidation()
        {
            
            return true;
        }
        public async Task<bool> ValidateSerialNumber()
        {
            bool result = false;
            MasterDataManagementSL dataManagementSL = new MasterDataManagementSL();

            result = await dataManagementSL.ValidateSerialNumber(SerialNo);
           
          
                return result;
            

           // if(ModelNumberValide)
        }
        public async Task ValidateModelNumber()
        {
            try
            {
                MasterDataManagementSL dataManagementSL = new MasterDataManagementSL();
                if (!string.IsNullOrEmpty(ModelNo) && ModelNo.Length > 3)
                {
                    ModelNumberValide = false;
                    DealerRequried = true;
                    return;
                }
                modelNumberSearchResponses = await dataManagementSL.SearchModelNumberByInitials(ModelNo, 0);
                if (modelNumberSearchResponses != null)
                {
                    var exstingItem = modelNumberSearchResponses.Where(u => u.ModelName.ToLower() == ModelNo.ToLower()).ToList();
                    if (exstingItem.Count > 0)
                        ModelNumberValide = true;
                    else
                        ModelNumberValide = false;



                }
                if (!ModelNumberValide)
                    DealerRequried = true;
                else if (!SerialNumberValide)
                    DealerRequried = true;
                else if (ModelNumberValide && SerialNumberValide)
                    DealerRequried = false;

            }
            catch (Exception ex)
            {

            }
           
            // if(ModelNumberValide)
        }

        public async Task<string> CheckInvalidModelNo(string ModelNo)
        {
            string yesno = "";
            try
            {
                ProductsManagementSL productsManagementSL = new ProductsManagementSL();
                if (!string.IsNullOrEmpty(ModelNo))
                {
                    var result = await productsManagementSL.SearchModelNumberByModelNo(ModelNo);
                    if (result == null || result.Count == 0)
                    {
                        yesno = "yes";
                        await DisplayAlert("Warning!", "Invalid Model Number.Please check the model number and try again.");                        
                    }
                  
                }
                
            }
            catch (Exception ex)
            {
                await DisplayAlert("Internal Server Error:", "We're sorry, but our server encountered an unexpected condition. Please try again later.");
            }
            return yesno;
        }

        public async Task ValidateModelNumberbyAutoSuggest(string key)
        {
            try
            {
                MasterDataManagementSL dataManagementSL = new MasterDataManagementSL();
                if (!string.IsNullOrEmpty(ModelNo) && ModelNo.Length > 3)
                {
                    ModelNumberValide = false;
                    DealerRequried = true;
                    return;
                }
                modelNumberSearchResponses = await dataManagementSL.SearchModelNumberByInitials(key, 0);
                if (modelNumberSearchResponses != null)
                {
                    var exstingItem = modelNumberSearchResponses.Where(u => u.ModelName.ToLower() == ModelNo.ToLower()).ToList();
                    if (exstingItem.Count > 0)
                        ModelNumberValide = true;
                    else
                        ModelNumberValide = false;



                }
                if (!ModelNumberValide)
                    DealerRequried = true;
                else if (!SerialNumberValide)
                    DealerRequried = true;
                else if (ModelNumberValide && SerialNumberValide)
                    DealerRequried = false;

                // if(ModelNumberValide)
            }
            catch (Exception ex)
            {

            }
           
        }

        #endregion
        public async Task<bool> Validation()
        {
            //if(SelectedCategory == null)
            //{
            //    await ErrorDisplayAlert("Please select category.");
            //    return false;
            //}
            
            if (string.IsNullOrEmpty(ModelNo))
            {
                await ErrorDisplayAlert(AppResources.lblEnterModelNumber);
                return false;
            }
            if (string.IsNullOrEmpty(SerialNo))
            {
                await ErrorDisplayAlert(AppResources.lblEnterSerialNumber);
                return false;
            }
            //if (SelectedDate == default(DateTime))
            //{
            //    await ErrorDisplayAlert("Please select purchase Date.");
            //    return false;
            //}
            if (SelectedDate > DateTime.Now.AddYears(-1))
            {

                bool res = await ValidateModelandSerialNumber();
                if (res)
                {
                    DealerRequried = false;
                }
                else
                {
                    DealerRequried = true;
                }


                InvoiceDocumentRequried = true;
            }
            else
            {
                DealerRequried = false;
                InvoiceDocumentRequried = false;

            }
            if (SelectedDate > DateTime.Now.AddYears(-1))
            {
                //if (string.IsNullOrEmpty(PurchaseInvoiceNumber))
                //{
                //    await ErrorDisplayAlert("Please enter invoice number.");
                //    return false;
                //}
            }
            if (SelectCountry == null)
            {
                await ErrorDisplayAlert(AppResources.lblErrorSelectCountry);
                return false;
            }
            if (DealerRequried)
            {
                //if (string.IsNullOrEmpty(ProductImageFile))
                //{
                //    await ErrorDisplayAlert("Please upload product label.");
                //    return false;
                //}
            }
            if (InvoiceDocumentRequried)
            {
                if (string.IsNullOrEmpty(InvoiceFile))
                {
                    await ErrorDisplayAlert(AppResources.lblErrorUploadPurchanseInvoice);
                    return false;
                }
            }
            //ProductImageFile
            if (DealerRequried)
            {
                if (string.IsNullOrEmpty(DealerName))
                {
                    await ErrorDisplayAlert(AppResources.lblErrorEnterDealerName);
                    return false;
                }
                //if (string.IsNullOrEmpty(DealerAddress))
                //{
                //    await ErrorDisplayAlert(AppResources.lblDealerAddress);
                //    return false;
                //}
                //productModel.DealerName = DealerName;
                //productModel.DealerAddress = DealerName;
            }
            return true;
        }
        #region Methods
        public FileResult photo{ get; set; }
        async Task<FileData> TakePhotoAsync()
        {
            try
            {
                GC.Collect();
                FileData fileData = new FileData();
                string action = await Application.Current.MainPage.DisplayActionSheet(AppResources.lblTakePhoto, AppResources.lblCancel, null, AppResources.lblTakePhoto, AppResources.lblGallery);
                
                if (action == AppResources.lblGallery)
                {
                    photo = await MediaPicker.PickPhotoAsync();// CapturePhotoAsync();
                }
                else if (action == AppResources.lblTakePhoto)
                {
                    if (!MediaPicker.IsCaptureSupported)
                    {
                     await  ErrorDisplayAlert(AppResources.lblErrorCameranotsupported);
                        return null;
                    }
                    MediaPickerOptions mediaPicker = new MediaPickerOptions();
                    
                    photo = await MediaPicker.CapturePhotoAsync();
                } 
               
                if (photo != null)
                {
                  return  fileData = await LoadPhotoAsync(photo);

                   // Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
                }
                return fileData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
               return null;
            }
        }
        async Task<FileData> LoadPhotoAsync(FileResult photo)
        {
            // canceled
            try
            {
                FileData fileData = new FileData();

                if (photo == null)
                {
                    PhotoPath = null;
                    return null;
                }

                // save the file into local storage
                var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                fileData.FileType = photo.ContentType;
                if (Device.RuntimePlatform == Device.Android)
                { 
                    using (var stream = await photo.OpenReadAsync())
                    {
                        using (var newStream = File.OpenWrite(newFile))
                            await stream.CopyToAsync(newStream);

                        
                        string string64base = Extensions.ConvertToBase64(stream);
                        fileData.string64baseData = string64base;
                    }
                }
                else
                {
                    using (var stream = await photo.OpenReadAsync())
                    {
                        using (var newStream = File.OpenWrite(newFile))
                            await stream.CopyToAsync(newStream);

                        var originalImageByteArray = new Byte[(int)stream.Length];

                        stream.Seek(0, SeekOrigin.Begin);
                        stream.Read(originalImageByteArray, 0, (int)stream.Length);

                        var resizer = DependencyService.Get<IImageResizer>();
                        var resizedBytes = resizer.ResizeImage(originalImageByteArray, 400, 400);

                        string string64base = Convert.ToBase64String(resizedBytes);
                        fileData.string64baseData = string64base;
                    }
                 

                   

                }
                fileData.FileName = photo.FileName;

                return fileData;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        async Task SaveProduct()
        {
            IsBusy = true;
            try
            {
                string str = ProductName;
                var ss = SelectedCategory;
                var dd = SelectedDate;
              //  ModelNumberSearchResponse modelNumberSearchResponse = modelNumberSearchResponses.Where(u => u.ModelName == ModelNo).FirstOrDefault();
                ProductsManagementSL productsManagement = new ProductsManagementSL();
                Core.Models.ProductModel productModel = new Core.Models.ProductModel();
               // productModel.ModelName = ProductName;
                productModel.CustomerId = CommonAttribute.CustomeProfile.PersonId;
                if(modelNumberSearchResponse != null)
                {
                   // ModelNumberSearchResponse modelNumberSearchResponse = modelNumberSearchResponses.Where(u => u.ModelName == ModelNo).FirstOrDefault();
                    productModel.ProductCategoryId = modelNumberSearchResponse.ProductClassificationId;
                    productModel.ProductClassificationName = modelNumberSearchResponse.ModelDescreption;
                }
               
                productModel.PurchaseCountryId = SelectCountry.Id;
                productModel.ModelNumber = ModelNo;
                productModel.SerialNumber = SerialNo;
                productModel.PurchaseDate = SelectedDate;
                productModel.PurchaseInvoiceNumber = PurchaseInvoiceNumber;
                productModel.PurchaseInvoiceDate = SelectedDate;
                productModel.PurchaseDate = SelectedDate;
                productModel.IsProductExistInPrism = true;
                if (DealerRequried)
                {
                    productModel.ProductCategoryId = null;
                    productModel.IsProductExistInPrism = false;
                    productModel.DealerName = DealerName;
                    productModel.DealerAddress = DealerAddress;
                }
                List<FilesToUpload> filesToUploads = new List<FilesToUpload>();
               if(InvoiceUploadFile != null)
                {
                    filesToUploads.Add(InvoiceUploadFile);
                }
               
                if (ProdctImageUploadFile != null)
                {
                   // List<FilesToUpload> ProdctToUploads = new List<FilesToUpload>();
                    filesToUploads.Add(ProdctImageUploadFile);
                }
                // InvoiceUploadFile
                ProductRequest productRequest = new ProductRequest();
                productRequest.productModelDetails = productModel;
                productRequest.filesToUpload = filesToUploads;
                ReceiveContext<Core.Models.ProductModel> responseProduct = await productsManagement.AddCustomerProduct(productRequest);
                if (responseProduct?.status == Convert.ToInt16(APIResponseEnum.Success))
                {
                   // await DisplayAlert("", responseProduct.message);
                    await Navigation.PushAsync(new ProductSuccessPage());
                }
                else
                {
                    if (responseProduct != null)
                    {
                        if (responseProduct.errorMessage.ToLower().Contains("already registered"))
                        {
                            await Application.Current.MainPage.DisplayAlert("", AppResources.msgProductisalreadyregistered, AppResources.lblCancel);
                        }
                        else
                        {
                            await ErrorDisplayAlert(AppResources.lblAPIError);
                        }
                    }
                        
                    else
                        await ErrorDisplayAlert(AppResources.lblAPIError);
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await ErrorDisplayAlert(ex.Message);
            }
            IsBusy = false;
        }
        #endregion


        #region events
        //CountryChangeCommand
        public Command CountryChangeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (AllCountries != null && AllCountries.Count > 0)
                        {
                            DropDownPopupPage dropDownPopup = new DropDownPopupPage();
                            dropDownPopup.Title = AppResources.lblSelectCountry;
                            if (SelectCountry != null)
                                dropDownPopup.Title = SelectCountry.Title;
                            dropDownPopup.DropDownSelectedItem += DropDownPopup_DropDownSelectedItem; ;
                            dropDownPopup.PickerItemsSource = AllCountries;
                            dropDownPopup.MasterData = AllCountries.ToList();
                            await PopupNavigation.PushAsync(dropDownPopup);
                            //SelectCountry = item;
                            //  Navigation.PushAsync(new ProductSuccessPage());
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                });
            }
        }

        private void DropDownPopup_DropDownSelectedItem(object sender, EventArgs e)
        {
            DropDownPopupPage control = sender as DropDownPopupPage;
            SelectCountry = control.SelectedItem as DropDownModel;
        }

        public Command SaveCommand
        {
            get
            {
                return new Command(() =>
                {

                    Navigation.PushAsync(new ProductSuccessPage());
                });
            }
        }

        public Command ModelNumberCompleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (string.IsNullOrEmpty(ModelNo))
                    {
                        await DisplayAlert(AppResources.lblError, AppResources.lblEnterModelNumber);
                    }
                    await ValidateModelNumber();
                });
            }
        }

        public Command UploadInvoiceCommand
        {
            get
            {
                return new Command( async () =>
                {
                    try
                    {
                        // IsBusy = true;
                        FileData fileData = await TakePhotoAsync();
                        InvoiceUploadFile = new FilesToUpload();
                        InvoiceUploadFile.fileName = fileData.FileName;
                        InvoiceUploadFile.mimeType = fileData.FileType;
                        InvoiceUploadFile.path = fileData.FileName;
                        InvoiceUploadFile.fileTypeId = 2;// Convert.ToInt16(FileTypeEnum.ProductInvoice);
                        InvoiceUploadFile.base64StringImage = fileData.string64baseData;
                        //  ProductsManagementSL productsManagement = new ProductsManagementSL();
                        //  var resp =await productsManagement.ProductFileUplod(fileData.string64baseData);

                        //InvoiceFile = fileData?.FileName;

                        string FileExtn = System.IO.Path.GetExtension(fileData?.FileName);
                        InvoiceFile = "InvoiceImage" + "" + FileExtn;
                    }
                    catch (Exception ex)
                    {

                    }
                    //IsBusy = false;
                });
            }
        }
        public Command ModelsPopupCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        IsBusy = true;
                        DropDownPopupPage dropDownPopup = new DropDownPopupPage();
                        dropDownPopup.Title = AppResources.lblModelNumber;

                        if (!string.IsNullOrEmpty(ModelNo))
                        {
                            dropDownPopup.SetSearchKey(ModelNo);
                            await dropDownPopup.GetModelNumber(ModelNo);
                        }
                        //else
                        //    await dropDownPopup.GetModelNumber("a");
                        dropDownPopup.DropDownSelectedItem += DropDownPopup_DropDownSelectedItem1; ;
                        IsBusy = false;
                        await PopupNavigation.PushAsync(dropDownPopup);
                    }
                    catch (Exception ex)
                    {

                    }
                   

                });
            }
        }

        private void DropDownPopup_DropDownSelectedItem1(object sender, EventArgs e)
        {
            try
            {
                DropDownPopupPage control = sender as DropDownPopupPage;
                ModelNo = control.SelectedItem.Title.ToUpper();
                //  ModelNumberValide=true
                ModelNumberValide = true;
                modelNumberSearchResponse = new Core.ResponseModels.ModelNumberSearchResponse() { ProductClassificationId = control.SelectedItem.Id, ModelName = control.SelectedItem.Title, ModelDescreption = control.SelectedItem.Desc };
            }
            catch (Exception ex)
            {

            }
            
        }

       
        public Command AddProductCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    if (! await Validation())
                    {
                        IsBusy = false;
                        return;

                    }
                      

                    //IsBusy = true;
                    
                    Device.BeginInvokeOnMainThread(async () => {
                      //  IsBusy = true;
                        await SaveProduct();
                        IsBusy = false;
                    });

                });
            }
        }
        //  Navigation.PushAsync(new ProductSuccessPage());
      //  public ICommand DateSlectCommand { get; set; }
        public Command DateSlectCommand
        {
            get
            {
                return new Command(() =>
                {
                   // Navigation.PushAsync(new AddProductPage());
                });
            }
        }
        public ICommand CategoryChangeCommand { get; set; }
        
        //public ICommand UploadInvoiceCommand { get; set; }
        public ICommand UploadWarrantyInvoiceCommand { get; set; }
        public Command UploadProductCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        FileData fileData = await TakePhotoAsync();
                        ProdctImageUploadFile = new FilesToUpload();
                        ProdctImageUploadFile.fileName = fileData.FileName;
                        ProdctImageUploadFile.mimeType = fileData.FileType;
                        ProdctImageUploadFile.path = fileData.FileName;
                        ProdctImageUploadFile.fileTypeId = 1;// Convert.ToInt16(FileTypeEnum.ProductImage);
                                                             //Convert.ToInt16(FileTypeEnum.ProductImage)
                        ProdctImageUploadFile.base64StringImage = fileData.string64baseData;
                        //  ProductsManagementSL productsManagement = new ProductsManagementSL();
                        //  var resp =await productsManagement.ProductFileUplod(fileData.string64baseData);

                        //ProductImageFile = fileData?.FileName;
                        string FileExtn = System.IO.Path.GetExtension(fileData?.FileName);
                        ProductImageFile = "ProductImage" + "" + FileExtn;

                    }
                    catch (Exception ex)
                    {

                    }
                });
            }
        }
        public Command ModelNoCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        var qrcode= await Extensions.QrScanning();
                        if(qrcode != null)
                        {
                            ModelNo = qrcode;
                        }
                      
                    }
                    catch (Exception ex)
                    {

                    }
                });
            }
        }
        public Command ModelNoInfoCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (string.IsNullOrEmpty(ModelNo))
                        {
                            // https://prism.panasonic.ae/ewarranty/ProductInfo
                            //  await DisplayAlert("Error!", "Please enter model number");
                            string weburl = "https://prism.panasonic.ae/ewarranty/ProductInfo";// + ModelNo;
                            await Browser.OpenAsync(weburl, new BrowserLaunchOptions
                            {
                                LaunchMode = BrowserLaunchMode.SystemPreferred,
                                TitleMode = BrowserTitleMode.Show,
                                PreferredToolbarColor = Color.AliceBlue,
                                PreferredControlColor = Color.Violet
                            });
                            return;
                        }
                        else
                        {
                            string weburl = "https://prism.panasonic.ae/ewarranty/ProductInfo?product=" + ModelNo;
                            await Browser.OpenAsync(weburl, new BrowserLaunchOptions
                            {
                                LaunchMode = BrowserLaunchMode.SystemPreferred,
                                TitleMode = BrowserTitleMode.Show,
                                PreferredToolbarColor = Color.AliceBlue,
                                PreferredControlColor = (Color)Application.Current.Resources["BlueColor"]
                            }); ;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                });
            }
        }
        public Command SerialNoCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        SerialNo = await Extensions.QrScanning();
                    }
                    catch(Exception ex)
                    {

                    }
                });
            }
        }
        #endregion

        #region Properties
        public ModelNumberSearchResponse modelNumberSearchResponse { get; set; }
        // public bool ModelNumberValide { get; set; }
        //List<ModelNumberSearchResponse> responses

        private List<string> _AllModelNos;
        public List<string> AllModelNos
        {
            get { return _AllModelNos; }
            set
            {
                _AllModelNos = value;
                OnPropertyChanged(nameof(AllmodelNumbers));
            }
        }

        private List<ModelNumberSearchResponse> _AllmodelNumbers;
        public List<ModelNumberSearchResponse> AllmodelNumbers
        {
            get { return _AllmodelNumbers; }
            set
            {
                _AllmodelNumbers = value;
                OnPropertyChanged(nameof(AllmodelNumbers));
            }
        }

        private List<ModelNumberSearchResponse> _modelNumberSearchResponses;
        public List<ModelNumberSearchResponse> modelNumberSearchResponses
        {
            get { return _modelNumberSearchResponses; }
            set
            {
                _modelNumberSearchResponses = value;
                OnPropertyChanged("modelNumberSearchResponses");
            }
        }
        private bool _ModelNumberValide;
        public bool ModelNumberValide
        {
            get { return _ModelNumberValide; }
            set
            {
                
                _ModelNumberValide = value;
                OnPropertyChanged("ModelNumberValide");
            }
        }
        private bool _SerialNumberValide;
        public bool SerialNumberValide
        {
            get { return _SerialNumberValide; }
            set
            {

                _SerialNumberValide = value;
                OnPropertyChanged("ModelNumberValide");
            }
        }
        private bool _DealerRequried;
        public bool DealerRequried
        {
            get { return _DealerRequried; }
            set
            {

                _DealerRequried = value;
                OnPropertyChanged("DealerRequried");
            }
        }
        private bool _InvoiceDocumentRequried;
        public bool InvoiceDocumentRequried
        {
            get { return _InvoiceDocumentRequried; }
            set
            {

                _InvoiceDocumentRequried = value;
                OnPropertyChanged("InvoiceDocumentRequried");
            }
        }

        public FilesToUpload InvoiceUploadFile { get; set; }
        public FilesToUpload ProdctImageUploadFile { get; set; }
        public string PhotoPath { get; set; }
        private ObservableCollection<DropDownModel> _CategorySource;
        public ObservableCollection<DropDownModel> CategorySource
        {
            get { return _CategorySource; }
            set
            {
                _CategorySource = value;
                OnPropertyChanged("CategorySource");
            }
        }
        private DropDownModel _SelectedCategory;
        public DropDownModel SelectedCategory
        {
            get { return _SelectedCategory; }
            set
            {
                _SelectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }
        private ObservableCollection<DropDownModel> _AllCountries;
        public ObservableCollection<DropDownModel> AllCountries
        {
            get { return _AllCountries; }
            set
            {
                _AllCountries = value;
                OnPropertyChanged("AllCountries");
            }
        }
        private DropDownModel _SelectCountry;
        public DropDownModel SelectCountry
        {
            get { return _SelectCountry; }
            set
            {
                _SelectCountry = value;
                OnPropertyChanged("SelectCountry");
            }
        }
        //DealerAddress
        private string _DealerAddress;
        public string DealerAddress
        {
            get { return _DealerAddress; }
            set
            {
                _DealerAddress = value;
                OnPropertyChanged("DealerAddress");
            }
        }
        private string _DealerName;
        public string DealerName
        {
            get { return _DealerName; }
            set
            {
                _DealerName = value;
                OnPropertyChanged("DealerName");
            }
        }
        private string _ProductName;
        public string ProductName
        {
            get { return _ProductName; }
            set
            {
                _ProductName = value;
                OnPropertyChanged("ProductName");
            }
        }
        private DateTime _SelectedDate;
        public DateTime SelectedDate
        {
            get { return _SelectedDate; }
            set
            {
                _SelectedDate = value;
               
               
                OnPropertyChanged("SelectedDate");
            }
        }
        private string _SerialNo;
        public string SerialNo
        {
            get { return _SerialNo; }
            set
            {
                _SerialNo = value.ToUpper();
               
                OnPropertyChanged("SerialNo");
            }
        }
        private string _ModelNo;
        public string ModelNo
        {
            get { return _ModelNo; }
            set
            {
                ModelNumberValide = true;
                _ModelNo = value.ToUpper();
                OnPropertyChanged("ModelNo");
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
        //purchaseInvoiceNumber
        private string _InvoiceFile;
        public string InvoiceFile
        {
            get { return _InvoiceFile; }
            set
            {
                _InvoiceFile = value;
                OnPropertyChanged("InvoiceFile");
            }
        }
        private string _ProductImageFile;
        public string ProductImageFile
        {
            get { return _ProductImageFile; }
            set
            {
                _ProductImageFile = value;
                OnPropertyChanged("ProductImageFile");
            }
        }
        private string _WarrantyInvoice;
        public string WarrantyInvoice
        {
            get { return _WarrantyInvoice; }
            set
            {
                _WarrantyInvoice = value;
                OnPropertyChanged("WarrantyInvoice");
            }
        }
        private bool _gdDealer;
        public bool gdDealer
        {
            get { return _gdDealer; }
            set
            {
                _gdDealer = value;
                OnPropertyChanged("gdDealer");
            }
        }
        //gdDealer
        //SerialNo
        #endregion

    }
}


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Customer.CommonPages;
using eWarranty.Views.Customer.SRDetails;
using Xamarin.Essentials;
using Xamarin.Forms;
using Extensions = eWarranty.Hepler.Extensions;

namespace eWarranty.ViewModels.Customer.SRDetails
{
    public class AddServicesRequestViewModel : BaseViewModel
    {
        public AddServicesRequestViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;

            // BindingData();
            Device.BeginInvokeOnMainThread(async () => {
                await BindingData();
                IsBusy = false;
            });
            //  IsBusy = false;
        }
        public async Task BindingData()
        {
            try
            {
                if (ServiceRequest == null)
                    ServiceRequest = new ServiceRequest();

                HomeDesc = false;
                MaxDate = DateTime.Today.AddDays(10);
                MinDate = DateTime.Today;
                IFormatProvider culture = new CultureInfo("en-US", true);
                //SDTimeSpan = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);
                if (ScheduleDateTimes == null)
                    ScheduleDateTimes = new ObservableCollection<DropDownModel>();


                if (ServiceRequestLocationTyps == null)
                    ServiceRequestLocationTyps = new ObservableCollection<DropDownModel>();
                var SRLocationType = new DropDownModel() { Id = Convert.ToInt16(ServiceLocationTypeEnum.ServiceCenterRepair), Title = AppResources.titleIwilltakemyproducttoservicecenter };
                //var SRLocationType = new DropDownModel() { Id = Convert.ToInt16(ServiceLocationTypeEnum.HomeService), Title = "I Prefer Home Service" };
                ServiceRequestLocationTyps.Add(SRLocationType);
                ServiceRequestLocationTyps.Add(new DropDownModel() { Id = Convert.ToInt16(ServiceLocationTypeEnum.HomeService), Title = AppResources.titleIPreferHomeService });

                ServiceRequestLocationType = SRLocationType;

                if (CommonAttribute.SRInputModel != null)
                {
                    ProductName = CommonAttribute.SRInputModel.ProductModelWarrantyResponse.ModelNumber;
                    ServiceCenterName = CommonAttribute.SRInputModel.ServiceCenter.Name;
                }

                ScheduleDateTimesCommand = new Command<DropDownModel>((item) =>
                {
                    SelectedScheduleDateTimes = item;

                });
                WarrantyTypeCommand = new Command<DropDownModel>((item) =>
                {
                    SelectedWarrantyType = item;

                });
                ServiceRequestTypeCommand = new Command<DropDownModel>((item) =>
                {


                    ServiceRequestType = item;

                });
                MasterDataManagementSL masterDataManagement = new MasterDataManagementSL();
                List<ServiceRequestTypesResponse> serviceRequestTypes = await masterDataManagement.GetServiceRequestTypes();
                if (ServiceRequestTyps == null)
                    ServiceRequestTyps = new ObservableCollection<DropDownModel>();
                foreach (var item in serviceRequestTypes)
                {
                    if (item.serviceRequestTypeId == 1)
                    {
                        DropDownModel dropDownModel = new DropDownModel();
                        dropDownModel.Id = item.serviceRequestTypeId;
                        dropDownModel.Title = item.name;

                        if (CommonAttribute.selectedLang.lid == 2) // as per Akash sir
                        {
                            dropDownModel.Title = AppResources.lblRepair;
                        }
                        else
                        {
                            dropDownModel.Title = item.name;
                        }

                        ServiceRequestTyps.Add(dropDownModel);
                        if (ServiceRequestType == null)
                            ServiceRequestType = dropDownModel;



                    }
                }

                ServiceLocationId = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            
        }

        async Task<FileData> LoadPhotoAsync(FileResult photo)
        {
            FileData fileData = new FileData();
            try
            {
                if (photo == null)
                {
                    //  PhotoPath = null;
                    return null;
                }
                // save the file into local storage
                var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                fileData.FileType = photo.ContentType;
                using (var stream = await photo.OpenReadAsync())
                {
                    using (var newStream = File.OpenWrite(newFile))
                        await stream.CopyToAsync(newStream);
                    string string64base = Extensions.ConvertToBase64(stream);
                    fileData.string64baseData = string64base;
                }
                fileData.FileName = photo.FileName;
            }
            catch (Exception ex)
            {
                return null;
            }
            

            return fileData;

        }
        public FileResult photo { get; set; }
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
                        await ErrorDisplayAlert(AppResources.lblErrorCameranotsupported);
                        return null;
                    }
                    MediaPickerOptions mediaPicker = new MediaPickerOptions();

                    photo = await MediaPicker.CapturePhotoAsync();
                }

                if (photo != null)
                {
                    return fileData = await LoadPhotoAsync(photo);

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
        public Command UploadProductCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        FileData fileData = await TakePhotoAsync();
                        if (fileData != null)
                        {
                            ProductUploadFile = new FilesToUploadRequest();
                            ProductUploadFile.FileName = fileData.FileName;
                            ProductUploadFile.MimeType = fileData.FileType;
                            ProductUploadFile.Path = fileData.FileName;
                            ProductUploadFile.FileTypeId = 2;// Convert.ToInt16(FileTypeEnum.ProductInvoice);
                            ProductUploadFile.base64StringImage = fileData.string64baseData;

                            string FileExtn = System.IO.Path.GetExtension(fileData?.FileName);
                            InvoiceFile = "ProductImage" + "" + FileExtn;

                            //InvoiceFile = fileData.FileName;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                });
            }
        }

        public async Task SaveServiceRequest()
        {
            IsBusy = true;
            try
            {
                //  SDDate = DateTime.Now;
                // SDTimeSpan = new TimeSpan(9, 00, 00);
                //ServiceRequestTyps
                IsBusy = true;
                ServiceRequestSL serviceRequestSL = new ServiceRequestSL();
                //   ServiceRequest.ServiceRequestName = CommonAttribute.SRInputModel.ProductModel.ModelNumber;
                ServiceRequest.ServiceRequestNumber = DateTime.Now.Millisecond.ToString();
                //  ServiceRequest.ServiceCenterId = CommonAttribute.SRInputModel.ServiceCenterId;
                ServiceRequest.CreationDate = DateTime.Now;
                // ServiceRequest.CustomerPerson = CommonAttribute.CustomeProfile;
                ServiceRequest.CustomerPersonId = (long)CommonAttribute.CustomeProfile?.PersonId;
                //  ServiceRequest.CustomerRemark = "";
                ServiceRequest.ProductModelId = (long)CommonAttribute.SRInputModel?.ProductModelWarrantyResponse?.ProductModelID;
                //ServiceRequest.ServiceRequestAddressId = 1;// customer address id
                if (SelectedAddress != null)
                {
                    ServiceRequest.ServiceRequestAddressId = SelectedAddress.AddressId;
                }
                else
                {
                    ServiceRequest.ServiceRequestAddressId = null;
                }

                //if (SelectedWarrantyType != null)
                //    ServiceRequest.ProductWarrantyTypeId = SelectedWarrantyType.Id;
                //else
                //    ServiceRequest.ProductWarrantyTypeId = 1;

                //DateTime dateVal = SDDate.Date.AddHours(CommonAttribute.CustTimeSpan.Hours);
                //dateVal.Date.AddMinutes(CommonAttribute.CustTimeSpan.Minutes);
                //dateVal.Date.AddTicks(CommonAttribute.CustTimeSpan.Ticks);

                //if (ServiceRequestLocationType != null)
                //{
                //    IFormatProvider culture = new CultureInfo("en-US", true);
                //    var Time = SDTimeSpan.ToString();
                //    //DateTime dateVal = SDDate.AddHours(SDTimeSpan.Hours); //DateTime.ParseExact(SelectedScheduleDateTimes.Title, "dd/MM/yyyy HH:mm", culture);

                //    ServiceRequest.CustomerSrpreferredDateTime = dateVal;
                //    ServiceRequest.ServiceLocationTypeId = ServiceRequestLocationType.Id;

                //}
                //if (ServiceRequestLocationType.Id == Convert.ToInt16(ServiceLocationTypeEnum.HomeService))
                //{
                //    //ServiceRequest.CustomerSrpreferredDateTime = CommonAttribute.PreferData;
                //    var Time = SDTimeSpan.ToString();
                //    //DateTime dateVal = SDDate.AddHours(SDTimeSpan.Hours); //DateTime.ParseExact(SelectedScheduleDateTimes.Title, "dd/MM/yyyy HH:mm", culture);

                //    ServiceRequest.CustomerSrpreferredDateTime = dateVal;
                //}
                DateTime dateVal = DateTime.Now.Date;
                if (CommonAttribute.PreferData.Date.ToString() != "1/1/0001 12:00:00 AM")
                {
                    SDDate = CommonAttribute.PreferData.Date;
                    dateVal = SDDate.Date.AddHours(CommonAttribute.CustTimeSpan.Hours);
                }

                if (ServiceRequestLocationType != null)
                {
                    IFormatProvider culture = new CultureInfo("en-US", true);
                    
                    dateVal.Date.AddMinutes(CommonAttribute.CustTimeSpan.Minutes);
                    dateVal.Date.AddTicks(CommonAttribute.CustTimeSpan.Ticks);
                    ServiceRequest.CustomerSrpreferredDateTime = dateVal;
                    ServiceRequest.ServiceLocationTypeId = ServiceRequestLocationType.Id;

                }
                if (ServiceRequestLocationType.Id == Convert.ToInt16(ServiceLocationTypeEnum.HomeService))
                {
                    //ServiceRequest.CustomerSrpreferredDateTime = CommonAttribute.PreferData;

                    
                    dateVal.Date.AddMinutes(CommonAttribute.CustTimeSpan.Minutes);
                    dateVal.Date.AddTicks(CommonAttribute.CustTimeSpan.Ticks);
                    ServiceRequest.CustomerSrpreferredDateTime = dateVal;
                    ServiceRequest.ServiceLocationTypeId = ServiceRequestLocationType.Id;
                }

                ServiceRequest.TypeId = Convert.ToInt16(ServiceRequestTypeEnum.RepairService);
                //if (ServiceLocationId ==2)
                //    ServiceRequest.TypeId = ServiceRequestType.Id;
                //else
                //    ServiceRequest.TypeId = 1;

                ServiceRequest.PriorityId = Convert.ToInt16(ServiceRequestPriorityEnum.Moderate);
                ServiceRequest.StatusId = Convert.ToInt16(ServiceRequestStatusEnum.New);
                ServiceRequest.ServiceCenterId = (int)CommonAttribute.SRInputModel?.ServiceCenter?.ServiceCenterId;
                // ServiceRequest.ServiceRequestAddressId
                //  ServiceRequest.typeId= // service reqest type id

                ServiceRequest.StartDateTime = dateVal; //as per anu

                //ServiceRequest.StartDateTime = DateTime.Now; // previous

                //  ServiceRequest.EndDateTime = DateTime.Now; null

                List<FilesToUploadRequest> filesToUploads = new List<FilesToUploadRequest>();
                if (ProductUploadFile != null)
                {
                    filesToUploads.Add(ProductUploadFile);
                }
                ServiceRequest.FilesToUpload = filesToUploads;

                //ReceiveContext<string> receiveContext = await serviceRequestSL.AddServiceRequests(ServiceRequest);
                APIResponse receiveContext = await serviceRequestSL.AddServiceRequests(ServiceRequest);
                if (receiveContext?.Status == Convert.ToInt16(APIResponseEnum.Success))
                {
                    string refrance = receiveContext.Message;
                    string msg = CommonFunctions.GetMessagesByLanguage(receiveContext, CommonAttribute.selectedLang.lid);
                    if (SelectedAddress != null)
                    {
                        await AddressNavigation.PushAsync(new SRSuccessPage(msg));
                    }
                    else
                    {
                        await Navigation.PushAsync(new SRSuccessPage(msg));
                    }
                }
                else
                {
                    string msg = CommonFunctions.GetMessagesByLanguage(receiveContext, CommonAttribute.selectedLang.lid);
                    //await Application.Current.MainPage.DisplayAlert("", AppResources.msgServicerequestisalreadyinprogress, AppResources.lblCancel);
                    await Application.Current.MainPage.DisplayAlert("", msg, AppResources.lblCancel);
                }
                IsBusy = false;

            }
            catch (Exception ex)
            {
                await ErrorDisplayAlert(ex.Message);
                IsBusy = false;
            }
        }

        public void SubmitServicesRequest()
        {
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                await SaveServiceRequest();
                IsBusy = false;
            });
        }
        public async Task<bool> Validation()
        {
            if (string.IsNullOrEmpty(ServiceRequest.CustomerRemark))
            {
                await ErrorDisplayAlert(AppResources.lblPleaseenterdescription);
                return false;
            }
            if (ServiceRequestType == null)
            {
                await ErrorDisplayAlert(AppResources.lblPleaseselectservicerequesttype);
                return false;
            }
            //if (SelectedWarrantyType == null)
            //{
            //    await ErrorDisplayAlert("Please select warranty type.");
            //    return false;
            //}
            //if(SelectedAddres == null)
            //{
            //    await ErrorDisplayAlert("Please select address.");
            //    return false;
            //}
            //if (SelectedScheduleDateTimes == null)
            //{
            //    await ErrorDisplayAlert("Please select address.");
            //    return false;
            //}
            //if (SDDate == default)
            //{
            //    await ErrorDisplayAlert("Please select date.");
            //    return false;
            //}
            //if (SDTimeSpan == default)
            //{
            //    await ErrorDisplayAlert("Please select time.");
            //    return false;
            //}
            //if (CommonAttribute.SRInputModel.ServiceCenter.WorkingHoursStart != null)
            //{
            //    TimeSpan start = TimeSpan.Parse(CommonAttribute.SRInputModel.ServiceCenter.WorkingHoursStart.ToString());
            //    TimeSpan end = TimeSpan.Parse(CommonAttribute.SRInputModel.ServiceCenter.WorkingHoursEnd.ToString());
            //    if(SDTimeSpan > start)
            //    {
            //        await ErrorDisplayAlert("Service center timing are :"+ start.ToString("HH: mm tt") + " To "+ end.ToString("HH: mm tt"));
            //        return false;
            //    }
            //    if (SDTimeSpan < start)
            //    {
            //        await ErrorDisplayAlert("Service center timing are :" + start.ToString("HH: mm tt") + " To " + end.ToString("HH: mm tt"));
            //        return false;
            //    }
            //}
            return true;
        }
        #region events

        public ICommand WarrantyTypeCommand { get; set; }
        public ICommand ServiceRequestTypeCommand { get; set; }
        public ICommand ScheduleDateTimesCommand { get; set; }
        public Command SelectAddressCommand
        {
            get
            {
                return new Command(async () =>
                {

                    //MessagingCenter.Unsubscribe<AddressesPage, Address>(this, "Address");
                    //MessagingCenter.Subscribe<AddressesPage, Address>(this, "Address", async (sender, arg) =>
                    //{
                    //    try
                    //    {
                    //        SelectedAddres = arg;

                    //    }
                    //    catch(Exception ex)
                    //    {

                    //    }

                    //});
                    try
                    {
                        IsBusy = true;
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            if (await Validation())
                            {
                                if (ServiceRequestLocationType.Id == Convert.ToInt16(ServiceLocationTypeEnum.ServiceCenterRepair))
                                {
                                    await Task.Delay(TimeSpan.FromSeconds(1));
                                    SubmitServicesRequest();
                                }
                                else
                                {
                                    SRconfirmPage addressesPage = new SRconfirmPage(this);
                                    addressesPage.SelectedAddress -= AddressesPage_SelectedAddress;
                                    addressesPage.SelectedAddress += async (sender, arg) =>
                                    {
                                        //addressesPage.Navigation.PopAsync();
                                        AddressNavigation = addressesPage.Navigation;
                                        SelectedAddress = sender as AddressResponse;
                                        NavigationPage.SetHasBackButton(addressesPage, false);

                                        await Task.Delay(TimeSpan.FromSeconds(1));
                                        SubmitServicesRequest();

                                    };
                                    await Navigation.PushAsync(addressesPage);
                                }
                            }
                            IsBusy = false;
                        });

                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                    

                });
            }
        }
        public INavigation AddressNavigation { get; set; }
        private async void AddressesPage_SelectedAddress(object sender, EventArgs e)
        {

        }

        public Command SaveCommand
        {
            get
            {
                return new Command(async () =>
                {

                });
            }
        }
        public Command ServiceRequestLocationTypeCommand
        {
            get
            {
                return new Command<DropDownModel>(async (item) =>
                {
                    ServiceRequestLocationType = item;
                    if (ServiceRequestLocationType.Id == Convert.ToInt16(ServiceLocationTypeEnum.ServiceCenterRepair))
                        HomeDesc = false;
                    else
                        HomeDesc = true;

                });
            }
        }
        #endregion
        #region properties
        //InvoiceFile
        //ServiceLocationId

        public FilesToUploadRequest ProductUploadFile { get; set; }

        private bool _ServiceLocationId;
        public bool ServiceLocationId
        {
            get { return _ServiceLocationId; }
            set
            {

                _ServiceLocationId = value;
                OnPropertyChanged("ServiceLocationId");
            }
        }
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
        private bool _HomeDesc;
        public bool HomeDesc
        {
            get { return _HomeDesc; }
            set
            {

                _HomeDesc = value;
                OnPropertyChanged("HomeDesc");
            }
        }
        private DateTime _MaxDate;
        public DateTime MaxDate
        {
            get { return _MaxDate; }
            set
            {

                _MaxDate = value;
                OnPropertyChanged("MaxDate");
            }
        }
        private DateTime _MinDate;
        public DateTime MinDate
        {
            get { return _MinDate; }
            set
            {

                _MinDate = value;
                OnPropertyChanged("MinDate");
            }
        }
        private AddressResponse _SelectedAddress;
        public AddressResponse SelectedAddress
        {
            get { return _SelectedAddress; }
            set
            {
                _SelectedAddress = value;
                OnPropertyChanged("SelectedAddress");
            }
        }
        private DropDownModel _SelectedWarrantyType;
        public DropDownModel SelectedWarrantyType
        {
            get { return _SelectedWarrantyType; }
            set
            {
                _SelectedWarrantyType = value;
                OnPropertyChanged("SelectedWarrantyType");
            }
        }
        private ObservableCollection<DropDownModel> _WarrantyCustomerProducts;
        public ObservableCollection<DropDownModel> WarrantyCustomerProducts
        {
            get { return _WarrantyCustomerProducts; }
            set
            {
                _WarrantyCustomerProducts = value;
                OnPropertyChanged("WarrantyCustomerProducts");
            }
        }
        //WarrantyCustomerProduct
        private ObservableCollection<DropDownModel> _ServiceRequestTyps;
        public ObservableCollection<DropDownModel> ServiceRequestTyps
        {
            get { return _ServiceRequestTyps; }
            set
            {
                _ServiceRequestTyps = value;
                OnPropertyChanged("ServiceRequestTyps");
            }
        }
        private DropDownModel _ServiceRequestType;
        public DropDownModel ServiceRequestType
        {
            get { return _ServiceRequestType; }
            set
            {
                _ServiceRequestType = value;
                OnPropertyChanged("ServiceRequestType");
            }
        }
        private ObservableCollection<DropDownModel> _ServiceRequestLocationTyps;
        public ObservableCollection<DropDownModel> ServiceRequestLocationTyps
        {
            get { return _ServiceRequestLocationTyps; }
            set
            {
                _ServiceRequestLocationTyps = value;
                OnPropertyChanged("ServiceRequestLocationTyps");
            }
        }
        private DropDownModel _ServiceRequestLocationType;
        public DropDownModel ServiceRequestLocationType
        {
            get { return _ServiceRequestLocationType; }
            set
            {
                _ServiceRequestLocationType = value;
                OnPropertyChanged("ServiceRequestLocationType");
            }
        }
        private ServiceRequest _ServiceRequest;
        public ServiceRequest ServiceRequest
        {
            get { return _ServiceRequest; }
            set
            {
                _ServiceRequest = value;
                OnPropertyChanged("ServiceRequest");
            }
        }
        private DateTime _SDDate;
        public DateTime SDDate
        {
            get { return _SDDate; }
            set
            {
                _SDDate = value;
                OnPropertyChanged("SDDate");
            }
        }

        private string _CustTime;
        public string CustTime
        {
            get { return _CustTime; }
            set
            {
                _CustTime = value;
                OnPropertyChanged(nameof(CustTime));
            }
        }

        private TimeSpan _SDTimeSpan;
        public TimeSpan SDTimeSpan
        {
            get { return _SDTimeSpan; }
            set
            {
                _SDTimeSpan = value;
                OnPropertyChanged("SDTimeSpan");
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
        private string _ServiceCenterName;
        public string ServiceCenterName
        {
            get { return _ServiceCenterName; }
            set
            {
                _ServiceCenterName = value;
                OnPropertyChanged("ServiceCenterName");
            }
        }
        //ServiceCenterName
        private ObservableCollection<DropDownModel> _ScheduleDateTimes;
        public ObservableCollection<DropDownModel> ScheduleDateTimes
        {
            get { return _ScheduleDateTimes; }
            set
            {
                _ScheduleDateTimes = value;
                OnPropertyChanged("ScheduleDateTimes");
            }
        }
        private DropDownModel _SelectedScheduleDateTimes;
        public DropDownModel SelectedScheduleDateTimes
        {
            get { return _SelectedScheduleDateTimes; }
            set
            {
                _SelectedScheduleDateTimes = value;
                OnPropertyChanged("SelectedScheduleDateTimes");
            }
        }
        #endregion
    }
}


//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Windows.Input;
//using eWarranty.Core.Common;
//using eWarranty.Core.Enums;
//using eWarranty.Core.Models;
//using eWarranty.Core.RequestModels;
//using eWarranty.Core.ResponseModels;
//using eWarranty.Core.ServiceLayer;
//using eWarranty.Hepler;
//using eWarranty.Models;
//using eWarranty.Resx;
//using eWarranty.Views.Customer.CommonPages;
//using eWarranty.Views.Customer.SRDetails;
//using Xamarin.Essentials;
//using Xamarin.Forms;
//using Extensions = eWarranty.Hepler.Extensions;

//namespace eWarranty.ViewModels.Customer.SRDetails
//{
//    public class AddServicesRequestViewModel : BaseViewModel
//    {
//        public AddServicesRequestViewModel(INavigation navigation) : base(navigation)
//        {
//            IsBusy = true;

//           // BindingData();
//              Device.BeginInvokeOnMainThread( async() => {
//                    await BindingData();
//                  IsBusy = false;
//              });
//            //  IsBusy = false;
//        }
//        public async Task BindingData()
//        {
//            if (ServiceRequest == null)
//                ServiceRequest = new ServiceRequest();

//            HomeDesc = false;
//            SDDate = DateTime.Now;
//            MaxDate = DateTime.Today.AddDays(10);
//            MinDate = DateTime.Today;
//            IFormatProvider culture = new CultureInfo("en-US", true);
//            SDTimeSpan = new TimeSpan(DateTime.Now.Hour,DateTime.Now.Minute,0);
//            if (ScheduleDateTimes == null)
//                ScheduleDateTimes = new ObservableCollection<DropDownModel>();


//            if (ServiceRequestLocationTyps == null)
//                ServiceRequestLocationTyps = new ObservableCollection<DropDownModel>();
//            var SRLocationType = new DropDownModel() { Id = Convert.ToInt16(ServiceLocationTypeEnum.ServiceCenterRepair), Title = AppResources.titleIwilltakemyproducttoservicecenter };
//          //var SRLocationType = new DropDownModel() { Id = Convert.ToInt16(ServiceLocationTypeEnum.HomeService), Title = "I Prefer Home Service" };
//            ServiceRequestLocationTyps.Add(SRLocationType);
//            ServiceRequestLocationTyps.Add(new DropDownModel() { Id = Convert.ToInt16(ServiceLocationTypeEnum.HomeService), Title = AppResources.titleIPreferHomeService });

//            ServiceRequestLocationType = SRLocationType;

//            ProductName = CommonAttribute.SRInputModel.ProductModelWarrantyResponse.ModelNumber;
//            ServiceCenterName = CommonAttribute.SRInputModel.ServiceCenter.Name;

//            ScheduleDateTimesCommand = new Command<DropDownModel>((item) =>
//            {
//                SelectedScheduleDateTimes = item;

//            });
//            WarrantyTypeCommand = new Command<DropDownModel>((item) =>
//            {
//                SelectedWarrantyType = item;

//            });
//            ServiceRequestTypeCommand = new Command<DropDownModel>((item) =>
//            {


//                ServiceRequestType = item;

//            });
//            MasterDataManagementSL masterDataManagement = new MasterDataManagementSL();
//            List<ServiceRequestTypesResponse> serviceRequestTypes = await masterDataManagement.GetServiceRequestTypes();
//            if (ServiceRequestTyps == null)
//                ServiceRequestTyps = new ObservableCollection<DropDownModel>();
//            foreach (var item in serviceRequestTypes)
//            {
//                if (item.serviceRequestTypeId == 1)
//                {
//                    DropDownModel dropDownModel = new DropDownModel();
//                    dropDownModel.Id = item.serviceRequestTypeId;
//                    dropDownModel.Title = item.name;

//                    if (CommonAttribute.selectedLang.lid == 2) // as per Akash sir
//                    {
//                        dropDownModel.Title = AppResources.lblRepair;
//                    }
//                    else
//                    {
//                        dropDownModel.Title = item.name;
//                    }

//                    ServiceRequestTyps.Add(dropDownModel);
//                    if (ServiceRequestType == null)
//                        ServiceRequestType = dropDownModel;



//                }
//            }

//            ServiceLocationId = true;
//                    IsBusy = false;
//        }

//        async Task<FileData> LoadPhotoAsync(FileResult photo)
//        {
//            // canceled
//            FileData fileData = new FileData();

//            if (photo == null)
//            {
//              //  PhotoPath = null;
//                return null;
//            }
//            // save the file into local storage
//            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
//            fileData.FileType = photo.ContentType;
//            using (var stream = await photo.OpenReadAsync())
//            {
//                using (var newStream = File.OpenWrite(newFile))
//                    await stream.CopyToAsync(newStream);
//                string string64base = Extensions.ConvertToBase64(stream);
//                fileData.string64baseData = string64base;
//            }
//            fileData.FileName = photo.FileName;

//            return fileData;

//        }
//        public FileResult photo { get; set; }
//        async Task<FileData> TakePhotoAsync()
//        {
//            try
//            {
//                GC.Collect();
//                FileData fileData = new FileData();
//                string action = await Application.Current.MainPage.DisplayActionSheet(AppResources.lblTakePhoto, AppResources.lblCancel, null, AppResources.lblTakePhoto, AppResources.lblGallery);

//                if (action == AppResources.lblGallery)
//                {
//                    photo = await MediaPicker.PickPhotoAsync();// CapturePhotoAsync();
//                }
//                else if (action == AppResources.lblTakePhoto)
//                {
//                    if (!MediaPicker.IsCaptureSupported)
//                    {
//                        await ErrorDisplayAlert(AppResources.lblErrorCameranotsupported);
//                        return null;
//                    }
//                    MediaPickerOptions mediaPicker = new MediaPickerOptions();

//                    photo = await MediaPicker.CapturePhotoAsync();
//                }

//                if (photo != null)
//                {
//                    return fileData = await LoadPhotoAsync(photo);

//                    // Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
//                }
//                return fileData;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
//                return null;
//            }
//        }
//        public Command UploadProductCommand
//        {
//            get
//            {
//                return new Command(async () =>
//                {
//                    FileData fileData = await TakePhotoAsync();
//                    if (fileData != null)
//                    {
//                        ProductUploadFile = new FilesToUploadRequest();
//                        ProductUploadFile.FileName = fileData.FileName;
//                        ProductUploadFile.MimeType = fileData.FileType;
//                        ProductUploadFile.Path = fileData.FileName;
//                        ProductUploadFile.FileTypeId = 2;// Convert.ToInt16(FileTypeEnum.ProductInvoice);
//                        ProductUploadFile.base64StringImage = fileData.string64baseData;
//                        InvoiceFile = fileData.FileName;
//                    }
//                });
//            }
//        }

//        public async Task SaveServiceRequest()
//        {
//            try
//            {
//                //  SDDate = DateTime.Now;
//                // SDTimeSpan = new TimeSpan(9, 00, 00);
//                //ServiceRequestTyps
//                IsBusy = true;
//                ServiceRequestSL serviceRequestSL = new ServiceRequestSL();
//                //   ServiceRequest.ServiceRequestName = CommonAttribute.SRInputModel.ProductModel.ModelNumber;
//                ServiceRequest.ServiceRequestNumber = DateTime.Now.Millisecond.ToString();
//                //  ServiceRequest.ServiceCenterId = CommonAttribute.SRInputModel.ServiceCenterId;
//                ServiceRequest.CreationDate = DateTime.Now;
//                // ServiceRequest.CustomerPerson = CommonAttribute.CustomeProfile;
//                ServiceRequest.CustomerPersonId =(long) CommonAttribute.CustomeProfile?.PersonId;
//                //  ServiceRequest.CustomerRemark = "";
//                ServiceRequest.ProductModelId = (long)CommonAttribute.SRInputModel?.ProductModelWarrantyResponse?.ProductModelID;
//                //ServiceRequest.ServiceRequestAddressId = 1;// customer address id
//                if (SelectedAddress != null)
//                {
//                    ServiceRequest.ServiceRequestAddressId = SelectedAddress.AddressId;
//                }
//                else
//                {
//                    ServiceRequest.ServiceRequestAddressId = null;
//                }

//                //if (SelectedWarrantyType != null)
//                //    ServiceRequest.ProductWarrantyTypeId = SelectedWarrantyType.Id;
//                //else
//                //    ServiceRequest.ProductWarrantyTypeId = 1;
//                if (ServiceRequestLocationType != null)
//                {
//                    IFormatProvider culture = new CultureInfo("en-US", true);
//                    DateTime dateVal = SDDate.AddHours(SDTimeSpan.Hours); //DateTime.ParseExact(SelectedScheduleDateTimes.Title, "dd/MM/yyyy HH:mm", culture);
//                    dateVal.AddMinutes(SDTimeSpan.Minutes);
//                    ServiceRequest.CustomerSrpreferredDateTime = dateVal;
//                    ServiceRequest.ServiceLocationTypeId = ServiceRequestLocationType.Id;

//                }
//                if (ServiceRequestLocationType.Id == Convert.ToInt16(ServiceLocationTypeEnum.HomeService))
//                {
//                    ServiceRequest.CustomerSrpreferredDateTime = CommonAttribute.PreferData;
//                }



//                ServiceRequest.TypeId = Convert.ToInt16(ServiceRequestTypeEnum.RepairService);
//                //if (ServiceLocationId ==2)
//                //    ServiceRequest.TypeId = ServiceRequestType.Id;
//                //else
//                //    ServiceRequest.TypeId = 1;

//                ServiceRequest.PriorityId = Convert.ToInt16(ServiceRequestPriorityEnum.Moderate);
//                ServiceRequest.StatusId = Convert.ToInt16(ServiceRequestStatusEnum.New);
//                ServiceRequest.ServiceCenterId =(int) CommonAttribute.SRInputModel?.ServiceCenter?.ServiceCenterId;
//                // ServiceRequest.ServiceRequestAddressId
//                //  ServiceRequest.typeId= // service reqest type id
//                ServiceRequest.StartDateTime = DateTime.Now;
//                //  ServiceRequest.EndDateTime = DateTime.Now; null

//                List<FilesToUploadRequest> filesToUploads = new List<FilesToUploadRequest>();
//                if (ProductUploadFile != null)
//                {
//                    filesToUploads.Add(ProductUploadFile);
//                }
//                ServiceRequest.FilesToUpload = filesToUploads;

//                //ReceiveContext<string> receiveContext = await serviceRequestSL.AddServiceRequests(ServiceRequest);
//                APIResponse receiveContext = await serviceRequestSL.AddServiceRequests(ServiceRequest);
//                if (receiveContext?.Status == Convert.ToInt16(APIResponseEnum.Success))
//                {
//                    string refrance = receiveContext.Message;
//                    string msg = CommonFunctions.GetMessagesByLanguage(receiveContext, CommonAttribute.selectedLang.lid);
//                    if (SelectedAddress != null)
//                    {
//                        await AddressNavigation.PushAsync(new SRSuccessPage(msg));
//                    }
//                    else
//                    {
//                        await Navigation.PushAsync(new SRSuccessPage(msg));
//                    }
//                }
//                else
//                {
//                    string msg = CommonFunctions.GetMessagesByLanguage(receiveContext, CommonAttribute.selectedLang.lid);
//                    //await Application.Current.MainPage.DisplayAlert("", AppResources.msgServicerequestisalreadyinprogress, AppResources.lblCancel);
//                    await Application.Current.MainPage.DisplayAlert("", msg, AppResources.lblCancel);
//                }
//                IsBusy = false;

//            }
//            catch (Exception ex)
//            {
//                await ErrorDisplayAlert(ex.Message);
//                IsBusy = false;
//            }
//        }

//        public void SubmitServicesRequest()
//        {
//            IsBusy = true;
//            Device.BeginInvokeOnMainThread(async () =>
//            {
//                await Task.Delay(TimeSpan.FromSeconds(1));
//                await SaveServiceRequest();
//                IsBusy = false;
//            });
//        }
//        public async Task<bool> Validation()
//        {
//            if(string.IsNullOrEmpty(ServiceRequest.CustomerRemark))
//            {
//               await ErrorDisplayAlert(AppResources.lblPleaseenterdescription);
//                return false;
//            }
//            if (ServiceRequestType == null)
//            {
//                await ErrorDisplayAlert(AppResources.lblPleaseselectservicerequesttype);
//                return false;
//            }
//            //if (SelectedWarrantyType == null)
//            //{
//            //    await ErrorDisplayAlert("Please select warranty type.");
//            //    return false;
//            //}
//            //if(SelectedAddres == null)
//            //{
//            //    await ErrorDisplayAlert("Please select address.");
//            //    return false;
//            //}
//            //if (SelectedScheduleDateTimes == null)
//            //{
//            //    await ErrorDisplayAlert("Please select address.");
//            //    return false;
//            //}
//            //if (SDDate == default)
//            //{
//            //    await ErrorDisplayAlert("Please select date.");
//            //    return false;
//            //}
//            //if (SDTimeSpan == default)
//            //{
//            //    await ErrorDisplayAlert("Please select time.");
//            //    return false;
//            //}
//            //if (CommonAttribute.SRInputModel.ServiceCenter.WorkingHoursStart != null)
//            //{
//            //    TimeSpan start = TimeSpan.Parse(CommonAttribute.SRInputModel.ServiceCenter.WorkingHoursStart.ToString());
//            //    TimeSpan end = TimeSpan.Parse(CommonAttribute.SRInputModel.ServiceCenter.WorkingHoursEnd.ToString());
//            //    if(SDTimeSpan > start)
//            //    {
//            //        await ErrorDisplayAlert("Service center timing are :"+ start.ToString("HH: mm tt") + " To "+ end.ToString("HH: mm tt"));
//            //        return false;
//            //    }
//            //    if (SDTimeSpan < start)
//            //    {
//            //        await ErrorDisplayAlert("Service center timing are :" + start.ToString("HH: mm tt") + " To " + end.ToString("HH: mm tt"));
//            //        return false;
//            //    }
//            //}
//            return true;
//        }
//        #region events

//        public ICommand WarrantyTypeCommand { get; set; }
//        public ICommand ServiceRequestTypeCommand { get; set; }
//        public ICommand ScheduleDateTimesCommand { get; set; }
//        public Command SelectAddressCommand
//        {
//            get
//            {
//                return new Command(async () =>
//                {

//                    //MessagingCenter.Unsubscribe<AddressesPage, Address>(this, "Address");
//                    //MessagingCenter.Subscribe<AddressesPage, Address>(this, "Address", async (sender, arg) =>
//                    //{
//                    //    try
//                    //    {
//                    //        SelectedAddres = arg;

//                    //    }
//                    //    catch(Exception ex)
//                    //    {

//                    //    }

//                    //});
//                    IsBusy = true;
//                    Device.BeginInvokeOnMainThread(async () =>
//                    {
//                        if (await Validation())
//                        {
//                            if (ServiceRequestLocationType.Id == Convert.ToInt16(ServiceLocationTypeEnum.ServiceCenterRepair))
//                            {
//                                await Task.Delay(TimeSpan.FromSeconds(1));
//                                SubmitServicesRequest();
//                            }
//                            else
//                            {
//                                SRconfirmPage addressesPage = new SRconfirmPage(this);
//                                addressesPage.SelectedAddress -= AddressesPage_SelectedAddress;
//                                addressesPage.SelectedAddress += async (sender, arg) =>
//                                {
//                                    //addressesPage.Navigation.PopAsync();
//                                    AddressNavigation = addressesPage.Navigation;
//                                    SelectedAddress = sender as AddressResponse;
//                                    NavigationPage.SetHasBackButton(addressesPage, false);

//                                    await Task.Delay(TimeSpan.FromSeconds(1));
//                                    SubmitServicesRequest();

//                                };
//                                await Navigation.PushAsync(addressesPage);
//                            }
//                        }
//                        IsBusy = false;
//                    });


//                });
//            }
//        }
//        public INavigation AddressNavigation { get; set; }
//        private async void AddressesPage_SelectedAddress(object sender, EventArgs e)
//        {

//        }

//        public Command SaveCommand
//        {
//            get
//            {
//                return new Command(async () =>
//                {

//                });
//            }
//        }
//        public Command ServiceRequestLocationTypeCommand
//        {
//            get
//            {
//                return new Command<DropDownModel>(async (item) =>
//                {
//                    ServiceRequestLocationType = item;
//                    if (ServiceRequestLocationType.Id == Convert.ToInt16(ServiceLocationTypeEnum.ServiceCenterRepair))
//                        HomeDesc = false;
//                    else
//                        HomeDesc = true;

//                });
//            }
//        }
//        #endregion
//        #region properties
//        //InvoiceFile
//        //ServiceLocationId

//        public FilesToUploadRequest ProductUploadFile { get; set; }

//        private bool _ServiceLocationId;
//        public bool ServiceLocationId
//        {
//            get { return _ServiceLocationId; }
//            set
//            {

//                _ServiceLocationId = value;
//                OnPropertyChanged("ServiceLocationId");
//            }
//        }
//        private string _InvoiceFile;
//        public string InvoiceFile
//        {
//            get { return _InvoiceFile; }
//            set
//            {

//                _InvoiceFile = value;
//                OnPropertyChanged("InvoiceFile");
//            }
//        }
//        private bool _HomeDesc;
//        public bool HomeDesc
//        {
//            get { return _HomeDesc; }
//            set
//            {

//                _HomeDesc = value;
//                OnPropertyChanged("HomeDesc");
//            }
//        }
//        private DateTime _MaxDate;
//        public DateTime MaxDate
//        {
//            get { return _MaxDate; }
//            set
//            {

//                _MaxDate = value;
//                OnPropertyChanged("MaxDate");
//            }
//        }
//        private DateTime _MinDate;
//        public DateTime MinDate
//        {
//            get { return _MinDate; }
//            set
//            {

//                _MinDate = value;
//                OnPropertyChanged("MinDate");
//            }
//        }
//        private AddressResponse _SelectedAddress;
//        public AddressResponse SelectedAddress
//        {
//            get { return _SelectedAddress; }
//            set
//            {
//                _SelectedAddress = value;
//                OnPropertyChanged("SelectedAddress");
//            }
//        }
//        private DropDownModel _SelectedWarrantyType;
//        public DropDownModel SelectedWarrantyType
//        {
//            get { return _SelectedWarrantyType; }
//            set
//            {
//                _SelectedWarrantyType = value;
//                OnPropertyChanged("SelectedWarrantyType");
//            }
//        }
//        private ObservableCollection<DropDownModel> _WarrantyCustomerProducts;
//        public ObservableCollection<DropDownModel> WarrantyCustomerProducts
//        {
//            get { return _WarrantyCustomerProducts; }
//            set
//            {
//                _WarrantyCustomerProducts = value;
//                OnPropertyChanged("WarrantyCustomerProducts");
//            }
//        }
//        //WarrantyCustomerProduct
//        private ObservableCollection<DropDownModel> _ServiceRequestTyps;
//        public ObservableCollection<DropDownModel> ServiceRequestTyps
//        {
//            get { return _ServiceRequestTyps; }
//            set
//            {
//                _ServiceRequestTyps = value;
//                OnPropertyChanged("ServiceRequestTyps");
//            }
//        }
//        private DropDownModel _ServiceRequestType;
//        public DropDownModel ServiceRequestType
//        {
//            get { return _ServiceRequestType; }
//            set
//            {
//                _ServiceRequestType = value;
//                OnPropertyChanged("ServiceRequestType");
//            }
//        }
//        private ObservableCollection<DropDownModel> _ServiceRequestLocationTyps;
//        public ObservableCollection<DropDownModel> ServiceRequestLocationTyps
//        {
//            get { return _ServiceRequestLocationTyps; }
//            set
//            {
//                _ServiceRequestLocationTyps = value;
//                OnPropertyChanged("ServiceRequestLocationTyps");
//            }
//        }
//        private DropDownModel _ServiceRequestLocationType;
//        public DropDownModel ServiceRequestLocationType
//        {
//            get { return _ServiceRequestLocationType; }
//            set
//            {
//                _ServiceRequestLocationType = value;
//                OnPropertyChanged("ServiceRequestLocationType");
//            }
//        }
//        private ServiceRequest _ServiceRequest;
//        public ServiceRequest ServiceRequest
//        {
//            get { return _ServiceRequest; }
//            set
//            {
//                _ServiceRequest = value;
//                OnPropertyChanged("ServiceRequest");
//            }
//        }
//        private DateTime _SDDate;
//        public DateTime SDDate
//        {
//            get { return _SDDate; }
//            set
//            {
//                _SDDate = value;
//                OnPropertyChanged("SDDate");
//            }
//        }
//        private TimeSpan _SDTimeSpan;
//        public TimeSpan SDTimeSpan
//        {
//            get { return _SDTimeSpan; }
//            set
//            {
//                _SDTimeSpan = value;
//                OnPropertyChanged("SDTimeSpan");
//            }
//        }
//        private string _ProductName;
//        public string ProductName
//        {
//            get { return _ProductName; }
//            set
//            {
//                _ProductName = value;
//                OnPropertyChanged("ProductName");
//            }
//        }
//        private string _ServiceCenterName;
//        public string ServiceCenterName
//        {
//            get { return _ServiceCenterName; }
//            set
//            {
//                _ServiceCenterName = value;
//                OnPropertyChanged("ServiceCenterName");
//            }
//        }
//        //ServiceCenterName
//        private ObservableCollection<DropDownModel> _ScheduleDateTimes;
//        public ObservableCollection<DropDownModel> ScheduleDateTimes
//        {
//            get { return _ScheduleDateTimes; }
//            set
//            {
//                _ScheduleDateTimes = value;
//                OnPropertyChanged("ScheduleDateTimes");
//            }
//        }
//        private DropDownModel _SelectedScheduleDateTimes;
//        public DropDownModel SelectedScheduleDateTimes
//        {
//            get { return _SelectedScheduleDateTimes; }
//            set
//            {
//                _SelectedScheduleDateTimes = value;
//                OnPropertyChanged("SelectedScheduleDateTimes");
//            }
//        }
//        #endregion
//    }
//}

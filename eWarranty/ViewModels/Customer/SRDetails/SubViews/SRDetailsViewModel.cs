    using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Customer.CommonPages;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.SRDetails.SubViews
{
    public class SRDetailsViewModel : BaseViewModel
    {
        public SRDetailsViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;

            Device.BeginInvokeOnMainThread(async () => {
                await BindingData();
                IsBusy = false;
            });
        }

        //callicon command
        public Command CallServiceCentorCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        //if(serviceRequest?.ServiceCenter?.ContactNumber1 !=null && serviceRequest?.ServiceCenter?.ContactNumber1 != string.Empty && serviceRequest?.ServiceCenter?.ContactNumber1 != "")
                        //{
                        //    Extensions.PlacePhoneCall(serviceRequest?.ServiceCenter?.ContactNumber1);
                        //}
                        //else if (serviceRequest?.ServiceCenter?.ContactNumber2 != null && serviceRequest?.ServiceCenter?.ContactNumber2 != string.Empty && serviceRequest?.ServiceCenter?.ContactNumber2 != "")
                        //{
                        //    Extensions.PlacePhoneCall(serviceRequest?.ServiceCenter?.ContactNumber2);
                        //}
                        //else
                        //{
                        //    await ErrorDisplayAlert(AppResources.ErrorMsgMobilenumberisnotavailable);
                        //}

                        if (serviceRequest?.ContactNumber1 != null && serviceRequest?.ContactNumber1 != string.Empty && serviceRequest?.ContactNumber1 != "")
                        {
                            Extensions.PlacePhoneCall(serviceRequest?.ContactNumber1);
                        }
                        else if (serviceRequest?.ContactNumber2 != null && serviceRequest?.ContactNumber2 != string.Empty && serviceRequest?.ContactNumber2 != "")
                        {
                            Extensions.PlacePhoneCall(serviceRequest?.ContactNumber2);
                        }
                        else
                        {
                            await ErrorDisplayAlert(AppResources.ErrorMsgMobilenumberisnotavailable);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                });
            }
        }

        public async Task BindingData()
        {
            try
            {
                ServiceRequestSL serviceRequestSL = new ServiceRequestSL();
                //serviceRequest = new ServiceRequestDetailsResponse();
                //if (CommonAttribute.EditServiceRequest == null)
                //{
                //serviceRequest = await serviceRequestSL.GetServiceRequestImprovedAllDetails(CommonAttribute.CustomerSRidSelected);
                serviceRequest = await serviceRequestSL.GetServiceRequestImprovedAllDetailsNew(CommonAttribute.CustomerSRidSelected);
                if (serviceRequest != null)
                {
                    CommonAttribute.EditServiceRequest = serviceRequest;
                    // }
                    // serviceRequest = CommonAttribute.EditServiceRequest;
                    CustRemarks = serviceRequest.CustomerRemark;
                    if (serviceRequest.ServiceLocationTypeId == Convert.ToInt16(ServiceLocationTypeEnum.ServiceCenterRepair))
                        HomeServices = false;
                    else
                        HomeServices = true;

                    // CustomerSrpreferredDateTime

                    //StatusName = serviceRequest.CustServiceRequestStatusName;
                    //ProductModel = serviceRequest.ProductModel;

                    StatusName = serviceRequest.CustServiceRequestStatusName;
                    //ProductModel = serviceRequest.ProductModel;

                    CommonAttribute.SelectedProductModelId = serviceRequest.ProductModelId;
                    AddressesSL addressesSL = new AddressesSL();
                    List<AddressResponse> resAddress = await addressesSL.GetCustomerAddresses(CommonAttribute.CustomeProfile.PersonId);

                    SelectedAddres = resAddress.Where(a => a.AddressId == serviceRequest.ServiceRequestAddressId).FirstOrDefault();
                    SelectedScheduleDateTimes = new DropDownModel();
                    SelectedScheduleDateTimes.Id = 1;
                    SelectedScheduleDateTimes.Title = Convert.ToDateTime(serviceRequest.CustomerSrpreferredDateTime).ToString("dd/MM/yyyy:hh:mm");
                    CustomerSrpreferredDateTime = Convert.ToDateTime(serviceRequest.CustomerSrpreferredDateTime);
                    //Convert.ToDateTime(serviceRequest.CustomerSrpreferredDateTime);
                    if (ScheduleDateTimes == null)
                        ScheduleDateTimes = new ObservableCollection<DropDownModel>();

                    ScheduleDateTimes.Add(SelectedScheduleDateTimes);

                    SDDate = serviceRequest.CustomerSrpreferredDateTime;
                    var DateTimeStamp = serviceRequest.CustomerSrpreferredDateTime;
                    SDTimeSpan = new TimeSpan(DateTimeStamp.Hour, DateTimeStamp.Minute, 0);
                    if (SelectedAddres != null)
                    {
                        if (!string.IsNullOrEmpty(SelectedAddres.ApartmentNumber))
                            ClientAddress = SelectedAddres.ApartmentNumber;
                        if (SelectedAddres.FloorNumber != null)
                            ClientAddress = ClientAddress + ", " + SelectedAddres.FloorNumber.ToString();
                        if (!string.IsNullOrEmpty(SelectedAddres.Area))
                            ClientAddress = ClientAddress + ", " + SelectedAddres.Area;
                        if (!string.IsNullOrEmpty(SelectedAddres.BuildingName))
                            ClientAddress = ClientAddress + ", " + SelectedAddres.BuildingName;
                        if (!string.IsNullOrEmpty(SelectedAddres.City))
                            ClientAddress = ClientAddress + ", " + SelectedAddres.City;
                        if (!string.IsNullOrEmpty(SelectedAddres.CountryName))
                            ClientAddress = ClientAddress + ", " + SelectedAddres.CountryName;
                        if (SelectedAddres.PostalCode != null)
                            ClientAddress = ClientAddress + ", " + SelectedAddres.PostalCode.ToString();
                    }
                    // ClientAddress
                    //for (int i = 1; i < 4; i++)
                    //{


                    //    TimeSpan startTime = new TimeSpan(9, 0, 0);
                    //    TimeSpan endTime = new TimeSpan(18, 0, 0);
                    //    if (serviceRequest.ServiceCenter?.WorkingHoursStart != null)
                    //        startTime = TimeSpan.Parse(serviceRequest.ServiceCenter.WorkingHoursStart.ToString());
                    //    if (serviceRequest.ServiceCenter?.WorkingHoursEnd != null)
                    //        endTime = TimeSpan.Parse(serviceRequest.ServiceCenter.WorkingHoursEnd.ToString());

                    //    while (startTime <= endTime)
                    //    {
                    //        var additem = DateTime.Now.AddDays(i).Add(startTime);
                    //        ScheduleDateTimes.Add(new DropDownModel() { Id = i+ startTime.Hours, Title = additem.ToString("dd/MM/yyyy:hh:mm") });

                    //        startTime = startTime.Add(new TimeSpan(1, 0, 0));
                    //    }
                    //}

                    if (ProductStatus == null)
                        ProductStatus = new List<DropDownModel>();

                    ProductStatus.Add(new DropDownModel() { Id = 1, Title = AppResources.lblNotWorking });
                    ProductStatus.Add(new DropDownModel() { Id = 2, Title = AppResources.lblPartiallyworking });
                    ProductStatus.Add(new DropDownModel() { Id = 3, Title = AppResources.lblWorkingbutotherissues });

                    if (serviceRequest.ServiceRequestFiles != null && serviceRequest?.ServiceRequestFiles?.Count > 0)
                    {
                        if (ServiceRequestFiles == null)
                            ServiceRequestFiles = new ObservableCollection<ServiceRequestFileResponse>();

                        var image = serviceRequest.ServiceRequestFiles.ToList()[0];

                        SRProductImage = new Uri(CommonAttribute.ImageBaseUrl + image.FileInfo?.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
           

            
        }

        //directionCommand
        public Command directionCommand
        {
            get
            {
                return new Command(async () =>
                {
                    //if (serviceRequest?.ServiceCenter?.Longitude != null && serviceRequest?.ServiceCenter.Longitude != null)
                    //{
                    //    var location = new Xamarin.Essentials.Location(Convert.ToDouble(serviceRequest.ServiceCenter.Latitude), Convert.ToDouble(serviceRequest.ServiceCenter.Longitude));
                    //    var placemark = new Placemark
                    //    {                           
                    //        AdminArea = serviceRequest.ServiceCenter.StreetAddress,
                    //        Thoroughfare = serviceRequest.ServiceCenter.CityName,
                    //        Locality = serviceRequest.ServiceCenter.Landmark,

                    //    };
                    //    //var options = new MapLaunchOptions { Name = "Microsoft Building 25" };
                    //    var options = new MapLaunchOptions { Name = serviceRequest.ServiceCenter.Name };

                    //    await Xamarin.Essentials.Map.OpenAsync(location, options);
                    //}
                    try
                    {
                        if (serviceRequest?.Longitude != null && serviceRequest?.Longitude != null)
                        {
                            var location = new Xamarin.Essentials.Location(Convert.ToDouble(serviceRequest.Latitude), Convert.ToDouble(serviceRequest.Longitude));
                            var placemark = new Placemark
                            {
                                AdminArea = serviceRequest.StreetAddress,
                                Thoroughfare = serviceRequest.CityName,
                                Locality = serviceRequest.Landmark,

                            };
                            //var options = new MapLaunchOptions { Name = "Microsoft Building 25" };
                            var options = new MapLaunchOptions { Name = serviceRequest.Name };

                            await Xamarin.Essentials.Map.OpenAsync(location, options);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    

                });
            }
        }
        public Command SelectAddressCommand
        {
            get
            {
                return new Command(() =>
                {
                    MessagingCenter.Unsubscribe<AddressesPage, AddressResponse>(this, "Address");
                    MessagingCenter.Subscribe<AddressesPage, AddressResponse>(this, "Address", (sender, arg) =>
                    {
                        SelectedAddres = arg;
                    });
                    Navigation.PushAsync(new AddressesPage());
                });
            }
        }
        public Command SaveCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (CommonAttribute.EditServiceRequest.StatusId != Convert.ToInt16(ServiceRequestStatusEnum.JobClosed))
                        {
                            //if (SDDate == default)
                            //{
                            //    await ErrorDisplayAlert(AppResources.lblPleaseselectdate);
                            //    return;
                            //}
                            //if (SDTimeSpan != null)
                            //{
                            //    await ErrorDisplayAlert(AppResources.lblPleaseselecttime);
                            //    return;
                            //}

                            TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
                            ServiceRequestUpdateforTech serviceRequestUpdateforTech = new ServiceRequestUpdateforTech();
                            serviceRequestUpdateforTech.ServiceRequestId = Convert.ToInt32(serviceRequest.ServiceRequestId);
                            serviceRequestUpdateforTech.CustomerPersonId = serviceRequest.CustomerPersonId;
                            serviceRequestUpdateforTech.StartDateTime = serviceRequest.StartDateTime;
                            serviceRequestUpdateforTech.EndDateTime = serviceRequest.EndDateTime;
                            serviceRequestUpdateforTech.CreationDate = serviceRequest.CreationDate;
                            serviceRequestUpdateforTech.PromoCodeId = serviceRequest.PromoCodeId;
                            serviceRequestUpdateforTech.CustomerRemark = serviceRequest.CustomerRemark;
                            serviceRequestUpdateforTech.TypeId = serviceRequest.TypeId;
                            serviceRequestUpdateforTech.StatusId = serviceRequest.StatusId;
                            serviceRequestUpdateforTech.ServiceRequestAddressId = serviceRequest.ServiceRequestAddressId;
                            serviceRequestUpdateforTech.ProductModelId = Convert.ToInt32(serviceRequest.ProductModelId);
                            serviceRequestUpdateforTech.ProductWarrantyTypeId = Convert.ToInt32(serviceRequest.ProductWarrantyTypeId);
                            serviceRequestUpdateforTech.ProductWarrantyStatusId = Convert.ToInt32(serviceRequest.ProductWarrantyStatusId);
                            serviceRequestUpdateforTech.PriorityId = Convert.ToInt32(serviceRequest.PriorityId);
                            serviceRequestUpdateforTech.TechnicianComments = serviceRequest.TechnicianComments;
                            serviceRequestUpdateforTech.SupervisorRemark = serviceRequest.SupervisorRemark;
                            serviceRequestUpdateforTech.VisitAddressLandmark = serviceRequest.VisitAddressLandmark;

                            //string time = SDTimeSpan.ToString("hh:mm:tt");
                            DateTime dateVal = SDDate.Date.AddHours(SDTimeSpan.Hours); //DateTime.ParseExact(SelectedScheduleDateTimes.Title, "dd/MM/yyyy HH:mm", culture);
                            dateVal.AddMinutes(SDTimeSpan.Minutes);
                            serviceRequestUpdateforTech.CustomerSrpreferredDateTime = dateVal;
                            // IFormatProvider culture = new CultureInfo("en-US", true);
                            //if (SelectedScheduleDateTimes != null && !string.IsNullOrEmpty(SelectedScheduleDateTimes.Title))
                            //{
                            //    DateTime dateVal = DateTime.ParseExact(SelectedScheduleDateTimes.Title, "dd/MM/yyyy HH:mm", culture);
                            //    serviceRequestUpdateforTech.CustomerSrpreferredDateTime = dateVal;
                            //}
                            //else
                            //{
                            //    serviceRequestUpdateforTech.CustomerSrpreferredDateTime = Convert.ToDateTime(SelectedScheduleDateTimes.Title);

                            //}

                            serviceRequestUpdateforTech.EstimatedWorkDurationHours = Convert.ToDecimal(serviceRequest.EstimatedWorkDurationHours);
                            serviceRequestUpdateforTech.PriorityId = Convert.ToInt16(serviceRequest.PriorityId);

                            serviceRequestUpdateforTech.ProductWarrantyStatusId = Convert.ToInt16(serviceRequest.ProductWarrantyStatusId);
                            serviceRequestUpdateforTech.ProductWarrantyTypeId = Convert.ToInt16(serviceRequest.ProductWarrantyTypeId);
                            //  serviceRequestUpdateforTech.PromoCodeId = Convert.ToInt16(serviceRequest.PromoCodeId);
                            serviceRequestUpdateforTech.ServiceCenterId = Convert.ToInt16(serviceRequest.ServiceCenterId);
                            serviceRequestUpdateforTech.ServiceLocationTypeId = Convert.ToInt32(serviceRequest.ServiceLocationTypeId);
                            serviceRequestUpdateforTech.ServiceRequestAddressId = Convert.ToInt16(serviceRequest.ServiceRequestAddressId);
                            serviceRequestUpdateforTech.ServiceRequestId = Convert.ToInt16(serviceRequest.ServiceRequestId);
                            serviceRequestUpdateforTech.ServiceRequestName = serviceRequest.ServiceRequestName;
                            serviceRequestUpdateforTech.ServiceRequestNumber = serviceRequest.ServiceRequestNumber;

                            serviceRequestUpdateforTech.CustomerPersonId = Convert.ToInt32(serviceRequest.TechnicianPersonId);

                            serviceRequestUpdateforTech.CustomerPersonId = Convert.ToInt64(CommonAttribute.CustomeProfile.PersonId);
                            serviceRequestUpdateforTech.ActionedByPersonRoleId = Convert.ToInt16(eWarranty.Core.Enums.PersonRoleEnum.Customer);
                            serviceRequestUpdateforTech.ActionedByPersonId = Convert.ToInt16(CommonAttribute.CustomeProfile.PersonId);

                            //  serviceRequestUpdateforTech.CustomerSrpreferredDateTime = Convert.ToDateTime(SelectedScheduleDateTimes.Title);



                            var receiveContext = await technicianManagementSL.UpdateServiceRequests(serviceRequest.ServiceRequestId, serviceRequestUpdateforTech);
                            if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                            {
                                await DisplayAlert(AppResources.lblSuccess, AppResources.lblServicerequestupdatedSuccessfully);
                                // MessagingCenter.Send<TaskDetailsViewModel>(this, "TechSRUpdate");
                                await BindingData();
                            }
                            else if (receiveContext != null)
                            {
                                await ErrorDisplayAlert(receiveContext.errorMessage);
                            }
                            else
                            {
                                await ErrorDisplayAlert(Resx.AppResources.lblErrorTitle);
                            }
                        }
                        else
                        {
                            await ErrorDisplayAlert(AppResources.lblServiceRequestClosed);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                });
            
            }
        }
        //ProductModel
        private bool _HomeServices;
        public bool HomeServices
        {
            get { return _HomeServices; }
            set
            {
                _HomeServices = value;
                OnPropertyChanged("HomeServices");
            }
        }
        private string _ClientAddress;
        public string ClientAddress
        {
            get { return _ClientAddress; }
            set
            {
                _ClientAddress = value;
                OnPropertyChanged("ClientAddress");
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
        //ServiceRequestDetailsResponse serviceRequest
        private ServiceRequestDetailsNewResponse _serviceRequest;
        public ServiceRequestDetailsNewResponse serviceRequest
        {
            get { return _serviceRequest; }
            set
            {
                _serviceRequest = value;
                OnPropertyChanged(nameof(serviceRequest));
            }
        }

        //private ServiceRequestDetailsResponse _serviceRequest;
        //public ServiceRequestDetailsResponse serviceRequest
        //{
        //    get { return _serviceRequest; }
        //    set
        //    {
        //        _serviceRequest = value;
        //        OnPropertyChanged("serviceRequest");
        //    }
        //}
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
        private AddressResponse _SelectedAddres;
        public AddressResponse SelectedAddres
        {
            get { return _SelectedAddres; }
            set
            {
                _SelectedAddres = value;
                OnPropertyChanged("SelectedAddres");
            }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        private string _StatusName;
        public string StatusName
        {
            get { return _StatusName; }
            set
            {
                _StatusName = value;
                OnPropertyChanged("StatusName");
            }
        }
        private string _CustRemarks;
        public string CustRemarks
        {
            get { return _CustRemarks; }
            set
            {
                _CustRemarks = value;
                OnPropertyChanged("CustRemarks");
            }
        }
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
        private DateTime _CustomerSrpreferredDateTime;
        public DateTime CustomerSrpreferredDateTime
        {
            get { return _CustomerSrpreferredDateTime; }
            set
            {
                _CustomerSrpreferredDateTime = value;
                OnPropertyChanged("CustomerSrpreferredDateTime");

            }
        }
        private List<DropDownModel> _ProductStatus;
        public List<DropDownModel> ProductStatus
        {
            get { return _ProductStatus; }
            set
            {
                _ProductStatus = value;
                OnPropertyChanged("ProductStatus");
            }
        }
        private DropDownModel _SelectedProductStatus;
        public DropDownModel SelectedProductStatus
        {
            get { return _SelectedProductStatus; }
            set
            {
                _SelectedProductStatus = value;
                OnPropertyChanged("SelectedProductStatus");
            }
        }

        private Uri _SRProductImage;
        public Uri SRProductImage
        {
            get { return _SRProductImage; }
            set
            {
                _SRProductImage = value;
                OnPropertyChanged("SRProductImage");
            }
        }

        private ObservableCollection<ServiceRequestFileResponse> _ServiceRequestFiles;
        public ObservableCollection<ServiceRequestFileResponse> ServiceRequestFiles
        {
            get { return _ServiceRequestFiles; }
            set
            {
                _ServiceRequestFiles = value;
                OnPropertyChanged("ProductFiles");
            }
        }

    }
}

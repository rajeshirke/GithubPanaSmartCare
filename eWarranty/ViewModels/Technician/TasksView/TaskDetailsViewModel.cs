using System;
using System.Collections.ObjectModel;
using System.Globalization;
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
using eWarranty.Views.Technician.TaskViews;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Technician.TasksView
{
    public class TaskDetailsViewModel : BaseViewModel
    {
        public TaskDetailsViewModel(INavigation navigation) : base(navigation)
        {
            //IsBusy = true;
            //Device.BeginInvokeOnMainThread( async() => {
            //  await  BindingData();
            //    IsBusy = false;
            //  });
        }
        public async Task BindingData()
        {
            try
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    IsBusy = true;

                    int NewId = Convert.ToInt16(ServiceRequestStatusEnum.New);
                    int EstimationConfirmationPendingId = Convert.ToInt16(ServiceRequestStatusEnum.EstimationConfirmationPending);
                    int RepairInprogressId = Convert.ToInt16(ServiceRequestStatusEnum.RepairInprogress);
                    int PendingForPartsId = Convert.ToInt16(ServiceRequestStatusEnum.PendingForParts);
                    int RepairCompletionId = Convert.ToInt16(ServiceRequestStatusEnum.RepairCompletion);
                    int PendingForPaymentId = Convert.ToInt16(ServiceRequestStatusEnum.PendingForPayment);
                    int JobClosedWithoutRepairId = Convert.ToInt16(ServiceRequestStatusEnum.JobClosedWithoutRepair);
                    int JobClosedId = Convert.ToInt16(ServiceRequestStatusEnum.JobClosed);
                    int PendingForConfirmation = Convert.ToInt16(ServiceRequestStatusEnum.PendingforRequestConfirmation);
                    int Confirmed = Convert.ToInt16(ServiceRequestStatusEnum.EstimationConfirmed);

                    //only these should be there as per new requirement
                    if (JobStatusList != null && JobStatusList.Count > 0)
                    {
                        JobStatusList.Clear();
                    }
                    JobStatusList = new ObservableCollection<DropDownModel>();
                    JobStatusList.Add(new DropDownModel() { Id = JobClosedId, Title = "Job Closed" });
                    JobStatusList.Add(new DropDownModel() { Id = PendingForConfirmation, Title = "In Progress" });
                    JobStatusList.Add(new DropDownModel() { Id = Confirmed, Title = "Estimation Confirmed" });

                    JobStatusList.OrderBy(j => j.Title);
                    TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
                    serviceRequest = await technicianManagementSL.GetServiceRequestImprovedAllDetails(CommonAttribute.SelectedServiceRequest.ServiceRequestId);
                    // serviceRequest = await technicianManagementSL.GetTechnicianServiceRequestDetails(CommonAttribute.SelectedServiceRequest.ServiceRequestId);

                    if (serviceRequest != null)
                    {
                        //if (serviceRequest.ProductModel.ActiveWarrantyCustomerProduct.WarrantyTypeId == 0)
                        //    Estimate = "Estimate";
                        //else
                        //    Estimate = "";
                        
                        if (serviceRequest.StatusId == Convert.ToInt16(ServiceRequestStatusEnum.JobClosed))
                        {
                            IsVisibleUpdate = false;
                            Estimate = "";
                        }
                        else
                        {
                            IsVisibleUpdate = true;
                            Estimate = "Estimate";
                        }

                        WarrantyStatus = serviceRequest.ProductModel.ActiveWarrantyCustomerProduct.WarrantyTypeName;
                        if (serviceRequest.ServiceRequestAddress != null)
                        {
                            if (!string.IsNullOrEmpty(serviceRequest.ServiceRequestAddress.ApartmentNumber))
                                RequestAddress = serviceRequest.ServiceRequestAddress.ApartmentNumber;
                            if (serviceRequest.ServiceRequestAddress.FloorNumber != null)
                                RequestAddress = ", " + serviceRequest.ServiceRequestAddress.FloorNumber;
                            if (!string.IsNullOrEmpty(serviceRequest.ServiceRequestAddress.Street))
                                RequestAddress = ", " + serviceRequest.ServiceRequestAddress.Street;
                            if (!string.IsNullOrEmpty(serviceRequest.ServiceRequestAddress.BuildingName))
                                RequestAddress = ", " + serviceRequest.ServiceRequestAddress.BuildingName;
                            if (!string.IsNullOrEmpty(serviceRequest.ServiceRequestAddress.Area))
                                RequestAddress = ", " + serviceRequest.ServiceRequestAddress.Area;
                            if (!string.IsNullOrEmpty(serviceRequest.ServiceRequestAddress.City))
                                RequestAddress = ", " + serviceRequest.ServiceRequestAddress.City;
                            if (!string.IsNullOrEmpty(serviceRequest.ServiceRequestAddress.CountryName))
                                RequestAddress = ", " + serviceRequest.ServiceRequestAddress.CountryName;
                        }


                        IsCheckStandbysetrequest = serviceRequest.IsStandBySetRequestOpen;
                        //if (serviceRequest.IsServiceChargeable == null)
                        //    IsChargeableJob = false;
                        //else
                        //    IsChargeableJob = (bool)serviceRequest.IsServiceChargeable;

                        //if (IsCheckStandbysetrequest == true)
                        //    IsSendRequest = true;
                        //else
                        //    IsSendRequest = false;

                        CommonAttribute.TechEditServiceRequest = serviceRequest;
                        SelectedTaskStatus = JobStatusList.Where(u => u.Id == serviceRequest.StatusId).FirstOrDefault();
                        SelectedJobStatus= JobStatusList.Where(u => u.Id == serviceRequest.StatusId).FirstOrDefault();
                        //  ServiceLocationId = serviceRequest.ServiceLocationTypeId;
                        estimatedWorkDurationHours = Convert.ToDecimal(serviceRequest.EstimatedWorkDurationHours);
                        SDDate = Convert.ToDateTime(serviceRequest.CustomerSrpreferredDateTime);
                        SDTimeSpan = new TimeSpan(SDDate.Hour, SDDate.Minute, 0);
                        //if (ServiceLocations == null)
                        //    ServiceLocations = new ObservableCollection<DropDownModel>();



                        if (ServiceLocations != null && ServiceLocations.Count > 0)
                        {
                            ServiceLocations.Clear();
                        }

                        var LocationsList = new ObservableCollection<DropDownModel>();
                        ServiceLocations = LocationsList;

                        DropDownModel homeDropDown = new DropDownModel();
                        DropDownModel scDropDown = new DropDownModel();

                        homeDropDown = new DropDownModel() { Id = 1, Title = "Home" };
                        scDropDown = new DropDownModel() { Id = 2, Title = "Service Center" };

                        ServiceLocations.Add(homeDropDown);
                        ServiceLocations.Add(scDropDown);

                        if (serviceRequest.ServiceLocationTypeId == 1)
                        {
                            SelectedServiceLocation = homeDropDown;
                            HomeColor = Color.White;
                            SCColor = Color.WhiteSmoke;
                            ServiceLocationId = 1;                            
                        }
                        else
                        {
                            SelectedServiceLocation = scDropDown;
                            HomeColor = Color.WhiteSmoke;
                            SCColor = Color.White;
                            ServiceLocationId = 2;
                            
                        }

                        SelectedScheduleDateTimes = new DropDownModel();
                        SelectedScheduleDateTimes.Id = 0;
                        SelectedScheduleDateTimes.Title = Convert.ToDateTime(serviceRequest.CustomerSrpreferredDateTime).ToString("dd/MM/yyyy:hh:mm");

                        //Convert.ToDateTime(serviceRequest.CustomerSrpreferredDateTime);
                        if (ScheduleDateTimes == null)
                            ScheduleDateTimes = new ObservableCollection<DropDownModel>();

                        PriorityTypes = new ObservableCollection<DropDownModel>();
                        if (PriorityTypes == null)
                            PriorityTypes = new ObservableCollection<DropDownModel>();
                        SelectedPriorityType = new DropDownModel() { Id = Convert.ToInt32(ServiceRequestPriorityEnum.High), Title = "High" };
                        PriorityTypes.Add(SelectedPriorityType);
                        PriorityTypes.Add(new DropDownModel() { Id = Convert.ToInt32(ServiceRequestPriorityEnum.Moderate), Title = "Moderate" });

                        if(serviceRequest.PriorityId != null)
                        {
                            if (serviceRequest.PriorityId == Convert.ToInt32(ServiceRequestPriorityEnum.High))
                            {
                                SelectedPriorityType = PriorityTypes.Where(p => p.Id == serviceRequest.PriorityId).FirstOrDefault();
                            }
                            else
                            {
                                SelectedPriorityType = PriorityTypes.Where(p => p.Id == serviceRequest.PriorityId).FirstOrDefault();
                            }
                        }
                        

                        if (serviceRequest.ProductModel.ProductFiles.Count > 0)
                        {

                            var Item1 = serviceRequest.ProductModel.ProductFiles.ToList()[0];
                            if (Item1.FileInfo?.FileTypeId == Convert.ToInt16(FileTypeEnum.ProductImage))
                            {
                                ProductImagePath1 = new Uri(CommonAttribute.ImageBaseUrl + Item1.FileInfo?.FileName);
                            }
                            else if (Item1.FileInfo?.FileTypeId == Convert.ToInt16(FileTypeEnum.ProductInvoice))
                            {
                                InvoiceImagePath1 = new Uri(CommonAttribute.ImageBaseUrl + Item1.FileInfo?.FileName);
                            }

                            if (serviceRequest.ProductModel.ProductFiles.Count > 1)
                            {
                                var Item2 = serviceRequest.ProductModel.ProductFiles.ToList()[1];
                                if (Item2.FileInfo?.FileTypeId == Convert.ToInt16(FileTypeEnum.ProductImage))
                                {
                                    ProductImagePath1 = new Uri(CommonAttribute.ImageBaseUrl + Item2.FileInfo?.FileName);
                                }
                                else if (Item2.FileInfo?.FileTypeId == Convert.ToInt16(FileTypeEnum.ProductInvoice))
                                {
                                    InvoiceImagePath1 = new Uri(CommonAttribute.ImageBaseUrl + Item2.FileInfo?.FileName);
                                }
                            }

                        }

                        HomeColor = Color.White;
                        SCColor = Color.WhiteSmoke;
                        IsBusy = false;

                        if (serviceRequest.CustomerPerson?.MobileNumber != null)
                            MobileNumber = serviceRequest.CustomerPerson?.MobileNumber;
                        else if (serviceRequest.CustomerPerson?.AlternateMobileNumber != null)
                            MobileNumber = serviceRequest.CustomerPerson?.AlternateMobileNumber;
                    }
                    IsBusy = false;
                });
               

            }
            catch(Exception ex)
            {
                IsBusy = false;
            }
            finally
            {
                IsBusy = false;
            }
        
        }

        public Command StandbysetRequestCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (IsCheckStandbysetrequest == true)
                    {
                        TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();

                        StandBySetRequestRequest standBySetRequestRequest = new StandBySetRequestRequest();
                        standBySetRequestRequest.ModelNumber = serviceRequest.ProductModel.ModelNumber;
                        standBySetRequestRequest.SerialNumber = serviceRequest.ProductModel.SerialNumber;
                        standBySetRequestRequest.ProductModelId = serviceRequest.ProductModelId;
                        standBySetRequestRequest.CreationDate = DateTime.Now;
                        standBySetRequestRequest.ServiceRequestId = serviceRequest.ServiceRequestId;
                        standBySetRequestRequest.CustomerId = serviceRequest.CustomerPersonId;
                        standBySetRequestRequest.StatusId = 1;
                        standBySetRequestRequest.ServiceCenterId = serviceRequest.ServiceCenterId;
                        standBySetRequestRequest.StandBySetAssignedByPersonId = CommonAttribute.CustomeProfile?.PersonId;

                        //standBySetRequestRequest.ServiceCenterId = CommonAttribute.CustomeProfile.PersonServiceCenters.FirstOrDefault().ServiceCenterId;

                        var receiveContext = await technicianManagementSL.CreateStandBySetRequest(standBySetRequestRequest);
                        if (receiveContext?.Status == Convert.ToInt16(APIResponseEnum.Success))
                        {

                            await DisplayAlert("Success", receiveContext.Message);

                        }
                        else if (receiveContext != null)
                        {
                            await ErrorDisplayAlert(receiveContext.ErrorMessage);
                        }
                        else
                        {
                            await ErrorDisplayAlert(Resx.AppResources.lblErrorTitle);
                        }
                    }
                    else
                    {
                        await ErrorDisplayAlert("Please select service request checkbox.");
                    }

                });

            }
        }
        #region event
        //Cust Call
        public Command CustCallCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (serviceRequest.CustomerPerson?.MobileNumber != null && serviceRequest.CustomerPerson?.MobileNumber != string.Empty && serviceRequest.CustomerPerson?.MobileNumber != "") //string.Empty added
                        {
                            Extensions.PlacePhoneCall(serviceRequest.CustomerPerson?.MobileNumber);
                        }
                        else if (serviceRequest.CustomerPerson?.AlternateMobileNumber != null && serviceRequest.CustomerPerson?.AlternateMobileNumber != string.Empty && serviceRequest.CustomerPerson?.AlternateMobileNumber != "")
                        {
                            Extensions.PlacePhoneCall(serviceRequest.CustomerPerson?.AlternateMobileNumber);
                        }
                        else
                        {
                            await ErrorDisplayAlert(AppResources.ErrorMsgMobilenumberisnotavailable);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {

                    }
                    
                });
            }
        }
        public Command CustLocationCommand
        {
            get
            {
                return new Command(() =>
                {
                    try
                    {
                        
                        LocationMapPage locationMapPage = new LocationMapPage();
                        UserCurrentLocation currentLocation = new UserCurrentLocation();
                        if (serviceRequest.ServiceRequestAddress?.Latitude != null)
                            currentLocation.Latitude = Convert.ToDouble(serviceRequest.ServiceRequestAddress?.Latitude);
                        if (serviceRequest.ServiceRequestAddress?.Longitude != null)
                            currentLocation.Longitude = Convert.ToDouble(serviceRequest.ServiceRequestAddress?.Longitude);
                        currentLocation.Locality = serviceRequest.ServiceRequestAddress?.Area;
                        if (serviceRequest.CustomerPerson?.MobileNumber != null)
                            currentLocation.MobileNumber = serviceRequest.CustomerPerson?.MobileNumber;
                        else if (serviceRequest.CustomerPerson?.AlternateMobileNumber != null)
                            currentLocation.MobileNumber = serviceRequest.CustomerPerson?.AlternateMobileNumber;

                        locationMapPage.currentLocation = currentLocation;

                        Navigation.PushAsync(locationMapPage);
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {

                    }
                    
                });
            }
        }
        public Command SelectedTaskCommand
        {
            get
            {
                return new Command<DropDownModel>((obj) =>
                {
                    if (obj != null)
                        SelectedTaskStatus = obj;
                });
            }
        }
        public Command EstimateCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (serviceRequest != null)
                        CommonAttribute.TechEditServiceRequest = serviceRequest;
                    Navigation.PushAsync(new EstimateTaskPage());
                });
            }
        }
        public Command UpdateTaskCommand
        {
            get
            {
                return new Command( () =>
                {
                    try
                    {
                        //IsBusy = true;
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            IsBusy = true;
                            await Task.Delay(TimeSpan.FromSeconds(5));
                            await ServiceReqUpdate();                            
                            IsBusy = false;
                        });
                    }
                    catch(Exception ex)
                    {

                    }
                    
                });
            }
        }
        public Command ScheduleDateTimesCommand
        {
            get
            {
                return new Command<DropDownModel>((obj) =>
                {
                    if (obj != null)
                        SelectedScheduleDateTimes = obj;
                });
            }
        }
        public Command HomeCommand
        {
            get
            {
                return new Command(() =>
                {
                    ServiceLocationId = 1;
                    HomeColor = Color.White;
                    SCColor = Color.WhiteSmoke;
                   
                });
            }
        }
        public Command SRCommand
        {
            get
            {
                return new Command(() =>
                {
                    ServiceLocationId = 2;
                    HomeColor = Color.WhiteSmoke;
                    SCColor = Color.White;
                    
                });
            }
        }

        public async Task ServiceReqUpdate()
        {
            try
            {
                IsBusy = true;
                //if (serviceRequest.TechnicianComments == null || serviceRequest.TechnicianComments == string.Empty)
                //{
                //    await DisplayAlert("Error!", "Please enter remark");
                //    return;
                //}

                TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
                ServiceRequestUpdateforTech serviceRequestUpdateforTech = new ServiceRequestUpdateforTech();
                serviceRequestUpdateforTech.CreationDate = DateTime.Now;
                serviceRequestUpdateforTech.CustomerPersonId = serviceRequest.CustomerPersonId;
                serviceRequestUpdateforTech.StartDateTime = Convert.ToDateTime(serviceRequest.StartDateTime);
                serviceRequestUpdateforTech.EndDateTime = serviceRequest.EndDateTime;
                serviceRequestUpdateforTech.CreationDate = serviceRequest.CreationDate;
                serviceRequestUpdateforTech.PromoCodeId = serviceRequest.PromoCodeId;
                serviceRequestUpdateforTech.CustomerRemark = serviceRequest.CustomerRemark;
                DateTime dateVal = SDDate.AddHours(SDTimeSpan.Hours); //DateTime.ParseExact(SelectedScheduleDateTimes.Title, "dd/MM/yyyy HH:mm", culture);
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

                serviceRequestUpdateforTech.EndDateTime = DateTime.Now;
                serviceRequestUpdateforTech.EstimatedWorkDurationHours = estimatedWorkDurationHours;
                if (SelectedPriorityType != null)
                    serviceRequestUpdateforTech.PriorityId = SelectedPriorityType.Id;
                else
                    serviceRequestUpdateforTech.PriorityId = Convert.ToInt16(serviceRequest.PriorityId);
                serviceRequestUpdateforTech.ProductModelId = Convert.ToInt16(serviceRequest.ProductModelId);
                serviceRequestUpdateforTech.ProductWarrantyStatusId = Convert.ToInt16(serviceRequest.ProductWarrantyStatusId);
                serviceRequestUpdateforTech.ProductWarrantyTypeId = Convert.ToInt16(serviceRequest.ProductWarrantyTypeId);
                //  serviceRequestUpdateforTech.PromoCodeId = Convert.ToInt16(serviceRequest.PromoCodeId);
                serviceRequestUpdateforTech.ServiceCenterId = Convert.ToInt16(serviceRequest.ServiceCenterId);
                serviceRequestUpdateforTech.ServiceLocationTypeId = SelectedServiceLocation.Id;
                serviceRequestUpdateforTech.ServiceRequestAddressId = Convert.ToInt16(serviceRequest.ServiceRequestAddressId);
                serviceRequestUpdateforTech.ServiceRequestId = Convert.ToInt16(serviceRequest.ServiceRequestId);
                serviceRequestUpdateforTech.ServiceRequestName = serviceRequest.ServiceRequestName;

                serviceRequestUpdateforTech.ServiceRequestNumber = serviceRequest.ServiceRequestNumber;

                //if (SelectedTaskStatus != null)
                //    serviceRequestUpdateforTech.StatusId = Convert.ToInt16(SelectedTaskStatus.Id);
                //else
                //    serviceRequestUpdateforTech.StatusId = serviceRequest.StatusId;

                if (SelectedJobStatus != null)
                    serviceRequestUpdateforTech.StatusId = Convert.ToInt16(SelectedJobStatus.Id);
                else
                    serviceRequestUpdateforTech.StatusId = serviceRequest.StatusId;

                serviceRequestUpdateforTech.TechnicianComments = serviceRequest.TechnicianComments;
                serviceRequestUpdateforTech.TechnicianPersonId = Convert.ToInt64(CommonAttribute.CustomeProfile.PersonId);
                serviceRequestUpdateforTech.ActionedByPersonRoleId = Convert.ToInt16(eWarranty.Core.Enums.PersonRoleEnum.Technician);
                serviceRequestUpdateforTech.ActionedByPersonId = Convert.ToInt16(CommonAttribute.CustomeProfile.PersonId);

                //  serviceRequestUpdateforTech.CustomerSrpreferredDateTime = Convert.ToDateTime(SelectedScheduleDateTimes.Title);
                serviceRequestUpdateforTech.ServiceRequestId = Convert.ToInt16(serviceRequest.ServiceRequestId);
                //serviceRequestUpdateforTech.IsServiceChargeable = IsChargeableJob;

                var receiveContext = await technicianManagementSL.UpdateServiceRequests(serviceRequest.ServiceRequestId, serviceRequestUpdateforTech);
                if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                {
                    await DisplayAlert("Success", "Your job details have been successfully updated!");
                    MessagingCenter.Send<TaskDetailsViewModel>(this, "TechSRUpdate");
                    if (SelectedJobStatus.Id == Convert.ToInt16(ServiceRequestStatusEnum.JobClosed))
                    {
                        await Navigation.PushAsync(new TaskPaymentPage());
                    }
                    else
                    {
                        await Navigation.PopAsync();
                    }

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
            catch(Exception ex)
            {
                IsBusy = false;
            }
            finally
            {
                IsBusy = false;
            }
            

        }
        //HomeCommand
        public Command PriorityTypesCommand
        {
            get
            {
                return new Command<DropDownModel>( (item) =>
                {
                    if (item != null)
                        SelectedPriorityType = item;
                });
            }
        }
        public Command ServiceLocationCommand
        {
            get
            {
                return new Command<DropDownModel>( (item) =>
                {
                    if (item != null)
                        SelectedServiceLocation = item;
                });
            }
        }
        public Command JobStatusCommand
        {
            get
            {
                return new Command<DropDownModel>( (item) =>
                {
                    if (item != null)
                        SelectedJobStatus = item;
                });
            }
        }
        #endregion

        #region Properties

        private bool _IsVisibleUpdate = true;
        public bool IsVisibleUpdate
        {
            get { return _IsVisibleUpdate; }
            set
            {
                _IsVisibleUpdate = value;
                OnPropertyChanged(nameof(IsVisibleUpdate));
            }
        }

        private string _MobileNumber;
        public string MobileNumber
        {
            get { return _MobileNumber; }
            set
            {
                _MobileNumber = value;
                OnPropertyChanged(nameof(MobileNumber));
            }
        }

        private DateTime _Date;
        public DateTime Date
        {
            get { return _Date; }
            set
            {
                _Date = value;
                OnPropertyChanged("Date");
            }
        }
        
        private bool _IsChargeableJob;
        public bool IsChargeableJob
        {
            get { return _IsChargeableJob; }
            set
            {
                _IsChargeableJob = value;
                OnPropertyChanged("IsChargeableJob");
            }
        }
        //Warranty Status
        private bool _IsCheckStandbysetrequest;
        public bool IsCheckStandbysetrequest
        {
            get { return _IsCheckStandbysetrequest; }
            set
            {
                _IsCheckStandbysetrequest = value;
                OnPropertyChanged("IsCheckStandbysetrequest");
            }
        }

        private bool _IsSendRequest;
        public bool IsSendRequest
        {
            get { return _IsSendRequest; }
            set
            {
                _IsSendRequest = value;
                OnPropertyChanged("IsSendRequest");
            }
        }

        private string _Estimate;
        public string Estimate
        {
            get { return _Estimate; }
            set
            {
                _Estimate = value;
                OnPropertyChanged("Estimate");
            }
        }

        private string _WarrantyStatus;
        public string WarrantyStatus
        {
            get { return _WarrantyStatus; }
            set
            {
                _WarrantyStatus = value;
                OnPropertyChanged("WarrantyStatus");
            }
        }
        private string _RequestAddress;
        public string RequestAddress
        {
            get { return _RequestAddress; }
            set
            {
                _RequestAddress = value;
                OnPropertyChanged("RequestAddress");
            }
        }
        private ObservableCollection<DropDownModel> _PriorityTypes;
        public ObservableCollection<DropDownModel> PriorityTypes
        {
            get { return _PriorityTypes; }
            set
            {
                _PriorityTypes = value;
                OnPropertyChanged("PriorityTypes");
            }
        }
        private DropDownModel _SelectedPriorityType;
        public DropDownModel SelectedPriorityType
        {
            get { return _SelectedPriorityType; }
            set
            {
                _SelectedPriorityType = value;
                OnPropertyChanged("SelectedPriorityType");
            }
        }
        private ObservableCollection<DropDownModel> _ServiceLocations;
        public ObservableCollection<DropDownModel> ServiceLocations
        {
            get { return _ServiceLocations; }
            set
            {
                _ServiceLocations = value;
                OnPropertyChanged(nameof(ServiceLocations));
            }
        }
        private DropDownModel _SelectedServiceLocation;
        public DropDownModel SelectedServiceLocation
        {
            get { return _SelectedServiceLocation; }
            set
            {
                _SelectedServiceLocation = value;
                OnPropertyChanged(nameof(SelectedServiceLocation));
            }
        }
        private ObservableCollection<DropDownModel> _JobStatusList;
        public ObservableCollection<DropDownModel> JobStatusList
        {
            get { return _JobStatusList; }
            set
            {
                _JobStatusList = value;
                OnPropertyChanged("JobStatusList");
            }
        }
        private DropDownModel _SelectedJobStatus;
        public DropDownModel SelectedJobStatus
        {
            get { return _SelectedJobStatus; }
            set
            {
                _SelectedJobStatus = value;
                OnPropertyChanged("SelectedJobStatus");
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
        private int _ServiceLocationId;
        public int ServiceLocationId
        {
            get { return _ServiceLocationId; }
            set
            {
                _ServiceLocationId = value;
                OnPropertyChanged("ServiceLocationId");
            }
        }
        private decimal _estimatedWorkDurationHours;
        public decimal estimatedWorkDurationHours
        {
            get { return _estimatedWorkDurationHours; }
            set
            {
                _estimatedWorkDurationHours = value;
                OnPropertyChanged("estimatedWorkDurationHours");
            }
        }
        //estimatedWorkDurationHours
        private Color _HomeColor;
        public Color HomeColor
        {
            get { return _HomeColor; }
            set
            {
                _HomeColor = value;
                OnPropertyChanged("HomeColor");
            }
        }
        private Color _SCColor;
        public Color SCColor
        {
            get { return _SCColor; }
            set
            {
                _SCColor = value;
                OnPropertyChanged("SCColor");
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
        private ServiceRequestDetailsResponse _serviceRequest;
        public ServiceRequestDetailsResponse serviceRequest
        {
            get { return _serviceRequest; }
            set
            {
                _serviceRequest = value;
                OnPropertyChanged("serviceRequest");
            }
        }
        private ObservableCollection<DropDownModel> _TaskStatusList;
        public ObservableCollection<DropDownModel> TaskStatusList
        {
            get { return _TaskStatusList; }
            set
            {
                _TaskStatusList = value;
                OnPropertyChanged("TaskStatusList");
            }
        }
        private DropDownModel _SelectedTaskStatus;
        public DropDownModel SelectedTaskStatus
        {
            get { return _SelectedTaskStatus; }
            set
            {
                _SelectedTaskStatus = value;
                OnPropertyChanged("SelectedTaskStatus");
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
        #endregion
    }
}


public class JobStatusDropDownModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Desc { get; set; }

}

public class SelectedLocationDropDownModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Desc { get; set; }

}
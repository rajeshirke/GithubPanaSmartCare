using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Views.Supervisor;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace eWarranty.ViewModels.Supervisor
{
    public class TechnicianAssignmentViewModel : BaseViewModel
    {
        public TechnicianAssignmentViewModel(INavigation navigation, ServiceRequestResponceSupervisor serviceRequestResponceSupervisor) : base(navigation)
        {
            IsBusy = true;
            ServiceRequestResponceSupervisors = new ServiceRequestResponceSupervisor();
            SelectedTimeSlot = new DropDownModel();
            Device.BeginInvokeOnMainThread(() =>
            {
                ServiceRequestResponceSupervisors = serviceRequestResponceSupervisor;
                GetTechnicianList();
                GetServiceRequestStatus();
                IsBusy = false;
            });
        }

        #region
        public Command SelectTechnicianCommand
        {
            get
            {
                return new Command<GetTechnicianWithAvailableTimeSlot>((item) =>
                {
                    SelectTech = new GetTechnicianWithAvailableTimeSlot();
                    SelectTech = item;
                });
            }
        }

        public Command AssignTechnicianCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    try
                    {
                        ServiceRequestCreateRequest serviceRequestCreateRequest = new ServiceRequestCreateRequest();
                        serviceRequestCreateRequest.ServiceRequestId = ServiceRequestResponceSupervisors.ServiceRequestId;
                        serviceRequestCreateRequest.StatusId = (int)ServiceRequestStatusEnum.Assigned;
                        serviceRequestCreateRequest.PriorityId = ServiceRequestResponceSupervisors.PriorityId;
                        serviceRequestCreateRequest.TechnicianPersonId = SelectTech.PersonId;
                        serviceRequestCreateRequest.ActionedByPersonRoleId = (int)CommonAttribute.CustomeProfile.PersonRoleId;
                        serviceRequestCreateRequest.ActionedByPersonId = (int)CommonAttribute.CustomeProfile.PersonId;
                        serviceRequestCreateRequest.SupervisorRemark = "";
                        serviceRequestCreateRequest.StartDateTime = ServiceRequestResponceSupervisors.CustomerSrpreferredDateTime;


                        TechnicianManagementSL managementSL = new TechnicianManagementSL();
                        APIResponse aPIResponse = await managementSL.SaveAssignedTechnicianJob(serviceRequestCreateRequest);
                        if (aPIResponse != null && aPIResponse.Status == Convert.ToInt16(APIResponseEnum.Success))
                        {
                            string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                            await DisplayAlert("", msg);
                            Application.Current.MainPage = new SupDashboardLeftSideMenu();
                        }
                        else
                        {
                            string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                            await DisplayAlert("", msg);
                        }

                        IsBusy = false;
                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                    
                });
            }
        }

        public Command SubmitCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    try
                    {
                        ServiceCenterUpdateRequest serviceCenterUpdateRequest = new ServiceCenterUpdateRequest();
                        ServiceRequestSL serviceRequestSL = new ServiceRequestSL();
                        if (ServiceRequestResponceSupervisors != null)
                        {
                            long ServiceRequestId = (long)(ServiceRequestResponceSupervisors?.ServiceRequestId);
                            long StatusId = (long)(SelectedServiceRequestStatus?.Id);
                            string SupervisorComment = Comment;

                            serviceCenterUpdateRequest.ServiceRequestId = (int)ServiceRequestId;
                            serviceCenterUpdateRequest.StatusId = (int)StatusId;
                            serviceCenterUpdateRequest.SupervisorComment = SupervisorComment;

                            APIResponse aPIResponse = await serviceRequestSL.UpdateServiceRequest(serviceCenterUpdateRequest);
                            if (aPIResponse != null && aPIResponse.Status == Convert.ToInt16(APIResponseEnum.Success))
                            {
                                string msg = "Service Request Status Updated Successfully!!!";
                                await DisplayAlert("", msg);
                                await PopupNavigation.Instance.PopAsync();
                                Application.Current.MainPage = new SupDashboardLeftSideMenu();
                            }
                            else
                            {
                                string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                                await DisplayAlert("", msg);
                            }

                            IsBusy = false;

                        }

                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                    finally
                    {
                        IsBusy = false;
                    }

                });
            }
        }

        public Command SelectTimeCommand
        {
            get
            {
                return new Command<DropDownModel>((item) =>
                {                   
                    SelectedTimeSlot = item;
                    if (SelectedTimeSlot != null)
                    {
                        var result = TechniciansList.Where(t => t.AvailableTime.ToString() == SelectedTimeSlot.Title).ToList();
                        Technicians = new ObservableCollection<GetTechnicianWithAvailableTimeSlot>(result);
                    }
                });
            }
        }

        #endregion

        public async void GetTechnicianList()
        {
            try
            {
                TechnicianWithLimitedDataRequest technicianWithLimitedDataRequest = new TechnicianWithLimitedDataRequest();
                AvailableTimeSlots = new ObservableCollection<DropDownModel>();

                technicianWithLimitedDataRequest.ServiceCenterId = ServiceRequestResponceSupervisors.ServiceCenterId;
                technicianWithLimitedDataRequest.PersonRoleId = 4;
                technicianWithLimitedDataRequest.ProductCategoryId = (int)ServiceRequestResponceSupervisors.ProductCategoryId;
                technicianWithLimitedDataRequest.CustomerSRPreferredDateTime = (DateTime)ServiceRequestResponceSupervisors.CustomerSrpreferredDateTime;

                TechniciansList = new List<GetTechnicianWithAvailableTimeSlot>();
                List<GetTechnicianWithAvailableTimeSlot> GetTechnicianWithAvailableTimeSlot = new List<GetTechnicianWithAvailableTimeSlot>();
                TechnicianManagementSL managementSL = new TechnicianManagementSL();
                GetTechnicianWithAvailableTimeSlot = await managementSL.GetTechnicianWithLimitedDatas(technicianWithLimitedDataRequest);
                if (GetTechnicianWithAvailableTimeSlot != null && GetTechnicianWithAvailableTimeSlot.Count > 0)
                {
                    TechniciansList = new List<GetTechnicianWithAvailableTimeSlot>(GetTechnicianWithAvailableTimeSlot);
                }

                if (TechniciansList != null && TechniciansList.Count > 0)
                {
                    int i = 1;
                    foreach (var item in TechniciansList)
                    {
                        if (AvailableTimeSlots != null && AvailableTimeSlots.Count > 0)
                        {
                            foreach (var item1 in AvailableTimeSlots.ToList())
                            {
                                if (Convert.ToDateTime(item1.Title) != item.AvailableTime)
                                {
                                    AvailableTimeSlots.Add(new DropDownModel { Id = i, Title = item.AvailableTime.ToString() });
                                }
                            }
                        }
                        else
                        {
                            AvailableTimeSlots.Add(new DropDownModel { Id = i, Title = item.AvailableTime.ToString() });
                        }
                        i++;
                    }

                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
                     
        }

        public Command ServiceRequestStatusCommand
        {
            get
            {
                return new Command<EntityKeyValueResponse>((item) =>
                {
                    var selectedItem = item;
                });
            }
        }

        public async void GetServiceRequestStatus()
        {
            try
            {
                obServiceRequestStatus = new ObservableCollection<DropDownModel>();
                ServiceRequestSL serviceRequestSL = new ServiceRequestSL();
                var result = await serviceRequestSL.GetServiceRequestStatus();
                if (result != null && result.Count > 0)
                {
                    foreach (var item in result)
                    {
                        obServiceRequestStatus.Add(new DropDownModel { Id = item.Id, Title = item.Name });
                    }
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
           
        }

        private DropDownModel _SelectedServiceRequestStatus;
        public DropDownModel SelectedServiceRequestStatus
        {
            get { return _SelectedServiceRequestStatus; }
            set
            {
                _SelectedServiceRequestStatus = value;
                OnPropertyChanged(nameof(SelectedServiceRequestStatus));
            }
        }

        private ObservableCollection<DropDownModel> _obServiceRequestStatus;
        public ObservableCollection<DropDownModel> obServiceRequestStatus
        {
            get { return _obServiceRequestStatus; }
            set
            {
                _obServiceRequestStatus = value;
                OnPropertyChanged(nameof(obServiceRequestStatus));
            }
        }

        private GetTechnicianWithAvailableTimeSlot _selectTech;
        public GetTechnicianWithAvailableTimeSlot SelectTech
        {
            get { return _selectTech; }
            set
            {
                _selectTech = value;
                OnPropertyChanged(nameof(SelectTech));
            }
        }

        private ObservableCollection<GetTechnicianWithAvailableTimeSlot> _Technicians;
        public ObservableCollection<GetTechnicianWithAvailableTimeSlot> Technicians
        {
            get { return _Technicians; }
            set
            {
                _Technicians = value;
                OnPropertyChanged(nameof(Technicians));
                OnPropertyChanged(nameof(RowHeight));
            }
        }

        private List<GetTechnicianWithAvailableTimeSlot> _TechniciansList;
        public List<GetTechnicianWithAvailableTimeSlot> TechniciansList
        {
            get { return _TechniciansList; }
            set
            {
                _TechniciansList = value;
                OnPropertyChanged(nameof(TechniciansList));              
            }
        }

        private ServiceRequestResponceSupervisor _serviceRequestResponceSupervisors;
        public ServiceRequestResponceSupervisor ServiceRequestResponceSupervisors
        {
            get { return _serviceRequestResponceSupervisors; }
            set
            {
                _serviceRequestResponceSupervisors = value;
                OnPropertyChanged(nameof(ServiceRequestResponceSupervisors));                
            }
        }

        private int _RowHeight;
        public int RowHeight
        {
            get
            {
                _RowHeight = 0;
                if (TechniciansList != null && TechniciansList.Count() > 0)
                    _RowHeight = TechniciansList.Count() * 80;
                return _RowHeight;
            }
        }


        private string _ServiceRequestStatus;
        public string ServiceRequestStatus
        {
            get
            {
                return _ServiceRequestStatus;
            }
            set
            {
                _ServiceRequestStatus = value;
                OnPropertyChanged(nameof(ServiceRequestStatus));
            }
        }

        private string _Comment;
        public string Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                _Comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        private ObservableCollection<DropDownModel> _AvailableTimeSlots;
        public ObservableCollection<DropDownModel> AvailableTimeSlots
        {
            get { return _AvailableTimeSlots; }
            set
            {
                _AvailableTimeSlots = value;
                OnPropertyChanged(nameof(AvailableTimeSlots));
            }
        }

        private ObservableCollection<DropDownModelTimeSlot> _TechAvailableTimeSlots;
        public ObservableCollection<DropDownModelTimeSlot> TechAvailableTimeSlots
        {
            get { return _TechAvailableTimeSlots; }
            set
            {
                _TechAvailableTimeSlots = value;
                OnPropertyChanged(nameof(TechAvailableTimeSlots));
            }
        }

        private DropDownModel _SelectedTimeSlot;
        public DropDownModel SelectedTimeSlot
        {
            get { return _SelectedTimeSlot; }
            set
            {
                _SelectedTimeSlot = value;
                OnPropertyChanged(nameof(SelectedTimeSlot));
            }
        }

    }
}


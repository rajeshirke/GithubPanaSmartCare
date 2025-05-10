using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Views.Customer.InquiryView;
using eWarranty.Views.Customer.Products;
using eWarranty.Views.Customer.SRDetails;
using eWarranty.Views.Supervisor;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Supervisor
{
    public class ServiceRequestsListViewModel : BaseViewModel
    {
        public ServiceRequestsListViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
           
            Device.BeginInvokeOnMainThread(async () =>
            {
                await BindingData();
            });
          
        }

        #region Method
        public async Task BindingData()
        {
            try
            {
                if (Services == null)
                    Services = new ObservableCollection<ServiceRequestResponceSupervisor>();

                await GetServiceRequest();
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            

        }
        public async Task GetServiceRequest()
        {
            ServiceRequestSL serviceRequestSL = new ServiceRequestSL();
            MasterData = await serviceRequestSL.GetServiceRequestsByServiceCenterSupervisor(CommonAttribute.CustomeProfile.PersonServiceCenters.FirstOrDefault().ServiceCenterId);
            if (MasterData != null && MasterData.Count > 0)
            {
                //Services = new ObservableCollection<ServiceRequestResponceSupervisor>(MasterData.Where(s => s.ServiceLocationTypeId == 1));
                Services = new ObservableCollection<ServiceRequestResponceSupervisor>(MasterData);
            }

        }

        public void SearchServiceRequests(string skey)
        {
            try
            {
                IsBusy = true;
                var ServiceRequestResponseList = new List<ServiceRequestResponceSupervisor>();

                if (Services != null && Services.Count > 0)
                {
                    ServiceRequestResponseList = new List<ServiceRequestResponceSupervisor>(Services);
                }

                if (!string.IsNullOrEmpty(skey))
                {
                    if (skey.Count() >= 2)
                    {
                        var FilteredList = ServiceRequestResponseList.FindAll(u => u.ServiceRequestNumber.ToLower().Contains(skey.ToLower()) ||
                                               u.CustomerPersonName.ToLower().Contains(skey.ToLower()) ||
                                               u.ServiceLocationTypeName.ToLower().Contains(skey.ToLower()) ||
                                               u.ProductModelNumber.ToLower().Contains(skey.ToLower()) ||
                                               u.ServiceRequestStatusName.ToLower().Contains(skey.ToLower()));

                        ////code by kumar
                        //var Modelnumberitems = MasterProductModels.Where(u => u.ModelNumber.ToLower().Contains(skey.ToLower())
                        //|| u.ProductClassification.ToLower().Contains(skey.ToLower()) || u.WarrantyTypeName.ToLower().Contains(skey.ToLower()));

                        //ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(Modelnumberitems);
                        Services = new ObservableCollection<ServiceRequestResponceSupervisor>(FilteredList);

                    }

                }
                else
                    Services = new ObservableCollection<ServiceRequestResponceSupervisor>(MasterData);

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }

        }


        #endregion
        #region events
        public ICommand ServiceDetailsCommand
        {
            get
            {
                return new Command<ServiceRequestResponceSupervisor>((item) =>
                {
                    Navigation.PushAsync(new ServiceRequestDetails((int)item.ServiceRequestId));
                });
            }
        }

        public ICommand AssignTechCommand
        {
            get
            {
                return new Command<ServiceRequestResponceSupervisor>((item) =>
                {
                    Navigation.PushAsync(new TechnicianAssignmentView(item));
                });
            }
        }

        public ICommand UpdateStatusCommand
        {
            get
            {
                return new Command<ServiceRequestResponceSupervisor>(async (item) =>
                {
                    await PopupNavigation.Instance.PushAsync(new ProductServiceByServiceCenterPopup(item));

                });
            }
        }

        #endregion
        #region Properties
        public List<ServiceRequestResponceSupervisor> MasterData { get; set; }
        private ObservableCollection<ServiceRequestResponceSupervisor> _Services;
        public ObservableCollection<ServiceRequestResponceSupervisor> Services
        {
            get { return _Services; }
            set
            {
                _Services = value;
                OnPropertyChanged(nameof(Services));
            }
        }

        private bool _IsVisibleAssignTechnician = false;
        public bool IsVisibleAssignTechnician
        {
            get { return _IsVisibleAssignTechnician; }
            set
            {

                _IsVisibleAssignTechnician = value;
                OnPropertyChanged(nameof(IsVisibleAssignTechnician));
            }
        }

        private bool _IsVisibleUpdateStatus = false;
        public bool IsVisibleUpdateStatus
        {
            get { return _IsVisibleUpdateStatus; }
            set
            {

                _IsVisibleUpdateStatus = value;
                OnPropertyChanged(nameof(IsVisibleUpdateStatus));
            }
        }

        #endregion
    }
}


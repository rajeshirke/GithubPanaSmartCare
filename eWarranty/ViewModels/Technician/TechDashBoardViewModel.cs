using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Views.Customer.CommonPages;
using eWarranty.Views.Technician;
using eWarranty.Views.Technician.AccessoriesView;
using eWarranty.Views.Technician.FAQViews;
using eWarranty.Views.Technician.ServiceCenterView;
using eWarranty.Views.Technician.SparePartsViews;
using eWarranty.Views.Technician.SupportViews;
using eWarranty.Views.Technician.TaskViews;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Technician
{
    public class TechDashBoardViewModel : BaseViewModel
    {
        public TechDashBoardViewModel(INavigation navigation) : base(navigation)
        {
            // IsBusy = true;
            SelectedDate = DateTime.Now;
            Device.BeginInvokeOnMainThread(async () => {
                await BindingData();
                IsBusy = false;
            });
           
        }

        public async Task BindingData()
        {
            try
            {
                IsBusy = true;

                TechnicianManagementSL managementSL = new TechnicianManagementSL();
                TechnicianSrRequest technicianSrRequest = new TechnicianSrRequest();
                technicianSrRequest.TechnicianPersonId = (int)CommonAttribute.CustomeProfile.PersonId;
                //techGetServiceRequests.serviceRequestDate = SelectedDate;
                technicianSrRequest.TechnicianMobileDashboardStatusId = (int)MobileDashboardSRStatusEnum.TodaysJobs;

                List<ServiceRequestResponce> resServiceRequest = await managementSL.GetServiceRequestsByDashboardStatus(technicianSrRequest);

                resServiceRequest = resServiceRequest.OrderBy(u => u.CustomerSrpreferredDateTime).ToList();

                Tasks = new ObservableCollection<ServiceRequestResponce>(resServiceRequest);

                TechnicianManagementSL centersManagementSL = new TechnicianManagementSL();
                TechnicianJobCounts serviceManualModels = await centersManagementSL.GetTechnicianJobsCounts(CommonAttribute.CustomeProfile.PersonId);
                if (serviceManualModels != null)
                {
                    TodaysJob = serviceManualModels.TodaysJobs;
                    PendingJobs = serviceManualModels.PendingJobs;
                    InPregressJobs = serviceManualModels.InProgressJobs;
                    FutureJobs = serviceManualModels.FutureScheduleJobs;
                    CompletedJobs = serviceManualModels.ClosedJobs;
                }

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
        }

        private int _FutureJobs;
        public int FutureJobs
        {
            get { return _FutureJobs; }
            set
            {

                _FutureJobs = value;
                OnPropertyChanged(nameof(FutureJobs));
            }
        }
        private int _InPregressJobs;
        public int InPregressJobs
        {
            get { return _InPregressJobs; }
            set
            {

                _InPregressJobs = value;
                OnPropertyChanged(nameof(InPregressJobs));
            }
        }
        private int _TodaysJob;
        public int TodaysJob
        {
            get { return _TodaysJob; }
            set
            {

                _TodaysJob = value;
                OnPropertyChanged(nameof(TodaysJob));
            }
        }
        private int _PendingJobs;
        public int PendingJobs
        {
            get { return _PendingJobs; }
            set
            {

                _PendingJobs = value;
                OnPropertyChanged(nameof(PendingJobs));
            }
        }

        private int _CompletedJobs;
        public int CompletedJobs
        {
            get { return _CompletedJobs; }
            set
            {

                _CompletedJobs = value;
                OnPropertyChanged(nameof(CompletedJobs));
            }
        }

        #region event
        public Command PerDateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    SelectedDate = SelectedDate.AddDays(-1);
                   await BindingData();
                    IsBusy = false;
                });
            }
        }
        public Command NextDateCommand
        {
            get
            {
                return new Command(async () =>
                {
                  
                    IsBusy = true;
                    SelectedDate = SelectedDate.AddDays(1);
                    await BindingData();
                    IsBusy = false;
                });
            }
        }

        public Command TodaysJobCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new TasksSchedulePage((int)MobileDashboardSRStatusEnum.TodaysJobs));
                });
            }
        }

        public Command InProgressJobsCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new TasksSchedulePage((int)MobileDashboardSRStatusEnum.InProgressJob));
                });
            }
        }

        public Command FutureJobsCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new TasksSchedulePage((int)MobileDashboardSRStatusEnum.FutureScheduleJobs));
                });
            }
        }

        public Command PendingJobsCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new TasksSchedulePage((int)MobileDashboardSRStatusEnum.PendingJobs));
                });
            }
        }

        public Command CompletedJobsCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new TasksSchedulePage((int)MobileDashboardSRStatusEnum.CompletedJobs));
                });
            }
        }

        public Command UserNotificationsCommand
        {
            get
            {
                return new Command(() =>
                {

                    Navigation.PushAsync(new UserNotificationsPage());
                });
            }
        }


        //PerDateCommand
        public Command FindServiceCenterCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new ServiceManualModelPage());
                });
            }
        }
        public Command SparePartCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new SparePartsPage(1));
                });
            }
        }
        public Command AccessoriesCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new TipsAndFAQPage());
                });
            }
        }
        public Command ServiceCenterChatCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new ServiceCenterChatPage());
                });
            }
        }
        //ServiceCenterChatPage

        //selected item from list Command
        public Command ProductsCommand
        {
            get
            {
                return new Command<ServiceRequestResponce>((obj) =>
                {
                    IsBusy = true;
                    CommonAttribute.SelectedServiceRequest = obj;
                    Navigation.PushAsync(new TaskDetailsPage());
                });
            }
        }

        public Command ServiceManualCommand
        {
            get
            {
                return new Command(async () =>
                {                     
                    await Navigation.PushAsync(new ServiceManualModelPage());
                });
            }
        }
        public Command TipsAndFAQPCommand
        {
            get
            {
                return new Command(async () =>
                {                     
                    await Navigation.PushAsync(new TipsAndFAQPage());
                });
            }
        }
        public Command MyjobsCommand
        {
            get
            {
                return new Command(async () =>
                {                     
                    await Navigation.PushAsync(new TasksSchedulePage((int)MobileDashboardSRStatusEnum.TodaysJobs));                    
                });
            }
        }

        public Command FAQCommand
        {
            get
            {
                return new Command(async () =>
                {                      
                    await Navigation.PushAsync(new SearchQuery());
                });
            }
        }

        public Command MyQueriesCommand
        {
            get
            {
                return new Command(async () =>
                {                      
                    await Navigation.PushAsync(new MyQueries());
                });
            }
        }
        public ICommand AMCRequestListCommand { get; set; }
      
        public ICommand InquiryCommand { get; set; }
        #endregion

        #region properties
        //ObservableCollection
        //private ObservableCollection<TaskModel> _Tasks;
        //public ObservableCollection<TaskModel> Tasks
        //{
        //    get { return _Tasks; }
        //    set
        //    {
        //        _Tasks = value;
        //        OnPropertyChanged("Tasks");
        //    }
        //}

        private ServiceRequestResponce _SelectedItem;
        public ServiceRequestResponce SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<ServiceRequestResponce> _Tasks;
        public ObservableCollection<ServiceRequestResponce> Tasks
        {
            get { return _Tasks; }
            set
            {
                _Tasks = value;
                OnPropertyChanged("Tasks");
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
        #endregion
    }
}

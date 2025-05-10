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
using eWarranty.Views.Technician.TaskViews;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Technician.TasksView
{
    public class TaskScheduleViewModel : BaseViewModel
    {
        public TaskScheduleViewModel(INavigation navigation,int _StatusID) : base(navigation)
        {
            IsBusy = true;
            StatusID = _StatusID;
           // DataBinding();
        }
        public async Task DataBinding()
        {
            try
            {
                DateItemCommand = new Command(() =>
                {
                    Navigation.PushAsync(new TaskDetailsPage());
                });

                if (CollectionDates == null)
                    CollectionDates = new List<string>();


                if (Tasks == null)
                    Tasks = new ObservableCollection<ServiceRequestResponce>();
                //Tasks.Add(new TaskModel() { Distance = "1.2km", SheDate = "01/01/2021", Status = true, TaskDesc = "Task desc1", TaskName = "Task Name 1" });
                //Tasks.Add(new TaskModel() { Distance = "2.0km", SheDate = "01/01/2021", Status = true, TaskDesc = "Task desc2", TaskName = "Task Name 2" });
                //Tasks.Add(new TaskModel() { Distance = "2.8m", SheDate = "01/01/2021", Status = true, TaskDesc = "Task desc3", TaskName = "Task Name 3" });
                //Tasks.Add(new TaskModel() { Distance = "3.9km", SheDate = "01/01/2021", Status = true, TaskDesc = "Task desc4", TaskName = "Task Name 4" });
                //Tasks.Add(new TaskModel() { Distance = "8.0km", SheDate = "01/01/2021", Status = true, TaskDesc = "Task desc5", TaskName = "Task Name 5" });
                //Tasks.Add(new TaskModel() { Distance = "10.7km", SheDate = "01/01/2021", Status = true, TaskDesc = "Task desc6", TaskName = "Task Name 6" });
                //Tasks.Add(new TaskModel() { Distance = "8.0km", SheDate = "01/01/2021", Status = true, TaskDesc = "Task desc5", TaskName = "Task Name 5" });
                //Tasks.Add(new TaskModel() { Distance = "10.7km", SheDate = "01/01/2021", Status = true, TaskDesc = "Task desc6", TaskName = "Task Name 6" });
                //Tasks.Add(new TaskModel() { Distance = "1.2km", SheDate = "01/01/2021", Status = true, TaskDesc = "Task desc1", TaskName = "Task Name 1" });
                //Tasks.Add(new TaskModel() { Distance = "2.0km", SheDate = "01/01/2021", Status = true, TaskDesc = "Task desc2", TaskName = "Task Name 2" });
                //Tasks.Add(new TaskModel() { Distance = "2.8m", SheDate = "01/01/2021", Status = true, TaskDesc = "Task desc3", TaskName = "Task Name 3" });
                //Tasks.Add(new TaskModel() { Distance = "3.9km", SheDate = "01/01/2021", Status = true, TaskDesc = "Task desc4", TaskName = "Task Name 4" });
                //Tasks.Add(new TaskModel() { Distance = "8.0km", SheDate = "01/01/2021", Status = true, TaskDesc = "Task desc5", TaskName = "Task Name 5" });
                //Tasks.Add(new TaskModel() { Distance = "10.7km", SheDate = "01/01/2021", Status = true, TaskDesc = "Task desc6", TaskName = "Task Name 6" });
                //Tasks.Add(new TaskModel() { Distance = "8.0km", SheDate = "01/01/2021", Status = true, TaskDesc = "Task desc5", TaskName = "Task Name 5" });
                //Tasks.Add(new TaskModel() { Distance = "10.7km", SheDate = "01/01/2021", Status = true, TaskDesc = "Task desc6", TaskName = "Task Name 6" });

                //ProductsCommand = new Command<object>((obj) =>
                //{
                //    Navigation.PushAsync(new TaskDetailsPage());
                //});
                SelectedItemCommand = new Command(() =>
                {
                    Navigation.PushAsync(new TaskDetailsPage());
                });
                //  MessagingCenter.Send<TaskDetailsViewModel>(this, "TechSRUpdate");
                MessagingCenter.Subscribe<TaskDetailsViewModel>(this, "TechSRUpdate", async (sender) =>
                {
                    IsBusy = true;
                    await FilterData(StatusID);
                    IsBusy = false;
                });
                await FilterData(StatusID);
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
           
        }
        public async Task FilterData(int statusid)
        {
            try
            {
                TasksList = new ObservableCollection<ServiceRequestResponce>();
                Tasks = new ObservableCollection<ServiceRequestResponce>();
                TechnicianManagementSL managementSL = new TechnicianManagementSL();
                //TechGetServiceRequests techGetServiceRequests = new TechGetServiceRequests();
                //techGetServiceRequests.technicianPersonId = CommonAttribute.CustomeProfile.PersonId;
                //techGetServiceRequests.serviceRequestStatusId = statusid;
                //if (statusid == 1)
                //    techGetServiceRequests.serviceRequestStatusId = Convert.ToInt16(ServiceRequestStatusEnum.Assigned);
                //else if (statusid == 2)
                //    techGetServiceRequests.serviceRequestStatusId = Convert.ToInt16(ServiceRequestStatusEnum.RepairInprogress);
                //else
                //    techGetServiceRequests.serviceRequestStatusId = null;
                //List<ServiceRequestResponce> resServiceRequest = await managementSL.GetServiceRequestsOfTechnician(techGetServiceRequests);

                TechnicianSrRequest technicianSrRequest = new TechnicianSrRequest();
                technicianSrRequest.TechnicianPersonId = (int)CommonAttribute.CustomeProfile.PersonId;
                //techGetServiceRequests.serviceRequestDate = SelectedDate;
                technicianSrRequest.TechnicianMobileDashboardStatusId = statusid;

                List<ServiceRequestResponce> resServiceRequest = await managementSL.GetServiceRequestsByDashboardStatus(technicianSrRequest);
                //resServiceRequest = resServiceRequest.OrderBy(u => u.CustomerSrpreferredDateTime).ToList();
                TasksList = new ObservableCollection<ServiceRequestResponce>(resServiceRequest);
                foreach (var item in resServiceRequest)
                {
                    var existItem = CollectionDates.Where(u => u == Convert.ToDateTime(item.CustomerSrpreferredDateTime).ToString("dd MMM-yyyy")).ToList();
                    if (existItem.Count == 0)
                        CollectionDates.Add(Convert.ToDateTime(item.CustomerSrpreferredDateTime).ToString("dd MMM-yyyy"));
                }
                Tasks = new ObservableCollection<ServiceRequestResponce>(resServiceRequest);
                //if(statusid == 1)
                // Tasks = new ObservableCollection<ServiceRequest>(resServiceRequest.Where(u=>u.StatusId == Convert.ToInt16(ServiceRequestStatusEnum.Assigned)));
                //else if (statusid == 2)
                //    Tasks = new ObservableCollection<ServiceRequest>(resServiceRequest.Where(u => u.StatusId == Convert.ToInt16(ServiceRequestStatusEnum.RepairInprogress)));
                //else if (statusid == 3)
                //    Tasks = new ObservableCollection<ServiceRequest>(resServiceRequest.Where(u => u.StatusId != Convert.ToInt16(ServiceRequestStatusEnum.Assigned)));

            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            
        }


        public void SearchJobsAssigned(string skey)
        {
            try
            {
                IsBusy = true;
                var JobsAssignedResponseList = new List<ServiceRequestResponce>();

                if (Tasks != null && Tasks.Count > 0)
                {
                    JobsAssignedResponseList = new List<ServiceRequestResponce>(Tasks);
                }

                if (!string.IsNullOrEmpty(skey))
                {
                    if (skey.Count() >= 2)
                    {
                        var FilteredList = JobsAssignedResponseList.FindAll(u => u.CustomerPersonName.ToLower().Contains(skey.ToLower()) ||
                                               u.ServiceRequestTypeName.ToLower().Contains(skey.ToLower()) || u.ServiceRequestNumber.ToLower().Contains(skey.ToLower()));

                        ////code by kumar
                        //var Modelnumberitems = MasterProductModels.Where(u => u.ModelNumber.ToLower().Contains(skey.ToLower())
                        //|| u.ProductClassification.ToLower().Contains(skey.ToLower()) || u.WarrantyTypeName.ToLower().Contains(skey.ToLower()));

                        //ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(Modelnumberitems);
                        Tasks = new ObservableCollection<ServiceRequestResponce>(FilteredList);

                    }
                    else
                    {
                        MessagingCenter.Subscribe<TaskDetailsViewModel>(this, "TechSRUpdate", async (sender) =>
                        {
                            Tasks = new ObservableCollection<ServiceRequestResponce>(TasksList);

                            IsBusy = true;
                            await FilterData(StatusID);
                            IsBusy = false;
                        });
                    }

                }
                else
                {
                    MessagingCenter.Subscribe<TaskDetailsViewModel>(this, "TechSRUpdate", async (sender) =>
                    {
                        Tasks = new ObservableCollection<ServiceRequestResponce>(TasksList);

                        IsBusy = true;
                        await FilterData(StatusID);
                        IsBusy = false;
                    });
                }


                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }

        }

        #region event
        public Command SelectedTagChangedCommand
        {
            get
            {
                return new Command<object>((obj) =>
                {
                    string st = SelectedTab;
                    Console.WriteLine("1231231");
                });
            }
        }
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

       // public ICommand ProductsCommand { get; set; }
        public ICommand SelectedItemCommand { get; set; }
        public ICommand DateItemCommand { get; set; }

        #endregion
        #region Properties
        private int _StatusID;
        public int StatusID
        {
            get { return _StatusID; }
            set
            {
                _StatusID = value;
                OnPropertyChanged("StatusID");
            }
        }

        private List<string> _CollectionDates;
        public List<string> CollectionDates
        {
            get { return _CollectionDates; }
            set
            {
                _CollectionDates = value;
                OnPropertyChanged("CollectionDates");
            }
        }
        private string _SelectedTab;
        public string SelectedTab
        {
            get { return _SelectedTab; }
            set
            {
                _SelectedTab = value;
                OnPropertyChanged("SelectedTab");
            }
        }
        private TabOption _SelectedTabOption;
        public TabOption SelectedTabOption
        {
            get { return _SelectedTabOption; }
            set
            {
                _SelectedTabOption = value;
                OnPropertyChanged("SelectedTabOption");
            }
        }
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
                OnPropertyChanged(nameof(Tasks));
            }
        }

        private ObservableCollection<ServiceRequestResponce> _TasksList;
        public ObservableCollection<ServiceRequestResponce> TasksList
        {
            get { return _TasksList; }
            set
            {
                _TasksList = value;
                OnPropertyChanged(nameof(TasksList));
            }
        }
        //collectionDates
        #endregion
    }
}

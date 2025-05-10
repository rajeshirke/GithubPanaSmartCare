using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.ViewModels.Technician.TasksView;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.TaskViews
{
    public partial class TasksSchedulePage : ContentPage
    {
        public TaskScheduleViewModel viewModel { get; set; }
        public int _StatusID { get; set; }

        public TasksSchedulePage()
        {
            InitializeComponent();            
            tabSelection((int)MobileDashboardSRStatusEnum.TodaysJobs);
            BindingContext = viewModel = new TaskScheduleViewModel(Navigation, (int)MobileDashboardSRStatusEnum.TodaysJobs);
        }
        public TasksSchedulePage(int StatusID)
        {
            InitializeComponent();
            _StatusID = StatusID;
            tabSelection(_StatusID);
            BindingContext = viewModel = new TaskScheduleViewModel(Navigation, StatusID);
        }
        protected async override void OnAppearing()
        {
           await viewModel.DataBinding();
            viewModel.IsBusy = false;
            base.OnAppearing();
        }

        void gvTab1_Tapped(System.Object sender, System.EventArgs e)
        {
            searchAssignedJob.Text = "";
            Device.BeginInvokeOnMainThread(async () =>
            {
                IsBusy = true;
                tabSelection((int)MobileDashboardSRStatusEnum.TodaysJobs);
                await viewModel.FilterData((int)MobileDashboardSRStatusEnum.TodaysJobs);
                IsBusy = false;
            });
        }

        void gvTab2_Tapped(System.Object sender, System.EventArgs e)
        {
            searchAssignedJob.Text = "";
            Device.BeginInvokeOnMainThread(async () =>
            {
                IsBusy = true;
                tabSelection((int)MobileDashboardSRStatusEnum.InProgressJob);
                await viewModel.FilterData((int)MobileDashboardSRStatusEnum.InProgressJob);
                IsBusy = false;
            });            
        }

        void gvTab3_Tapped(System.Object sender, System.EventArgs e)
        {
            searchAssignedJob.Text = "";
            Device.BeginInvokeOnMainThread(async () =>
            {
                IsBusy = true;
                tabSelection((int)MobileDashboardSRStatusEnum.FutureScheduleJobs);
                await viewModel.FilterData((int)MobileDashboardSRStatusEnum.FutureScheduleJobs);
                IsBusy = false;
            });           
        }

        void gvTab4_Tapped(System.Object sender, System.EventArgs e)
        {
            searchAssignedJob.Text = "";
            Device.BeginInvokeOnMainThread(async () =>
            {
                IsBusy = true;
                tabSelection((int)MobileDashboardSRStatusEnum.PendingJobs);
                await viewModel.FilterData((int)MobileDashboardSRStatusEnum.PendingJobs);
                IsBusy = false;
            });
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            searchAssignedJob.Text = "";
            Device.BeginInvokeOnMainThread(async () =>
            {
                IsBusy = true;
                tabSelection((int)MobileDashboardSRStatusEnum.CompletedJobs);
                await viewModel.FilterData((int)MobileDashboardSRStatusEnum.CompletedJobs);
                IsBusy = false;
            });
        }

        public void tabSelection(int val)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                tab1.BackgroundColor = Color.FromHex("#F4F6FA");
                tab2.BackgroundColor = Color.FromHex("#F4F6FA");
                tab3.BackgroundColor = Color.FromHex("#F4F6FA");
                tab4.BackgroundColor = Color.FromHex("#F4F6FA");
                tab5.BackgroundColor = Color.FromHex("#F4F6FA");


                tab1bg.BackgroundColor = Color.FromHex("#FFFFFF");
                tab2bg.BackgroundColor = Color.FromHex("#FFFFFF");
                tab3bg.BackgroundColor = Color.FromHex("#FFFFFF");
                tab4bg.BackgroundColor = Color.FromHex("#FFFFFF");
                tab5bg.BackgroundColor = Color.FromHex("#FFFFFF");

                if (val == (int)MobileDashboardSRStatusEnum.TodaysJobs)
                {
                    tab1.BackgroundColor = Color.Black;
                    tab1bg.BackgroundColor = Color.FromHex("#E5E5E5");
                }
                else if (val == (int)MobileDashboardSRStatusEnum.InProgressJob)
                {
                    tab2.BackgroundColor = Color.Black;
                    tab2bg.BackgroundColor = Color.FromHex("#E5E5E5");
                }
                else if (val == (int)MobileDashboardSRStatusEnum.FutureScheduleJobs)
                {
                    tab3.BackgroundColor = Color.Black;
                    tab3bg.BackgroundColor = Color.FromHex("#E5E5E5");
                }
                else if(val== (int)MobileDashboardSRStatusEnum.PendingJobs)
                {
                    tab4.BackgroundColor = Color.Black;
                    tab4bg.BackgroundColor = Color.FromHex("#E5E5E5");
                }
                else if (val == (int)MobileDashboardSRStatusEnum.CompletedJobs)
                {
                    tab5.BackgroundColor = Color.Black;
                    tab5bg.BackgroundColor = Color.FromHex("#E5E5E5");
                }

            });
        }

        async void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            try
            {
                string sKey = string.Empty;
                if (!string.IsNullOrEmpty(e.NewTextValue))
                {
                    sKey = e.NewTextValue.Trim();
                    viewModel.SearchJobsAssigned(sKey);
                }
                else
                {
                    await viewModel.FilterData(viewModel.StatusID);
                }
                  
            }
            catch (Exception ex)
            {

            }
        }

        
    }
}

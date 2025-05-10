using System;
using System.Collections.Generic;
using eWarranty.Core.ResponseModels;
using eWarranty.Hepler;
using eWarranty.ViewModels.Technician;
using eWarranty.Views.Technician.TaskViews;
using Xamarin.Forms;

namespace eWarranty.Views.Technician
{
    public partial class TechDashBoardPage : ContentPage
    {
        public ToolbarItem toolbarItem { get; set; }
        public TechDashBoardViewModel viewModel { get; set; }
        public TechDashBoardPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new TechDashBoardViewModel(Navigation);

            toolbarItem = new ToolbarItem
            {
                Text = "dashbord",
                IconImageSource = ImageSource.FromFile("info.png"),
                Order = ToolbarItemOrder.Primary,
                Command = viewModel.UserNotificationsCommand,
                Priority = 0
            };

            // "this" refers to a Page object
            this.ToolbarItems.Add(toolbarItem);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.BindingData();
            CommonAttribute.TechEditServiceRequest = new ServiceRequestDetailsResponse();

        }

        //void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        //{
        //    // AssignedJobs.BackgroundColor = Color.Pink;
        //    Navigation.PushAsync(new TasksSchedulePage());
        //}

    }
}

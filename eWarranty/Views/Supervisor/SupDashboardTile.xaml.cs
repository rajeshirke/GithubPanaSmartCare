using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Supervisor;
using eWarranty.ViewModels.Technician;
using Xamarin.Forms;

namespace eWarranty.Views.Supervisor
{
    public partial class SupDashboardTile : ContentPage
    {
        public SupDashboardTileViewModel viewModel { get; set; }
        public ToolbarItem toolbarItem { get; set; }

        public SupDashboardTile()
        {
            InitializeComponent();
            BindingContext = viewModel= new SupDashboardTileViewModel(Navigation);

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
    }
}

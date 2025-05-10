using System;
using System.Collections.Generic;
using eWarranty.Core.ResponseModels;
using eWarranty.ViewModels.Technician.TasksView;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.TaskViews
{
    public partial class OrderRequestsPage : ContentPage
    {
        public OrderRequestsPage()
        {
            InitializeComponent();
            BindingContext = new OrderRequestsViewModel(Navigation);
        }
    }
}

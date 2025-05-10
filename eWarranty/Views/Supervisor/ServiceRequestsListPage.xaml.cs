using System;
using System.Collections.Generic;
using System.Linq;
using eWarranty.Core.ResponseModels;
using eWarranty.ViewModels.Customer.SRDetails;
using eWarranty.ViewModels.Supervisor;
using Xamarin.Forms;

namespace eWarranty.Views.Supervisor
{
    public partial class ServiceRequestsListPage : ContentPage
    {
        public ServiceRequestsListViewModel viewModel { get; set; }

        public ServiceRequestsListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ServiceRequestsListViewModel(Navigation);
        }

        void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            string sKey = string.Empty;
            if (!string.IsNullOrEmpty(e.NewTextValue))
                sKey = e.NewTextValue.Trim();
            viewModel.SearchServiceRequests(sKey);
            //try
            //{
            //    var NewProductResponseList = new List<ServiceRequestResponceSupervisor>();
            //    if (viewModel.Services != null && viewModel.Services.Count > 0)
            //    {
            //        NewProductResponseList = new List<ServiceRequestResponceSupervisor>(viewModel.Services);
            //    }
            //    if (!string.IsNullOrEmpty(e.NewTextValue))
            //    {
            //        var text = e.NewTextValue;
            //        if (text.Count() >= 2)
            //        {
            //            var List = NewProductResponseList.FindAll(u => u.CustomerPersonName.ToLower().StartsWith(e.NewTextValue.ToLower()) ||
            //                       u.ServiceLocationTypeName.ToLower().Contains(e.NewTextValue.ToLower()) ||
            //                       u.ProductModelNumber.ToLower().Contains(e.NewTextValue.ToLower()) ||
            //                       u.ServiceRequestStatusName.ToLower().Contains(e.NewTextValue.ToLower()));

            //            clServiceReqList.ItemsSource = List;
            //        }

            //    }
            //    else
            //    {
            //        clServiceReqList.ItemsSource = viewModel.Services;
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }
    }
}

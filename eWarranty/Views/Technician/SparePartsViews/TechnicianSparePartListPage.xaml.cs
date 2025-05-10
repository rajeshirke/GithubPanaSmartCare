using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Technician.SparePartsView;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.SparePartsViews
{
    public partial class TechnicianSparePartListPage : ContentPage
    {
        public TechnicianSparePartListViewModel viewModel { get; set; }
        public TechnicianSparePartListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new TechnicianSparePartListViewModel(Navigation);
        }
    }
}

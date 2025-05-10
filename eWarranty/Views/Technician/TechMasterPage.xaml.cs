using System;
using System.Collections.Generic;
using eWarranty.Core.ResponseModels;
using eWarranty.Hepler;
using eWarranty.ViewModels.Technician;
using Xamarin.Forms;

namespace eWarranty.Views.Technician
{
    public partial class TechMasterPage : Shell
    {
        public TechMasterPage()
        {
            InitializeComponent();
            BindingContext = new TechMasterViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CommonAttribute.TechEditServiceRequest = new ServiceRequestDetailsResponse();
        }
    }
}

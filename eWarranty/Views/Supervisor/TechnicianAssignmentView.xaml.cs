using System;
using System.Collections.Generic;
using System.Linq;
using eWarranty.Core.ResponseModels;
using eWarranty.ViewModels.Customer.SRDetails;
using eWarranty.ViewModels.Supervisor;
using Xamarin.Forms;

namespace eWarranty.Views.Supervisor
{
    public partial class TechnicianAssignmentView : ContentPage
    {
        public TechnicianAssignmentViewModel viewModel { get; set; }

        public TechnicianAssignmentView(ServiceRequestResponceSupervisor serviceRequestResponceSupervisor)
        {
            InitializeComponent();
            BindingContext = viewModel = new TechnicianAssignmentViewModel(Navigation, serviceRequestResponceSupervisor);
        }

        Grid lastElementSelected;
        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            if (lastElementSelected != null)
                VisualStateManager.GoToState(lastElementSelected, "UnSelected");

            VisualStateManager.GoToState((Grid)sender, "Selected");

            lastElementSelected = (Grid)sender;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //Navigation.RemovePage(this);
            var existingPages = Navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                if (page != null)
                    Navigation.RemovePage(page);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Technician.TasksView;
using eWarranty.Views.Customer.CommonPages;
using eWarranty.Views.Technician.SparePartsViews;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.TaskViews
{
    public partial class TaskDetailsPage : ContentPage
    {
        public TaskDetailsViewModel  viewModel { get; set; }
        public TaskDetailsPage()
        {
            InitializeComponent();
            BindingContext = viewModel= new TaskDetailsViewModel(Navigation);
           // ddlTaskStatus. = viewModel.SelectedTaskStatus;
        }
        protected async override void OnAppearing()
        {
            //await viewModel.BindingData();
            base.OnAppearing();            
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await viewModel.BindingData();
                IsBusy = false;
            });
        }
        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new CustomerLocationPage());
        }

        void TapGestureRecognizer_Tapped_1(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SparePartsPage(1));
        }

        async void TapGestureRecognizer_Tapped_2(System.Object sender, System.EventArgs e)
        {
            if(viewModel.ProductImagePath1 != null)
            {
                await Navigation.PushModalAsync(new ImagePopupView(viewModel.ProductImagePath1.ToString()), true);
            }
        }

        async void TapGestureRecognizer_Tapped_3(System.Object sender, System.EventArgs e)
        {
            if(viewModel.InvoiceImagePath1 != null)
            {
                await Navigation.PushModalAsync(new ImagePopupView(viewModel.InvoiceImagePath1.ToString()), true);
            }
        }

    }
}

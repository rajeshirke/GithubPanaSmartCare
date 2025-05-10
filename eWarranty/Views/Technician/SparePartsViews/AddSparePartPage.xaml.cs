using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Technician.SparePartsView;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.SparePartsViews
{
    public partial class AddSparePartPage : ContentPage
    {
        AddSparePartViewModel viewModel { get; set; }
        public AddSparePartPage()
        {
            InitializeComponent();
            BindingContext = viewModel= new AddSparePartViewModel(Navigation);
        }

        async void SearchPartNumber_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            await viewModel.ValidatePartNumber();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Navigation.RemovePage(this);
        }
    }
}

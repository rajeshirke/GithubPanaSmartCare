using System;
using System.Collections.Generic;
using eWarranty.Core.Models;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.ViewModels.Customer.CommonPages;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.CommonPages
{
    public partial class ServicecenterPage : ContentPage
    {
        public ServicecenterViewModel viewModel { get; set; }
        public ServicecenterPage()
        {
            InitializeComponent();
            BindingContext = viewModel=new ServicecenterViewModel(Navigation);
            slKilometer.Value = 50;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           // viewModel.RefreshData();
            //if (viewModel.ServiceCentors.Count != 0)
            //{
            //    cvServiceCentors.ItemsSource = viewModel.ServiceCentors;
            //}
           // viewModel.RefreshData();
        }

        void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            //var selectedItems = e.CurrentSelection;
            //if (selectedItems.Count > 0)
            //{
            //    var item = selectedItems[0] as ServiceCenter;

            //    viewModel.SelectedServiceCentorCommand.Execute(item);
            //}
            ((CollectionView)sender).SelectedItem = null;
        }

        void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            string sKey = string.Empty;
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                sKey = e.NewTextValue.Trim();
                viewModel.SearchServiceCenter(sKey);
            }
                
        }
        void slKilometer_ValueChanged(System.Object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            int value = Convert.ToInt32(e.NewValue);
            if (CommonAttribute.selectedLang.lid == 1)
                lblmsg.Text = String.Format("Locate within {0} kilometers", value);
            else if (CommonAttribute.selectedLang.lid == 2)
                lblmsg.Text = String.Format("حدد الموقع في نطاق {0} كيلومترًا", value);
            string sk = sbTextbox.Text;
            //viewModel.FilterServiceCenter(value, sk);
        }
    }
}

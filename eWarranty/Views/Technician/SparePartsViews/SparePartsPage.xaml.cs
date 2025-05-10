using System;
using System.Collections.Generic;
using System.Linq;
using eWarranty.ViewModels.Technician.SparePartsView;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.SparePartsViews
{
    public partial class SparePartsPage : ContentPage
    {
        SparePartsViewModel viewModel { get; set; }
        public SparePartsPage(int SwipeRightFlag)
        {
            InitializeComponent();
            BindingContext = viewModel = new SparePartsViewModel(Navigation, SwipeRightFlag);
        }
        public SparePartsPage()
        {
            InitializeComponent();
            int SwipeRightFlag = 1;
            BindingContext = viewModel = new SparePartsViewModel(Navigation, SwipeRightFlag);
        }
        void gvTab1_Tapped(System.Object sender, System.EventArgs e)
        {
            tabSelection(1);
        }
        void gvTab2_Tapped(System.Object sender, System.EventArgs e)
        {
            tabSelection(2);
        }
        void gvTab3_Tapped(System.Object sender, System.EventArgs e)
        {
            tabSelection(3);
        }
        public void tabSelection(int val)
        {
            //Device.BeginInvokeOnMainThread(() =>
            //{
            //    tab1.BackgroundColor = Color.FromHex("#F4F6FA");
            //    tab2.BackgroundColor = Color.FromHex("#F4F6FA");
               
            //    if (val == 1)
            //        tab1.BackgroundColor = Color.Black;
            //    else if (val == 2)
            //        tab2.BackgroundColor = Color.Black;
               
            //});
        }

        void SearchBar_SearchButtonPressed(System.Object sender, System.EventArgs e)
        {
            var btn = sender as SearchBar;
            if (!string.IsNullOrEmpty(btn.Text))
            {
                viewModel.SpareParts.Where(s => s.PartNumber.ToLower() == btn.Text.ToLower().Trim());
            }
        }

        async void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            string sKey = string.Empty;
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                sKey = e.NewTextValue;
                //viewModel.SpareParts.Where(s => s.PartNumber.ToLower().Contains(sKey.ToLower())).ToList();
                viewModel.SearchSparePartsCommand.Execute(sKey);
            }
            else
            {
                await viewModel.GetTechnicianStock();

                //if (tab1.BackgroundColor == Color.Gray)
                //{
                //    await viewModel.GetTechnicianStock();
                //}
                //else
                //{
                //    await viewModel.GetServiceCenterStock();
                //}

            }

        }
    }
}

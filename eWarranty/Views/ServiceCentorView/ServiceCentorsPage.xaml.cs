using System;
using System.Collections.Generic;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.ViewModels.ServiceCentor;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.Views.ServiceCentorView
{
    public partial class ServiceCentorsPage : ContentPage
    {
        public ServiceCentorViewModel viewModel { get; set; }
        public ServiceCentorsPage()
        {
            InitializeComponent();
            BindingContext = viewModel= new ServiceCentorViewModel(Navigation);
            slKilometer.Value = 50;
        }

        void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            string sKey = string.Empty;
            if (!string.IsNullOrEmpty(e.NewTextValue))
                sKey = e.NewTextValue.Trim();
            viewModel.SearchServiceCenter(sKey);
            
        }
        public FilterModel FilterData { get; set; }
        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            if (FilterData == null)
                FilterData = new FilterModel();
            var popupProperties = new SCFilterPage(FilterData);
            popupProperties.SelectedItem -= PopupProperties_SelectedItem;
            popupProperties.SelectedItem += PopupProperties_SelectedItem;
           
            var scaleAnimation = new ScaleAnimation
            {
                PositionIn = MoveAnimationOptions.Right,
                PositionOut = MoveAnimationOptions.Left
            };

            popupProperties.Animation = scaleAnimation;
             PopupNavigation.PushAsync(popupProperties);
        }

        private void PopupProperties_SelectedItem(object sender, EventArgs e)
        {
            FilterData = sender as FilterModel;
            //viewModel.FilterServiceCenter(FilterData.Distnce, FilterData.City);
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

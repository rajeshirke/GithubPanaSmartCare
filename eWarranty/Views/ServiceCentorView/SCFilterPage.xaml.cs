using System;
using System.Collections.Generic;
using eWarranty.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.Views.ServiceCentorView
{
    public partial class SCFilterPage : PopupPage
    {
        public SCFilterPage(FilterModel filter)
        {
            InitializeComponent();
            FilterData = filter;
            if(filter?.Distnce != 0)
            {
                lblmsg.Text = String.Format("Select Near by  KM {0}", filter.Distnce);
                slKilometer.Value = Convert.ToDouble(filter.Distnce);
                
            }
            if (filter != null && !string.IsNullOrEmpty(filter.City))
                txtCity.Text = filter.City;

        }
        public event EventHandler SelectedItem;
        public FilterModel FilterData { get; set; }
        void Slider_ValueChanged(System.Object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            int value = Convert.ToInt32(e.NewValue);
            lblmsg.Text = String.Format("Select Near by  KM {0}", value);
            FilterData.Distnce = value;
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            FilterData.City = txtCity.Text;
            EventHandler handler = SelectedItem;
            if (handler != null)
            {
               
                handler(FilterData, e);
             
                PopupNavigation.PopAsync();
            }
           
        }

        void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            FilterData.City = "";
            FilterData.Distnce = 0;
            EventHandler handler = SelectedItem;
            if (handler != null)
            {

                handler(FilterData, e);
            
                PopupNavigation.PopAsync();
            }
        }
    }
}

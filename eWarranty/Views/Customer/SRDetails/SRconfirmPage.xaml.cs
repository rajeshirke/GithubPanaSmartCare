using System;
using System.Collections.Generic;
using System.Linq;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.ViewModels.Customer.SRDetails;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.SRDetails
{
    public partial class SRconfirmPage : ContentPage
    {
        public event EventHandler SelectedAddress;
        public SRconfirmViewModel ViewModel { get; set; }
        public AddServicesRequestViewModel vm { get; set; }
        DateTime _triggerTime;
        public SRconfirmPage(AddServicesRequestViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = ViewModel=  new SRconfirmViewModel(Navigation , viewModel);
            //ServiceLocationId
            if (CommonAttribute.CustomeProfile != null && !string.IsNullOrWhiteSpace(CommonAttribute.CustomeProfile.MobileNumber) && !string.IsNullOrWhiteSpace(CommonAttribute.CustomeProfile.AlternateMobileNumber))
                txtPrimary.Text = CommonAttribute.CustomeProfile.PhoneCode + " " + CommonAttribute.CustomeProfile.MobileNumber; //+" || "+ CommonAttribute.CustomeProfile.AlternateMobileNumber;
            else if (CommonAttribute.CustomeProfile != null && !string.IsNullOrWhiteSpace(CommonAttribute.CustomeProfile.MobileNumber))
                txtPrimary.Text = CommonAttribute.CustomeProfile.MobileNumber;
            else if (CommonAttribute.CustomeProfile != null && !string.IsNullOrWhiteSpace(CommonAttribute.CustomeProfile.AlternateMobileNumber))
            {
                txtPrimary.Text = CommonAttribute.CustomeProfile.AlternateMobileNumber;
            }
            else
                txtPrimary.IsVisible = false;

        }

        //void ListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        //{
        //    var item = e.SelectedItem as Address;

        //    ViewModel.SelectedAddress = item;
        //}

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                AddressesSL addressesSL = new AddressesSL();
                List<AddressResponse> resAddress = await addressesSL.GetCustomerAddresses(CommonAttribute.CustomeProfile.PersonId);
                if (resAddress != null && resAddress.Count > 0)
                {
                    ViewModel.SelectedAddress = resAddress.FirstOrDefault();
                    if (ViewModel.SelectedAddress != null)
                    {
                        EventHandler handler = SelectedAddress;
                        if (handler != null)
                        {
                            CommonAttribute.PreferData = ViewModel.SDDate.Date.AddHours(ViewModel.SDTimeSpan.Hours).AddMinutes(ViewModel.SDTimeSpan.Minutes);
                            handler(ViewModel.SelectedAddress, e);
                            //handler.Invoke(item, e);
                        }
                    }
                    else
                    {
                        await ViewModel.ErrorDisplayAlert("Please update address.");
                    }
                }
                
                IsBusy = false;
            });

        }

        //void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        //{
        //    var selectedItem = e.Item as AddressResponse;
        //    selectedItem.BgColor = "#FFFFFF";

        //    foreach (var item in this.lvAddress.ItemsSource)
        //    {
        //        if (item != selectedItem)
        //            (item as AddressResponse).BgColor = "#EA1D24";
        //    }
        //}

        void lvAddress_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            //var selectedItem = e.SelectedItem as AddressResponse;
            //selectedItem.BgColor = "#FFFFFF";

            //foreach (var item in this.lvAddress.ItemsSource)
            //{
            //    if (item == selectedItem)
            //        (item as AddressResponse).BgColor = "#EA1D24";
            //}

        }
        ViewCell lastCell;
        void ViewCell_Tapped(System.Object sender, System.EventArgs e)
        {
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.White;
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.LightGray;
                lastCell = viewCell;
            }
        }

        void CustPreferredTime_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Time")
            {
                
                //SetTriggerTime();
                ViewModel.SDTimeSpan = CustPreferredTime.Time;
                CommonAttribute.CustTimeSpan= CustPreferredTime.Time; 
            }
        }

        void SetTriggerTime()
        {
            _triggerTime = DateTime.Today + CustPreferredTime.Time;
            if (_triggerTime < DateTime.Now)
            {
                _triggerTime += TimeSpan.FromDays(1);
            }
        }

        //void TitledDateTimePicker_ItemTapped(System.Object sender, System.EventArgs e)
        //{
        //    var dp = sender as DatePicker;
        //    ViewModel.SDDate = dp.Date;
        //}

        void dPicker_DateSelected(System.Object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            var dp = sender as DatePicker;
            ViewModel.SDDate = dp.Date;
        }
    }
}

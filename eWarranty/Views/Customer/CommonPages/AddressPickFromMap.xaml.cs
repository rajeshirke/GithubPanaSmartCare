using System;
using System.Collections.Generic;
using eWarranty.Models;
using Xamarin.Forms;
using eWarranty.Hepler;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using eWarranty.Resx;

namespace eWarranty.Views.Customer.CommonPages
{
    public partial class AddressPickFromMap : ContentPage
    {
        public AddressPickFromMap()
        {
            InitializeComponent();
        }
        public event EventHandler PickerSelectedItem;
        public UserCurrentLocation currentLocation { get; set; }
        protected async override void OnAppearing()
        {

            currentLocation = await Extensions.GetGeolocation();
            if (currentLocation != null)
            {
                MapSpan mapSpan = MapSpan.FromCenterAndRadius(new Position(Convert.ToDouble(currentLocation.Latitude), Convert.ToDouble(currentLocation.Longitude)), Distance.FromKilometers(0.444));
                map.MoveToRegion(mapSpan);
                string labelName = "";
                if (!string.IsNullOrEmpty(currentLocation.Area))
                    labelName = currentLocation.Area;
                else if (!string.IsNullOrEmpty(currentLocation.SubArea))
                    labelName = currentLocation.SubArea;
                else if (!string.IsNullOrEmpty(currentLocation.Locality))
                    labelName = currentLocation.Locality;
                else if (!string.IsNullOrEmpty(currentLocation.CountryName))
                    labelName = currentLocation.CountryName;

                Pin pin = new Pin
                {
                    Label = labelName,
                    Address = currentLocation.Locality + ", " + currentLocation.CountryName,
                    Type = PinType.Place,
                    Position = new Position(currentLocation.Latitude, currentLocation.Longitude)
                };
                position = new Position(currentLocation.Latitude, currentLocation.Longitude);
                map.Pins.Clear();
                map.Pins.Add(pin);
            }
            base.OnAppearing();
        }
        public void BindMapPins()
        {

        }
        public Position position { get; set; }
        async void map_MapClicked(System.Object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            try
            {
                currentLocation = await Extensions.GetGeoAddress(e.Position.Latitude, e.Position.Longitude);
                if (currentLocation == null)
                {
                    await DisplayAlert("", AppResources.msgLocationNotProvide, AppResources.lblOk);
                    return;
                }
                string labelStr = "";// currentLocation.Area;
                if (string.IsNullOrEmpty(currentLocation.Area))
                    labelStr = currentLocation.Locality;
                else
                    labelStr = currentLocation.Area;

                Pin pin = new Pin
                {
                    Label = labelStr,
                    Address = currentLocation.Locality + ", " + currentLocation.CountryName,
                    Type = PinType.Place,
                    Position = new Position(e.Position.Latitude, e.Position.Longitude)
                };
                position = new Position(e.Position.Latitude, e.Position.Longitude);
                map.Pins.Clear();
                map.Pins.Add(pin);
               


            }
            catch (Exception ex)
            {
                await DisplayAlert("", AppResources.msgLocationNotProvide, AppResources.lblOk);
            }
        }

        void btnPickAddress_Clicked(System.Object sender, System.EventArgs e)
        {
            AddressesModel addresses = new AddressesModel();
            addresses.City = currentLocation.Locality;
            addresses.SubArea = currentLocation.SubArea;
            addresses.Location = currentLocation.Area;
           
            addresses.Location = currentLocation.Area;
            addresses.CountryName = currentLocation.CountryName;
            addresses.CountryCode = currentLocation.CountryCode;
            addresses.PostalCode = currentLocation.PostalCode;
            addresses.Position = position;
            MessagingCenter.Send<AddressPickFromMap, AddressesModel>(this, "PickAddress", addresses);
            EventHandler handler = PickerSelectedItem;
            if (handler != null)
            {

                handler(this, e);
                handler.Invoke(this, e);

            }
            Navigation.PopAsync();
        }

        void btnBack_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        void btnPickAddress_Clicked_1(System.Object sender, System.EventArgs e)
        {
            try
            {
                AddressesModel addresses = new AddressesModel();
                addresses.City = currentLocation.Locality;
                addresses.SubArea = currentLocation.SubArea;
                addresses.Location = currentLocation.Area;

                addresses.Location = currentLocation.Area;
                addresses.CountryName = currentLocation.CountryName;
                addresses.CountryCode = currentLocation.CountryCode;
                addresses.PostalCode = currentLocation.PostalCode;
                addresses.Position = position;
                MessagingCenter.Send<AddressPickFromMap, AddressesModel>(this, "PickAddress", addresses);
                EventHandler handler = PickerSelectedItem;
                if (handler != null)
                {

                    handler(addresses, e);
                   // handler.Invoke(this, e);

                }
                Navigation.PopAsync();
            }
            catch (Exception ex)
            {

            }
        }
    }
}

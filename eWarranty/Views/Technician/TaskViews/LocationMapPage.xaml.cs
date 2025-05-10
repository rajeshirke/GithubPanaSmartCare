using System;
using System.Collections.Generic;
using eWarranty.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using eWarranty.Hepler;
using eWarranty.Resx;

namespace eWarranty.Views.Technician.TaskViews
{
    public partial class LocationMapPage : ContentPage
    {
        public UserCurrentLocation currentLocation { get; set; }
        public LocationMapPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {

           // currentLocation = await Extensions.GetGeolocation();
            if (currentLocation != null)
            {
                MapSpan mapSpan = MapSpan.FromCenterAndRadius(new Position(Convert.ToDouble(currentLocation.Latitude), Convert.ToDouble(currentLocation.Longitude)), Distance.FromKilometers(0.444));
                string labelName = "NA";
                if (!string.IsNullOrEmpty(currentLocation.Area))
                    labelName = currentLocation.Area;
                map.MoveToRegion(mapSpan);
                Pin pin = new Pin
                {
                    Label = labelName,
                    Address = currentLocation.Locality + ", " + currentLocation.CountryName,
                    Type = PinType.Place,
                    Position = new Position(currentLocation.Latitude, currentLocation.Longitude)
                };
                map.Pins.Clear();
                map.Pins.Add(pin);
            }
            base.OnAppearing();
        }
        async void MenuItem1_Clicked(System.Object sender, System.EventArgs e)
        {
            var location = new Xamarin.Essentials.Location(currentLocation.Longitude, currentLocation.Latitude);
            var placemark = new Placemark
            {
                CountryName = currentLocation.CountryName,
                AdminArea = currentLocation.Area,
                Thoroughfare = currentLocation.Locality,
                Locality = currentLocation.Locality,

            };
            //var options = new MapLaunchOptions { Name = "Microsoft Building 25" };
            var options = new MapLaunchOptions { Name = currentLocation.Locality };

            await Xamarin.Essentials.Map.OpenAsync(location, options);
        }

        async void call_Clicked(System.Object sender, System.EventArgs e)
        {
            if (currentLocation.MobileNumber != null)
                Extensions.PlacePhoneCall(currentLocation.MobileNumber);
            else
            {
                await DisplayAlert(AppResources.lblErrorAlert, AppResources.ErrorMsgMobilenumberisnotavailable, AppResources.lblOk);
            }
        }

        void  direction_Clicked(System.Object sender, System.EventArgs e)
        {
            var location = new Xamarin.Essentials.Location(currentLocation.Latitude, currentLocation.Longitude);
            var placemark = new Placemark
            {
                CountryName = currentLocation.CountryName,
                AdminArea = currentLocation.Area,
                Thoroughfare = currentLocation.Locality,
                Locality = currentLocation.Locality,

            };
            //var options = new MapLaunchOptions { Name = "Microsoft Building 25" };

            var options = new MapLaunchOptions { Name = CommonAttribute.CustomerSelectedServiceCenter?.Name };

            //var options = new MapLaunchOptions { Name = CommonAttribute.TechEditServiceRequest.ServiceCenter.Name };

            Xamarin.Essentials.Map.OpenAsync(location, options);
        }
    }
}

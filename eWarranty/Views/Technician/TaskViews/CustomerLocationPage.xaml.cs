using System;
using System.Collections.Generic;
using eWarranty.Models;
using eWarranty.Views.Customer.CommonPages;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using eWarranty.Hepler;
using Xamarin.Essentials;

namespace eWarranty.Views.Technician.TaskViews
{
    public partial class CustomerLocationPage : ContentPage
    {
        public CustomerLocationPage()
        {
            InitializeComponent();
        }
        public UserCurrentLocation currentLocation { get; set; }
        protected async override void OnAppearing()
        {

            currentLocation = await Extensions.GetGeolocation();
            if (currentLocation != null)
            {
                MapSpan mapSpan = MapSpan.FromCenterAndRadius(new Position(Convert.ToDouble(currentLocation.Latitude), Convert.ToDouble(currentLocation.Longitude)), Distance.FromKilometers(0.444));
                map.MoveToRegion(mapSpan);
                Pin pin = new Pin
                {
                    Label = currentLocation.Area,
                    Address = currentLocation.Locality + ", " + currentLocation.CountryName,
                    Type = PinType.Place,
                    Position = new Position(currentLocation.Latitude, currentLocation.Longitude)
                };
                map.Pins.Clear();
                map.Pins.Add(pin);

                  }
            base.OnAppearing();
        }
        public void BindMapPins()
        {

        }
     

        void btnBack_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

       async void btnDirection_Clicked(System.Object sender, System.EventArgs e)
        {
            var location = new Xamarin.Essentials.Location(25.0692, 55.1388);
            var placemark = new Placemark
            {
                CountryName = currentLocation.CountryName,
                AdminArea = currentLocation.Area,
                Thoroughfare = currentLocation.Locality,
                Locality = currentLocation.Locality,

            };
            //var options = new MapLaunchOptions { Name = "Microsoft Building 25" };
            var options = new MapLaunchOptions { Name = "Customer Location" };

            await Xamarin.Essentials.Map.OpenAsync(location, options);
        }
    }
}

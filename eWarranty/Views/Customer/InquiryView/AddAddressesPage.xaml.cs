using System;
using System.Collections.Generic;
using Xamarin.Forms;
using eWarranty.Hepler;
using eWarranty.Models;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using eWarranty.ViewModels.Customer.CommonPages;

namespace eWarranty.Views.Customer.CommonPages
{
    public partial class AddAddressesPage : ContentPage
    {
        public AddAddressesPage()
        {
            InitializeComponent();
            BindingContext = new NewAddressViewModel(Navigation);
        }
        public AddAddressesPage(string pageType)
        {
            InitializeComponent();
            BindingContext = new NewAddressViewModel(Navigation);
        }
        //public UserCurrentLocation currentLocation { get; set; }
        //protected async override void OnAppearing()
        //{

        //    currentLocation = await Extensions.GetGeolocation();
        //    if (currentLocation != null)
        //    {
        //        MapSpan mapSpan = MapSpan.FromCenterAndRadius(new Position(Convert.ToDouble(currentLocation.Latitude), Convert.ToDouble(currentLocation.Longitude)), Distance.FromKilometers(0.444));
        //        map.MoveToRegion(mapSpan);
        //    }
        //    base.OnAppearing();
        //}

        //void btnFind_Clicked(System.Object sender, System.EventArgs e)
        //{
        //    var m = map;
        //    //var location = new Xamarin.Essentials.Location(currentLocation.Latitude, currentLocation.Longitude);
        //    //var options = new Xamarin.Essentials.MapLaunchOptions { NavigationMode = NavigationMode.Driving };
        //    // Xamarin.Essentials.Map.OpenAsync(location, options);
        //}

        //async void  map_MapClicked(System.Object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        //{
        //    try
        //    {
        //        UserCurrentLocation Address = await Extensions.GetGeoAddress(e.Position.Latitude, e.Position.Longitude);
        //        if (Address == null)
        //        {
        //            await DisplayAlert("", "We will not provide service in this location.", "ok");
        //            return;
        //        }
        //        Pin pin = new Pin
        //        {
        //            Label = Address.Area,
        //            Address = Address.Locality + ", " + Address.CountryName,
        //            Type = PinType.Place,
        //            Position = new Position(e.Position.Latitude, e.Position.Longitude)
        //        };
        //        map.Pins.Clear();
        //        map.Pins.Add(pin);
        //        txtArea.Text = Address.Area;
        //        txtCity.Text = Address.Locality + ", " + Address.CountryName;
        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("", "We will not provide service in this location.", "ok");
        //    }
        //}
    }
}

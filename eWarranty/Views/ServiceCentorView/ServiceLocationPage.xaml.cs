using System;
using System.Collections.Generic;
using eWarranty.Models;
using Xamarin.Forms;
using eWarranty.Hepler;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using eWarranty.Resx;

namespace eWarranty.Views.ServiceCentorView
{
    public partial class ServiceLocationPage : ContentPage
    {
        public UserCurrentLocation currentLocation { get; set; }
        public ServiceLocationPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            if (currentLocation == null)
                currentLocation = new UserCurrentLocation();
            this.Title = CommonAttribute.CustomerSelectedServiceCenter.Name;
            currentLocation.Area = CommonAttribute.CustomerSelectedServiceCenter.StreetAddress;
            currentLocation.Latitude = Convert.ToDouble(CommonAttribute.CustomerSelectedServiceCenter.Latitude);
            currentLocation.Longitude =Convert.ToDouble(CommonAttribute.CustomerSelectedServiceCenter.Longitude);
            if(CommonAttribute.CustomerSelectedServiceCenter?.ContactNumber1 != null && CommonAttribute.CustomerSelectedServiceCenter?.ContactNumber1 != string.Empty && CommonAttribute.CustomerSelectedServiceCenter?.ContactNumber1 != "")
            {
                currentLocation.MobileNumber = CommonAttribute.CustomerSelectedServiceCenter?.ContactNumber1;
            }
            else if (CommonAttribute.CustomerSelectedServiceCenter?.ContactNumber2 != null && CommonAttribute.CustomerSelectedServiceCenter?.ContactNumber2 != string.Empty && CommonAttribute.CustomerSelectedServiceCenter?.ContactNumber2 != "")
            {
                currentLocation.MobileNumber = CommonAttribute.CustomerSelectedServiceCenter?.ContactNumber2;
            }

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
        async void map_MapClicked(System.Object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            try
            {
                currentLocation = await Extensions.GetGeoAddress(e.Position.Latitude, e.Position.Longitude);
                if (currentLocation == null)
                {
                    await DisplayAlert("", "We will not provide service in this location.", "ok");
                    return;
                }
                string labelStr = "NA";// currentLocation.Area;
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

                map.Pins.Clear();
                map.Pins.Add(pin);



            }
            catch (Exception ex)
            {
                await DisplayAlert("", "We will not provide service in this location.", "ok");
            }
        }

        async void  MenuItem1_Clicked(System.Object sender, System.EventArgs e)
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
            var options = new MapLaunchOptions { Name = CommonAttribute.CustomerSelectedServiceCenter.Name };
            
            await Xamarin.Essentials.Map.OpenAsync(location, options);
        }

        async void MenuItem1_Clicked_1(System.Object sender, System.EventArgs e)
        {
            if (currentLocation.MobileNumber != null && currentLocation.MobileNumber != string.Empty && currentLocation.MobileNumber != "")
            {
                Extensions.PlacePhoneCall(currentLocation.MobileNumber);
            }
            else
            {
                await DisplayAlert(AppResources.lblErrorAlert, AppResources.ErrorMsgMobilenumberisnotavailable, AppResources.lblOk);
            }
                
        }
    }
}

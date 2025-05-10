using System;
using Android.Content;
using eWarranty.DependencyServices;
using eWarranty.Droid.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocationShare))]
namespace eWarranty.Droid.DependencyServices
{
    public class LocationShare : ILocSettings
    {
        public bool isGpsAvailable()
        {
            bool value = false;
            Android.Locations.LocationManager manager = (Android.Locations.LocationManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.LocationService);
            if (!manager.IsProviderEnabled(Android.Locations.LocationManager.GpsProvider))
            {
                //gps disable
                value = false;
            }
            else
            {
                //Gps enable
                value = true;
            }
            return value;
        }
        public void OpenSettings()
        {
            Intent intent = new Android.Content.Intent(Android.Provider.Settings.ActionLocat‌​ionSourceSettings);
            intent.AddFlags(ActivityFlags.NewTask);
            Android.App.Application.Context.StartActivity(intent);
        }
    }
}

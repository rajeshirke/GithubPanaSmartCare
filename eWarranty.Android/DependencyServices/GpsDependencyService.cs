using System;
using Android.Content;
using Android.Locations;
using eWarranty.DependencyServices;
using eWarranty.Droid.DependencyServices;

[assembly: Xamarin.Forms.Dependency(typeof(GpsDependencyService))]
namespace eWarranty.Droid.DependencyServices
{
    public class GpsDependencyService : IGpsDependencyService
    {
        public bool IsGpsTurnedOn()
        {
            LocationManager locationManager = (LocationManager)Android.App.Application.Context.GetSystemService(Context.LocationService);
            return locationManager.IsProviderEnabled(LocationManager.GpsProvider);
        }

        public void OpenSettings()
        {
            Intent intent = new Intent(Android.Provider.Settings.ActionLocat‌​ionSourceSettings);
            intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);

            try
            {
                Android.App.Application.Context.StartActivity(intent);

            }
            catch (ActivityNotFoundException activityNotFoundException)
            {
                System.Diagnostics.Debug.WriteLine(activityNotFoundException.Message);
                Android.Widget.Toast.MakeText(Android.App.Application.Context, "Error: Gps Activity", Android.Widget.ToastLength.Short).Show();
            }
        }
    }
}
    
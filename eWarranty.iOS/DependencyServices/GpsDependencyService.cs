using System;
using CoreLocation;
using eWarranty.DependencyServices;
using eWarranty.iOS.DependencyServices;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(GpsDependencyService))]
namespace eWarranty.iOS.DependencyServices
{
    public class GpsDependencyService : IGpsDependencyService
    {

        public bool IsGpsTurnedOn()
        {
            if (CLLocationManager.Status == CLAuthorizationStatus.Denied)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void OpenSettings()
        {
            var WiFiURL = new NSUrl("prefs:root=WIFI");

            if (UIApplication.SharedApplication.CanOpenUrl(WiFiURL))
            {   //> Pre iOS 10
                UIApplication.SharedApplication.OpenUrl(WiFiURL);
            }
            else
            {   //> iOS 10
                UIApplication.SharedApplication.OpenUrl(new NSUrl("App-Prefs:root=WIFI"));
            }
        }
    }
}

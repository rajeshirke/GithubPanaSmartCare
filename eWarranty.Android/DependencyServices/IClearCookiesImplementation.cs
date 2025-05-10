using Xamarin.Forms;
using System.Net;
using Android.Webkit;
using eWarranty.DependencyServices;
using eWarranty.Droid.DependencyServices;

[assembly: Dependency(typeof(IClearCookiesImplementation))]
namespace eWarranty.Droid.DependencyServices
{
    public class IClearCookiesImplementation : IClearCookies
    {
        public void Clear()
        {
            var cookieManager = CookieManager.Instance;
            cookieManager.RemoveAllCookie();
        }
    }
}

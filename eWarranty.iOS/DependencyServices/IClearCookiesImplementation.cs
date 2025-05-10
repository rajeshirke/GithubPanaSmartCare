using Xamarin.Forms;
using System.Net;
using Foundation;
using eWarranty.iOS.DependencyServices;
using eWarranty.DependencyServices;

[assembly: Dependency(typeof(IClearCookiesImplementation))]
namespace eWarranty.iOS.DependencyServices
{
    public class IClearCookiesImplementation : IClearCookies
    {
        public void Clear()
        {
            NSHttpCookieStorage CookieStorage = NSHttpCookieStorage.SharedStorage;
            foreach (var cookie in CookieStorage.Cookies)
                CookieStorage.DeleteCookie(cookie);
        }
    }
}
using System;
using eWarranty.DependencyServices;
using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(IBaseUrl))]
namespace eWarranty.iOS.DependencyServices
{
    public class BaseUrl : IBaseUrl
    {
        //public string Get()
        //{
        //    return NSBundle.MainBundle.BundlePath;
        //}
        public string Get()
        {
            return "";
           // return NSBundle.MainBundle.BundlePath;
        }
    }
}

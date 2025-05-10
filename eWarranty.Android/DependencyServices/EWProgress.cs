using System;
using eWarranty.DependencyServices;
using AndroidHUD;

using Xamarin.Forms;
using eWarranty.Droid.DependencyServices;
using Plugin.CurrentActivity;

[assembly: Dependency(typeof(EWProgress))]
namespace eWarranty.Droid.DependencyServices
{
    public class EWProgress : IEWProgress
    {
        //public void Dismiss()
        //{
        //    AndHUD.Shared.Dismiss(CrossCurrentActivity.Current.Activity);
        //}

        //public void Show()
        //{
        //    AndHUD.Shared.Show(CrossCurrentActivity.Current.Activity, "Please Wait", 1);
        //}

        //public void Show(string message)
        //{
        //    AndHUD.Shared.Show(CrossCurrentActivity.Current.Activity, message, 1);
        //}

        public void Dismiss()
        {
            AndHUD.Shared.Dismiss(CrossCurrentActivity.Current.Activity);
            //MessagingCenter.Send<string>("Hide", "ShowLoaderAnim");
        }

        public void Show()
        {
            AndHUD.Shared.Show(CrossCurrentActivity.Current.Activity, "Please Wait", 1);
            
            //MessagingCenter.Send<string>("Show", "ShowLoaderAnim");
        }

        public void Show(string message)
        {
            AndHUD.Shared.Show(CrossCurrentActivity.Current.Activity, message, 1);
            //MessagingCenter.Send<string>("Show", "ShowLoaderAnim");
        }
    }
}

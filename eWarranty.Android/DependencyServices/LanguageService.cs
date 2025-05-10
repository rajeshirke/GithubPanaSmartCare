using System;
using System.Globalization;
using System.Threading;
using Android.Content;
using eWarranty.DependencyServices;
using eWarranty.Droid.DependencyServices;
using Java.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(LanguageService))]
namespace eWarranty.Droid.DependencyServices
{
    public class LanguageService : ILanguageService
    {
        public void SetLanguage(string lang)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                // Get application context
                Context context = Android.App.Application.Context;

                // Set application locale by selected language
                Locale.Default = new Locale(lang);
                context.Resources.Configuration.Locale = Locale.Default;
                context.ApplicationContext.CreateConfigurationContext(context.Resources.Configuration);
                context.Resources.DisplayMetrics.SetTo(context.Resources.DisplayMetrics);

                // Relaunch MainActivity
                Intent intent = new Intent(context, new MainActivity().Class);
                intent.AddFlags(ActivityFlags.NewTask);
                context.StartActivity(intent);
            }
        }
        public void SetApplicationLanguage(CultureInfo ci)
        {
           
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;
        }
    }
}

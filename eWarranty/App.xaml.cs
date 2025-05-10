using System;
using System.Globalization;
using eWarranty.Controls;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.Views.Account;
using eWarranty.Views.Technician;
using Plugin.Multilingual;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using eWarranty.Views.Customer.InquiryView;
using System.Threading.Tasks;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.Enums;
using eWarranty.DependencyServices;
using eWarranty.Views.Customer;
using Xamarin.Essentials;
using Extensions = eWarranty.Hepler.Extensions;
using eWarranty.Views.Technician.ServiceCenterView;
using Plugin.FirebasePushNotification;
using System.Threading;
using eWarranty.Views.Supervisor;
using Shiny;
using System.Linq;
using System.Diagnostics;
using Device = Xamarin.Forms.Device;
using Application = Xamarin.Forms.Application;
using eWarranty.Views.AppOnBoard;

namespace eWarranty
{

    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            LocalizationResourceManager.Instance.SetCulture(CultureInfo.GetCultureInfo("en-US"));

            InitializeComponent();
            //string phoneToken =CrossFirebasePushNotification.Current.Token.ToString();
            //Console.WriteLine($"Token: {phoneToken}");

            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTg3MjY2QDMxMzkyZTM0MmUzMFFTNnZlWEF4Q0xDK01sUzRZVHB0dkNaVVFIUkhqTkttYm9KaklMTWV2YWs9");
            XF.Material.Forms.Material.Init(this);

            if (Device.RuntimePlatform == Device.iOS)
            {
                CrossFirebasePushNotification.Current.OnNotificationReceived += Current_OnNotificationReceived;
            }

            
        }        

        private void Current_OnNotificationReceived(object source, FirebasePushNotificationDataEventArgs e)
        {
            Debug.WriteLine("Notification", $"Data: {e.Data["myData"]}", "OK");
        }

        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            string phoneToken = e.Token.ToString();
            Debug.WriteLine($"Token: {phoneToken}");
        }

        public async Task<bool> LoginPage()
        {
           var languages = Extensions.Getlanguages();
            CommonAttribute.selectedLang = languages[0];
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.email = Current.Properties["email"].ToString();
            loginRequest.username = Current.Properties["email"].ToString();
            loginRequest.password = Current.Properties["password"].ToString();
            UserManagementSL userManagementSL = new UserManagementSL();
            ReceiveContext<PersonLoginResponse> receiveContext = await userManagementSL.ValidateUser(loginRequest);
            if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
            {
                if (receiveContext.data.PersonRoleId == Convert.ToInt16(PersonRoleEnum.Customer))
                {
                    CommonAttribute.CustomeProfile = receiveContext.data;
                    return true;
                    // Application.Current.MainPage = new DashBoadMasterPage();
                }
                else if (receiveContext.data.PersonRoleId == Convert.ToInt16(PersonRoleEnum.Technician))
                {
                    CommonAttribute.CustomeProfile = receiveContext.data;
                    return true;
                    // Application.Current.MainPage = new DashBoadMasterPage();
                }
                else if (receiveContext.data.PersonRoleId == Convert.ToInt16(PersonRoleEnum.Supervisor))
                {
                    CommonAttribute.CustomeProfile = receiveContext.data;
                    return true;
                    // Application.Current.MainPage = new DashBoadMasterPage();
                }
            }
            return false;

        }
        protected async override void OnStart()
        {
            // iOS App Privacy
            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                var appTrackingTransparencyPermission = DependencyService.Get<IAppTrackingTransparencyPermission>();
                var status = await appTrackingTransparencyPermission.CheckStatusAsync();

                if (status != PermissionStatus.Granted)
                    appTrackingTransparencyPermission.RequestAsync(s => MyImplementation(s));
                else
                    MyImplementation(status);

            }
            else
            {
                // app center or other implementations
                #region AppCenter
                AppCenter.Start("android={c975b828-0c5f-4fd6-b0d2-c39487f223d8};",
                    typeof(Analytics), typeof(Crashes));
                #endregion
            }

             if (Current.Properties.ContainsKey("email") && Current.Properties.ContainsKey("password"))
            {
                try
                {
                    // credential check
                    bool res = await LoginPage();
                    if (res)
                    {
                        if (CommonAttribute.CustomeProfile.PersonRoleId == (int)PersonRoleEnum.Customer)
                        {
                            MainPage = new DashBoadMasterPage();
                        }
                        else if (CommonAttribute.CustomeProfile.PersonRoleId == (int)PersonRoleEnum.Technician)
                        {
                            MainPage = new TechMasterPage();
                        }
                        else if (CommonAttribute.CustomeProfile.PersonRoleId == (int)PersonRoleEnum.Supervisor)
                        {
                            MainPage = new SupDashboardLeftSideMenu();
                        }
                    }
                    else
                    {
                        var navigation = new NavigationPage(new LoginPage());

                        navigation.BarBackgroundColor = Color.FromHex("#1E55A5");
                        MainPage = navigation;// new NavigationPage(new ServiceManualModelPage());
                    }                 

                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                var navigation = new NavigationPage(new LoginPage());

                navigation.BarBackgroundColor = Color.FromHex("#1E55A5");
                MainPage = navigation;// new TechMasterPage(); //navigation;
            }

            await GetCurrentLocation();

        }
        private void MyImplementation(PermissionStatus status)
        {
            if (status == PermissionStatus.Granted)
            {
                // app center or other implementations
                #region AppCenter
                AppCenter.Start("ios={3029d06e-3c5b-442c-8139-762fe3036b41};",
                    typeof(Analytics), typeof(Crashes));

                #endregion
            }
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {

        }
        //Location tracking
        CancellationTokenSource cts;
        async Task GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (Xamarin.Essentials.PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
        //protected override void OnDisappearing()
        //{
        //    if (cts != null && !cts.IsCancellationRequested)
        //        cts.Cancel();
        //    base.OnDisappearing();
        //}


        #region AppNotification

        private void AppOpenedDateTime(string param)
        {
            try
            {
                //BackgroundTasks();
                RunShinyJobsAsync();
            }
            catch (Exception ex)
            {
                Debugger.Log(0, null, ex.ToString());
            }
        }

        private async Task RunShinyJobsAsync()
        {
            var accessStatus = await ShinyHost.Resolve<Shiny.Notifications.INotificationManager>().RequestAccess();
            var result = await ShinyHost.Resolve<Shiny.Jobs.IJobManager>().RunAll(System.Threading.CancellationToken.None);
            var success = result.FirstOrDefault().Success ? "Success" : "Fail";
        }

        #endregion
    }
}

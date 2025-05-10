using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using eWarranty.ViewModels;
using eWarranty.Hepler;
using Plugin.CurrentActivity;
using Xamarin.Forms.Platform.Android;
using ImageCircle.Forms.Plugin.Droid;
using Android;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Plugin.FirebasePushNotification;
using Android.Content;
using eWarranty.DependencyServices;
using eWarranty.Droid.DependencyServices;
using Shiny;
using Plugin.LocalNotification;

namespace eWarranty.Droid
{//eWarranty
    [Activity(Label = "CIAA", Icon = "@mipmap/masticon", Theme = "@style/MainTheme",ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static int StatusBarHeight;
        public static MainActivity rootActivity { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            NotificationCenter.CreateNotificationChannel();

            //this.ShinyOnCreate();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTg3MjY2QDMxMzkyZTM0MmUzMFFTNnZlWEF4Q0xDK01sUzRZVHB0dkNaVVFIUkhqTkttYm9KaklMTWV2YWs9");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // w.setFlags(WindowManager.LayoutParams.FLAG_LAYOUT_NO_LIMITS, WindowManager.LayoutParams.FLAG_LAYOUT_NO_LIMITS);

            // Window.ClearFlags(WindowManagerFlags.LayoutNoLimits);
            // Window.AddFlags(WindowManagerFlags.TranslucentStatus);
            //  Resource.Drawable.gradient_one
            //Window.AddFlags(WindowManagerFlags.LayoutNoLimits);
            //Window.AddFlags(WindowManagerFlags.LayoutInScreen);
            //Window.DecorView.SetFitsSystemWindows(true);
            // Window.SetStatusBarColor(Color.Transparent.ToAndroid());
            base.OnCreate(savedInstanceState);
            ImageCircleRenderer.Init();
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.SetFlags("Brush_Experimental");
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");

            Rg.Plugins.Popup.Popup.Init(this);
            FirebasePushNotificationManager.ProcessIntent(this, Intent);
            Firebase.FirebaseApp.InitializeApp(this);
            XF.Material.Droid.Material.Init(this, savedInstanceState);
            //ShinyHost.Init((IPlatform)this);
            //Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            //Forece app to run as RTL
            MessagingCenter.Unsubscribe<BaseViewModel>(this, "Lang");
            MessagingCenter.Subscribe<BaseViewModel>(this, "Lang", (sender) =>
            {
                if(CommonAttribute.flowDirection == FlowDirection.LeftToRight)
                    Window.DecorView.LayoutDirection = LayoutDirection.Ltr;
                else
                    Window.DecorView.LayoutDirection = LayoutDirection.Rtl;

            });
            CommonAttribute.ScreenHeight = (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);
            CommonAttribute.ScreenWidth = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);
            rootActivity = this;
            //this.Window.AddFlags(WindowManagerFlags.Fullscreen);
            ////  Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            //if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            //{
            //    Window.DecorView.SystemUiVisibility = 0;
            //    var statusBarHeightInfo = typeof(FormsAppCompatActivity).GetField("_statusBarHeight", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            //    statusBarHeightInfo?.SetValue(this, 0);
            //    Window.SetStatusBarColor(new Android.Graphics.Color(18, 52, 86, 255));
            //}
            var intent = new Intent(this, typeof(PeriodicService));
            StartService(intent);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
           
            // Window.SetFlags(WindowManagerFlags.LayoutNoLimits, WindowManagerFlags.LayoutNoLimits);
            LoadApplication(new App());
            StatusBarHeight = getStatusBarHeight();
            CreateNotificationFromIntent(Intent);
            NotificationCenter.NotifyNotificationTapped(Intent);
        }
        public int getStatusBarHeight()
        {

            int statusBarHeight = 0, totalHeight = 0, contentHeight = 0;
            int resourceId = Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                statusBarHeight = Resources.GetDimensionPixelSize(resourceId);


            }
            return statusBarHeight;
        }
        private void TransparentStatusBar()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                // for covering the full screen in android..
                Window.SetFlags(WindowManagerFlags.LayoutNoLimits, WindowManagerFlags.LayoutNoLimits);

                // clear FLAG_TRANSLUCENT_STATUS flag:
                Window.ClearFlags(WindowManagerFlags.TranslucentStatus);

                Window.SetStatusBarColor(Android.Graphics.Color.Transparent);

            }

        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            BadgeDrawable.SetBadgeCount(this, menu.GetItem(0),3,Android.Graphics.Color.Red, Android.Graphics.Color.White);
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {

            return base.OnCreateOptionsMenu(menu);
        }

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //    RequestPermissions(new string[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation }, 0);
        // //   ActivityCompat.RequestPermissions(CrossCurrentActivity.Current.Activity, new[] { Manifest.Permission.AccessBackgroundLocation.ToString() }, 1000);
        //}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnStart()
        {
            base.OnStart();
            
        }
        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            FirebasePushNotificationManager.ProcessIntent(this, intent);
            this.ShinyOnNewIntent(intent);
            CreateNotificationFromIntent(intent);
            NotificationCenter.NotifyNotificationTapped(intent);
        }

       
        void CreateNotificationFromIntent(Intent intent)
        {
            if (intent?.Extras != null)
            {
                string title = intent.GetStringExtra(AndroidNotificationManager.TitleKey);
                string message = intent.GetStringExtra(AndroidNotificationManager.MessageKey);
                DependencyService.Get<INotificationManager>().ReceiveNotification(title, message);
            }
        }
    }
}
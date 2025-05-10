using System;
using System.Collections.Generic;
using System.Linq;
using eWarranty.DependencyServices;
using eWarranty.Hepler;
using eWarranty.iOS.DependencyServices;
using eWarranty.ViewModels;
using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using KeyboardOverlap.Forms.Plugin.iOSUnified;
using Plugin.FirebasePushNotification;
using Plugin.Iconize;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfAutoComplete.XForms.iOS;
using Syncfusion.SfBusyIndicator.XForms.iOS;
using Syncfusion.SfPicker.XForms.iOS;
using Syncfusion.SfRadialMenu.XForms.iOS;
using Syncfusion.XForms.iOS.Cards;
using Syncfusion.XForms.iOS.EffectsView;
using UIKit;
using Xamarin.Forms;

namespace eWarranty.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        [System.Runtime.InteropServices.DllImport(ObjCRuntime.Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
        internal extern static IntPtr IntPtr_objc_msgSend(IntPtr receiver, IntPtr selector, UISemanticContentAttribute arg1);
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            CommonAttribute.ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;
            CommonAttribute.ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;

            try
            {
                // Color of the selected tab icon:
                var appearanceTabBar = new UITabBarAppearance()
                {
                    BackgroundColor = UIColor.FromRGB(red: 30, green: 85, blue: 165),
                    ShadowColor = UIColor.FromRGB(red: 30, green: 85, blue: 165),
                };
                UITabBar.Appearance.StandardAppearance = appearanceTabBar;

                var appearanceNavigation = new UINavigationBarAppearance()
                {
                    BackgroundColor = UIColor.FromRGB(red: 30, green: 85, blue: 165),
                    ShadowColor = UIColor.FromRGB(red: 30, green: 85, blue: 165),
                };
                UINavigationBar.Appearance.StandardAppearance = appearanceNavigation;

                if (Convert.ToInt32(UIDevice.CurrentDevice.SystemVersion.Split(".")[0]) >= 15)
                {
                    UITabBar.Appearance.ScrollEdgeAppearance = appearanceTabBar;
                    UINavigationBar.Appearance.ScrollEdgeAppearance = appearanceNavigation;
                }

                // NavigationController.NavigationBar.SetBackgroundImage(, UIBarMetrics.Default);
                // NavigationController.NavigationBar.Alpha = alpha;

            }
            catch (Exception ex)
            {

            }

            UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval(UIApplication.BackgroundFetchIntervalMinimum);

            global::Xamarin.Forms.Forms.SetFlags("Brush_Experimental");
            global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsMaps.Init();

            DependencyService.Register<IAppTrackingTransparencyPermission, AppTrackingTransparencyPermission>();

            FirebasePushNotificationManager.Initialize(options, true);
            LoadApplication(new App());
            Rg.Plugins.Popup.Popup.Init();
            ImageCircleRenderer.Init();
            KeyboardOverlapRenderer.Init();
            SfCardViewRenderer.Init();
            SfRadialMenuRenderer.Init();
            Syncfusion.XForms.iOS.ComboBox.SfComboBoxRenderer.Init();
            Syncfusion.XForms.iOS.Border.SfBorderRenderer.Init();
            Syncfusion.XForms.iOS.Buttons.SfButtonRenderer.Init();
            Syncfusion.XForms.iOS.Graphics.SfGradientViewRenderer.Init();
            Syncfusion.XForms.iOS.Expander.SfExpanderRenderer.Init();
            Syncfusion.SfChart.XForms.iOS.Renderers.SfChartRenderer.Init();
            Syncfusion.XForms.iOS.Accordion.SfAccordionRenderer.Init();
            Syncfusion.XForms.iOS.ProgressBar.SfLinearProgressBarRenderer.Init();
            Syncfusion.SfCarousel.XForms.iOS.SfCarouselRenderer.Init();

            SfListViewRenderer.Init();
            SfEffectsViewRenderer.Init();
            Iconize.Init();
            SfPickerRenderer.Init();
            //SfBusyIndicatorRenderer.Init();
            new SfBusyIndicatorRenderer();
            new SfAutoCompleteRenderer();

            MessagingCenter.Unsubscribe<BaseViewModel>(this, "Lang");
            MessagingCenter.Subscribe<BaseViewModel>(this, "Lang", (sender) =>
            {
                ObjCRuntime.Selector selector = new ObjCRuntime.Selector("setSemanticContentAttribute:");
               
                if (CommonAttribute.flowDirection == FlowDirection.LeftToRight)
                    AppDelegate.IntPtr_objc_msgSend(UIView.Appearance.Handle, selector.Handle, UISemanticContentAttribute.ForceLeftToRight);
                else
                    AppDelegate.IntPtr_objc_msgSend(UIView.Appearance.Handle, selector.Handle, UISemanticContentAttribute.ForceRightToLeft);

            });
           

           
            return base.FinishedLaunching(app, options);
        }
        public override void PerformFetch(UIApplication application, Action<UIBackgroundFetchResult> completionHandler)
        {
            // Check for new data, and display it
            var okAlertController = UIAlertController.Create("Title", "The message", UIAlertControllerStyle.Alert);

            Console.WriteLine("kumar log");
            // Inform system of fetch results
            completionHandler(UIBackgroundFetchResult.NewData);
        }
        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            FirebasePushNotificationManager.DidRegisterRemoteNotifications(deviceToken);
        }

        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            FirebasePushNotificationManager.RemoteNotificationRegistrationFailed(error);

        }

        // To receive notifications in foreground on iOS 9 and below.
        // To receive notifications in background in any iOS version
        public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {
            // If you are receiving a notification message while your app is in the background,
            // this callback will not be fired 'till the user taps on the notification launching the application.

            // If you disable method swizzling, you'll need to call this method. 
            // This lets FCM track message delivery and analytics, which is performed
            // automatically with method swizzling enabled.
            FirebasePushNotificationManager.DidReceiveMessage(userInfo);
            // Do your magic to handle the notification data
            System.Console.WriteLine(userInfo);

            completionHandler(UIBackgroundFetchResult.NewData);
        }
    }
}

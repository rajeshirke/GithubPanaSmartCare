﻿using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Plugin.CurrentActivity;
using Plugin.FirebasePushNotification;

namespace eWarranty.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            //Set the default notification channel for your app when running Android Oreo
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                //Change for your default notification channel id here
                FirebasePushNotificationManager.DefaultNotificationChannelId = "FirebasePushNotificationChannel";

                //Change for your default notification channel name here
                FirebasePushNotificationManager.DefaultNotificationChannelName = "General";

                FirebasePushNotificationManager.DefaultNotificationChannelImportance = NotificationImportance.Max;
            }

            //If debug you should reset the token each time.
#if DEBUG
            FirebasePushNotificationManager.Initialize(this, true);
#else
            FirebasePushNotificationManager.Initialize(this, false);
#endif

            //Handle notification when app is closed here
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {


            };
        }
    }



    //    //#if DEBUG
    //    //    [Application(Debuggable = true)]
    //    //#else
    //    //	    [Application(Debuggable = false)]
    //    //#endif
    //    [Application]
    //    public partial class MainApplication : Application, Application.IActivityLifecycleCallbacks
    //    {
    //        public MainApplication(IntPtr handle, JniHandleOwnership transer)
    //          : base(handle, transer)
    //        {
    //        }

    //        public override void OnCreate()
    //        {
    //            base.OnCreate();
    //            CrossCurrentActivity.Current.Init(this);
    //            RegisterActivityLifecycleCallbacks(this);
    //            #region Pushnotification
    //            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
    //            {
    //                //Change for your default notification channel id here
    //                FirebasePushNotificationManager.DefaultNotificationChannelId = "FirebasePushNotificationChannel";

    //                //Change for your default notification channel name here
    //                FirebasePushNotificationManager.DefaultNotificationChannelName = "General";

    //                FirebasePushNotificationManager.DefaultNotificationChannelImportance = NotificationImportance.Max;
    //            }

    //            //If debug you should reset the token each time.
    //#if DEBUG
    //            FirebasePushNotificationManager.Initialize(this, true);
    //#else
    //            //FirebasePushNotificationManager.Initialize(this, true);
    //#endif

    //            //Handle notification when app is closed here
    //            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
    //            {


    //            };
    //            #endregion
    //        }

    //        public override void OnTerminate()
    //        {
    //            base.OnTerminate();
    //            UnregisterActivityLifecycleCallbacks(this);
    //        }

    //        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
    //        {
    //            CrossCurrentActivity.Current.Activity = activity;
    //        }

    //        public void OnActivityDestroyed(Activity activity)
    //        {
    //        }

    //        public void OnActivityPaused(Activity activity)
    //        {
    //        }

    //        public void OnActivityResumed(Activity activity)
    //        {
    //            CrossCurrentActivity.Current.Activity = activity;
    //        }

    //        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
    //        {
    //        }

    //        public void OnActivityStarted(Activity activity)
    //        {
    //            CrossCurrentActivity.Current.Activity = activity;
    //        }

    //        public void OnActivityStopped(Activity activity)
    //        {
    //        }
    //    }
}
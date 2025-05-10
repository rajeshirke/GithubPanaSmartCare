using System;
using Android.Content;
using eWarranty.Droid.Renderers;
using eWarranty.Views.Customer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
//using Android.Support.V4.Content;
//using Android.Support.V4.App;
//using Android.Support.V4.Content.Res;
//using Android.Support.Design.Widget;
//using Android.Support.V7.Widget;
using AndroidX.Core.Content.Resources;
using AndroidX.CoordinatorLayout.Widget;
using AndroidX.AppCompat.Widget;

[assembly: ExportRenderer(typeof(DashBoadMasterPage), typeof(CustomShellRenderer))]
namespace eWarranty.Droid.Renderers
{
    public class CustomShellRenderer : Xamarin.Forms.Platform.Android.ShellRenderer
    {
        Context context;

        public CustomShellRenderer(Context ctx) : base(ctx)
        {
            context = ctx;
        }

        protected override IShellFlyoutContentRenderer CreateShellFlyoutContentRenderer()
        {
            var flyout = base.CreateShellFlyoutContentRenderer();

            var bg = ResourcesCompat.GetDrawable(context.Resources, Resource.Drawable.toolbar_bg, null);
            //flyout.AndroidView.SetBackground(drawable: bg);

            var cl = ((CoordinatorLayout)flyout.AndroidView);
          //  cl.SetBackgroundColor(Color.Transparent.ToAndroid());
           // cl.SetBackground(bg);

         //   var g = (AppBarLayout)cl.GetChildAt(0);
         //   g.SetBackgroundColor(Color.Transparent.ToAndroid());
         //   g.OutlineProvider = null;

         //   var header = g.GetChildAt(0);
          //  header.SetBackgroundColor(Color.Transparent.ToAndroid());


            return flyout;
        }
        protected override IShellToolbarTracker CreateTrackerForToolbar(Toolbar toolbar)
        {
            //return base.CreateTrackerForToolbar(toolbar);
            var d = ResourcesCompat.GetDrawable(context.Resources, Resource.Drawable.toolbar_bg, null);
            // toolbar.SetBackground(d);

            var t = base.CreateTrackerForToolbar(toolbar);
            return t;
        }
        //protected override IShellToolbarTracker CreateTrackerForToolbar(Toolbar toolbar)
        //{

        //    var d = ResourcesCompat.GetDrawable(context.Resources, Resource.Drawable.toolbar_bg, null);
        //   // toolbar.SetBackground(d);

        //    var t = base.CreateTrackerForToolbar(toolbar);
        //    return t;
        //}
    }
}
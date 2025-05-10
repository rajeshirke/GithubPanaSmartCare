using System;
using Android.Widget;
using eWarranty.Controls;
using eWarranty.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AView = Android.Views.View;

[assembly: ExportRenderer(typeof(ContentPage), typeof(EWContentPageRenderer))]
namespace eWarranty.Droid.Renderers
{
    public class EWContentPageRenderer : PageRenderer
    {
        public EWContentPageRenderer()
        {
        }


        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
          

        }
        IPageController PageController => Element as IPageController;
        CustomNavigationPage CustomNavigationPage => Element as CustomNavigationPage;
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
           // base.OnLayout(changed, l, t, r, b);
            //CustomNavigationPage.IgnoreLayoutChange = true;
            base.OnLayout(changed, l, t, r, b);
            //CustomNavigationPage.IgnoreLayoutChange = false;

            int containerHeight = b - t;

            PageController.ContainerArea = new Rectangle(0, 0, Context.FromPixels(r - l), Context.FromPixels(containerHeight));

            for (var i = 0; i < ChildCount; i++)
            {
                AView child = GetChildAt(i);

                if (child is Toolbar)
                {
                    continue;
                }

                child.Layout(0, 0, r, b);
            }
        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);



            float pixWidth = (float)Resources.DisplayMetrics.WidthPixels;
            float fdpWidth = (float)App.Current.MainPage.Width;
            float pixPerDp = pixWidth / fdpWidth;

           // this.Element.Padding = new Thickness(0, MainActivity.StatusBarHeight / pixPerDp, 0, 0);

        }
    }
}
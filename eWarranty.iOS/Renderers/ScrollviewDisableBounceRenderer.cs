using System;
using eWarranty.iOS.Renderers;
using eWarranty.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ScrollViewBounce), typeof(ScrollviewDisableBounceRenderer))]
namespace eWarranty.iOS.Renderers
{
    public class ScrollviewDisableBounceRenderer : ScrollViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            try
            {
                Bounces = false;

                if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
                {
                    ContentInsetAdjustmentBehavior = UIKit.UIScrollViewContentInsetAdjustmentBehavior.Never;
                }
            }
            catch (Exception ex)
            {
                //TODO
            }
        }
    }
}
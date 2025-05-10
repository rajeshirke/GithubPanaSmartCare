using System;
using eWarranty.Controls;
using eWarranty.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(ShadowEffect), typeof(ShadowEffectiOS))]
namespace eWarranty.iOS.Renderers
{
    public class ShadowEffectiOS : PlatformEffect
    {
        protected override void OnAttached()
        {
            Control.Layer.ShadowColor = UIColor.Black.CGColor;
            Control.Layer.ShadowOffset = new CoreGraphics.CGSize(4, 4);
            Control.Layer.ShadowOpacity = 1.0f;
            Control.Layer.ShadowRadius = 4.0f;
        }

        protected override void OnDetached()
        {
        }
    }
}

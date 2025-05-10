using System;
using CoreAnimation;
using CoreGraphics;
using eWarranty.Controls;
using eWarranty.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]
namespace eWarranty.iOS.Renderers
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {

                Picker element = (Element as Picker);

                if (element != null)
                {
                    Control.Layer.BorderWidth = 0;
                    Control.BorderStyle = UITextBorderStyle.None;
                   // Control.TextAlignment = UITextAlignment.Center;

                    //CALayer borderLayer = new CALayer();
                    //borderLayer.BackgroundColor = Color.FromHex("#000000").ToCGColor();
                    //borderLayer.Frame = new CGRect(0, 30, 50, 2);
                    //Layer.AddSublayer(borderLayer);
                }
            }
        }
        //protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        //{
        //    base.OnElementChanged(e);

        //    var element = (CustomPicker)this.Element;

        //    if (this.Control != null && this.Element != null && !string.IsNullOrEmpty(element.Image))
        //    {
        //        //this.Control.bo
        //        //var downarrow = UIImage.FromBundle(element.Image);
        //        //Control.RightViewMode = UITextFieldViewMode.Always;
        //        //UIImageView uIImageView = new UIImageView(new CoreGraphics.CGRect(0, 50, 10, 10));
        //        //uIImageView.Image = downarrow;
        //        //Control.RightView = uIImageView;
        //        //Control.ContentMode = UIViewContentMode.ScaleAspectFill;
        //        //	Control.RightView.Bounds = new CoreGraphics.CGRect(10, 20, 20, 20);
        //        //Control.RightViewRect(new CoreGraphics.CGRect(100, 0, 10, 10));
        //        //	Control.Inset
        //        //Control.RightView.Frame.se = new CoreGraphics.CGRect(0, 100, Control.RightView.Frame.Width, Control.RightView.Frame.Height);
        //    }
        //}
    }
}

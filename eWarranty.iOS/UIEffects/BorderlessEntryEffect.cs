using System;
using eWarranty.UIEffects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("eWarranty")]
[assembly: ExportEffect(typeof(BorderlessEntryEffect), "BorderlessEntryEffect")]
namespace eWarranty.iOS.UIEffects
{
    public class BorderlessEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var entry = Control as UITextField;
            if (entry != null)
            {
                entry.BorderStyle = UITextBorderStyle.None;
            }
        }

        protected override void OnDetached()
        {

        }
    }
}
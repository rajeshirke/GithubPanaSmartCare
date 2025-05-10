using System;
using Android.Widget;
using eWarranty.Controls;
using eWarranty.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(ShadowEffect), typeof(ShadowEffectDroid))]
namespace eWarranty.Droid.Renderers
{
    public class ShadowEffectDroid : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var control = Control as TextView;
                if (control != null)
                {
                    float radius = 10;
                    float distanceX = 4;
                    float distanceY = 4;
                    Android.Graphics.Color color = Android.Graphics.Color.Gray;

                    control.SetShadowLayer(radius, distanceX, distanceY, color);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}

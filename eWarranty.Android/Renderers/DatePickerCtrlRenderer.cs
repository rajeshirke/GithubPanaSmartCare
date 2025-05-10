using System;
using Android.Graphics.Drawables;
using eWarranty.Controls;
using eWarranty.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DatePickerCtrl), typeof(DatePickerCtrlRenderer))]

namespace eWarranty.Droid.Renderers
{
    [Obsolete]
    public class DatePickerCtrlRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            this.Control.SetTextColor(Android.Graphics.Color.Black);   
               this.Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            this.Control.SetPadding(20, 0, 0, 0);
           // this.Control.SetBackgroundDrawable(gd);

          //  GradientDrawable gd = new GradientDrawable();
           // SetCornerRadius(25); //increase or decrease to changes the corner look
           // SetColor(Android.Graphics.Color.Transparent);
           // SetStroke(3, Android.Graphics.Color.#533f95;             
         

             DatePickerCtrl element = Element as DatePickerCtrl;
            if (!string.IsNullOrWhiteSpace(element.Placeholder))
            {
                Control.Text = element.Placeholder;
            }
            this.Control.TextChanged += (sender, arg) => {
                var selectedDate = arg.Text.ToString();
                if (selectedDate == element.Placeholder)
                {
                    Control.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            };
        }
    }
}

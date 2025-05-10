using System;
using eWarranty.Controls;
using eWarranty.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(DatePickerCtrl), typeof(DatePickerCtrlRenderer))]
namespace eWarranty.iOS.Renderers
{
    public class DatePickerCtrlRenderer: DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (this.Control == null)
                return;
            var element = e.NewElement as DatePickerCtrl;
            if (!string.IsNullOrWhiteSpace(element.Placeholder))
            {
                Control.Text = element.Placeholder;
            }
            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 2))
            {
                UIDatePicker picker = (UIDatePicker)Control.InputView;
                picker.PreferredDatePickerStyle = UIDatePickerStyle.Wheels;
            }
           // Control.BorderStyle = UITextBorderStyle.RoundedRect;
         //  Control.Layer.BorderColor = UIColor.FromWhiteAlpha(1, 0.5f);// .CGColor;   
           Control.Layer.CornerRadius = 5;
            Control.Layer.BorderWidth = 0f;
            Control.AdjustsFontSizeToFitWidth = true;
            Control.TextColor = UIColor.Black;
            Control.BackgroundColor = UIColor.White;
           Control.ShouldEndEditing += (textField) => {
               var seletedDate = (UITextField)textField;
               var text = seletedDate.Text;
               if (text == element.Placeholder)
               {
                   Control.Text = DateTime.Now.ToString("ddd MM yyyy hh:mm");
               }
               return true;
           };
        }
        private void OnCanceled(object sender, EventArgs e)
        {
            Control.ResignFirstResponder();
        }
        private void OnDone(object sender, EventArgs e)
        {
            Control.ResignFirstResponder();
        }
    }
}

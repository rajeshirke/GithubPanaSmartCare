

using System.Drawing;
using eWarranty.Controls;
using eWarranty.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using CoreAnimation;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace eWarranty.iOS.Renderers
{
	public class ExtendedEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Element == null)
			return;

			if (this.Control != null)
			{

				var customColor = UIColor.FromRGBA(194, 194, 194, 194);
				var borderLayer = new CALayer();
				var frameWidth = Frame.Width;
					
				var widths =  Device.Info.PixelScreenSize.Width;
				var height = Device.Info.PixelScreenSize.Width;

				if (widths <= 750 && height <= 1280)
				{
					frameWidth = frameWidth + 20 ;
				}
				else if (widths > 1242)
				{
					frameWidth = frameWidth + 70 ;
				}
				else 
				{
					frameWidth = frameWidth + 50;
				}


				borderLayer.Frame = new CoreGraphics.CGRect(0f, Frame.Height , frameWidth, 1f);
				borderLayer.BorderColor = customColor.CGColor;

				borderLayer.BorderWidth = 1.0f;
                borderLayer.CornerRadius = 1;
                Control.Layer.AddSublayer(borderLayer);
                Control.BorderStyle = UITextBorderStyle.None;
            }

			// Check only for Numeric keyboard
			if (this.Element.Keyboard == Keyboard.Numeric)
				this.AddDoneButton();
		}

		/// <summary>
		/// <para>Add toolbar with Done button</para>
		/// </summary>
		protected void AddDoneButton()
		{
			var toolbar = new UIToolbar(new RectangleF(0.0f, 0.0f, 50.0f, 44.0f));

			var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate
			{
				this.Control.ResignFirstResponder();
				var baseEntry = this.Element.GetType();
				((IEntryController)Element).SendCompleted();
			});

			toolbar.Items = new UIBarButtonItem[] {
				new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace),
				doneButton
			};
			this.Control.InputAccessoryView = toolbar;
		}
	}
}
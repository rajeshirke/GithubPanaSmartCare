﻿using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using eWarranty.Controls;
using eWarranty.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Editor), typeof(CustomEditorRenderer))]
namespace eWarranty.Droid.Renderers
{
    public class CustomEditorRenderer : EditorRenderer
    {
        bool initial = true;
        Drawable originalBackground;

        public CustomEditorRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                if (initial)
                {
                    originalBackground = Control.Background;
                    initial = false;
                }
                Control.SetMaxLines(5);

            }

            if (e.NewElement != null)
            {
               // var customControl = (ExtendedEditorControl)Element;
                var customControl = (Editor)Element;
                //if (customControl.HasRoundedCorner)
                //{
                //  //  ApplyBorder();
                //}

                if (!string.IsNullOrEmpty(customControl.Placeholder))
                {
                    Control.Hint = customControl.Placeholder;
                    Control.SetHintTextColor(customControl.PlaceholderColor.ToAndroid());

                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var customControl = (Editor)Element;

            if (Editor.PlaceholderProperty.PropertyName == e.PropertyName)
            {
                Control.Hint = customControl.Placeholder;

            }
            else if (Editor.PlaceholderColorProperty.PropertyName == e.PropertyName)
            {

                Control.SetHintTextColor(customControl.PlaceholderColor.ToAndroid());

            }
            //else if (Editor.HasRoundedCornerProperty.PropertyName == e.PropertyName)
            //{
            //    //if (customControl.HasRoundedCorner)
            //    //{
            //    //    ApplyBorder();

            //    //}
            //    //else
            //    //{
            //    //    this.Control.Background = originalBackground;
            //    //}
            //}
            this.Control.Background = originalBackground;
        }

        void ApplyBorder()
        {
            GradientDrawable gd = new GradientDrawable();
            gd.SetCornerRadius(10);
            gd.SetStroke(2, Color.Black.ToAndroid());
            this.Control.Background = gd;
        }
    }
}

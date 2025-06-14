﻿using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
//using Android.Support.V4.Content;
using Android.Views;
using AndroidX.Core.Content;

using eWarranty.Controls;
using eWarranty.Droid.Renderers;
using eWarranty.Hepler;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ImageEntry), typeof(ImageEntryRenderer))]
namespace eWarranty.Droid.Renderers
{
    public class ImageEntryRenderer : EntryRenderer
    {
        ImageEntry element;

        public ImageEntryRenderer(Context context) : base(context)
        {
            
        }
        //protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
            
        //    if (CommonAttribute.flowDirection == FlowDirection.LeftToRight)
        //        Control.LayoutDirection = LayoutDirection.Rtl;
        //    else
        //        Control.LayoutDirection = LayoutDirection.Rtl;
        //    base.OnElementPropertyChanged(sender, e);
        //}
        // PropertyChangingEventArgs
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            element = (ImageEntry)this.Element;


            var editText = this.Control;
            if (!string.IsNullOrEmpty(element.Image))
            {
                switch (element.ImageAlignment)
                {
                    case ImageAlignment.Left:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.Image), null, null, null);
                        break;
                    case ImageAlignment.Right:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.Image), null);
                        break;
                }
            }
            //editText.CompoundDrawablePadding = 30;
            Control.Background.SetColorFilter(element.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
            Control.SetBackgroundResource(Resource.Drawable.rounded_edittext);
        }

        private BitmapDrawable GetDrawable(string imageEntryImage)
        {
            int resID = Resources.GetIdentifier(imageEntryImage, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, element.ImageWidth+15 , element.ImageHeight+15 , true));
        }

    }
}

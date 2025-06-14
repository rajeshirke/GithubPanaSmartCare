﻿using System;
using Xamarin.Forms;

namespace eWarranty.Controls
{
    public class RoundedCornerView : Frame
    {
        public static readonly BindableProperty FillColorProperty = BindableProperty.Create<RoundedCornerView, Color>(w => w.FillColor, Color.White);
        public Color FillColor
        {
            get
            {
                return (Color)GetValue(FillColorProperty);
            }
            set
            {
                SetValue(FillColorProperty, value);
            }
        }
        public static readonly BindableProperty RoundedCornerRadiusProperty = BindableProperty.Create<RoundedCornerView, double>(w => w.RoundedCornerRadius, 3);
        public double RoundedCornerRadius
        {
            get
            {
                return (double)GetValue(RoundedCornerRadiusProperty);
            }
            set
            {
                SetValue(RoundedCornerRadiusProperty, value);
            }
        }
        public static readonly BindableProperty MakeCircleProperty = BindableProperty.Create<RoundedCornerView, Boolean>(w => w.MakeCircle, false);
        public Boolean MakeCircle
        {
            get
            {
                return (Boolean)GetValue(MakeCircleProperty);
            }
            set
            {
                SetValue(MakeCircleProperty, value);
            }
        }
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create<RoundedCornerView, Color>(w => w.BorderColor, Color.Transparent);
        public Color BorderColor
        {
            get
            {
                return (Color)GetValue(BorderColorProperty);
            }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }
        public static readonly BindableProperty ShadowProperty = BindableProperty.Create<RoundedCornerView, bool>(w => w.Shadow, false);
        public bool Shadow
        {
            get
            {
                return (bool)GetValue(ShadowProperty);
            }
            set
            {
                SetValue(ShadowProperty, value);
            }
        }
        //ShadowRadius
        public static readonly BindableProperty ShadowRadiusProperty = BindableProperty.Create<RoundedCornerView, int>(w => w.ShadowRadius, 1);
        public int ShadowRadius
        {
            get
            {
                return (int)GetValue(ShadowRadiusProperty);
            }
            set
            {
                SetValue(ShadowRadiusProperty, value);
            }
        }
        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create<RoundedCornerView, int>(w => w.BorderWidth, 1);
        public int BorderWidth
        {
            get
            {
                return (int)GetValue(BorderWidthProperty);
            }
            set
            {
                SetValue(BorderWidthProperty, value);
            }
        }
    }
}

﻿using System;
using Xamarin.Forms;

namespace eWarranty.Controls
{
	public class CustomPicker : Picker
	{
		public CustomPicker()
        {
			
        }
		public static readonly BindableProperty ImageProperty =
			BindableProperty.Create(nameof(Image), typeof(string), typeof(CustomPicker), string.Empty);

		public string Image
		{
			get { return (string)GetValue(ImageProperty); }
			set { SetValue(ImageProperty, value); }
		}
	}
}

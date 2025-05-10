using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace eWarranty.Views.Customer.CommonPages
{
    public partial class ImagePopupView : ContentPage
    {
        public ImagePopupView(string imageUrl)
        {
            InitializeComponent();

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            //TapGestureRecognizer tapEvent = new TapGestureRecognizer();
            //tapEvent.Tapped += (sender, e) =>
            //{
            //    Navigation.PopModalAsync(this);
            //};

            //CancelImg.GestureRecognizers.Add(tapEvent);

            ZoomImage.Source = imageUrl.Replace("Uri: ", "");
            ZoomImage.Source = imageUrl.Replace("File: ", "");
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}

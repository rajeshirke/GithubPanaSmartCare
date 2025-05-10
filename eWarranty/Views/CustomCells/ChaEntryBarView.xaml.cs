using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace eWarranty.Views.CustomCells
{
    public partial class ChaEntryBarView : ContentView
    {
        public ChaEntryBarView()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.iOS)
            {
                this.SetBinding(HeightRequestProperty, new Binding("Height", BindingMode.OneWay, null, null, null, chatTextInput));
            }
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            chatTextInput.Focus();
        }
        public void UnFocusEntry()
        {
            chatTextInput?.Unfocus();
        }
    }
}

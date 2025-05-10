using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace eWarranty.Views.Technician.TaskViews
{
    public partial class PaymentSuccessfulPage : ContentPage
    {
        public PaymentSuccessfulPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new TechMasterPage();
            //Shell.Current.GoToAsync($"//Customer/DashBoard");
        }
    }
}

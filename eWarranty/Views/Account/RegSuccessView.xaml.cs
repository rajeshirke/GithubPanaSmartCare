using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eWarranty.Hepler;
using eWarranty.Views.AppOnBoard;
using eWarranty.Views.Customer;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eWarranty.Views.Account
{
    public partial class RegSuccessView : ContentPage
    {
        public RegSuccessView()
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetBackButtonTitle(this, "");

            string usernm = CommonAttribute.CustomeProfile?.FirstName;

            LblWelcome.Text = "Welcome " + usernm + "," + "We wish you an amazing Post Sales Support Journey!";
        }

        //void Button_Clicked(System.Object sender, System.EventArgs e)
        //{
        //    Application.Current.MainPage = new DashBoadMasterPage();
        //}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Wait for 3 seconds
            await Task.Delay(4000);
            // Navigate to the main page
            Application.Current.MainPage = new DashBoadMasterPage();
        }
    }
}

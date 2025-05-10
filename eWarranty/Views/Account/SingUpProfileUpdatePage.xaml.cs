using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.ProfileView;
using Xamarin.Forms;

namespace eWarranty.Views.Account
{
    public partial class SingUpProfileUpdatePage : ContentPage
    {
        public SingUpProfileUpdatePage()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = (Color)Application.Current.Resources["BlueColor"];
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
            NavigationPage.SetHasBackButton(this, false);// = "False"
            BindingContext = new MyProfileViewModel(Navigation);
        }

        //void entryArea_Completed(System.Object sender, System.EventArgs e)
        //{
        //    entryApartmentNo.Focus();
        //}
        void entryApartmentNo_Completed(System.Object sender, System.EventArgs e)
        {
            entryBuildingVillaName.Focus();
        }

        void entryBuildingVillaName_Completed(System.Object sender, System.EventArgs e)
        {
            entryStreet.Focus();
        }

        void entryStreet_Completed(System.Object sender, System.EventArgs e)
        {
            entryState.Focus();
        }

        void entryState_Completed(System.Object sender, System.EventArgs e)
        {
            entryPostalcode.Focus();
        }

        
    }
}

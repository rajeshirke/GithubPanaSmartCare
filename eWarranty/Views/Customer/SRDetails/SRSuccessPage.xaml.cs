using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.SRDetails
{
    public partial class SRSuccessPage : ContentPage
    {
        public SRSuccessPage(string msg)
        {
            try
            {

                InitializeComponent();
                lblfrenceNo.Text =   msg;
                NavigationPage.SetHasBackButton(this, false);
                NavigationPage.SetHasNavigationBar(this, false);
            }
            catch (Exception ex)
            {

            }
        }

        void Back_Clicked(System.Object sender, System.EventArgs e)
        {
            var _navigation = Application.Current.MainPage.Navigation;
            var _lastPage = _navigation.NavigationStack.LastOrDefault();

            _navigation.RemovePage(_lastPage);

            var _lastPage1 = _navigation.NavigationStack.LastOrDefault();

            _navigation.RemovePage(_lastPage1);
            var _lastPage2 = _navigation.NavigationStack.LastOrDefault();

            _navigation.RemovePage(_lastPage2);

            var _lastPage3 = _navigation.NavigationStack.LastOrDefault();
            if(_lastPage3 != null)
            _navigation.RemovePage(_lastPage3);

            var _lastPage4 = _navigation.NavigationStack.LastOrDefault();
            if(_lastPage4 != null)
            _navigation.RemovePage(_lastPage4);

            var _lastPage5 = _navigation.NavigationStack.LastOrDefault();
            if(_lastPage5 != null)
             _navigation.RemovePage(_lastPage5);


            _navigation.PushAsync(new ServicesPage());
            // MessagingCenter.Send<SRSuccessPage>(this, "sendsrlist");
        }
    }
}

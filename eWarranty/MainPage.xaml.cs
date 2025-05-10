using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eWarranty.ViewModels.Account;
using eWarranty.Views.Account;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eWarranty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext =  new LoginViewModel(Navigation);
         //   Title = "Monkey Title";
           // opacitySlider.Value = 0.6f;
          //  CustomNavigationPage.SetTitleColor(this, Color.Navy);
           // CustomNavigationPage.SetBarBackground(this, Device.RuntimePlatform == Device.iOS ? "topbg.png" : "topbg");
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}

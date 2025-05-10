using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eWarranty.Core.Common;
using eWarranty.Core.Models;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.ViewModels.Account;
using Xamarin.Forms;

namespace eWarranty.Views.Account
{
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel viewModel { get; set; }
        public LoginPage()
        {
            InitializeComponent();
            //CommonAttribute.selectedLang = new LanguageModel() { LongName = "English", LongCode = "en", lid = 1 };
            BindingContext = viewModel=new LoginViewModel(Navigation);
            //  if (CommonAttribute.flowDirection == null)
            //   CommonAttribute.flowDirection = FlowDirection.LeftToRight;
            // viewModel.flowDirection = CommonAttribute.flowDirection;
            //  picker = new Picker { Title = "Select a monkey", TitleColor = Color.Red };

            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#a786db");
            //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;
        }

        //private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        //{
           
        //    Picker langPicker = sender as Picker;
        //    var selectedItem = langPicker.SelectedItem as LanguageModel;

        //    CommonAttribute.selectedLang = selectedItem;
        //    lblLong.Text = selectedItem.LongName;
        //    viewModel.LoginLangChange(selectedItem.LongCode);
        //    // viewModel.flowDirection=
        //    CommonFunctions.LongCode = CommonAttribute.selectedLang.LongCode;
        //    if (CommonAttribute.selectedLang.LongCode == "ur")
        //    {
        //        viewModel.flowDirection = FlowDirection.RightToLeft;
        //      //  Device.FlowDirection
        //       // Application.Current.MainPage.FlowDirection = FlowDirection.RightToLeft;
        //       // Application.Current.MainPage =new  LoginPage();
        //    }
        //    else
        //        viewModel.flowDirection = FlowDirection.LeftToRight;

            
        //    CommonAttribute.flowDirection = viewModel.flowDirection;
        //   // Application.Current.MainPage = new NavigationPage(new LoginPage());
        //}
        protected async override void OnAppearing()
        {
            if (Application.Current.Properties.ContainsKey("email"))
                viewModel.Email = Application.Current.Properties["email"].ToString();
            base.OnAppearing();
            

        }
        private  void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {

            Device.InvokeOnMainThreadAsync(() => {
               //if (pkLong.IsFocused)
               //     pkLong.Unfocus();

               // pkLong.Focus();
           });
            

        }

        
    }
}

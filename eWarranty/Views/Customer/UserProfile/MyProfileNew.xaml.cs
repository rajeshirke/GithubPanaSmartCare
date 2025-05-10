using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.ViewModels.Customer.ProfileView;
using ImageCircle.Forms.Plugin.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace eWarranty.Views.Customer.UserProfile
{
    public partial class MyProfileNew : ContentPage
    {
        MyProfilePageViewModel viewModel;
        

        public MyProfileNew()
        {

            InitializeComponent();
            BindingContext = viewModel = new MyProfilePageViewModel(Navigation);
            lblLong.Text = CommonAttribute.selectedLang.LongName;
            if (CommonAttribute.CustomeProfile.ProfilePictureFileInfo != null)
            {
                if (Application.Current.Properties.ContainsKey("Photoaction") && Application.Current.Properties["Photoaction"] != null)
                {
                    if (Application.Current.Properties["Photoaction"].ToString() == "Take Photo")
                        PhotoImage.Rotation = 90;

                }

                PhotoImage.Source = CommonAttribute.ImageBaseUrl + CommonAttribute.CustomeProfile.ProfilePictureFileInfo.Path;
            }
            else
                PhotoImage.Source = "userdashbaord.png";

        }
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

            Picker langPicker = sender as Picker;
            var selectedItem = langPicker.SelectedItem as LanguageModel;
            CommonAttribute.selectedLang = selectedItem;
            lblLong.Text = selectedItem.LongName;
            viewModel.ChangeLangugeCommand.Execute(selectedItem.LongCode);
            // viewModel.flowDirection=
            if (CommonAttribute.selectedLang.LongCode == "ur")
            {
                viewModel.flowDirection = FlowDirection.RightToLeft;
                //  Device.FlowDirection
                // Application.Current.MainPage.FlowDirection = FlowDirection.RightToLeft;
                // Application.Current.MainPage =new  LoginPage();
            }
            else
                viewModel.flowDirection = FlowDirection.LeftToRight;


            CommonAttribute.flowDirection = viewModel.flowDirection;
            // Application.Current.MainPage = new NavigationPage(new LoginPage());
        }


        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            Device.InvokeOnMainThreadAsync(() => {
                if (pkLong.IsFocused)
                    pkLong.Unfocus();

                pkLong.Focus();
            });
        }

        void TapGestureRecognizer_Tapped_1(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ProfileUpdatePage());
        }
        void ChnageTapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ChnagePasswordPage());
        }

        void TapGestureRecognizer_Tapped_2(System.Object sender, System.EventArgs e)
        {
            viewModel.IsBusy = true;
            Device.BeginInvokeOnMainThread(async () =>
            {

                FileData fileData = await viewModel.TakePhotoAsync();
                if (!string.IsNullOrEmpty(fileData?.string64baseData))
                {

                    viewModel.UserPic = ImageSource.FromStream(
               () => new MemoryStream(Convert.FromBase64String(fileData.string64baseData)));
                    PhotoImage.Source = viewModel.UserPic;

                    MessagingCenter.Send<MyProfileNew, ImageSource>(this, "UserPhoto", viewModel.UserPic);
                    if (viewModel.Photoaction != "Gallery")
                        PhotoImage.Rotation = 90;
                    else
                        PhotoImage.Rotation = 0;
                    await viewModel.SaveUserPic(fileData);
                }
                viewModel.IsBusy = false;
                

            });

            
        }

        void TapGestureRecognizer_Tapped_3(System.Object sender, System.EventArgs e)
        {
            viewModel.IsBusy = true;
            Device.BeginInvokeOnMainThread(async () =>
            {

                FileData fileData = await viewModel.TakePhotoAsync();
                if (!string.IsNullOrEmpty(fileData?.string64baseData))
                {

                    viewModel.UserPic = ImageSource.FromStream(
               () => new MemoryStream(Convert.FromBase64String(fileData.string64baseData)));
                    PhotoImage.Source = viewModel.UserPic;

                    MessagingCenter.Send<MyProfileNew, ImageSource>(this, "UserPhoto", viewModel.UserPic);
                    if (viewModel.Photoaction != "Gallery")
                        PhotoImage.Rotation = 90;
                    else
                        PhotoImage.Rotation = 0;
                    await viewModel.SaveUserPic(fileData);
                }
                viewModel.IsBusy = false;

            });
        }

    }
}

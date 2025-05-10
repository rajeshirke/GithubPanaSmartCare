using System;
using System.Collections.Generic;
using System.IO;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.ViewModels.Customer.ProfileView;
using eWarranty.Views.Customer.UserProfile;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.ProfileViews
{
    public partial class MyProfilePage : ContentPage
    {
        public MyProfilePageViewModel viewModel { get; set; }
        public MyProfilePage()
        {
            InitializeComponent();
            BindingContext = viewModel= new MyProfilePageViewModel(Navigation);
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
                PhotoImage.Source = "userdashbaord";
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ChnagePasswordPage());
        }

        void TapGestureRecognizer_Tapped_1(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ProfileUpdatePage());
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

                    MessagingCenter.Send<MyProfilePage, ImageSource>(this, "UserPhoto", viewModel.UserPic);
                    if (viewModel.Photoaction != "Gallery")
                        PhotoImage.Rotation = 90;
                    else
                        PhotoImage.Rotation = 0;
                    await viewModel.SaveUserPic(fileData);
                }
                viewModel.IsBusy = false;
                //        FileData fileData = await viewModel.TakePhotoAsync();
                //        viewModel.UserPic = ImageSource.FromStream(
                //() => new MemoryStream(Convert.FromBase64String(fileData.string64baseData)));
                //        var newFile = Path.Combine(FileSystem.CacheDirectory, fileData.FileName);
                //        Application.Current.Properties["userpic"] = viewModel.UserPic;
            });
        }        //ChnageTapGestureRecognizer_Tapped

    }
}

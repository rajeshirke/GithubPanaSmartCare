using System;
using System.Collections.Generic;
using eWarranty.Hepler;
using eWarranty.ViewModels.Customer;
using eWarranty.ViewModels.Supervisor;
using Xamarin.Forms;

namespace eWarranty.Views.Supervisor
{
    public partial class SupDashboardLeftSideMenu : Shell
    {
        public SupLeftSideMenuViewModel viewModel { get; set; }

        public SupDashboardLeftSideMenu()
        {
            InitializeComponent();
            BindingContext = viewModel = new SupLeftSideMenuViewModel(Navigation);

            MessagingCenter.Unsubscribe<MyProfilePageSup, ImageSource>(this, "UserPhotoSup");
            MessagingCenter.Subscribe<MyProfilePageSup, ImageSource>(this, "UserPhotoSup", (sender, img) =>
            {
                imgUserPic.Source = img;

            });
            if (CommonAttribute.CustomeProfile.ProfilePictureFileInfo != null)
            {
                if (Application.Current.Properties.ContainsKey("Photoaction") && Application.Current.Properties["Photoaction"] != null)
                {
                    if (Application.Current.Properties["Photoaction"].ToString() == "Take Photo")
                        imgUserPic.Rotation = 90;

                }

                imgUserPic.Source = CommonAttribute.ImageBaseUrl + CommonAttribute.CustomeProfile.ProfilePictureFileInfo.Path;
            }
            else
                imgUserPic.Source = "userdashbaord.png";
        }

        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {

        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {

        }
    }
}

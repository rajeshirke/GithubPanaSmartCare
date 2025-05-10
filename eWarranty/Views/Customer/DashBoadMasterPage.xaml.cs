using System;
using System.Collections.Generic;
using System.Linq;
using eWarranty.Core.Enums;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.DependencyServices;
using eWarranty.Hepler;
using eWarranty.ViewModels.Customer;
using eWarranty.Views.Customer.Products;
using eWarranty.Views.Customer.UserProfile;
using Plugin.FirebasePushNotification;
using Xamarin.Forms;

namespace eWarranty.Views.Customer
{
    public partial class DashBoadMasterPage : Shell
    {
        private void Current_OnNotificationReceived(object source, FirebasePushNotificationDataEventArgs e)
        {
            DisplayAlert("Notification", $"Data: {e.Data["myData"]}", "OK");
        }
        private async void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            // System.Diagnostics.Debug.WriteLine($"Token: {e.Token}");
           // Console.WriteLine($"Token: {e.Token}");
            UserManagementSL userManagementSL = new UserManagementSL();
            PushNotificationToken pushNotificationToken = new PushNotificationToken();
            if (Device.RuntimePlatform == Device.Android)
            {
                pushNotificationToken.OstypeId = Convert.ToInt16(OStypeEnum.Android);
                pushNotificationToken.OstypeName = "Android";
            }
            else
            {
                pushNotificationToken.OstypeId = Convert.ToInt16(OStypeEnum.iOS);
                pushNotificationToken.OstypeName = "iOS";
            }
            pushNotificationToken.PersonId = CommonAttribute.CustomeProfile.PersonId;
            pushNotificationToken.Token = e.Token;
            pushNotificationToken.UpdatedDate = DateTime.Now;
           await userManagementSL.CreateUpdatePushNotificationToken(pushNotificationToken);
        }
        public eWMasterDetailViewModel viewModel { get; set; }
        public DashBoadMasterPage()
        {
            Device.SetFlags(new[] {
                "Brush_Experimental",
            });
            InitializeComponent();
            
            //if (Device.RuntimePlatform == Device.iOS)
            //{
            //    CrossFirebasePushNotification.Current.OnNotificationReceived += Current_OnNotificationReceived;
            //}
            //CrossFirebasePushNotification.Current.Subscribe("all");
            //CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;
            //   var navPage=Application.Current.MainPage
            //   Brush brush = new Brush();

            BindingContext = viewModel= new eWMasterDetailViewModel(Navigation);
            int menuCount = CurrentShell.Items.Count;
            for (int i = 0; i < menuCount; i++)
            {
                MenuSetup();
            }


            //  FlyoutIsPresented = true;
            MessagingCenter.Subscribe<DashBoardPage>(this, "Hi", (sender) =>
            {
                if (FlyoutIsPresented)
                    FlyoutIsPresented = false;

                FlyoutIsPresented = true;
            });
            MessagingCenter.Unsubscribe<MyProfilePage, ImageSource>(this, "UserPhoto");
            MessagingCenter.Subscribe<MyProfilePage,ImageSource>(this, "UserPhoto", (sender,img) =>
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
        public void MenuSetup()
        {
            foreach (ShellItem item in CurrentShell.Items)
            {
                if (item.Title == "Products")
                {
                    if (!viewModel.IsRegisterProduct)
                    {
                        CurrentShell.Items.Remove(item);
                        break;
                    }

                }
                else if (item.Title == "Services History")
                {
                    if (!viewModel.IsServices)
                    {
                        CurrentShell.Items.Remove(item);
                        break;
                    }

                }
                else if (item.Title == "Chat History")
                {
                    if (!viewModel.IsChat)
                    {
                        CurrentShell.Items.Remove(item);
                        break;
                    }

                }
                else if (item.Title == "Survey")
                {
                    if (!viewModel.IsSurvey)
                    {
                        CurrentShell.Items.Remove(item);
                        break;
                    }

                }
                else if (item.Title == "Terms &amp; Conditions")
                {
                    if (!viewModel.IsTermsandCondition)
                    {
                        CurrentShell.Items.Remove(item);
                        break;
                    }

                }
                else if (item.Title == "Service Center")
                {
                    if (!viewModel.IsServiceCenter)
                    {
                        CurrentShell.Items.Remove(item);
                        break;
                    }

                }
                else if (item.Title == "My Account")
                {
                    if (!viewModel.IsProfile)
                    {
                        CurrentShell.Items.Remove(item);
                        break;
                    }

                }
                else if (item.Title == "My Orders")
                {
                    if (!viewModel.IsOrders)
                    {
                        CurrentShell.Items.Remove(item);
                        break;
                    }

                }
                else if (item.Title == "Buy Amc")
                {
                    if (!viewModel.IsOrders)
                    {
                        CurrentShell.Items.Remove(item);
                        break;
                    }

                }
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
        }
        private void BtnMenu_Clicked(object sender, EventArgs e)
        {
            if (FlyoutIsPresented)
                FlyoutIsPresented = false;

            FlyoutIsPresented = true;
        }
        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            
        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
            
        }
    }
}

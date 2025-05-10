using System;
using System.Collections.Generic;
using System.Linq;
using eWarranty.DependencyServices;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.ViewModels.Customer;
using eWarranty.Views.AppOnBoard;
using Plugin.LocalNotification;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eWarranty.Views.Customer
{
    public partial class DashBoardPage : ContentPage
    {
        DashBoardViewModel viewModel;
        public ToolbarItem toolbarItem { get; set; }
        public DashBoardPage()
        {
            InitializeComponent();
            BindingContext = viewModel= new DashBoardViewModel(Navigation);
            AppResources.Culture = System.Globalization.CultureInfo.CurrentUICulture;
            Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
            {

                cvBanners.Position = (cvBanners.Position + 1) % viewModel.BannersData.Count;

                return true;
            }));
            toolbarItem = new ToolbarItem
            {
                Text = "dashbord",
                IconImageSource = ImageSource.FromFile("info.png"),
                Order = ToolbarItemOrder.Primary,
                Command= viewModel.UserNotificationsCommand,
                Priority = 0
            };

            // "this" refers to a Page object
            this.ToolbarItems.Add(toolbarItem);
            //    ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Transparent;
            // NavigationPage.SetHasNavigationBar(this, false);
            // this.NavigationPage.BarBackgroundColor = Color.Transparent;
            //  btnMenu.Clicked += BtnMenu_Clicked;
            // this.na

            var UserName = CommonAttribute.CustomeProfile?.FirstName;
            var hour = DateTime.Now.Hour;

            if (hour >= 12 && hour < 17)
            {
                lblGreetings.Text = "Good Afternoon" + " " + UserName;
            }
            else if (hour >= 17 && hour < 21)
            {
                lblGreetings.Text = "Good Evening" + " " + UserName;
            }
            else if (hour >= 21 && hour < 24)
            {
                lblGreetings.Text = "Good Night" + " " + UserName;
            }
            else
            {
                lblGreetings.Text = "Good Morning" + " " + UserName;
            }

        }

        private void Current_NotificationTapped(NotificationTappedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                DisplayAlert("Notification tapped", e.Data, "OK");
            });
        }

        private void Current_NotificationReceived(NotificationReceivedEventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert(e.Title, e.Description, "OK");
                });
            }
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "Test Description",
                Title = "Notification!",
                ReturningData = "Dummy Data",
                NotificationId = 1337,
                NotifyTime = DateTime.Now.AddSeconds(5)
            };

            NotificationCenter.Current.Show(notification);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            int result = await viewModel.BindingData();
            if (ToolbarItems.Count > 0)
            {
               // result = 2;
                DependencyService.Get<IToolbarItemBadgeService>().SetBadge(this, toolbarItem, $"{result}", Color.Red, Color.White);
            }
        }
        private void BtnMenu_Clicked(object sender, EventArgs e)
        {
            //if(Shell.Current.FlyoutIsPresented)
               Shell.Current.FlyoutIsPresented = true;
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
           // MessagingCenter.Send<DashBoardPage>(this, "Hi");


        }
    }
}

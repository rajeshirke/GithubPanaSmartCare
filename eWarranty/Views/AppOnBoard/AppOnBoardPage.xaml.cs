using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using eWarranty.Core.Enums;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Views.Customer;
using eWarranty.Views.Supervisor;
using eWarranty.Views.Technician;
using Xamarin.Forms;

namespace eWarranty.Views.AppOnBoard
{
    public partial class AppOnBoardPage : ContentPage
    {

        private ObservableCollection<AppOnBoardDetails> _obAppOnBoardDetails;
        public ObservableCollection<AppOnBoardDetails> obAppOnBoardDetails
        {
            get { return _obAppOnBoardDetails; }
            set
            {
                _obAppOnBoardDetails = value;
                OnPropertyChanged(nameof(obAppOnBoardDetails));
            }
        }

        public AppOnBoardPage()
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetBackButtonTitle(this, "");
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.White;
            //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;


            obAppOnBoardDetails = new ObservableCollection<AppOnBoardDetails>();

            obAppOnBoardDetails.Add(new AppOnBoardDetails { BannerImage = "apponboard.png", Discription = "Explore some exciting offers inside application!!!" });
            obAppOnBoardDetails.Add(new AppOnBoardDetails { BannerImage = "apponboardtwo.png", Discription = "Explore some exciting offers inside application!!!" });

            carouselView.ItemsSource = obAppOnBoardDetails;
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            //Application.Current.MainPage = new DashBoadMasterPage();
            //await Navigation.PushAsync(new DashBoadMasterPage());

            if (CommonAttribute.CustomeProfile.PersonRoleId == Convert.ToInt16(PersonRoleEnum.Customer))
            {
                Application.Current.MainPage = new DashBoadMasterPage();
            }
            //else if (CommonAttribute.CustomeProfile.PersonRoleId == Convert.ToInt16(PersonRoleEnum.Technician))
            //{
            //    //CommonAttribute.CustomeProfile = receiveContext.data;
            //    Application.Current.MainPage = new TechMasterPage();
            //}
            //else if (CommonAttribute.CustomeProfile.PersonRoleId == Convert.ToInt16(PersonRoleEnum.Supervisor))
            //{
            //    //CommonAttribute.CustomeProfile = receiveContext.data;
            //    Application.Current.MainPage = new SupDashboardLeftSideMenu();
            //}
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //Navigation.RemovePage(this);
        }
    }
}

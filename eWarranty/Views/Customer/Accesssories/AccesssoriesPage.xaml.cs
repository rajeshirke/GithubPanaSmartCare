using System;
using System.Collections.Generic;
using System.Linq;
using eWarranty.Core.Models;
using eWarranty.Core.ServiceLayer;
using eWarranty.DependencyServices;
using eWarranty.Hepler;
using eWarranty.ViewModels.Customer.Accesssories;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.Accesssories
{
    public partial class AccesssoriesPage : ContentPage
    {
        public AccesssoriesViewModel viewModel { get; set; }
        public AccesssoriesPage()
        {
            try
            {
                InitializeComponent();
                BindingContext = viewModel=new AccesssoriesViewModel(Navigation);
                // CommonAttribute.CartCount = 1;
                // DependencyService.Get<IToolbarItemBadgeService>().SetBadge(this, ToolbarItems.First(), $"1", Color.Red, Color.White);

                //if (viewModel.ServiceCentors != null)
                //{
                //    ServiceCenterLocation.ItemsSource = viewModel.ServiceCentors;
                //    ServiceCenterLocation.SelectedItem = viewModel.ServiceCentors[0];
                //}
                //if (viewModel.BannersData != null)
                //{
                //    Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
                //    {
                //        cvBanners.Position = (cvBanners.Position + 1) % viewModel.BannersData.Count;
                //        return true;
                //    }));
                //}
            }
            catch(Exception ex)
            { }
        }
       
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //CommonAttribute.CartCount = await viewModel.GetCartCount();
           // DependencyService.Get<IToolbarItemBadgeService>().SetBadge(this, ToolbarItems.First(), $"{CommonAttribute.CartCount}", Color.Red, Color.White);

        }
        public void SetupCartCount()
        {
            try
            {
                if (ToolbarItems.Count > 0)
                {
                    if (CommonAttribute.CartCount != 0)
                        DependencyService.Get<IToolbarItemBadgeService>().SetBadge(this, ToolbarItems.First(), $"{CommonAttribute.CartCount}", Color.Red, Color.White);

                }
                // MessagingCenter.Send<AccesssoriesDetailsPage>(this, "cartcount");
                //MessagingCenter.Unsubscribe<AccesssoriesDetailsPage>(this, "cartcount");

                //MessagingCenter.Subscribe<AccesssoriesDetailsPage>(this, "cartcount", (obj) =>
                //{
                //     if (CommonAttribute.CartCount != 0)
                //         DependencyService.Get<IToolbarItemBadgeService>().SetBadge(this, ToolbarItems.First(), $"{CommonAttribute.CartCount}", Color.Red, Color.White);

                // });
            }
            catch (Exception ex)
            {

            }
        }

        void sbAccessories_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                viewModel.txtDeviceName = e.NewTextValue;
                viewModel.SearchProductCommand.Execute(e.NewTextValue);
            }
            else
                viewModel.BindingData();
        }

        void ServiceCenterLocation_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            viewModel.SelectedLocation = picker.SelectedItem.ToString();
        }

    }
}

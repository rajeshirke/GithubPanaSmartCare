using System;
using System.Collections.Generic;
using System.Linq;
using eWarranty.Core.ResponseModels;
using eWarranty.DependencyServices;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.ViewModels.Customer.Accesssories;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.Accesssories
{
    public partial class AccesssoriesDetailsPage : ContentPage
    {
        public AccesssoriesDetailsViewModel viewModel { get; set; }
        public AccesssoriesDetailsPage(AccessoryResponse model)
        {
            InitializeComponent();
            BindingContext = viewModel= new AccesssoriesDetailsViewModel(Navigation, model);
            if (CommonAttribute.CartCount != 0)
                DependencyService.Get<IToolbarItemBadgeService>().SetBadge(this, ToolbarItems.First(), $"{CommonAttribute.CartCount}", Color.Red, Color.White);
            
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            CommonAttribute.CartCount =await viewModel.GetCartCount();
            DependencyService.Get<IToolbarItemBadgeService>().SetBadge(this, ToolbarItems.First(), $"{CommonAttribute.CartCount}", Color.Red, Color.White);

        }
        //CheckoutPage
        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (ToolbarItems.Count > 0)
                {
                    CommonAttribute.CartCount = CommonAttribute.CartCount + 1;
                    if (CommonAttribute.CartCount != 0)
                        DependencyService.Get<IToolbarItemBadgeService>().SetBadge(this, ToolbarItems.First(), $"{CommonAttribute.CartCount}", Color.Red, Color.White);

                    // MessagingCenter.Send<AccesssoriesDetailsPage>(this, "cartcount");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}

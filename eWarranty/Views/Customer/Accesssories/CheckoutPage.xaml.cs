using System;
using System.Collections.Generic;
using System.Linq;
using eWarranty.DependencyServices;
using eWarranty.Hepler;
using eWarranty.ViewModels.Customer.Accesssories;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.Accesssories
{
    public partial class CheckoutPage : ContentPage
    {
        public CheckoutPage()
        {
            InitializeComponent();
            BindingContext = new CheckoutViewModel(Navigation);
            if (ToolbarItems.Count > 0)
            {
                if (CommonAttribute.CartCount != 0)
                    DependencyService.Get<IToolbarItemBadgeService>().SetBadge(this, ToolbarItems.First(), $"{CommonAttribute.CartCount}", Color.Red, Color.White);

            }
        }
        public CheckoutPage(string cart)
        {
            InitializeComponent();
            BindingContext = new CheckoutViewModel(Navigation,cart);
            if (ToolbarItems.Count > 0)
            {
                if (CommonAttribute.CartCount != 0)
                    DependencyService.Get<IToolbarItemBadgeService>().SetBadge(this, ToolbarItems.First(), $"{CommonAttribute.CartCount}", Color.Red, Color.White);

            }
        }
    }
}

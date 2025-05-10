using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.CommonPages;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.CommonPages
{
    public partial class UserNotificationsPage : ContentPage
    {
        public UserNotificationsPage()
        {
            InitializeComponent();
            BindingContext = new NotificationsViewModel(Navigation);
        }
    }
}

using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.SRDetails.SubViews;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.SRDetails.SubViews
{
    public partial class AddFollowUpPage : PopupPage
    {
        [Obsolete]
        public AddFollowUpPage()
        {
            InitializeComponent();
            BindingContext = new AddFllowUpViewModel(Navigation);
        }
    }
}

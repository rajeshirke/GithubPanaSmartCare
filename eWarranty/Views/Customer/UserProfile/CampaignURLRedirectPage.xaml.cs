using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace eWarranty.Views.Customer.UserProfile
{
    public partial class CampaignURLRedirectPage : ContentPage
    {
        public CampaignURLRedirectPage(string strURL)
        {
            InitializeComponent();
            CampaignURL.Source = strURL;
        }
    }
}

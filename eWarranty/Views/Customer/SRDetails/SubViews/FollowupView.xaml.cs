using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Customer.SRDetails.SubViews;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.SRDetails.SubViews
{
    public partial class FollowupView : ContentView
    {
        public FollowupView(long rsid)
        {
            InitializeComponent();
            BindingContext = new FollowupsViewModel(Navigation, rsid);
        }
    }
}

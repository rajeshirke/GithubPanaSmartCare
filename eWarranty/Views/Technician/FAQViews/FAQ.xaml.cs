using System;
using System.Collections.Generic;
using eWarranty.ViewModels.Technician.FAQViews;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.FAQViews
{
    public partial class FAQ : ContentPage
    {
        public TechnicianFAQViewModel viewModel { get; set; }

        public FAQ()
        {
            InitializeComponent();
            //lblmsg.IsVisible = false;
            //  gdDealer.IsVisible = false;
            BindingContext = viewModel = new TechnicianFAQViewModel(Navigation);

            //< dm:AutoSuggestBox x:Name = "SuggestBox1" Grid.Row = "2"
            //              PlaceholderText = "Enter a country"
            //              TextChanged = "SuggestBox_TextChanged"
            //              QuerySubmitted = "SuggestBox_QuerySubmitted" />



            //  slAutoSuggestBoxSR.Children.Add(autoSuggestBoxSR);

        }
    }
}

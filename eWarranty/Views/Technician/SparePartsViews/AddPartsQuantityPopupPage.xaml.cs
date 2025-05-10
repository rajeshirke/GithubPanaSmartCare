using System;
using System.Collections.Generic;
using eWarranty.Core.Models;
using eWarranty.ViewModels.Technician.SparePartsView;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.SparePartsViews
{
    public partial class AddPartsQuantityPopupPage
    {
        public AddPartsQuantityPopupPage(PartStockMaster partStockMaster)
        {
            InitializeComponent();
            BindingContext = new SparePartsViewModel(Navigation, partStockMaster);
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}

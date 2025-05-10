using System;
using System.Collections.Generic;
using System.Linq;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Resx;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.SparePartsViews
{
    public partial class ReturnPartPopupView
    {
        //public string ReturnPartNumber { get; set; }
        //public int ReturnQty { get; set; }
        //public string Description { get; set; }
        public int ExistingQty { get; set; }

        public ReturnPartPopupView(PartStockMaster partStockMaster)
        {
            InitializeComponent();
            ReturnPartNumber.Text = partStockMaster.PartNumber;
            ReturnQty.Text = partStockMaster.Quantity.ToString();
            ExistingQty= partStockMaster.Quantity;
            Description.Text = partStockMaster.Description;
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            IsBusy = true;
            if (string.IsNullOrEmpty(ReturnPartNumber.Text))
            {
                await DisplayAlert(AppResources.lblError, "Please enter part number.", AppResources.lblOk);
                return;
            }
            if(string.IsNullOrEmpty(ReturnQty.Text))
            {
                await DisplayAlert(AppResources.lblError, "Please enter quantity.", AppResources.lblOk);
                return;
            }
            if (Convert.ToInt16(ReturnQty.Text) > ExistingQty)
            {
                await DisplayAlert(AppResources.lblError, "Quantity should not be greater than the available quantity.", AppResources.lblOk);
                return;
            }
            ReturnSpareParts = new PartRequest();
            TechnicianManagementSL managementSL = new TechnicianManagementSL();
            
            ReturnSpareParts.ServiceCenterId = CommonAttribute.CustomeProfile.PersonServiceCenters.FirstOrDefault().ServiceCenterId;
            ReturnSpareParts.RequestDate = DateTime.Now;
            ReturnSpareParts.RequestedByTechnicianId = CommonAttribute.CustomeProfile.PersonId;
            ReturnSpareParts.PartUsedInServiceFromBucketId = (int)PartStockBucketEnum.AllocatedStock;
            ReturnSpareParts.PartRequestTypeId = Convert.ToInt16(PartRequestTypeEnum.ReturnRequest);
            ReturnSpareParts.PartRequestStatusId = Convert.ToInt16(PartRequestStatusEnum.Open);
            ReturnSpareParts.UpdatedDate = DateTime.Now;
            ReturnSpareParts.PartNumber = ReturnPartNumber.Text;
            ReturnSpareParts.RequestedPartQuantity = Convert.ToInt32(ReturnQty.Text);
            ReturnSpareParts.TechnicianRemark = Description.Text;
            
            var receiveContext = await managementSL.AddPartRequests(ReturnSpareParts);
            if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
            {
                await DisplayAlert(AppResources.lblSuccess, receiveContext.message, AppResources.lblOk);
                await PopupNavigation.Instance.PopAsync();
            }
            else if (receiveContext != null)
            {
                await DisplayAlert(AppResources.lblError, receiveContext.errorMessage, AppResources.lblOk);
                await PopupNavigation.Instance.PopAsync();
            }
            else
            {
                await DisplayAlert(AppResources.lblError, Resx.AppResources.lblErrorTitle, AppResources.lblOk);
                await PopupNavigation.Instance.PopAsync();
            }
            IsBusy = false;
        }

        private PartRequest _SpareParts;
        public PartRequest ReturnSpareParts
        {
            get { return _SpareParts; }
            set
            {
                _SpareParts = value;
                OnPropertyChanged();
            }
        }
    }
}

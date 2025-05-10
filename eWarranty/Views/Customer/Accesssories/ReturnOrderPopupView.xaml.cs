using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.ViewModels.Customer.Accesssories;
using eWarranty.Views.Customer.InquiryView;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace eWarranty.Views.Customer.Accesssories
{
    public partial class ReturnOrderPopupView
    {
        public MyOrderDetailsViewModel viewModel { get; set; }
        public ReturnOrderPopupView(OrderResponse order)
        {
            InitializeComponent();            
            lstReturnOrder.ItemsSource = order.OrderDetails;
            order.OrderDetails.ForEach(c => c.CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode);
            OrderResponses = order;
        }

        async void btnReturnOrder_Clicked(System.Object sender, System.EventArgs e)
        {
            FullOrderReturnRequest fullOrderReturnRequest = new FullOrderReturnRequest();
            fullOrderReturnRequest.OrderId = OrderResponses.OrderId;
            fullOrderReturnRequest.Reason = "";

            AccessoryManagementSL accessoryManagementSL = new AccessoryManagementSL();
            APIResponse receiveContext = await accessoryManagementSL.FullReturnOrder(fullOrderReturnRequest);
            if (receiveContext?.Status == Convert.ToInt16(APIResponseEnum.Success))
            {
                IsBusy = false;
                await Navigation.PushAsync(new FeedBackSuccessPage("ReturnOrder"));
                await PopupNavigation.Instance.PopAsync();

            }
            else if (receiveContext != null)
            {
                IsBusy = false;
                string msg = CommonFunctions.GetMessagesByLanguage(receiveContext, CommonAttribute.selectedLang.lid);
                await Application.Current.MainPage.DisplayAlert("", msg, AppResources.lblCancel);
            }
            else
            {
                await DisplayAlert("", AppResources.servererror, AppResources.lblOk);
                IsBusy = false;
            }
            }

        private OrderResponse _OrderResponses;
        public OrderResponse OrderResponses
        {
            get { return _OrderResponses; }
            set
            {
                _OrderResponses = value;
                OnPropertyChanged("OrderResponses");
            }
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}

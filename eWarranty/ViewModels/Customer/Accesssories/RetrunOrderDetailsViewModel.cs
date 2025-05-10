using System;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.Views.Customer.InquiryView;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.Accesssories
{
    public class RetrunOrderDetailsViewModel : BaseViewModel
    {
        public RetrunOrderDetailsViewModel(INavigation navigation, OrderDetailResponse order) : base(navigation)
        {
            OrderResponses = order;
            OrderResponses.CurrencyCode= CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode;
        }
        private OrderDetailResponse _OrderResponses;
        public OrderDetailResponse OrderResponses
        {
            get { return _OrderResponses; }
            set
            {
                _OrderResponses = value;
                OnPropertyChanged("OrderResponses");
            }
        }
        public Command SaveCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (string.IsNullOrEmpty(Description))
                        {
                            await ErrorDisplayAlert(AppResources.lblPleaseenterdescription);
                            return;
                        }
                        IsBusy = true;
                        AccessoryManagementSL accessoryManagementSL = new AccessoryManagementSL();
                        OrderReturnRequest returnOrderRequest = new OrderReturnRequest();
                        returnOrderRequest.Reason = Description;
                        returnOrderRequest.OrderDetailId = OrderResponses.OrderDetailId;
                        returnOrderRequest.Quantity = OrderResponses.Quantity;
                        returnOrderRequest.ServiceCenterID = Convert.ToInt16(OrderResponses.ServiceCenterId);
                        APIResponse receiveContext = await accessoryManagementSL.ReturnOrderRequest(returnOrderRequest);
                        if (receiveContext?.Status == Convert.ToInt16(APIResponseEnum.Success))
                        {
                            IsBusy = false;
                            await Navigation.PushAsync(new FeedBackSuccessPage("ReturnOrder"));
                        }
                        else if (receiveContext != null)
                        {
                            IsBusy = false;
                            //string msg = CommonFunctions.GetMessagesByLanguage(receiveContext, CommonAttribute.selectedLang.lid);

                            await Application.Current.MainPage.DisplayAlert("", AppResources.lblErrorFailedReturnOrder, AppResources.lblCancel);
                        }
                        else
                        {
                            await ErrorDisplayAlert(AppResources.servererror);
                            IsBusy = false;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    

                });
            }
        }
        private string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                OnPropertyChanged("Description");
            }
        }
        //Description
    }
}

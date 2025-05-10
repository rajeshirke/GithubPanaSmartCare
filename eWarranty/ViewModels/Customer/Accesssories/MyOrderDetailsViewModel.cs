using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.Views.Customer.Accesssories;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace eWarranty.ViewModels.Customer.Accesssories
{
    public class MyOrderDetailsViewModel : BaseViewModel
    {
        DateTime FutureDate;
        public MyOrderDetailsViewModel(INavigation navigation, OrderListResponse order) : base(navigation)
        {
            CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode;
            OrderResponsesNew = order;

            IsBusy = true;
            BindingData();

            //Device.BeginInvokeOnMainThread(async () =>
            //{
            //    await BindingData();
            //    IsBusy = false;
            //});

            //OrderDetails = new ObservableCollection<OrderDetailResponse>(OrderResponses.OrderDetails);
            //OrderDetails.ForEach(c => c.CurrencyCode = CurrencyCode);
            //IsReturnFullOrderVisible = true;
            //foreach (var item in OrderDetails)
            //{
            //    if (item.IsReturnOrderVisible == false)
            //    {
            //        IsReturnFullOrderVisible = false;
            //        break;
            //    }
            //}

            //NetAmount = OrderResponses.NetAmount;
            //DiscountAmount = OrderResponses.DiscountAmount;
            //TaxAmount = OrderResponses.TaxAmount;
            //TotalAmount = OrderResponses.TotalAmount;
            //SubTotalAmount = OrderResponses.SubTotalAmount;
            //SubTotalAmount = Math.Round(SubTotalAmount, 2);
            //ShippingFee = 0; ShippingFee = Math.Round(ShippingFee, 2);
            //PromoDiscountAmount = 0; PromoDiscountAmount = Math.Round(PromoDiscountAmount, 2);
            ////TaxAmount = OrderResponses.TaxAmount;
            ////TaxAmount = Math.Round((TaxRate / 100) * SubTotalAmount + ShippingFee, 2);

            //if (!string.IsNullOrEmpty(OrderResponses.DeliveryAddress?.ApartmentNumber))
            //    AddressString = OrderResponses.DeliveryAddress?.ApartmentNumber;
            //if (!string.IsNullOrEmpty(OrderResponses.DeliveryAddress?.BuildingName))
            //    AddressString = AddressString + ", " + OrderResponses.DeliveryAddress?.BuildingName;
            //if (!string.IsNullOrEmpty(OrderResponses.DeliveryAddress?.Area))
            //    AddressString = AddressString + ", " + OrderResponses.DeliveryAddress?.Area;
            //if (!string.IsNullOrEmpty(OrderResponses.DeliveryAddress?.City))
            //    AddressString = AddressString + ", " + OrderResponses.DeliveryAddress?.City;
            //if (!string.IsNullOrEmpty(OrderResponses.DeliveryAddress?.CountryName))
            //    AddressString = AddressString + ", " + OrderResponses.DeliveryAddress?.CountryName;

            ////FutureDate = OrderResponses.OrderDate.AddDays(7);
            ////if (OrderResponses.OrderDetails.Where())
            ////{ }
            //if(CommonAttribute.CustomeProfile!=null)
            //{
            //    string firstname= CommonAttribute.CustomeProfile?.FirstName;
            //    string lastname= CommonAttribute.CustomeProfile?.LastName;
            //    CustName = firstname + " " + lastname;
            //    if (CommonAttribute.CustomeProfile?.MobileNumber != null)
            //        CustContactDetail = CommonAttribute.CustomeProfile?.MobileNumber;
            //    else
            //        CustContactDetail = CommonAttribute.CustomeProfile?.AlternateMobileNumber;

            //    TaxRate = Convert.ToDecimal(CommonAttribute.CustomeProfile.CountryResponse?.CountryLevelSettingResponse?.TaxPercentage);

            //}
            //else
            //{
            //    CustName = "";
            //    CustContactDetail = "";
            //}

        }

        public async void BindingData()
        {
            try
            {
                OrderResponses = new OrderResponse();
                AccessoryManagementSL accessoryManagementSL = new AccessoryManagementSL();
                var orders = await accessoryManagementSL.GetOrdersByOrderIdPersonId(OrderResponsesNew.OrderId, (long)(CommonAttribute.CustomeProfile?.PersonId));
                if(orders != null)
                {
                    //var orders = await accessoryManagementSL.GetOrdersByPersonId((long)(CommonAttribute.CustomeProfile?.PersonId));
                    ////OrderResponsesList = new ObservableCollection<OrderResponse>(orders);
                    OrderResponses = orders;
                    OrderDetails = new ObservableCollection<OrderDetailResponse>(orders.OrderDetails);
                    OrderDetails.ForEach(c => c.CurrencyCode = CurrencyCode);
                    if (Device.RuntimePlatform == Device.Android)
                        OrderDetailsLength = OrderDetails.Count * 250;
                    else if (Device.RuntimePlatform == Device.iOS)
                        OrderDetailsLength = OrderDetails.Count * 225;
                    else
                        OrderDetailsLength = OrderDetails.Count * 225;
                    IsReturnFullOrderVisible = true;
                    foreach (var item in OrderDetails)
                    {
                        if (item.IsReturnOrderVisible == false)
                        {
                            IsReturnFullOrderVisible = false;
                            break;
                        }
                    }

                    NetAmount = OrderResponses.NetAmount;
                    DiscountAmount = OrderResponses.DiscountAmount;
                    TaxAmount = OrderResponses.TaxAmount;
                    TotalAmount = OrderResponses.TotalAmount;
                    SubTotalAmount = OrderResponses.SubTotalAmount;
                    SubTotalAmount = Math.Round(SubTotalAmount, 2);
                    ShippingFee = 0; ShippingFee = Math.Round(ShippingFee, 2);
                    PromoDiscountAmount = 0; PromoDiscountAmount = Math.Round(PromoDiscountAmount, 2);
                    //TaxAmount = OrderResponses.TaxAmount;
                    //TaxAmount = Math.Round((TaxRate / 100) * SubTotalAmount + ShippingFee, 2);

                    if (!string.IsNullOrEmpty(OrderResponses.DeliveryAddress?.ApartmentNumber))
                        AddressString = OrderResponses.DeliveryAddress?.ApartmentNumber;
                    if (!string.IsNullOrEmpty(OrderResponses.DeliveryAddress?.BuildingName))
                        AddressString = AddressString + ", " + OrderResponses.DeliveryAddress?.BuildingName;
                    if (!string.IsNullOrEmpty(OrderResponses.DeliveryAddress?.Area))
                        AddressString = AddressString + ", " + OrderResponses.DeliveryAddress?.Area;
                    if (!string.IsNullOrEmpty(OrderResponses.DeliveryAddress?.City))
                        AddressString = AddressString + ", " + OrderResponses.DeliveryAddress?.City;
                    if (!string.IsNullOrEmpty(OrderResponses.DeliveryAddress?.CountryName))
                        AddressString = AddressString + ", " + OrderResponses.DeliveryAddress?.CountryName;

                    //FutureDate = OrderResponses.OrderDate.AddDays(7);
                    //if (OrderResponses.OrderDetails.Where())
                    //{ }
                    if (CommonAttribute.CustomeProfile != null)
                    {
                        string firstname = CommonAttribute.CustomeProfile?.FirstName;
                        string lastname = CommonAttribute.CustomeProfile?.LastName;
                        CustName = firstname + " " + lastname;
                        if (CommonAttribute.CustomeProfile?.MobileNumber != null)
                            CustContactDetail = CommonAttribute.CustomeProfile?.MobileNumber;
                        else
                            CustContactDetail = CommonAttribute.CustomeProfile?.AlternateMobileNumber;

                        TaxRate = Convert.ToDecimal(CommonAttribute.CustomeProfile.CountryResponse?.CountryLevelSettingResponse?.TaxPercentage);

                    }
                    else
                    {
                        CustName = "";
                        CustContactDetail = "";
                    }
                }
                
            }
            catch (Exception ex)
            {

            }
            IsBusy = false;
        }

        public MyOrderDetailsViewModel(INavigation navigation, OrderDetailResponse orderDetailResponse) : base(navigation)
        {
            TrackOrderDetailResponse = orderDetailResponse;
            lstOrderTrackingResponse = TrackOrderDetailResponse.OrderTrackings.ToList();
            obOrderTrackingResponse = new ObservableCollection<OrderTrackingResponse>(lstOrderTrackingResponse);
        }

        public Command CallServiceCentorCommand
        {
            get
            {
                return new Command<OrderDetailResponse>(async (obj) =>
                {
                    try
                    {
                        if (obj.ServiceCenterResponse?.ContactNumber1 != null && obj.ServiceCenterResponse?.ContactNumber1 != string.Empty && obj.ServiceCenterResponse?.ContactNumber1 != "")
                            Extensions.PlacePhoneCall(obj.ServiceCenterResponse?.ContactNumber1);
                        else if (obj.ServiceCenterResponse?.ContactNumber2 != null && obj.ServiceCenterResponse?.ContactNumber2 != string.Empty && obj.ServiceCenterResponse?.ContactNumber2 != "")
                            Extensions.PlacePhoneCall(obj.ServiceCenterResponse?.ContactNumber2);
                        else
                        {
                            await ErrorDisplayAlert(AppResources.ErrorMsgMobilenumberisnotavailable);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                });
            }
        }

        public Command SelectedItemCommand
        {
            get
            {
                return new Command<OrderDetailResponse>(async (item) =>
                {
                    await Navigation.PushAsync(new RetrunOrderDetailsPage(item));
                });
            }
        }

        public Command TrackOrderCommand
        {
            get
            {
                return new Command<OrderDetailResponse>(async (item) =>
                {
                    //await DisplayAlert("title", "msg");
                    await PopupNavigation.Instance.PushAsync(new TrackOrderPopupPage(item));
                });
            }
        }


        public Command ReturnAllOrderCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await PopupNavigation.Instance.PushAsync(new ReturnOrderPopupView(OrderResponses));

                    //FullOrderReturnRequest fullOrderReturnRequest = new FullOrderReturnRequest();
                    //fullOrderReturnRequest.OrderId = OrderResponses.OrderId;
                    //fullOrderReturnRequest.Reason = "";

                    //AccessoryManagementSL accessoryManagementSL = new AccessoryManagementSL();
                    //APIResponse receiveContext = await accessoryManagementSL.FullReturnOrder(fullOrderReturnRequest);
                    //if (receiveContext?.Status == Convert.ToInt16(APIResponseEnum.Success))
                    //{
                    //    IsBusy = false;
                    //    await Navigation.PushAsync(new FeedBackSuccessPage("ReturnOrder"));
                    //}
                    //else if (receiveContext != null)
                    //{
                    //    IsBusy = false;
                    //    string msg = CommonFunctions.GetMessagesByLanguage(receiveContext, CommonAttribute.selectedLang.lid);
                    //    await Application.Current.MainPage.DisplayAlert("", msg, AppResources.lblCancel);
                    //}
                    //else
                    //{
                    //    await ErrorDisplayAlert(AppResources.servererror);
                    //    IsBusy = false;
                    //}
                });
            }
        }

        private string _CustContactDetail;
        public string CustContactDetail
        {
            get { return _CustContactDetail; }
            set
            {
                _CustContactDetail = value;
                OnPropertyChanged(nameof(CustContactDetail));
            }
        }

        private string _CustName;
        public string CustName
        {
            get { return _CustName; }
            set
            {
                _CustName = value;
                OnPropertyChanged(nameof(CustName));
            }
        }

        private string _AddressString;
        public string AddressString
        {
            get { return _AddressString; }
            set
            {
                _AddressString = value;
                OnPropertyChanged("AddressString");
            }
        }

        private OrderListResponse _OrderResponsesNew;
        public OrderListResponse OrderResponsesNew
        {
            get { return _OrderResponsesNew; }
            set
            {
                _OrderResponsesNew = value;
                OnPropertyChanged(nameof(OrderResponsesNew));
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

        private ObservableCollection<OrderResponse> _OrderResponsesList;
        public ObservableCollection<OrderResponse> OrderResponsesList
        {
            get { return _OrderResponsesList; }
            set
            {
                _OrderResponsesList = value;
                OnPropertyChanged(nameof(OrderResponsesList));
            }
        }

        //OrderDetailResponse
        private ObservableCollection<OrderDetailResponse> _OrderDetails;
        public ObservableCollection<OrderDetailResponse> OrderDetails
        {
            get { return _OrderDetails; }
            set
            {
                _OrderDetails = value;
                OnPropertyChanged(nameof(OrderDetails));
                //OnPropertyChanged(nameof(OrderDetailsLength));
            }
        }

        private int _OrderDetailsLength;
        public int OrderDetailsLength
        {
            get
            {

                return _OrderDetailsLength;
            }
            set
            {
                _OrderDetailsLength = value;
                OnPropertyChanged(nameof(OrderDetailsLength));

            }

        }
        private decimal _NetAmount;
        public decimal NetAmount
        {
            get { return _NetAmount; }
            set
            {
                _NetAmount = value;
                OnPropertyChanged("NetAmount");
            }
        }
        private decimal _TaxAmount;
        public decimal TaxAmount
        {
            get { return _TaxAmount; }
            set
            {
                _TaxAmount = value;
                OnPropertyChanged("TaxAmount");
            }
        }

        private decimal _DiscountAmount;
        public decimal DiscountAmount
        {
            get { return _DiscountAmount; }
            set
            {
                _DiscountAmount = value;
                OnPropertyChanged("DiscountAmount");
            }
        }
        private decimal _TotalAmount;
        public decimal TotalAmount
        {
            get { return _TotalAmount; }
            set
            {
                _TotalAmount = value;
                OnPropertyChanged("TotalAmount");
            }
        }

        private decimal _SubTotalAmount;
        public decimal SubTotalAmount
        {
            get { return _SubTotalAmount; }
            set
            {
                _SubTotalAmount = value;
                OnPropertyChanged("SubTotalAmount");
            }
        }
        private decimal _ShippingFee;
        public decimal ShippingFee
        {
            get { return _ShippingFee; }
            set
            {
                _ShippingFee = value;
                OnPropertyChanged("ShippingFee");
            }
        }

        private decimal _PromoDiscountAmount;
        public decimal PromoDiscountAmount
        {
            get { return _PromoDiscountAmount; }
            set
            {
                _PromoDiscountAmount = value;
                OnPropertyChanged("PromoDiscountAmount");
            }
        }

        private bool _IsReturnFullOrderVisible;
        public bool IsReturnFullOrderVisible
        {
            get { return _IsReturnFullOrderVisible; }
            set
            {
                _IsReturnFullOrderVisible = value;
                OnPropertyChanged("IsReturnFullOrderVisible");
            }
        }

        private OrderDetailResponse _TrackOrderDetailResponse;
        public OrderDetailResponse TrackOrderDetailResponse
        {
            get { return _TrackOrderDetailResponse; }
            set
            {
                _TrackOrderDetailResponse = value;
                OnPropertyChanged("TrackOrderDetailResponse");
            }
        }

        private List<OrderTrackingResponse> _lstOrderTrackingResponse;
        public List<OrderTrackingResponse> lstOrderTrackingResponse
        {
            get { return _lstOrderTrackingResponse; }
            set
            {
                _lstOrderTrackingResponse = value;
                OnPropertyChanged("lstOrderTrackingResponse");
            }
        }

        private ObservableCollection<OrderTrackingResponse> _obOrderTrackingResponse;
        public ObservableCollection<OrderTrackingResponse> obOrderTrackingResponse
        {
            get { return _obOrderTrackingResponse; }
            set
            {
                _obOrderTrackingResponse = value;
                OnPropertyChanged("obOrderTrackingResponse");
            }
        }

    }
}

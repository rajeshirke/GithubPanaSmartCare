using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.Views.Supervisor;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace eWarranty.ViewModels.Supervisor
{
    public class AccessoryRequestsViewModel : BaseViewModel
    {
        public AccessoryRequestsViewModel(INavigation navigation, AssignDeliveryRequest assignDeliveryRequest) : base(navigation)
        {
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await GetOrders();
                if(assignDeliveryRequest != null)
                {
                    AssignDeliveryRequests = new AssignDeliveryRequest();
                    AssignDeliveryRequests = assignDeliveryRequest;
                }
                
                IsBusy = false;
            });
        }

        //public AccessoryRequestsViewModel(INavigation navigation, AssignDeliveryRequest assignDeliveryRequest) : base(navigation)
        //{
        //    IsBusy = true;
        //    Device.BeginInvokeOnMainThread(async () =>
        //    {
        //        AssignDeliveryRequests = new AssignDeliveryRequest();
        //        AssignDeliveryRequests = assignDeliveryRequest;
        //        IsBusy = false;
        //    });
        //}

        public async Task GetOrders()
        {
            try
            {
                string Currency = "";
                OrderDetailResponses = new ObservableCollection<OrderDetailResponse>();
                MasterData = new List<OrderDetailResponse>();
                if (CommonAttribute.CustomeProfile.CountryResponse != null)
                {
                    Currency = CommonAttribute.CustomeProfile.CountryResponse.CurrencyCode;
                }
                AccessoryManagementSL accessoryManagementSL = new AccessoryManagementSL();
                MasterData = await accessoryManagementSL.GetAccessoryOrderByServiceCenterAndStatus(CommonAttribute.CustomeProfile.PersonServiceCenters.FirstOrDefault().ServiceCenterId);
                if (MasterData != null)
                {
                    OrderDetailResponses = new ObservableCollection<OrderDetailResponse>(MasterData);
                    OrderDetailResponses.ForEach(c => c.CurrencyCode = Currency);
                }
            }
            catch (Exception ex)
            {

            }
            
        }


        public ICommand AcceptCommand
        {
            get
            {
                return new Command<OrderDetailResponse>(async (item) =>
                {
                    IsBusy = true;
                    AssignDeliveryRequest assignDeliveryRequest = new AssignDeliveryRequest();
                    if (item != null)
                    {
                        assignDeliveryRequest.OrderDetailId = item.OrderDetailId;
                        assignDeliveryRequest.SerialNumber = null;

                        await PopupNavigation.Instance.PushAsync(new AcceptOrderPopupView(assignDeliveryRequest));

                        
                        IsBusy = false;
                    }

                });
            }
        }

        public ICommand RejectOrderCommand
        {
            get
            {
                return new Command<OrderDetailResponse>(async (item) =>
                {

                    IsBusy = true;
                    try
                    {
                        var res = await YesorNoDisplayAlert(AppResources.lblErrorAlert, "Do you want to reject the order??");
                        if (res)
                        {
                            if (item != null)
                            {
                                AccessoryManagementSL accessoryManagementSL = new AccessoryManagementSL();
                                APIResponse aPIResponse = await accessoryManagementSL.RejectOrder((int)item.OrderDetailId);
                                if (aPIResponse != null && aPIResponse.Status == Convert.ToInt16(APIResponseEnum.Success))
                                {
                                    string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                                    await DisplayAlert("", msg);
                                    await GetOrders();
                                }
                                else
                                {
                                    string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                                    await DisplayAlert("", msg);
                                }

                                IsBusy = false;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                    finally
                    {
                        IsBusy = false;
                    }


                });
            }
        }


        public Command AcceptOrderReqCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    try
                    {
                        AssignDeliveryRequest assignDeliveryRequest = new AssignDeliveryRequest();
                        assignDeliveryRequest.OrderDetailId = AssignDeliveryRequests.OrderDetailId;
                        assignDeliveryRequest.SerialNumber = AssignDeliveryRequests.SerialNumber;
                        assignDeliveryRequest.Remark = OrderRemark;

                        AccessoryManagementSL accessoryManagementSL = new AccessoryManagementSL();
                        APIResponse aPIResponse = await accessoryManagementSL.AcceptOrder(assignDeliveryRequest);
                        if (aPIResponse != null && aPIResponse.Status == Convert.ToInt16(APIResponseEnum.Success))
                        {
                            string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                            await DisplayAlert("Order Status", msg);
                            //await PopupNavigation.Instance.PopAsync();

                            //await GetOrders();

                        }
                        else
                        {
                            string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                            await DisplayAlert("Order Status", msg);
                            //await PopupNavigation.Instance.PopAsync();

                        }
                        await PopupNavigation.Instance.PopAsync();
                        Thread.Sleep(1000);
                        MessagingCenter.Send<string>("Refresh", "RefreshAccessoryList");

                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                    finally
                    {
                        IsBusy = false;
                    }

                    IsBusy = false;

                });
            }
        }

        public Command CancelCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await PopupNavigation.Instance.PopAsync();
                });
            }
        }

        public List<OrderDetailResponse> MasterData { get; set; }

        private ObservableCollection<OrderDetailResponse> _OrderDetailResponses;
        public ObservableCollection<OrderDetailResponse> OrderDetailResponses
        {
            get { return _OrderDetailResponses; }
            set
            {
                _OrderDetailResponses = value;
                OnPropertyChanged(nameof(OrderDetailResponses));
            }
        }

        private AssignDeliveryRequest _AssignDeliveryRequests;
        public AssignDeliveryRequest AssignDeliveryRequests
        {
            get { return _AssignDeliveryRequests; }
            set
            {
                _AssignDeliveryRequests = value;
                OnPropertyChanged(nameof(AssignDeliveryRequests));
            }
        }

        private string _OrderRemark;
        public string OrderRemark
        {
            get { return _OrderRemark; }
            set
            {
                _OrderRemark = value;
                OnPropertyChanged(nameof(OrderRemark));
            }
        }
    }
}


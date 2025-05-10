using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Resx;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Supervisor
{
    public class AMCRequestsViewModel : BaseViewModel
    {
        public AMCRequestsViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await GetAMCRequests();
                IsBusy = false;
            });
        }

        public async Task GetAMCRequests()
        {
            try
            {
                Services = new ObservableCollection<RequestResponse>();
                MasterData = new List<RequestResponse>();
                AmcRequestManagementSL serviceRequestSL = new AmcRequestManagementSL();
                MasterData = await serviceRequestSL.GetAMCRequests((int)CommonAttribute.CustomeProfile.PersonRoleId, CommonAttribute.CustomeProfile.PersonServiceCenters.FirstOrDefault().ServiceCenterId);
                if (MasterData != null && MasterData.Count > 0)
                {
                    Services = new ObservableCollection<RequestResponse>(MasterData);
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
           
        }

        public ICommand RejectAMCRequestCommand
        {
            get
            {
                return new Command<RequestResponse>(async (item) =>
                {
                    try
                    {
                        IsBusy = true;

                        AmcRequestCustomerRequest amcRequestCustomerRequest = new AmcRequestCustomerRequest();
                        var res = await YesorNoDisplayAlert(AppResources.lblErrorAlert, "Do you want to reject the request??");
                        if (res)
                        {
                            if (item != null)
                            {
                                amcRequestCustomerRequest.AmcRequestId = 0;
                                amcRequestCustomerRequest.AmcrequestMasterId = 0;
                                amcRequestCustomerRequest.ProductModelId = 0;
                                amcRequestCustomerRequest.RequestId = item.RequestId;
                                amcRequestCustomerRequest.ApprovedByPersonId = CommonAttribute.CustomeProfile.PersonId;
                                amcRequestCustomerRequest.AmcRequestStatusId = 3;
                                amcRequestCustomerRequest.ApprovalDate = DateTime.Now;
                                amcRequestCustomerRequest.RequestedDate = item.CreationDate;

                                AmcRequestManagementSL amcRequestManagementSL = new AmcRequestManagementSL();
                                APIResponse aPIResponse = await amcRequestManagementSL.ApproveAMCReq(amcRequestCustomerRequest);
                                if (aPIResponse != null && aPIResponse.Status == Convert.ToInt16(APIResponseEnum.Success))
                                {
                                    string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                                    await DisplayAlert("", msg);
                                    await GetAMCRequests();
                                }
                                else
                                {
                                    string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                                    await DisplayAlert("", msg);

                                }

                                IsBusy = false;
                            }

                        }
                        IsBusy = false;
                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                   

                });

            }
        }

        public ICommand AcceptAMCRequestCommand
        {
            get
            {
                return new Command<RequestResponse>(async (item) =>
                {
                    try
                    {
                        IsBusy = true;

                        AmcRequestCustomerRequest amcRequestCustomerRequest = new AmcRequestCustomerRequest();
                        var res = await YesorNoDisplayAlert(AppResources.lblErrorAlert, "Do you want to accept the request??");
                        if (res)
                        {
                            if (item != null)
                            {
                                amcRequestCustomerRequest.AmcRequestId = 0;
                                amcRequestCustomerRequest.AmcrequestMasterId = 0;
                                amcRequestCustomerRequest.ProductModelId = 0;
                                amcRequestCustomerRequest.RequestId = item.RequestId;
                                amcRequestCustomerRequest.ApprovedByPersonId = CommonAttribute.CustomeProfile.PersonId;
                                amcRequestCustomerRequest.AmcRequestStatusId = 2;
                                amcRequestCustomerRequest.ApprovalDate = DateTime.Now;
                                amcRequestCustomerRequest.RequestedDate = item.CreationDate;

                                AmcRequestManagementSL amcRequestManagementSL = new AmcRequestManagementSL();
                                APIResponse aPIResponse = await amcRequestManagementSL.ApproveAMCReq(amcRequestCustomerRequest);
                                if (aPIResponse != null && aPIResponse.Status == Convert.ToInt16(APIResponseEnum.Success))
                                {
                                    string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                                    await DisplayAlert("", msg);
                                    await GetAMCRequests();
                                }
                                else
                                {
                                    string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                                    await DisplayAlert("", msg);

                                }

                                IsBusy = false;
                            }
                        }

                        IsBusy = false;
                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                    

                });
            }
        }

        public List<RequestResponse> MasterData { get; set; }
        private ObservableCollection<RequestResponse> _Services;
        public ObservableCollection<RequestResponse> Services
        {
            get { return _Services; }
            set
            {
                _Services = value;
                OnPropertyChanged("Services");
            }
        }
    }
}


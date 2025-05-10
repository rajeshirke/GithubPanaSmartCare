using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Views.Supervisor;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Supervisor
{
    public class PartStockRequestsViewModel : BaseViewModel
    {
        public PartStockRequestsViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await GetPartRequests();
                IsBusy = false;
            });
        }

        public PartStockRequestsViewModel(INavigation navigation, PartRequestView partRequestView) : base(navigation)
        {
            IsBusy = true;

            SelectedPartReqStatusType = new DropDownModel();

            Device.BeginInvokeOnMainThread(async () =>
            {
                PartReqStatusTypes = new ObservableCollection<DropDownModel>();
                PartReqStatusTypes.Add(new DropDownModel { Id = (int)PartRequestStatusEnumSup.Open, Title = "Open" });
                PartReqStatusTypes.Add(new DropDownModel { Id = (int)PartRequestStatusEnumSup.InProgress, Title = "InProgress" });
                PartReqStatusTypes.Add(new DropDownModel { Id = (int)PartRequestStatusEnumSup.Issue, Title = "Issue" });
                PartReqStatusTypes.Add(new DropDownModel { Id = (int)PartRequestStatusEnumSup.UnderEstimation, Title = "UnderEstimation" });
                PartReqStatusTypes.Add(new DropDownModel { Id = (int)PartRequestStatusEnumSup.Cancel, Title = "Cancel" });
                PartReqStatusTypes.Add(new DropDownModel { Id = (int)PartRequestStatusEnumSup.Accept, Title = "Accept" });

                
                await GetPartRequestDetails(partRequestView);
                IsBusy = false;
            });
        }

        public async Task GetPartRequests()
        {
            try
            {
                Services = new ObservableCollection<PartRequestView>();

                TechnicianManagementSL serviceRequestSL = new TechnicianManagementSL();
                MasterData = await serviceRequestSL.GetPartRequestsByServiceCenterAndStatus(CommonAttribute.CustomeProfile.PersonServiceCenters.FirstOrDefault().ServiceCenterId);
                if (MasterData != null && MasterData.Count > 0)
                {
                    Services = new ObservableCollection<PartRequestView>(MasterData);
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            
        }

        public async Task GetPartRequestDetails(PartRequestView partRequestView)
        {
            try
            {
                PartReqDetails = new PartRequestView();
                TechnicianManagementSL serviceRequestSL = new TechnicianManagementSL();
                if (partRequestView != null)
                {
                    PartReqDetails = await serviceRequestSL.GetPartRequestByPartRequestId(partRequestView.PartRequestId, partRequestView.ServiceCenterId);
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            
        }

        public Command UpdatePartRequest
        {
            get
            {
                return new Command(async ()=>
                {
                    IsBusy = true;
                    try
                    {
                        if(SelectedPartReqStatusType != null)
                        {
                            PartRequestRequest partRequestRequest = new PartRequestRequest();
                            partRequestRequest.PartRequestId = PartReqDetails.PartRequestId;
                            partRequestRequest.PartRequestStatusId = SelectedPartReqStatusType.Id;
                            partRequestRequest.UpdatedByPersonId = CommonAttribute.CustomeProfile?.PersonId;
                            partRequestRequest.PartNumber = PartReqDetails.PartRequestNumber;
                            partRequestRequest.ServiceCenterId = PartReqDetails.ServiceCenterId;

                            TechnicianManagementSL serviceRequestSL = new TechnicianManagementSL();
                            APIResponse aPIResponse = await serviceRequestSL.UpdatePartRequest(PartReqDetails.PartRequestId, partRequestRequest);
                            if (aPIResponse != null && aPIResponse.Status == Convert.ToInt16(APIResponseEnum.Success))
                            {
                                string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                                await DisplayAlert("", msg);
                            }
                            else
                            {
                                string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                                await DisplayAlert("", msg);
                            }
                            await PopupNavigation.Instance.PopAsync();
                            //await GetPartRequests();
                            MessagingCenter.Send<string>("Refresh", "RefreshPartList");

                            IsBusy = false;

                        }
                        else
                        {
                            await DisplayAlert("Alert!", "Please Select Request Status.");
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

        

        public ICommand AcceptPartReqCommand
        {
            get
            {
                return new Command<PartRequestView>(async (item) =>
                {
                    await PopupNavigation.Instance.PushAsync(new PartReqPopup(item));

                });
            }
        }

        public Command PartStatusCommand
        {
            get
            {
                return new Command<DropDownModel>((item) =>
                {
                    SelectedPartReqStatusType = item;

                });
            }
        }

        public Command CancelCommand
        {
            get
            {
                return new Command(async() =>
                {
                    await PopupNavigation.Instance.PopAsync();
                });
            }
        }

        public List<PartRequestView> MasterData { get; set; }
        private ObservableCollection<PartRequestView> _Services;
        public ObservableCollection<PartRequestView> Services
        {
            get { return _Services; }
            set
            {
                _Services = value;
                OnPropertyChanged("Services");
            }
        }

        private PartRequestView _PartReqDetails;
        public PartRequestView PartReqDetails
        {
            get { return _PartReqDetails; }
            set
            {
                _PartReqDetails = value;
                OnPropertyChanged(nameof(PartReqDetails));
            }
        }

        private ObservableCollection<DropDownModel> _PartReqStatusTypes;
        public ObservableCollection<DropDownModel> PartReqStatusTypes
        {
            get { return _PartReqStatusTypes; }
            set
            {
                _PartReqStatusTypes = value;
                OnPropertyChanged(nameof(PartReqStatusTypes));
            }
        }
        private DropDownModel _SelectedPartReqStatusType;
        public DropDownModel SelectedPartReqStatusType
        {
            get { return _SelectedPartReqStatusType; }
            set
            {
                _SelectedPartReqStatusType = value;
                OnPropertyChanged(nameof(SelectedPartReqStatusType));
            }
        }
    }
}


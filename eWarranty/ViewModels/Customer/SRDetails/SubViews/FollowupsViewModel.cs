using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Customer.SRDetails.SubViews;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.SRDetails.SubViews
{
    public class FollowupsViewModel : BaseViewModel
    {
        public long ServiceRequestId { get; set; }
        public FollowupsViewModel(INavigation navigation, long rsid) : base(navigation)
        {
            try
            {
                if (Device.RuntimePlatform == Device.Android)
                    RowHeight = Convert.ToDouble(ScreenHeight) - 420;
                else
                {
                    if (ScreenHeight < 740)
                        RowHeight = Convert.ToDouble(ScreenHeight) - 410;
                    else
                        RowHeight = Convert.ToDouble(ScreenHeight) - 460;


                }

                ServiceRequestId = rsid;
                MessagingCenter.Unsubscribe<AddFllowUpViewModel, string>(this, "AddFllowUp");
                IsBusy = true;
                Device.BeginInvokeOnMainThread(async () => {
                    await BindingData();
                    IsBusy = false;
                });
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            
        }

       
        public async  Task BindingData()
        {
            try
            {
                FollowUps = new ObservableCollection<FollowUpUIModel>();

                FollowUpManagementSL upManagementSL = new FollowUpManagementSL();
                var followupList = await upManagementSL.GetFollowupsByServiceRequest(ServiceRequestId);
                if (followupList != null)
                {
                    if (FollowUps == null)
                        FollowUps = new ObservableCollection<FollowUpUIModel>();
                    foreach (var item in followupList)
                    {
                        var Newitems = new FollowUpUIModel()
                        {
                            CreatedDatetime = item.CreatedDatetime,
                            FollowUpId = item.FollowUpId,
                            MessageContent = item.MessageContent,
                            FromPersonId = item.FromPersonId,
                            ToPersonId = item.ToPersonId
                        };
                        FollowUps.Add(Newitems);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            
            
        }
        public Command AddNewFollowupCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        
                        if (CommonAttribute.EditServiceRequest.StatusId != Convert.ToInt16(ServiceRequestStatusEnum.JobClosed))
                        {
                            if (string.IsNullOrEmpty(FollowupMsg))
                            {
                                await ErrorDisplayAlert(AppResources.lblEnterFollowupMsg);
                                return;
                            }
                            IsBusy = true;
                            FollowUpManagementSL upManagementSL = new FollowUpManagementSL();
                            FollowUp followUp = new FollowUp();
                            followUp.ServiceRequestId = CommonAttribute.EditServiceRequest.ServiceRequestId;
                            followUp.MessageContent = FollowupMsg;
                            followUp.FollowUpTypeId = Convert.ToInt16(FollowUpTypeEnum.ServiceRequest);
                            followUp.CreatedDatetime = DateTime.Now;
                            followUp.ToPersonId = CommonAttribute.CustomeProfile.PersonId;
                            followUp.FromPersonId = CommonAttribute.CustomeProfile.PersonId;
                            // followUp.PersonID = CommonAttribute.CustomeProfile.PersonId;
                            var receiveContext = await upManagementSL.PostFollowUps(followUp);
                            if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                            {
                                await BindingData();
                                //await DisplayAlert(AppResources.lblSuccess, AppResources.lblUpdated);
                                FollowupMsg = string.Empty;

                            }
                            else if (receiveContext != null)
                            {
                                await ErrorDisplayAlert(receiveContext.errorMessage);
                            }
                            else
                            {
                                await ErrorDisplayAlert(Resx.AppResources.lblErrorTitle);
                            }
                            //  MessagingCenter.Unsubscribe<AddFllowUpViewModel, string>(this, "AddFllowUp");
                            IsBusy = false;

                            //MessagingCenter.Unsubscribe<AddFllowUpViewModel, string>(this, "AddFllowUp");
                            //MessagingCenter.Subscribe<AddFllowUpViewModel, string>(this, "AddFllowUp", async (sender, arg) =>
                            //{
                            //    IsBusy = true;
                            //    FollowUpManagementSL upManagementSL = new FollowUpManagementSL();
                            //    FollowUp followUp = new FollowUp();
                            //    followUp.ServiceRequestId = CommonAttribute.EditServiceRequest.ServiceRequestId;
                            //    followUp.MessageContent = arg;
                            //    followUp.FollowUpTypeId = Convert.ToInt16(FollowUpTypeEnum.ServiceRequest);
                            //    followUp.CreatedDatetime = DateTime.Now;
                            //    followUp.ToPersonId = CommonAttribute.CustomeProfile.PersonId;
                            //    followUp.FromPersonId = CommonAttribute.CustomeProfile.PersonId;
                            //// followUp.PersonID = CommonAttribute.CustomeProfile.PersonId;
                            //var receiveContext = await upManagementSL.PostFollowUps(followUp);
                            //    if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                            //    {
                            //        await BindingData();
                            //        await DisplayAlert("Success", "Updated.");

                            //    }
                            //    else if (receiveContext != null)
                            //    {
                            //        await ErrorDisplayAlert(receiveContext.errorMessage);
                            //    }
                            //    else
                            //    {
                            //        await ErrorDisplayAlert(Resx.AppResources.lblErrorTitle);
                            //    }
                            //    MessagingCenter.Unsubscribe<AddFllowUpViewModel, string>(this, "AddFllowUp");
                            //    IsBusy = false;
                            //});
                            //await PopupNavigation.PushAsync(new AddFollowUpPage());
                        }
                        else
                        {
                            IsBusy = false;
                            await ErrorDisplayAlert(AppResources.lblServiceRequestClosed);

                        }
                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                    

                });
            }
        }
        private ObservableCollection<FollowUpUIModel> _FollowUps;
        public ObservableCollection<FollowUpUIModel> FollowUps
        {
            get { return _FollowUps; }
            set
            {
                _FollowUps = value;
                OnPropertyChanged("FollowUps");
            }
        }
        private string _FollowupMsg;
        public string FollowupMsg

        {
            get { return _FollowupMsg; }
            set
            {
                _FollowupMsg = value;
                OnPropertyChanged("FollowupMsg");
            }
        }
        private double _RowHeight;
        public double RowHeight

        {
            get { return _RowHeight; }
            set
            {
                _RowHeight = value;
                OnPropertyChanged("FollowupMsg");
            }
        }

    }
}

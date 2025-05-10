using System;
using System.Windows.Input;
using eWarranty.Resx;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.SRDetails.SubViews
{
    public class AddFllowUpViewModel: BaseViewModel
    {
        [Obsolete]
        public AddFllowUpViewModel(INavigation navigation) : base(navigation)
        {
            BindingData();
        }

        [Obsolete]
        public void BindingData()
        {
            try
            {
                SaveCommand = new Command(async () =>
                {
                    if (string.IsNullOrEmpty(FollowupMsg))
                    {
                        await ErrorDisplayAlert(AppResources.lblEnterComments);
                        return;
                    }
                    MessagingCenter.Send<AddFllowUpViewModel, string>(this, "AddFllowUp", FollowupMsg);
                    await PopupNavigation.PopAsync();
                });
                CloseCommand = new Command(async () =>
                {
                    await PopupNavigation.PopAsync();
                });
            }
            catch (Exception ex)
            {

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
        public ICommand SaveCommand { get; set; }
        public ICommand CloseCommand { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.Inquiry
{
    public class SurveyListViewModel : BaseViewModel
    {
        public SurveyListViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DataBinding();
                IsBusy = false;
            });
        }
        public async Task DataBinding()
        {
            FollowUpManagementSL followUpManagementSL = new FollowUpManagementSL();
            List<CustomerSurveyResponse> response = await followUpManagementSL.GetCustomerSurveyByPersonId(CommonAttribute.CustomeProfile.PersonId);
            if (response != null)
            {
                ChatHistory = new ObservableCollection<CustomerSurveyResponse>(response);
            }

        }
        private ObservableCollection<CustomerSurveyResponse> _ChatHistory;
        public ObservableCollection<CustomerSurveyResponse> ChatHistory
        {
            get { return _ChatHistory; }
            set
            {
                _ChatHistory = value;
                OnPropertyChanged("ChatHistory");
            }
        }
    }
}
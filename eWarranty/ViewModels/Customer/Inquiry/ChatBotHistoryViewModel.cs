using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.Inquiry
{
    public class ChatBotHistoryViewModel : BaseViewModel
    {
        public ChatBotHistoryViewModel(INavigation navigation) : base(navigation)
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
            if (ChatMessages == null)
                ChatMessages = new ObservableCollection<ChatMessage>();

            FollowUpManagementSL followUpManagementSL = new FollowUpManagementSL();
            List<ChatbotEnquiryResponse> response= await followUpManagementSL.GetChatInqueriesByCustomer(CommonAttribute.CustomeProfile.PersonId);
            if(response != null)
            {
                ChatHistory = new ObservableCollection<ChatbotEnquiryResponse>(response);
                //foreach (var item in response)
                //{
                //    ChatMessages.Add(new ChatMessage() { UserId=item.  });
                //}
            }

        }
        private ObservableCollection<ChatbotEnquiryResponse> _ChatHistory;
        public ObservableCollection<ChatbotEnquiryResponse> ChatHistory
        {
            get { return _ChatHistory; }
            set
            {
                _ChatHistory = value;
                OnPropertyChanged("ChatHistory");
            }
        }
        private ObservableCollection<ChatMessage> _ChatMessages;
        public ObservableCollection<ChatMessage> ChatMessages
        {
            get { return _ChatMessages; }
            set
            {
                _ChatMessages = value;
                OnPropertyChanged("ChatMessage");
            }
        }
    }
}

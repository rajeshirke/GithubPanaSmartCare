using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.Views.Customer.InquiryView;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.Inquiry
{
    public class ChatBotViewModel : BaseViewModel
    {
        // public ObservableCollection<ChatBot> Messages { get; set; } = new ObservableCollection<ChatBot>();
        private ObservableCollection<ChatBot> _Messages { get; set; } = new ObservableCollection<ChatBot>();
        public ObservableCollection<ChatBot> Messages
        {
            get { return _Messages; }
            set
            {
                _Messages = value;
                OnPropertyChanged("Messages");
            }
        }

        private List<ChatBot> _RootMessages { get; set; } = new List<ChatBot>();
        public List<ChatBot> RootMessages
        {
            get { return _RootMessages; }
            set
            {
                _RootMessages = value;
                OnPropertyChanged("RootMessages");
            }
        }

        private bool _isToShowTextField;
        public bool IsToShowTextField
        {
            get { return _isToShowTextField; }
            set
            {
                _isToShowTextField = value;
                OnPropertyChanged("IsToShowTextField");
            }
        }
        private string _textToSend;
        public string TextToSend
        {
            get { return _textToSend; }
            set
            {
                _textToSend = value;
                OnPropertyChanged("TextToSend");
            }
        }
        public ICommand OnSendCommand { get; set; }
        //public string TextToSend { get; set; }
        ServiceRequestSL serviceRequestSL = new ServiceRequestSL();

        public ChatBotViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DataBinding();
                IsBusy = false;
            });

            OnSendCommand = new Command(async () =>
            {

                if (!string.IsNullOrEmpty(TextToSend))
                {
                    ChatBotRequest chatBotRequest = new ChatBotRequest()
                    {
                        customerPersonId = (int)CommonAttribute.CustomeProfile.PersonId,
                        enquiryMessage = TextToSend
                    };
                    ReceiveContext<string> receiveContext = await serviceRequestSL.PostChatBotRequest(chatBotRequest);
                    if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                    {
                        TextToSend = string.Empty;
                        IsToShowTextField = false;
                        await   Navigation.PushAsync(new FeedBackSuccessPage("chatbot"));

                        //await Application.Current.MainPage.DisplayAlert("", "Posted Message Successfully", "Cancel");

                    }
                }

            });
        }

        public Command SelectedEventCommand
        {
            get
            {
                return new Command(async (selectedevent) =>
                {
                    Root objChatbot = selectedevent as Root;
                    ChatBot chatBot1 = new ChatBot();
                    chatBot1.DataAlignment = "Right";
                    chatBot1.EventName = objChatbot.qadescription;
                    chatBot1.listEvents = new List<Root>();
                    RootMessages.Add(chatBot1);
                    //List<Root> objChatdata = await serviceRequestSL.GetChatbotData(objChatbot.id);
                    List<Root> objChatdata = await serviceRequestSL.GetByLanguage(objChatbot.id,CommonAttribute.selectedLang.lid);
                    if (objChatdata != null)
                    {
                        ManipulateData(objChatdata, objChatbot.otherMessage, objChatbot.contentLink);
                    }
                    Messages = new ObservableCollection<ChatBot>(RootMessages);

                    if (objChatbot.qadescription == AppResources.lblNo || objChatbot.qadescription == AppResources.lblOthers
                    || objChatbot.otherMessage.ToLower() == AppResources.lblEnteryourqueryrequest.ToLower()
                    || objChatbot.qadescription == AppResources.lblPleaseEnteryourqueryrequest || objChatbot.qadescription == AppResources.lblThankYouForVIsitingUs
                    || objChatbot.otherMessage == AppResources.lblPleaseTellUsMoreInDetail)
                    {
                        IsToShowTextField = true;
                    }
                    else
                    {
                        IsToShowTextField = false;
                    }

                });

            }
            

        }

        private void ManipulateData(List<Root> rootMessages, string headerText, string contentLink = null)
        {
            try
            {
                ChatBot chatBot = new ChatBot();
                chatBot.DataAlignment = "LEFT";
                chatBot.EventName = headerText;//rootMessages[0].otherMessage;
                chatBot.ContentLink = contentLink;
                chatBot.listEvents = new List<Root>();
                foreach (var message in rootMessages)
                {
                    Root root = new Root()
                    {
                        id = message.id,
                        qadescription = message.qadescription,
                        otherMessage = message.otherMessage,
                        contentLink = message.contentLink,
                        parentId = message.parentId,
                        qatypeID = message.qatypeID
                    };
                    chatBot.listEvents.Add(root);

                }
                RootMessages.Add(chatBot);
            }
            catch (Exception ex)
            {

            }

        }

        public async Task DataBinding()
        {
            await GetChatBotDetails();
            IsBusy = false;
        }

        public async Task GetChatBotDetails()
        {
            try
            {
                //List<Root> reschatdata = await serviceRequestSL.GetChatbotData(1); //// OLD
                List<Root> reschatdata = await serviceRequestSL.GetByLanguage(1,CommonAttribute.selectedLang.lid);
                
                if (reschatdata != null)
                {
                    ManipulateData(reschatdata, AppResources.lblWelcomeMessage);
                    //ManipulateData(reschatdata, "Are you a?");
                    Messages = new ObservableCollection<ChatBot>(RootMessages);
                }
            }
            catch (Exception ex)
            {

            }

        }

    }
}
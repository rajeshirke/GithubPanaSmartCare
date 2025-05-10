using System;
using eWarranty.Models;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Technician.SupportViews
{
    public class ChatPageViewModel : BaseViewModel
    {
        public ChatPageViewModel(INavigation navigation) : base(navigation)
        {
        }
        public bool ShowScrollTap { get; set; } = false;
        public bool LastMessageVisible { get; set; } = true;
        public int PendingMessageCount { get; set; } = 0;
        public bool PendingMessageCountVisible { get { return PendingMessageCount > 0; } }

        //public Queue<ChatMessage> DelayedMessages { get; set; } = new Queue<Message>();
        //public ObservableCollection<Message> Messages { get; set; } = new ObservableCollection<Message>();
        //public string TextToSend { get; set; }
    }
}

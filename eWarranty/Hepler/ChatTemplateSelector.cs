using System;
using eWarranty.Controls.Templates;
using eWarranty.Models;
using Xamarin.Forms;

namespace eWarranty.Hepler
{
    public class ChatTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;

        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as ChatMessage;
            if (messageVm == null)
                return null;


            return (messageVm.UserId == CommonAttribute.CustomeProfile.PersonId) ? outgoingDataTemplate : incomingDataTemplate;
        }

    }
}

using eWarranty.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eWarranty.Core.RequestModels
{
    public class NotificationRequest
    {
         
        public string ChannelType { get; set; }
        public int LanguageId { get; set; }
        
        public string Message { get; set; }
        public string Subject { get; set; }
        public string ToContact { get; set; }
       // public ICollection<Attachment> Attachments { get; set; }
        public string SenderEmail { get; set; }

        public string ProviderName { get; set; }
        public NotificationEventTypeEnum NotificationEventType { get; set; }
    }
}

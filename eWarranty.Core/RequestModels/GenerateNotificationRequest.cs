 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Core.Enums;

namespace eWarranty.Core.RequestModels
{
    public class GenerateNotificationRequest
    {
        public int? PersonId { get; set; }
        public NotificationEventTypeEnum NotificationEventType { get; set; }
        public dynamic CustomDataSource { get; set; }
        public string DestinationEmail { get; set; } 

       // public ICollection<Attachment> Attachments { get; set; }
        public string SenderEmail { get; set; }
        public string ChannelType { get; set; }
    }
}

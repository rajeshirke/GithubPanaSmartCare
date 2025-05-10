using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class Notification
    {
        public Notification()
        {
            NotificationAttachments = new HashSet<NotificationAttachment>();
            NotificationHistories = new HashSet<NotificationHistory>();
        }

        public int NotificationId { get; set; }
        public string Subject { get; set; }
        public string NotificationContent { get; set; }
        public int? NotificationEventTypeId { get; set; }
        public int? NotificationChannelTypeId { get; set; }

        public virtual NotificationChannelType NotificationChannelType { get; set; }
        public virtual NotificationEventType NotificationEventType { get; set; }
        public virtual ICollection<NotificationAttachment> NotificationAttachments { get; set; }
        public virtual ICollection<NotificationHistory> NotificationHistories { get; set; }
    }
}

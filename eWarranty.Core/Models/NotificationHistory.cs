using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class NotificationHistory
    {
        public int NotificationHistoryId { get; set; }
        public int PersonId { get; set; }
        public int NotificationEventTypeId { get; set; }
        public DateTime? Created { get; set; }
        public int? MessageTemplateId { get; set; }
        public int? NotificationId { get; set; }

        public virtual Notification Notification { get; set; }
    }
}

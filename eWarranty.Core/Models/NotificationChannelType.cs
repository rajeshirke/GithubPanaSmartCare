using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class NotificationChannelType
    {
        public NotificationChannelType()
        {
            CampaignChannelTypes = new HashSet<CampaignChannelType>();
            Notifications = new HashSet<Notification>();
        }

        public int NotificationChannelTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CampaignChannelType> CampaignChannelTypes { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class CampaignChannelType
    {
        public int CampaignChannelTypeId { get; set; }
        public int CampaignMasterId { get; set; }
        public int NotificationChannelTypeId { get; set; }

        public virtual CampaignMaster CampaignMaster { get; set; }
        public virtual NotificationChannelType NotificationChannelType { get; set; }
    }
}

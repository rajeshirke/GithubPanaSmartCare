using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class CampaignType
    {
        public CampaignType()
        {
            CampaignMasters = new HashSet<CampaignMaster>();
        }

        public int CampaignTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CampaignMaster> CampaignMasters { get; set; }
    }
}

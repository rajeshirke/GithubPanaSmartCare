using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class PromoCode
    {
        public PromoCode()
        {
            AmcRequestCustomers = new HashSet<AmcRequestCustomer>();
            CampaignMasters = new HashSet<CampaignMaster>();
            ServiceRequests = new HashSet<ServiceRequest>();
        }

        public int PromoCodeId { get; set; }
        public string Code { get; set; }
        public decimal? DiscountAmount { get; set; }
        public int? DiscountPercentage { get; set; }

        public virtual ICollection<AmcRequestCustomer> AmcRequestCustomers { get; set; }
        public virtual ICollection<CampaignMaster> CampaignMasters { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}

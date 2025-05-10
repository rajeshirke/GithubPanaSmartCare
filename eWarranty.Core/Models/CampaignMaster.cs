using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class CampaignMaster
    {
        public CampaignMaster()
        {
            CampaignChannelTypes = new HashSet<CampaignChannelType>();
            CampaignCountries = new HashSet<CampaignCountry>();
            CampaignLanguages = new HashSet<CampaignLanguage>();
            CampaignProductCategories = new HashSet<CampaignProductCategory>();
        }

        public int CampaignMasterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TermsAndConditions { get; set; }
        public int? CampaignTypeId { get; set; }
        public bool? IsActive { get; set; }
        public int? PromoCodeId { get; set; }
        public long CreateByPersonId { get; set; }
        public DateTime CampaignAnnouncementDate { get; set; }
        public DateTime CampaignExpiryDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual CampaignType CampaignType { get; set; }
        public virtual Person CreateByPerson { get; set; }
        public virtual PromoCode PromoCode { get; set; }
        public virtual ICollection<CampaignChannelType> CampaignChannelTypes { get; set; }
        public virtual ICollection<CampaignCountry> CampaignCountries { get; set; }
        public virtual ICollection<CampaignLanguage> CampaignLanguages { get; set; }
        public virtual ICollection<CampaignProductCategory> CampaignProductCategories { get; set; }
    }
}

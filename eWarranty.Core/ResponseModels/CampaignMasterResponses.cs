using System;
using eWarranty.Core.Enums;

namespace eWarranty.Core.ResponseModels
{
    public class CampaignMasterResponses : PromoCodeResponse
    {
        public int CampaignMasterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TermsAndConditions { get; set; }
        public int? CampaignTypeId { get; set; }
        public bool? IsActive { get; set; }
        //public int? PromoCodeId { get; set; }
        public long CreateByPersonId { get; set; }
        public DateTime CampaignAnnouncementDate { get; set; }
        public DateTime? CampaignStartDate { get; set; }
        public DateTime? CampaignExpiryDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CurrencyCode { get; set; }

        public bool IsRegButtonVisible
        {
            get
            {
                if (CampaignTypeId == (int)CampaignTypeEnum.Campaign)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsPromotionVisible
        {
            get
            {
                if (CampaignTypeId == (int)CampaignTypeEnum.Promotion)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}

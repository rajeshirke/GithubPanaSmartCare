using eWarranty.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public class CampaignPostRequest : CampaignMaster
    {
          
        public List<int> CampaignChannelTypeIds { get; set; }
        public List<int> CampaignCountryIds { get; set; }
        public List<int> CampaignLanguageIds { get; set; }
        public List<int> CampaignProductCategoryIds { get; set; }

    }
}

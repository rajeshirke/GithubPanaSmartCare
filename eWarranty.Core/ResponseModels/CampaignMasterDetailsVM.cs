using eWarranty.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class CampaignMasterDetailsVM : CampaignMaster
    {
        public List<PrismProductCategoryView> lstPrismProductCategories { get; set; }
    }
}

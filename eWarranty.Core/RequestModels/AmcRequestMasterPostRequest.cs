using eWarranty.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public  class AmcRequestMasterPostRequest : AmcRequestMaster
    {
        public List<int> AmcProductCategoryIds { get; set; }
    }
}

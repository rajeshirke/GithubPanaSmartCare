using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class ProductCategoryWarrantyResponse : SearchCustomerProductModelsResponse
    {
        public List<WarrantyCustomerProductResponse> warrantyCustomerProductResponses { get; set; }
        
    }

  
}

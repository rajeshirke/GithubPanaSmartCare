using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
   public class WarrantyChargeSearchRequest
    {
         
        public int CountryId { get; set; }
        public int ServiceCenterId { get; set; }  
        public int ProductClassificationId { get; set; }
    }
}

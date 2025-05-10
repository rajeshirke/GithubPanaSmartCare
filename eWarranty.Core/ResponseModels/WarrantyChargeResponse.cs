using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class WarrantyChargeResponse
    {
        public int WarrantyChargeId { get; set; }
        public int ProductClassificationId { get; set; }
        public decimal Rate { get; set; }
        public int CountryId { get; set; }
        public int? ServiceCenterId { get; set; }
        public string Description { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public long UpdatedByPersonId { get; set; }
    }
}

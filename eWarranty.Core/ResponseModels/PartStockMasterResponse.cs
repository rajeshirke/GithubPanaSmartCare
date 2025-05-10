using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class PartStockMasterResponse
    {
        public long PartStockMasterId { get; set; }
        public int ServiceCenterId { get; set; }
        public long? TechnicianPersonId { get; set; }
        public int PartStockBucketId { get; set; }
        public string PartNumber { get; set; }
        public int Quantity { get; set; }
        public DateTime EntryDate { get; set; }
        public long EntryByPersonId { get; set; }
        public decimal Cost { get; set; }
        public int? CurrencyId { get; set; }
        public string Description { get; set; }

    }
}

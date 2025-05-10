using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class PartStockMasterBucketCounts
    {
        public string PartStockBucketName { get; set; } 
        public int PartStockBucketId { get; set; }
        public string PartNumber { get; set; }
        public int Quantity { get; set; } 
    }
}

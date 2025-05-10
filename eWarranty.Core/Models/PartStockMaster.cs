using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class PartStockMaster
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
        public decimal TotalAmount { get; set; }
        public int? CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string Description { get; set; }      

        public bool IsVisibleSwipeRight { get; set; }
        public bool IsReturnPartVisible { get; set; }

        public virtual Person EntryByPerson { get; set; }
        public virtual PartStockBucket PartStockBucket { get; set; }
        public virtual Person TechnicianPerson { get; set; }
    }
}

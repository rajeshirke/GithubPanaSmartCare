using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class PrismSalesDataView
    {
        public int Id { get; set; }
        public int? Country { get; set; }
        public string Category { get; set; }
        public string ModelNo { get; set; }
        public string SerialNo { get; set; }
        public DateTime? ShipDate { get; set; }
        public string ReferenceNo { get; set; }
        public string Client { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

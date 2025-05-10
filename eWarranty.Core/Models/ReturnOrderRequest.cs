using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ReturnOrderRequest
    {
        public long ReturnOrderRequestId { get; set; }
        public DateTime RequestedDate { get; set; }
        public long OrderDetailId { get; set; }
        public string Reason { get; set; }
        public int? Quantity { get; set; }
        public long? ClosedByPersonId { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int? StatusId { get; set; }
        public string SupervisorComments { get; set; }
        public int ServiceCenterID { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
        public virtual RequestStatu Status { get; set; }
    }
}

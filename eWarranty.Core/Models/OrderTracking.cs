using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class OrderTracking
    {
        public int OrderTrackingId { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long OrderDetailId { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
        public virtual OrderStatu OrderStatus { get; set; }
    }
}

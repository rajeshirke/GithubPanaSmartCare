using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class OrderStatu
    {
        public OrderStatu()
        {
            OrderDetails = new HashSet<OrderDetail>();
            OrderTrackings = new HashSet<OrderTracking>();
        }

        public int OrderStatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<OrderTracking> OrderTrackings { get; set; }
    }
}

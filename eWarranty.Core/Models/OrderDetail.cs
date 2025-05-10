using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            AccessoryOrderDetails = new HashSet<AccessoryOrderDetail>();
            OrderTrackings = new HashSet<OrderTracking>();
            ReturnOrderRequests = new HashSet<ReturnOrderRequest>();
        }

        public long OrderDetailId { get; set; }
        public long OrderId { get; set; }
        public long AccessoryMasterId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string OrderDetailNo { get; set; }
        public decimal SubTotalAmount { get; set; }
        public int? OrderStatusId { get; set; }

        public virtual AccessoryMaster AccessoryMaster { get; set; }
        public virtual Order Order { get; set; }
        public virtual OrderStatu OrderStatus { get; set; }
        public virtual ICollection<AccessoryOrderDetail> AccessoryOrderDetails { get; set; }
        public virtual ICollection<OrderTracking> OrderTrackings { get; set; }
        public virtual ICollection<ReturnOrderRequest> ReturnOrderRequests { get; set; }
    }
}

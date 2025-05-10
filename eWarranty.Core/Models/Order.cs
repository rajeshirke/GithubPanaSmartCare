using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class Order
    {
        public Order()
        {
            AccessoryOrderDetails = new HashSet<AccessoryOrderDetail>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long OrderId { get; set; }
        public long CustomerPersonId { get; set; }
        public int PaymentModeId { get; set; }
        public int DeliveryAddressId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal NetAmount { get; set; }
        public int? PromoCodeId { get; set; }
        public string OrderNo { get; set; }
        public decimal SubTotalAmount { get; set; }
        public decimal ShippingFeeAmount { get; set; }

        public virtual Person CustomerPerson { get; set; }
        public virtual Address DeliveryAddress { get; set; }
        public virtual PaymentMode PaymentMode { get; set; }
        public virtual PromoCode PromoCode { get; set; }
        public virtual ICollection<AccessoryOrderDetail> AccessoryOrderDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

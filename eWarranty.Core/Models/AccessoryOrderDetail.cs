using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class AccessoryOrderDetail
    {
        public long AccessoryOrderDetailId { get; set; }
        public long AccessoryMasterId { get; set; }
        public string SerialNumber { get; set; }
        public decimal Price { get; set; }
        public long? OrderId { get; set; }
        public long? OrderDetailId { get; set; }
        public DateTime? DeliveredPersonId { get; set; }
        public DateTime? DeliveredOn { get; set; }
        public DateTime? ReturnedOn { get; set; }

        public virtual AccessoryMaster AccessoryMaster { get; set; }
        public virtual Order Order { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
    }
}

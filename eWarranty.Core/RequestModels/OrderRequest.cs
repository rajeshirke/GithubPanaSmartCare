using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public partial class OrderRequest
    {
        public long CustomerPersonId { get; set; }
        public int PaymentModeId { get; set; }
        public int DeliveryAddressId { get; set; }
        public int? PromoCodeId { get; set; }
        public int CountryId { get; set; }
        public int ServiceCenterID { get; set; }
        public virtual ICollection<OrderDetailRequest> OrderDetails { get; set; }
    }

    public partial class OrderDetailRequest
    {
        public long AccessoryMasterId { get; set; }
        public int Quantity { get; set; }
    }

    public partial class FullOrderReturnRequest
    {
        public long OrderId { get; set; }
        public string Reason { get; set; }
    }
}

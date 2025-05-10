using System;
namespace eWarranty.Core.RequestModels
{
    public class OrderReturnRequest
    {
        public long OrderDetailId { get; set; }
        public string Reason { get; set; }
        public int? Quantity { get; set; }
        public int? ServiceCenterID { get; set; }
    }
}

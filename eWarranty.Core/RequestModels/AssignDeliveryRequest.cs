using System;
namespace eWarranty.Core.RequestModels
{
    public class AssignDeliveryRequest
    {
        public long OrderDetailId { get; set; }
        public string SerialNumber { get; set; }
        public string Remark { get; set; }
    }
}

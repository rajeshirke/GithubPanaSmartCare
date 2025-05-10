using System;
namespace eWarranty.Core.RequestModels
{
    public class TechGetServiceRequests
    {
        public long technicianPersonId { get; set; }
        public int? serviceRequestStatusId { get; set; }
        public DateTime? serviceRequestDate { get; set; }
        public int? serviceRequestAddressId { get; set; }
    }
}

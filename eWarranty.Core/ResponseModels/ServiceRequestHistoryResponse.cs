using System;
namespace eWarranty.Core.ResponseModels
{
    public class ServiceRequestHistoryResponse
    {
        public long ServiceRequestHistoryId { get; set; }
        public long ServiceRequestId { get; set; }
        public int ServiceRequestStatusId { get; set; }
        public DateTime ServiceRequestUpdatedDatetime { get; set; }
        //public virtual ServiceRequestStatu ServiceRequestStatus { get; set; }
        public virtual string ServiceRequestStatusName { get; set; }
    }
}

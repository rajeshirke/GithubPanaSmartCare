using System;
namespace eWarranty.Core.RequestModels
{
    public class ServiceCenterUpdateRequest
    {
        public int ServiceRequestId { get; set; }
        public int StatusId { get; set; }
        public string SupervisorComment { get; set; }
    }
}

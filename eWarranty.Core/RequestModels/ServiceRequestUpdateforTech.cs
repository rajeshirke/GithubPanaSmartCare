using System;
namespace eWarranty.Core.RequestModels
{
    public class ServiceRequestUpdateforTech
    {
        public int ServiceRequestId { get; set; }
        public string ServiceRequestNumber { get; set; }
        public int ServiceCenterId { get; set; }
        public string ServiceRequestName { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
        public long CustomerPersonId { get; set; }
        public int? ServiceRequestAddressId { get; set; }
        public int ProductModelId { get; set; }
        public string CustomerRemark { get; set; }
        public DateTime CustomerSrpreferredDateTime { get; set; }
        public int ProductWarrantyTypeId { get; set; }
        public int ProductWarrantyStatusId { get; set; }
        public int PriorityId { get; set; }
        public int? PromoCodeId { get; set; }
        public decimal EstimatedWorkDurationHours { get; set; }
        public string SupervisorRemark { get; set; }
        public string TechnicianComments { get; set; }
        public string VisitAddressLandmark { get; set; }
        public long TechnicianPersonId { get; set; }
        public long ActionedByPersonRoleId { get; set; }
        public int ServiceLocationTypeId { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsServiceChargeable { get; set; }
        public long ActionedByPersonId { get; set; }

    }
}

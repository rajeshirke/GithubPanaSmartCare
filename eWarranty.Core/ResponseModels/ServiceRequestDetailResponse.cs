using System;
using System.Collections.Generic;

namespace eWarranty.Core.ResponseModels
{

    public class ServiceRequestDetailResponse
    {

        public long ServiceRequestId { get; set; }

        public string ServiceRequestNumber { get; set; }

        public int ServiceCenterId { get; set; }

        public string ServiceRequestName { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public int TypeId { get; set; }

        public int StatusId { get; set; }

        public long CustomerPersonId { get; set; }

        public int? ServiceRequestAddressId { get; set; }

        public long ProductModelId { get; set; }

        public string CustomerRemark { get; set; }

        public DateTime? CustomerSrpreferredDateTime { get; set; }

        public int? ProductWarrantyTypeId { get; set; }

        public string ProductModelWarrantyTypeName { get; set; } = "Out Warranty";

        public int? ProductWarrantyStatusId { get; set; }

        public int? PriorityId { get; set; }

        public int? PromoCodeId { get; set; }

        public decimal? EstimatedWorkDurationHours { get; set; }

        public string SupervisorRemark { get; set; }

        public string TechnicianComments { get; set; }

        public string VisitAddressLandmark { get; set; }

        public long? TechnicianPersonId { get; set; }

        public int? ServiceLocationTypeId { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

        public DateTime CreationDate { get; set; }

        public bool? IsServiceChargeable { get; set; }

        public string ErrorMessage { get; set; }

        public virtual PersonDetailsResponse CustomerPerson { get; set; }

        public virtual string PriorityName { get; set; }

        public virtual ProductModelResponse ProductModel { get; set; }

        public virtual PromoCodeResponse PromoCode { get; set; }

        public virtual ServiceCenterResponse ServiceCenter { get; set; }

        public virtual string ServiceLocationTypeName { get; set; }

        public virtual AddressResponse ServiceRequestAddress { get; set; }

        public virtual string ServiceRequestStatusName { get; set; }

        public virtual PersonDetailsResponse TechnicianPerson { get; set; }

        public virtual string ServiceRequestTypeName { get; set; }

        public virtual CountryResponse ServiceCenterCountry { get; set; }

        public virtual ICollection<FollowUpResponse> FollowUps { get; set; }

        public virtual ICollection<InvoiceResponse> Invoices { get; set; }

        public virtual ICollection<PartRequestResponse> PartRequests { get; set; }

        public virtual ICollection<ServiceCostEstimationResponse> ServiceCostEstimations { get; set; }

        public ICollection<ServiceRequestFileResponse> ServiceRequestFiles { get; set; }

        public virtual ICollection<ServiceRequestHistoryResponse> ServiceRequestHistories { get; set; }

        public bool IsStandBySetRequestOpen { get; set; } = false;

        public virtual ICollection<StandBySetRequestResponse> StandBySetRequests { get; set; }

        public virtual List<ServiceChargeMasterResponse> ServiceChargeMasterResponse { get; set; }//---FOR WEB

    }
}

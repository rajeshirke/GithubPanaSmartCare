using System;
using System.Collections.Generic;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;

namespace eWarranty.Core.ResponseModels
{
    public class ServiceRequestDetailsSupervisorResponse
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
        public string ProductModelWarrantyTypeName { get; set; }
        public int? ProductWarrantyStatusId { get; set; }
        public int? PriorityId { get; set; }
        public int? PromoCodeId { get; set; }
        public decimal? EstimatedWorkDurationHours { get; set; }
        public string SupervisorRemark { get; set; }
        public string SupervisorName { get; set; }
        public string ModelNumber { get; set; }
        public string SerialNumber { get; set; }
        public string ProductClassificationName { get; set; }
        public string IsProductExistInPrism { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string PurchaseCountryName { get; set; }
        public string PurchaseInvoiceNumber { get; set; }
        public DateTime? PurchaseInvoiceDate { get; set; }
        public string DealerName { get; set; }
        public string DealerAddress { get; set; }
        public string TechnicianComments { get; set; }
        public string VisitAddressLandmark { get; set; }
        public long? TechnicianPersonId { get; set; }
        public int? ServiceLocationTypeId { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public DateTime CreationDate { get; set; }
        public bool? IsServiceChargeable { get; set; }
        public virtual string PriorityName { get; set; }
        public virtual string ServiceLocationTypeName { get; set; }
        public virtual AddressResponse ServiceRequestAddress { get; set; }
        public virtual string ServiceRequestStatusName { get; set; }
        public virtual string ServiceRequestTypeName { get; set; }
        public bool IsStandBySetRequestOpen { get; set; } = false;        
        public virtual List<ServiceChargeMasterResponse> ServiceChargeMasterResponse { get; set; }//---FOR WEB
    }
}

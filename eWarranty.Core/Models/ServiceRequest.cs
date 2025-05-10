using System;
using System.Collections.Generic;
using eWarranty.Core.Enums;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ServiceRequest
    {
        public ServiceRequest()
        {
            CustomerFeedbacks = new HashSet<CustomerFeedback>();
            FollowUps = new HashSet<FollowUp>();
            Invoices = new HashSet<Invoice>();
            PartRequests = new HashSet<PartRequest>();
            ServiceCostEstimations = new HashSet<ServiceCostEstimation>();
            ServiceRequestHistories = new HashSet<ServiceRequestHistory>();
            ServiceRequestTechnicianHistories = new HashSet<ServiceRequestTechnicianHistory>();
        }

        public long ServiceRequestId { get; set; }
        public string ServiceRequestNumber { get; set; }
        public int ServiceCenterId { get; set; }
        public string ServiceRequestName { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }

        public List<FilesToUploadRequest> FilesToUpload { get; set; }

        #region kumar Code
        public string CustomerAddress
        {
            get
            {
                string address = "NA";
                if (ServiceRequestAddress != null)
                {
                    if (string.IsNullOrEmpty(ServiceRequestAddress.ApartmentNumber))
                        address = ServiceRequestAddress.ApartmentNumber;
                    else if (string.IsNullOrEmpty(ServiceRequestAddress.BuildingName))
                        address = address + ", " + ServiceRequestAddress.BuildingName;
                    else if (string.IsNullOrEmpty(ServiceRequestAddress.Street))
                        address = address + ", " + ServiceRequestAddress.Street;
                    else if (string.IsNullOrEmpty(ServiceRequestAddress.Area))
                        address = address + ", " + ServiceRequestAddress.Area;
                    else if (string.IsNullOrEmpty(ServiceRequestAddress.City))
                        address = address + ", " + ServiceRequestAddress.City;
                    else if (string.IsNullOrEmpty(ServiceRequestAddress.State))
                        address = address + ", " + ServiceRequestAddress.State;
                }

                return address;
            }
        }


        public string StatusName { get {
                if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.Assigned))
                    return "Assigned";
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.DeliveredPaymentCollection))
                    return "Delivered Payment Collection";
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.EstimationConfirmationPending))
                    return "Estimation Confirmation Pending";
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.JobClosed))
                    return "JobClosed";
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.JobClosedWithoutRepair))
                    return "Job Closed Without Repair";
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.New))
                    return "New";
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.PendingForParts))
                    return "Pending For Parts";
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.PendingForPayment))
                    return "Pending For Payment";
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.PendingforRequestConfirmation))
                    return "In Progress";
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.RepairCompletion))
                    return "Repair Completion";
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.RepairInprogress))
                    return "Repair Inprogress";
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.RequestSchedulledComfirmed))
                    return "Request Schedulled Comfirmed";
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.EstimationConfirmed))
                    return "Estimation Comfirmed";



                return "";
            } }
        public virtual ProductModelWarrantyResponse ProductModelWarrantyResponse { get; set; }
        #endregion
        public long CustomerPersonId { get; set; }
        public int? ServiceRequestAddressId { get; set; }
        public long ProductModelId { get; set; }
        public string CustomerRemark { get; set; }
        public DateTime? CustomerSrpreferredDateTime { get; set; }
        public int? ProductWarrantyTypeId { get; set; }
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

        public virtual Person CustomerPerson { get; set; }
        public virtual ServiceRequestPriority Priority { get; set; }
        public virtual ProductModel ProductModel { get; set; }
        public virtual PromoCode PromoCode { get; set; }
        public virtual ServiceCenter ServiceCenter { get; set; }
        public virtual ServiceLocationType ServiceLocationType { get; set; }
        public virtual Address ServiceRequestAddress { get; set; }
        public virtual ServiceRequestStatu Status { get; set; }
        public virtual Person TechnicianPerson { get; set; }
        public virtual ServiceRequestType Type { get; set; }
        public virtual ICollection<CustomerFeedback> CustomerFeedbacks { get; set; }
        public virtual ICollection<FollowUp> FollowUps { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<PartRequest> PartRequests { get; set; }
        public virtual ICollection<ServiceCostEstimation> ServiceCostEstimations { get; set; }
        public virtual ICollection<ServiceRequestHistory> ServiceRequestHistories { get; set; }
        public virtual ICollection<ServiceRequestTechnicianHistory> ServiceRequestTechnicianHistories { get; set; }
    }
}

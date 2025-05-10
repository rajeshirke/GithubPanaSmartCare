using System;
using System.Collections.Generic;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;

namespace eWarranty.Core.ResponseModels
{
    public class ServiceRequestDetailsResponse
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
        public bool IsStandBySetRequestOpen { get; set; } = false;
        //      public bool? IsPartialPayment { get; set; }
        public bool? IsServiceChargeable { get; set; }

        public virtual PersonDetailsResponse CustomerPerson { get; set; }
        //public virtual ServiceRequestPriority Priority { get; set; }
        public virtual string PriorityName { get; set; }
        public virtual ProductModelResponse ProductModel { get; set; }
        public virtual PromoCodeResponse PromoCode { get; set; }
        public virtual ServiceCenterResponse ServiceCenter { get; set; }
        //public virtual ServiceLocationType ServiceLocationType { get; set; }

        public virtual string ServiceLocationTypeName { get; set; }

        public virtual AddressResponse ServiceRequestAddress { get; set; }

        //public virtual ServiceRequestStatu Status { get; set; }
        public virtual string ServiceRequestStatusName
        {
            get
            {
                if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.Assigned))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "مكلف"; 
                    else
                        return "Technician Assigned";
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.Cancelled))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "ألغيت";
                    else
                        return "Cancelled";
                }

                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.DeliveredPaymentCollection))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "تحصيل المدفوعات المسلمة"; 
                    else
                        return "Delivered Payment Collection";
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.EstimationConfirmationPending))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "تأكيد التقدير معلق";
                    else
                        return "Estimation Confirmation Pending";
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.JobClosed))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "الوظيفة مغلقة";
                    else
                        return "Job Closed"; 
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.JobClosedWithoutRepair))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "تم إغلاق الوظيفة دون إصلاح";
                    else
                        return "Job Closed Without Repair"; 
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.New))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "الجديد";
                    else
                        return "New";

                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.PendingForParts))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "في انتظار قطع الغيار";
                    else
                        return "Pending For Parts";
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.PendingForPayment))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "معلق للدفع";
                    else
                        return "Pending For Payment";
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.PendingforRequestConfirmation))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "في انتظار تأكيد التقدير";
                    else
                        return "In Progress"; 
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.RepairCompletion))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "إتمام الإصلاح";
                    else
                        return "Repair Completion"; 
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.RepairInprogress))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "جاري الإصلاح";
                    else
                        return "Repair Inprogress";
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.EstimationConfirmed))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "تم تأكيد التقييم";
                    else
                        return "Estimation Confirmed";
                }
                else
                    return "-";
            }
        }

        //for customer status only showing this for inwarranty product 
        public string CustServiceRequestStatusName
        {
            get
            {

                if (ProductModel?.ActiveWarrantyCustomerProduct?.WarrantyTypeId != 0 && StatusId == Convert.ToInt16(ServiceRequestStatusEnum.Assigned))
                {
                    //for inwarranty product showing this status
                    if (CommonFunctions.LongCode == "ur")
                        return "تم تأكيد التقدير";
                    else
                        return "Estimation Confirmed";
                }
                else if (ProductModel?.ActiveWarrantyCustomerProduct?.WarrantyTypeId == 0 && StatusId == Convert.ToInt16(ServiceRequestStatusEnum.Assigned))
                {
                    //for inwarranty product showing this status
                    if (CommonFunctions.LongCode == "ur")
                        return "معلق لتأكيد الطلب";
                    else
                        return "In Progress";
                }

                if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.Assigned))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "مكلف";
                    else
                        return "Technican Assigned";
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.Cancelled))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "ألغيت";
                    else
                        return "Cancelled";
                }

                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.DeliveredPaymentCollection))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "تحصيل المدفوعات المسلمة";
                    else
                        return "Delivered Payment Collection";
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.EstimationConfirmationPending))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "تأكيد التقدير معلق";
                    else
                        return "Estimation Confirmation Pending";
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.JobClosed))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "الوظيفة مغلقة";
                    else
                        return "Job Closed";
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.JobClosedWithoutRepair))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "تم إغلاق الوظيفة دون إصلاح";
                    else
                        return "Job Closed Without Repair";
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.New))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "الجديد";
                    else
                        return "New";

                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.PendingForParts))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "في انتظار قطع الغيار";
                    else
                        return "Pending For Parts";
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.PendingForPayment))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "معلق للدفع";
                    else
                        return "Pending For Payment";
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.PendingforRequestConfirmation))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "معلق لتأكيد الطلب";
                    else
                        return "In Progress";
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.RepairCompletion))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "إتمام الإصلاح";
                    else
                        return "Repair Completion";
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.RepairInprogress))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "الإصلاح قيد التقدم";
                    else
                        return "Repair Inprogress";
                }
                else if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.EstimationConfirmed))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "تم تأكيد التقدير";
                    else
                        return "Estimation Confirmed";
                }

                else
                    return "-";


            }
        }

        public virtual PersonDetailsResponse TechnicianPerson { get; set; }

        //public virtual ServiceRequestType Type { get; set; }
        public virtual string ServiceRequestTypeName { get; set; }
        public virtual CountryResponse ServiceCenterCountry { get; set; }

        public virtual ICollection<FollowUpResponse> FollowUps { get; set; }
        public virtual ICollection<InvoiceResponse> Invoices { get; set; }
        public virtual ICollection<PartRequestResponse> PartRequests { get; set; }
        public virtual ICollection<ServiceCostEstimationResponse> ServiceCostEstimations { get; set; }
        public virtual ICollection<ServiceRequestHistoryResponse> ServiceRequestHistories { get; set; }
        public virtual ICollection<ServiceRequestFileResponse> ServiceRequestFiles { get; set; }

        public virtual ICollection<StandBySetRequestResponse> StandBySetRequests { get; set; }

        //11 oct 21
        public virtual List<ServiceChargeMasterResponse> ServiceChargeMasterResponse { get; set; }

    }
}


/*
 {
            get
            {
                string typeName = "-";

                if (ServiceRequestStatusName?.ToLower() == "new" || CommonFunctions.GetStringSplitToWholeWordsOrNumbers(ServiceRequestStatusName) == "New")
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "الجديد";
                    else
                        return "New";
                }
                else if (ServiceRequestStatusName?.ToLower() == "assigned" || CommonFunctions.GetStringSplitToWholeWordsOrNumbers(ServiceRequestStatusName) == "Assigned")
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "مكلف";
                    else
                        return "Assigned";
                }
                else if (ServiceRequestStatusName?.ToLower() == "pendingforRequestConfirmation" || CommonFunctions.GetStringSplitToWholeWordsOrNumbers(ServiceRequestStatusName) == "PendingforRequestConfirmation")
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "معلق لتأكيد الطلب";
                    else
                        return "Pending for Request Confirmation";
                }
                else if (ServiceRequestStatusName?.ToLower() == "estimationConfirmationPending" || CommonFunctions.GetStringSplitToWholeWordsOrNumbers(ServiceRequestStatusName) == "EstimationConfirmationPending")
                {
                    if (CommonFunctions.LongCode == "ur")
                        return  "تأكيد التقدير معلق";
                    else
                        return "Estimation Confirmation Pending";
                }
                else if (ServiceRequestStatusName?.ToLower() == "requestSchedulledComfirmed" || CommonFunctions.GetStringSplitToWholeWordsOrNumbers(ServiceRequestStatusName) == "RequestSchedulledComfirmed")
                {
                    if (CommonFunctions.LongCode == "ur")
                        return  "طلب تأكيد مجدول";
                    else
                        return  "Request Schedulled Comfirmed";
                }
                else if (ServiceRequestStatusName?.ToLower() == "repairInprogress" || CommonFunctions.GetStringSplitToWholeWordsOrNumbers(ServiceRequestStatusName) == "repairInprogress")
                {
                    if (CommonFunctions.LongCode == "ur")
                        return  "الإصلاح قيد التقدم";
                    else
                        return  "Repair Inprogress";
                }
                else if (ServiceRequestStatusName?.ToLower() == "pendingForParts" || CommonFunctions.GetStringSplitToWholeWordsOrNumbers(ServiceRequestStatusName) == "PendingForParts")
                {
                    if (CommonFunctions.LongCode == "ur")
                        return  "في انتظار قطع الغيار";
                    else
                        return  "Pending For Parts";
                }
                else if (ServiceRequestStatusName?.ToLower() == "repairCompletion" || CommonFunctions.GetStringSplitToWholeWordsOrNumbers(ServiceRequestStatusName) == "RepairCompletion")
                {
                    if (CommonFunctions.LongCode == "ur")
                        return  "إتمام الإصلاح";
                    else
                        return  "Repair Completion";
                }
                else if (ServiceRequestStatusName?.ToLower() == "pendingForPayment" || CommonFunctions.GetStringSplitToWholeWordsOrNumbers(ServiceRequestStatusName) == "PendingForPayment")
                {
                    if (CommonFunctions.LongCode == "ur")
                        return  "معلق للدفع";
                    else
                        return  "Pending For Payment";
                }
                else if (ServiceRequestStatusName?.ToLower() == "jobclosedwithoutrepair" || CommonFunctions.GetStringSplitToWholeWordsOrNumbers(ServiceRequestStatusName) == "JobClosedWithoutRepair")
                {
                    if (CommonFunctions.LongCode == "ur")
                        return  "تم إغلاق الوظيفة دون إصلاح";
                    else
                        return  "Job Closed Without Repair";
                }
                else if (ServiceRequestStatusName?.ToLower() == "jobclosed" || CommonFunctions.GetStringSplitToWholeWordsOrNumbers(ServiceRequestStatusName) == "JobClosed")
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "الوظيفة مغلقة";
                    else
                        return "Job Closed";
                }
                else if (ServiceRequestStatusName?.ToLower() == "deliveredPaymentCollection" || CommonFunctions.GetStringSplitToWholeWordsOrNumbers(ServiceRequestStatusName) == "DeliveredPaymentCollection")
                {
                    if (CommonFunctions.LongCode == "ur")
                        return  "تحصيل المدفوعات المسلمة";
                    else
                        return  "Delivered Payment Collection";
                }
                else if (ServiceRequestStatusName?.ToLower() == "cancelled" || CommonFunctions.GetStringSplitToWholeWordsOrNumbers(ServiceRequestStatusName) == "Cancelled")
                {
                    if (CommonFunctions.LongCode == "ur")
                        return  "ألغيت";
                    else
                        return  "Cancelled";
                }
                else if (ServiceRequestStatusName?.ToLower() == "confirmed" || CommonFunctions.GetStringSplitToWholeWordsOrNumbers(ServiceRequestStatusName) == "Confirmed")
                {
                    if (CommonFunctions.LongCode == "ur")
                        return  "تم تأكيد";
                    else
                        return  "Confirmed";
                }

                return typeName;
            }
        }
 */

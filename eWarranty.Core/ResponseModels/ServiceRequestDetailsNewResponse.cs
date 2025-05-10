using System;
using System.Collections.Generic;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;

namespace eWarranty.Core.ResponseModels
{
    public class ServiceRequestDetailsNewResponse
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

            public DateTime CustomerSrpreferredDateTime { get; set; }

            public int? ProductWarrantyTypeId { get; set; }

            public string ProductModelWarrantyTypeName { get; set; } = "Out of Warranty";

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

            public virtual string PriorityName { get; set; }

            public string ModelNumber { get; set; }

            public string SerialNumber { get; set; }

            public string ProductClassificationName { get; set; }

            public DateTime PurchaseDate { get; set; }

            public DateTime? RegistrationDate { get; set; }

            public DateTime? ExpiredOn { get; set; }

            public string DealerName { get; set; }

            public string DealerAddress { get; set; }

            public string PurchaseInvoiceNumber { get; set; }

            public int ActiveWarrantyCustomerProductId { get; set; }

            public bool IsStandBySetRequestOpen { get; set; } = false;

            public int? WarrantyTypeId { get; set; }

            public string? Name { get; set; }

            public string? StreetAddress { get; set; }

            public string? CityName { get; set; }

            public TimeSpan? WorkingHoursStart { get; set; }

            public TimeSpan? WorkingHoursEnd { get; set; }

            public virtual string ServiceRequestTypeName { get; set; }

            public decimal? Latitude { get; set; }

            public decimal? Longitude { get; set; }

            public int? CountryId { get; set; }

            public int? CityId { get; set; }

            public int? CompanyId { get; set; }

            public string ContactPersonName { get; set; }

            public string ContactNumber1 { get; set; }

            public string ContactNumber2 { get; set; }

            public bool? IsAuthorisedServiceCenter { get; set; }

            public string Landmark { get; set; }

            public byte[] ServiceCenterLogo { get; set; }

            public int? PartMarkupPercentage { get; set; }

        public virtual ICollection<ServiceCostEstimationResponse> ServiceCostEstimations { get; set; }

        public ICollection<ServiceRequestFileResponse> ServiceRequestFiles { get; set; }

        public virtual ICollection<InvoiceResponse> Invoices { get; set; }

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

                //if (WarrantyTypeId != 0 && StatusId == Convert.ToInt16(ServiceRequestStatusEnum.Assigned))
                //{
                //    //for inwarranty product showing this status
                //    if (CommonFunctions.LongCode == "ur")
                //        return "تم تأكيد التقدير";
                //    else
                //        return "Estimation Confirmed";
                //}
                //else if (WarrantyTypeId == 0 && StatusId == Convert.ToInt16(ServiceRequestStatusEnum.Assigned))
                //{
                //    //for inwarranty product showing this status
                //    if (CommonFunctions.LongCode == "ur")
                //        return "معلق لتأكيد الطلب";
                //    else
                //        return "In Progress";
                //}

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
    }
}

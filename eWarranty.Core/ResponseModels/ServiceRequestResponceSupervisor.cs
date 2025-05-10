using System;
using System.Collections.Generic;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;

namespace eWarranty.Core.ResponseModels
{
    public class ServiceRequestResponceSupervisor
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
        public string ServiceRequestFullAddress { get; set; }
        public long? TechnicianPersonId { get; set; }
        public int? ServiceLocationTypeId { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public DateTime CreationDate { get; set; }      
        public string ProductClassificationName { get; set; }
        public string ProductModelNumber { get; set; }
        public string ProductSerialNumber { get; set; }
        public DateTime ProductPurchaseDate { get; set; }
        public string TechnicianPersonName { get; set; }
        public string CustomerPersonName { get; set; }
        public string ProductModelWarrantyTypeId { get; set; }
        public string ProductModelWarrantyTypeName { get; set; } = "Out of Warranty";
        public string ServiceLocationTypeName { get; set; }
        public int? ProductCategoryId { get; set; }
        public string AssignedTechnician
        {
            get
            {
                if (TechnicianPersonName != null)
                    return TechnicianPersonName;
                else
                    return "Not Assigned";
            }
        }

        public bool IsVisibleAssignTechnician
        {
            get
            {               
                if(ServiceLocationTypeId == Convert.ToInt16(ServiceLocationTypeEnum.HomeService))
                {
                    return true;
                }
                else return false;
            }
        }

        public bool IsVisibleUpdateStatus
        {
            get
            {
                if (ServiceLocationTypeId == Convert.ToInt16(ServiceLocationTypeEnum.ServiceCenterRepair))
                {
                    return true;
                }                
                else return false;
            }
        }

        public string ServiceRequestStatusName
        {
            get
            {
                if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.Assigned))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "مكلف";
                    else
                        return "Assigned";
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

        public string ServiceRequestTypeName
        {
            get
            {

                if (TypeId == Convert.ToInt16(ServiceRequestTypeEnum.DemoInstallation))
                {
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "التثبيت التجريبي";
                        else
                            return "Demo Installation";
                    }
                }

                else if (TypeId == Convert.ToInt16(ServiceRequestTypeEnum.RepairService))
                {
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "خدمة الصيانة";
                        else
                            return "Repair Service";
                    }
                }

                else
                    return "";
            }
        }


    }
}

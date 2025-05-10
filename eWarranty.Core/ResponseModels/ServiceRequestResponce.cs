using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using eWarranty.Core.Common;

namespace eWarranty.Core.ResponseModels
{
    public class ServiceRequestResponce
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
        #region Kumar Code
        public string PriorityName
        {
            get
            {
                if (PriorityId == Convert.ToInt16(ServiceRequestPriorityEnum.High))
                {
                    if(CommonFunctions.LongCode=="ur")
                        return "عالي";
                    else
                        return "High";
                }
                    
                else if (PriorityId == Convert.ToInt16(ServiceRequestPriorityEnum.Moderate))
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "معتدل";
                    else
                        return "Moderate";
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
        public bool JobClosed
        {
            get
            {
                 if (StatusId == Convert.ToInt16(ServiceRequestStatusEnum.JobClosed))
                    return true;
                else
                    return false;
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


        //for customer only- inwarranty product showing this status
        public string CustServiceRequestStatusName
        {
            get
            {

                //if (ProductModelWarrantyTypeId != "0" && StatusId == Convert.ToInt16(ServiceRequestStatusEnum.Assigned))
                //{
                //    //for inwarranty product showing this status
                //    if (CommonFunctions.LongCode == "ur")
                //        return "تم تأكيد التقدير";
                //    else
                //        return "Estimation Confirmed";
                //}
                //else if (ProductModelWarrantyTypeId == "0" && StatusId == Convert.ToInt16(ServiceRequestStatusEnum.Assigned))
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
        #endregion

        //  public string PriorityName { get { return Extensions.GetDisplayName((ServiceRequestPriorityEnum)PriorityId); } }
        public int? PromoCodeId { get; set; }
        public decimal? EstimatedWorkDurationHours { get; set; }
        public string SupervisorRemark { get; set; }
        public string TechnicianComments { get; set; }
        public string VisitAddressLandmark { get; set; }
        public long? TechnicianPersonId { get; set; }
        public int? ServiceLocationTypeId { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string ProductModelWarrantyTypeId { get; set; }
        public string ProductModelWarrantyTypeName { get; set; }

        public string ProductModelWarrantyTypeNameWithLang  
        {
            get
            {
                if (ProductModelWarrantyTypeName != null)
                {
                    if (ProductModelWarrantyTypeName.ToLower() == "domestic")
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "المحلية";
                        else
                            return "Domestic";
                    }
                    else if (ProductModelWarrantyTypeName.ToLower() == "extended")
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "ممتد، طويل، ممدود";
                        else
                            return "Extended";
                    }
                    else if (ProductModelWarrantyTypeName.ToLower() == "out warranty")
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "الضمان خارج";
                        else
                            return "Out of Warranty";
                    }
                    else if (ProductModelWarrantyTypeName.ToLower().Contains("awaiting"))
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "بانتظار التأكيد";
                        else
                            return "Awaiting confirmation";
                    }
                    else if (ProductModelWarrantyTypeName.ToLower() == "international")
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "دولي";
                        else
                            return "International";
                    }
                    else if (ProductModelWarrantyTypeName.ToLower() == "amc")
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "AMC";
                        else
                            return "AMC";
                    }
                    else
                        return "-";
                }
                else
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "الضمان خارج";
                    else
                        return "Out of Warranty";
                }
            }
        }

        // public string ServiceRequestTypeName { get { return  Extensions.GetDisplayName((ServiceRequestTypeEnum)TypeId);  } }
        //  public string ServiceRequestStatusName { get { return Extensions.GetDisplayName((ServiceRequestStatusEnum)StatusId);  } }

        public string ProductClassificationName { get; set; }
        public string ProductModelNumber { get; set; }
        public string ProductSerialNumber { get; set; }
        public string TechnicianPersonName { get; set; }
        public string CustomerPersonName { get; set; }

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


        //public string ServiceRequestTypeName { get { return Enum.GetName(typeof(ServiceRequestTypeEnum)  , TypeId); } }
        //public string ServiceRequestStatusName { get { return Enum.GetName(typeof(ServiceRequestStatusEnum), StatusId); } }


        //public virtual PersonLimitedDataVM CustomerPerson { get; set; }
        //public virtual ProductModelResponse ProductModel { get; set; }
    }
}

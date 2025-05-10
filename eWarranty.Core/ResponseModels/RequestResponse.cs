using System;
using System.Collections.Generic;
using System.Text;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;
using Xamarin.Forms;

namespace eWarranty.Core.ResponseModels
{
    public class RequestResponse
    {
        public long RequestId { get; set; }
        public string RequestNumber { get; set; }
        public int? ServiceCenterId { get; set; }
        public int? CountryId { get; set; }
        public int RequestTypeId { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public long? UpdatedBy { get; set; }
        public int? RequestStatusId { get; set; }
        public string RequestStatusName
        {
            get
            {
                if (RequestStatusId == Convert.ToInt16(RequestStatusEnum.Closed))
                    return "Closed";
                else if (RequestStatusId == Convert.ToInt16(RequestStatusEnum.InProgress))
                    return "In Progress";
                else if (RequestStatusId == Convert.ToInt16(RequestStatusEnum.New))
                    return "New";

                return "";

            }
        }
                   // Extensions.GetDisplayName((RequestStatusEnum)RequestStatusId); } }
        public string RequestTypeName { get {
                if (RequestTypeId == Convert.ToInt16(RequestTypeEnum.AMCRequest))
                    return "AMC Request";
                else if (RequestTypeId == Convert.ToInt16(RequestTypeEnum.PartRequest))
                    return "Part Request";
                else if (RequestTypeId == Convert.ToInt16(RequestTypeEnum.ProductApprovalRequest))
                    return "Product Approval Request";

                return "";
                //  return Extensions.GetDisplayName((RequestTypeEnum)RequestTypeId);

            } }

        public string CustomerName { get; set; }
       
        public string ProductModelNumber { get; set; }
        public string ProductModelSerialNumber { get; set; }
        public string ProductRegistrationNumber { get; set; }

        public bool IsApproveEnable
        {
            get
            {
                if (RequestStatusId == Convert.ToInt16(RequestStatusEnum.Closed))
                    return false;
                else if (RequestStatusId == Convert.ToInt16(RequestStatusEnum.InProgress))
                    return true;
                else if (RequestStatusId == Convert.ToInt16(RequestStatusEnum.New))
                    return true;

                return true;
            }
        }

        public string lblApprove
        {
            get
            {
                if (RequestStatusId == Convert.ToInt16(RequestStatusEnum.Closed))
                    return "Closed";
                else if (RequestStatusId == Convert.ToInt16(RequestStatusEnum.InProgress))
                    return "In Progress";
                else if (RequestStatusId == Convert.ToInt16(RequestStatusEnum.New))
                    return "Approve";

                return "Approve";
            }
        }

        public Color BgColor
        {
            get
            {
                if (RequestStatusId == Convert.ToInt16(RequestStatusEnum.Closed))
                    return (Color)Application.Current.Resources["LabelGrayShade"];
                else if (RequestStatusId == Convert.ToInt16(RequestStatusEnum.InProgress))
                    return (Color)Application.Current.Resources["WhiteColor"];
                else if (RequestStatusId == Convert.ToInt16(RequestStatusEnum.New))
                    return (Color)Application.Current.Resources["WhiteColor"];

                return (Color)Application.Current.Resources["WhiteColor"];
            }
        }
    }
}

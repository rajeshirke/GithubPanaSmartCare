using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace eWarranty.Core.Common
{
    public static class CommonFunctions
    {
        public static string LongCode { get; set; }
        public static string ConvertDigitToComma(decimal value)
        {
            return string.Format("{0:#,#.00}", value);
            //string a1 = Common.convertDigitToComma(decimal.Parse("40500.00"));
            //string a2 = Common.convertDigitToComma(Convert.ToDecimal(60500));
        }

        //public static bool IsValidEmail(string email)
        //{
        //    try
        //    {
        //        var addr = new System.Net.Mail.MailAddress(email);
        //        return addr.Address == email;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public static string GetPhoneNumberFormatted(string phone)
        {
            return phone.Replace(" ", "").Replace("+", "");
        }


        public static bool IsDatePastToCurrentDate(DateTime DateToCheck)
        {
            return DateToCheck.Date > DateTime.UtcNow.Date;
        }

        public static ServiceRequestStatusForCustomerEnum GetServiceRequestStatusToDisplayForCustomer(int ServiceRequestStatusId)
        {
            List<int> lstInProgress = new List<int> {
                (int)ServiceRequestStatusEnum.Assigned,
                (int)ServiceRequestStatusEnum.PendingforRequestConfirmation ,
                (int)ServiceRequestStatusEnum.EstimationConfirmationPending,
                (int)ServiceRequestStatusEnum.RequestSchedulledComfirmed,
                (int)ServiceRequestStatusEnum.RepairInprogress,
                (int)ServiceRequestStatusEnum.PendingForParts,
                (int)ServiceRequestStatusEnum.RepairCompletion,
                (int)ServiceRequestStatusEnum.PendingForPayment};

            List<int> lstClosed = new List<int> {
                (int)ServiceRequestStatusEnum.JobClosed, 
                (int)ServiceRequestStatusEnum.JobClosedWithoutRepair, 
                (int)ServiceRequestStatusEnum.Cancelled };

            if (ServiceRequestStatusId == (int)ServiceRequestStatusEnum.New)
            {
                return ServiceRequestStatusForCustomerEnum.Requested;
            }
            else if (lstInProgress.Contains( ServiceRequestStatusId))
            {
                return ServiceRequestStatusForCustomerEnum.InProgress;
            }
            else if (lstClosed.Contains(ServiceRequestStatusId))
            {
                return ServiceRequestStatusForCustomerEnum.Closed;
            }

            return 0;
        }

        public static List<int> ServiceRequestStatusesByStatusForDashBoard(int DashboardStatusId)
        {
            List<int> lststatus = null;
            switch (DashboardStatusId)
            {
                case (int)ServiceRequestStatusForDashboardEnum.InProgress: 
                    lststatus = GetInProgressServiceRequestStatusIds();
                    break;
                case (int)ServiceRequestStatusForDashboardEnum.New:
                    lststatus = new List<int> {
                    (int)ServiceRequestStatusEnum.New };
                    break;
                case (int)ServiceRequestStatusForDashboardEnum.Due:
                    // code block
                    break;
                case (int)ServiceRequestStatusForDashboardEnum.Closed:
                    lststatus = GetClosedServiceRequestStatusIds();
                    break;
                case (int)ServiceRequestStatusForDashboardEnum.All: 
                    break;
                default: 
                    // code block
                    break; 
            }

            return lststatus;
        }

        public static List<int> GetInProgressServiceRequestStatusIds()
        {
            List<int>  lststatus = new List<int> {
                    (int)ServiceRequestStatusEnum.Assigned,
                    (int)ServiceRequestStatusEnum.PendingforRequestConfirmation ,
                    (int)ServiceRequestStatusEnum.EstimationConfirmationPending,
                    (int)ServiceRequestStatusEnum.RequestSchedulledComfirmed,
                    (int)ServiceRequestStatusEnum.RepairInprogress,
                    (int)ServiceRequestStatusEnum.PendingForParts,
                    (int)ServiceRequestStatusEnum.RepairCompletion,
                    (int)ServiceRequestStatusEnum.PendingForPayment};

            return lststatus;
        }

        public static List<int> GetClosedServiceRequestStatusIds()
        {
            List<int> lststatus  = new List<int> {
                     (int)ServiceRequestStatusEnum.JobClosed,
                    (int)ServiceRequestStatusEnum.JobClosedWithoutRepair,
                    (int)ServiceRequestStatusEnum.Cancelled };

            return lststatus;
        }


        public static string GetRequestNumbersByRequestType(int RequestTypeId ,long RequestId)
        {
            string reqNumber = "";
            switch (RequestTypeId)
            {
                case (int)RequestTypeEnum.PartRequest:
                    reqNumber = "PRT-" + RequestId ;
                    break;
                case (int)RequestTypeEnum.AMCRequest:
                    reqNumber = "AMC-" + RequestId;
                    break;
                case (int)RequestTypeEnum.ProductApprovalRequest:
                    reqNumber = "PRDA-" + RequestId;
                    break;
                default:
                    reqNumber = "";
                    break;
            }
            return reqNumber;
        }



        public static string GetMessagesByLanguage(APIResponse Res, int LangId)
        {
            string message = "";
            if (LangId == 1)
            {
                if (Res.Status == (int)APIResponseEnum.Success)
                {
                    message = Res.Message;
                }
                else
                {
                    message = Res.ErrorMessage;
                }
            }
            else
            {
                if (Res.Status == (int)APIResponseEnum.Success)
                {
                    message = Res.ArMessage;
                }
                else
                {
                    message = Res.ArErrorMessage;
                }
            }

            return message;
        }

        public static string GetStringSplitToWholeWordsOrNumbers(string stringToSplit)
        {
            //if(string.IsNullOrEmpty( stringToSplit))
            //{
            //    return "";
            //}
            var splitString = Regex.Matches(stringToSplit, @"([A-Z][a-z]+)|([0-9]+)").Cast<Match>().Select(m => m.Value);
            return string.Join(" ", splitString);
        }

    }



}

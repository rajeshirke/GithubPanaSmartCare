using System;
using System.Collections.Generic;
using System.Text;
using eWarranty.Core.Common;

namespace eWarranty.Core.ResponseModels
{
    public class ServiceCostEstimationOtherChargeResponse
    {
        public long ServiceCostEstimationOtherChargesId { get; set; }
        public long? ServiceRequestId { get; set; }
        public long? ServiceCostEstimationId { get; set; }
        public int ChargeTypeId { get; set; }
        public string ChargeTypeName { get; set; }
        public decimal OtherRate { get; set; }
        public string CurrencyName { get; set; }
        public string ChargeName
        {
            get
            {
                if (ChargeTypeName.ToLower().Contains("service"))
                {
                    if (CommonFunctions.LongCode == "ur")
                    {
                        return "تكلفة الخدمة";
                    }
                    else
                    {
                        return "Service Charge";
                    }
                }
                else if (ChargeTypeName.ToLower().Contains("inspection"))
                {
                    if (CommonFunctions.LongCode == "ur")
                    {
                        return "رسوم التفتيش";
                    }
                    else
                    {
                        return "Inspection Charge";
                    }
                }
                else if (ChargeTypeName.ToLower().Contains("transportation"))
                {
                    if (CommonFunctions.LongCode == "ur")
                    {
                        return "مواصلات";
                    }
                    else
                    {
                        return "Transportation Charge";
                    }
                }
                return "-";
            }
        }
    }
}

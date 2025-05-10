using System;
using System.Collections.Generic;
using eWarranty.Core.Common;

namespace eWarranty.Core.ResponseModels
{
    public class ServiceChargeMasterResponse
    {
        public int ServiceChargeMasterId { get; set; }
        public int CountryId { get; set; }
        public int? ServiceCenterId { get; set; }
        public int ServiceRequestTypeId { get; set; }
        public int ChargeTypeId { get; set; }
        public int? ProductClassificationId { get; set; }
        public decimal Rate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long? UpdatedByPersonId { get; set; }
        public string Description { get; set; }


        public string CountryName { get; set; }
        public string CountryIso { get; set; }
        public string ServiceCenterName { get; set; }
        public string ProductClassificationName { get; set; }
        public string ChargeTypeName { get; set; }
        public string ServiceRequestTypeName { get; set; }

        public string ChargeName
        {
            get
            {
                if(ChargeTypeName.ToLower().Contains("service"))
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
                else if(ChargeTypeName.ToLower().Contains("inspection"))
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

        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }

        public static implicit operator List<object>(ServiceChargeMasterResponse v)
        {
            throw new NotImplementedException();
        }
    }
}

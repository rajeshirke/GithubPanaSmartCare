using System;
using System.Collections.Generic;
using System.Text;
using eWarranty.Core.Common;

namespace eWarranty.Core.ResponseModels
{
    public class WarrantyCustomerProductResponse
    {

        public int WarrantyCustomerProductId { get; set; }
        public int? ProductClassificationId { get; set; }
        public long ProductModelId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? IsWarrantyActive { get; set; }
        public int? WarrantyMasterId { get; set; }
        public int WarrantyTypeId { get; set; }
        public int? ServiceCenterId { get; set; }
        public int? CountryId { get; set; }
        public string WarrantyCardImageURL { get; set; }
        public string WarrantyTypeName { get; set; }
        public bool IsPendingForProductRequestApproval { get; set; } = false;
        public string WarrantyType
        {
            get
            {
                string typeName = "-";

                if (IsPendingForProductRequestApproval)
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "بانتظار التأكيد";
                    else
                        return "Awaiting Confirmation";
                }

                if (WarrantyTypeName != null)
                {
                    if (WarrantyTypeName?.ToLower() == "domestic")
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "المحلية";
                        else
                            return "Domestic";
                    }
                    else if (WarrantyTypeName?.ToLower() == "extended")
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "ممتد، طويل، ممدود";
                        else
                            return "Extended";
                    }
                    else if (WarrantyTypeName?.ToLower() == "out warranty")
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "الضمان خارج";
                        else
                            return "Out of Warranty";
                    }
                    else if (WarrantyTypeName.Contains("Awaiting"))
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "بانتظار التأكيد";
                        else
                            return "Awaiting confirmation";
                    }
                    else if (WarrantyTypeName?.ToLower() == "international")
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "دولي";
                        else
                            return "International";
                    }
                    else if (WarrantyTypeName?.ToLower() == "amc")
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "AMC";
                        else
                            return "AMC";
                    }
                    else
                        typeName = WarrantyTypeName;
                }
                return typeName;
            }
        }

    }
}

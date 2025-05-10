using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class ServiceChargeExcelData
    {

        public int CountryId { get; set; }
        public int ServiceCenterId { get; set; }
        public int ServiceRequestTypeId { get; set; }
        public int ChargeTypeId { get; set; }
        public int? ProductClassificationId { get; set; }



        public string Country { get; set; }
        public string ServiceCenter { get; set; }
        public string ServiceRequestType { get; set; }
        public string ChargeType { get; set; }
        public string ProductClassification { get; set; }


        public decimal Rate { get; set; }
        public string Description { get; set; }

    }
}

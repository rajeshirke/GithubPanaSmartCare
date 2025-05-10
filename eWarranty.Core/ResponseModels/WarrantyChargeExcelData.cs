using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class WarrantyChargeExcelData
    {
        //public int WarrantyTypeId { get; set; }
        public int CountryId { get; set; }
        public int ServiceCenterId { get; set; }
        public int ProductClassificationID { get; set; }


        //public string WarrantyTypeName { get; set; }
        public string CountryName { get; set; }
        public string ServiceCenterName { get; set; }
        public string ProductClassificationName { get; set; }

        public decimal Rate { get; set; }

        public string Description { get; set; }


    }
}

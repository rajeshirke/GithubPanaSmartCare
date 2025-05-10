using eWarranty.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class AmcRequestMasterResponse
    {
        public int AmcRequestMasterId { get; set; }
        public int ServiceCenterId { get; set; }
        public int AmcTypeId { get; set; }
        public string Description { get; set; }
        public int PeriodInMonths { get; set; }
        public decimal Rate { get; set; }
        public int CurrencyId { get; set; }
        public int? CountryId { get; set; }
        public int? AmcExpiryNotificationDays { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedByPersonId { get; set; }
        [JsonIgnore]
        public string CurrencyCode { get; set; }

        //public virtual AmcType AmcType { get; set; }
        public string AmcTypeName { get; set; }
        public string CurrencyName { get; set; }
        public string CountryName { get; set; }

        // public virtual CountryResponse Country { get; set; }
        // public virtual ServiceCenterResponse ServiceCenter { get; set; }

    }
}

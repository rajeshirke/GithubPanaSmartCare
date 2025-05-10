using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class CountryLevelSetting
    {
        public int CountryLevelSettingId { get; set; }
        public int CountryId { get; set; }
        public int OrderReturnDays { get; set; }
        public bool? IsCarePlusWarranty { get; set; }
        public decimal? TaxPercentage { get; set; }

        public virtual Country Country { get; set; }
    }
}

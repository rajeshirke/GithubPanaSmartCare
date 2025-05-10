using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class PaymentModeCountry
    {
        public int CountryId { get; set; }
        public int PaymentModeId { get; set; }

        public virtual Country Country { get; set; }
        public virtual PaymentMode PaymentMode { get; set; }
    }
}

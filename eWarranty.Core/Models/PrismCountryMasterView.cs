using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class PrismCountryMasterView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Currency { get; set; }
        public string IsWarranty { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public string DailCode { get; set; }
    }
}

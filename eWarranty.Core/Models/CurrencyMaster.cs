using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class CurrencyMaster
    {
        public CurrencyMaster()
        {
            Countries = new HashSet<Country>();
        }

        public int CurrencyId { get; set; }
        public string Name { get; set; }
        public decimal ExchangeRate { get; set; }
        public string Code { get; set; }
        public int CountryId { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}

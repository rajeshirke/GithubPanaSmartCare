using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class Company
    {
        public Company()
        {
            InverseParentCompany = new HashSet<Company>();
            PersonCompanies = new HashSet<PersonCompany>();
            ServiceCenters = new HashSet<ServiceCenter>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Code { get; set; }
        public string ContactPersonName { get; set; }
        public int CountryId { get; set; }
        public string CompanyTypeName { get; set; }
        public int? ParentCompanyId { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Email { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string Address { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }

        public virtual Country Country { get; set; }
        public virtual Company ParentCompany { get; set; }
        public virtual ICollection<Company> InverseParentCompany { get; set; }
        public virtual ICollection<PersonCompany> PersonCompanies { get; set; }
        public virtual ICollection<ServiceCenter> ServiceCenters { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class Country
    {
        public Country()
        {
            AmcRequestMasters = new HashSet<AmcRequestMaster>();
            CampaignCountries = new HashSet<CampaignCountry>();
            Cities = new HashSet<City>();
            Companies = new HashSet<Company>();
            PaymentModeCountries = new HashSet<PaymentModeCountry>();
            Persons = new HashSet<Person>();
            ServiceCenters = new HashSet<ServiceCenter>();
            ServiceChargeMasters = new HashSet<ServiceChargeMaster>();
            States = new HashSet<State>();
            WarrantyCharges = new HashSet<WarrantyCharge>();
            WarrantyMasters = new HashSet<WarrantyMaster>();
        }

        public int CountryId { get; set; }
        public string Iso { get; set; }
        public string Name { get; set; }
        public string Iso3 { get; set; }
        public int? NumCode { get; set; }
        public int PhoneCode { get; set; }
        public string CurrencyCode { get; set; }
        public int? CurrencyId { get; set; }
        public bool? IsActive { get; set; }

        public virtual CurrencyMaster Currency { get; set; }
        public virtual CountryLevelSetting CountryLevelSetting { get; set; }
        public virtual ICollection<AmcRequestMaster> AmcRequestMasters { get; set; }
        public virtual ICollection<CampaignCountry> CampaignCountries { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<PaymentModeCountry> PaymentModeCountries { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
        public virtual ICollection<ServiceCenter> ServiceCenters { get; set; }
        public virtual ICollection<ServiceChargeMaster> ServiceChargeMasters { get; set; }
        public virtual ICollection<State> States { get; set; }
        public virtual ICollection<WarrantyCharge> WarrantyCharges { get; set; }
        public virtual ICollection<WarrantyMaster> WarrantyMasters { get; set; }
    }
}

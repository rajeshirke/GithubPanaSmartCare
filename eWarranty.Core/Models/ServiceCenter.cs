using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ServiceCenter
    {
        public ServiceCenter()
        {
            AmcRequestMasters = new HashSet<AmcRequestMaster>();
            PartRequests = new HashSet<PartRequest>();
            PersonServiceCenters = new HashSet<PersonServiceCenter>();
            Requests = new HashSet<Request>();
            ServiceChargeMasters = new HashSet<ServiceChargeMaster>();
            ServiceRequests = new HashSet<ServiceRequest>();
            WarrantyCharges = new HashSet<WarrantyCharge>();
            WarrantyMasters = new HashSet<WarrantyMaster>();
        }

        public int ServiceCenterId { get; set; }
        public string Name { get; set; }
        public string ContactPersonName { get; set; }
        public int? CountryId { get; set; }
        public string CityName { get; set; }
        public string StreetAddress { get; set; }
        public int? CityId { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public int? CompanyId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public TimeSpan? WorkingHoursStart { get; set; }
        public TimeSpan? WorkingHoursEnd { get; set; }
        public bool? IsAuthorisedServiceCenter { get; set; }
        public string Landmark { get; set; }
        public byte[] ServiceCenterLogo { get; set; }
        public int? PartMarkupPercentage { get; set; }
        public string StartDay { get; set; }
        public string EndDay { get; set; }
        #region Kumar Code
        public bool SelectedItem { get; set; }
        public double Distnace { get; set; }
        #endregion

        public virtual Company Company { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<AmcRequestMaster> AmcRequestMasters { get; set; }
        public virtual ICollection<PartRequest> PartRequests { get; set; }
        public virtual ICollection<PersonServiceCenter> PersonServiceCenters { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<ServiceChargeMaster> ServiceChargeMasters { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
        public virtual ICollection<WarrantyCharge> WarrantyCharges { get; set; }
        public virtual ICollection<WarrantyMaster> WarrantyMasters { get; set; }
    }
}

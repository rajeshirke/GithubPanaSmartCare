using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Order>();
            ServiceRequests = new HashSet<ServiceRequest>();
        }

        public int AddressId { get; set; }
        public long CustomerId { get; set; }
        public string ApartmentNumber { get; set; }
        public int? FloorNumber { get; set; }
        public string Street { get; set; }
        public string BuildingName { get; set; }
        public string Area { get; set; }
        public int? PostalCode { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public string City { get; set; }
        public int? CityId { get; set; }
        public bool? IsPrimary { get; set; }
        public bool? IsActive { get; set; }
        public string State { get; set; }
        public int? CountryId { get; set; }

        public virtual City CityNavigation { get; set; }
        public virtual Person Customer { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}

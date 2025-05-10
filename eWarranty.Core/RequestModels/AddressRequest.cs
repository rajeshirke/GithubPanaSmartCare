using eWarranty.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public  class AddressRequest
    {
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
    }
}

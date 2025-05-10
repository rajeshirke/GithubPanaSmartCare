using System;
using eWarranty.Core.Models;

namespace eWarranty.Core.ResponseModels
{
    public class AddressResponse
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
        public string CountryName { get; set; }

        #region kumar
        public string BgColor { get; set; } = "#FFFFFF";
        #endregion
    }
}

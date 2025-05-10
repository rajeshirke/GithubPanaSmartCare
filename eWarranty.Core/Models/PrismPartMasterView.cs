using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class PrismPartMasterView
    {
        public long PartId { get; set; }
        public int WebMasterId { get; set; }
        public string PartNumber { get; set; }
        public string PartDescription { get; set; }
        public string LatestPartNumber { get; set; }
        public string UnitCode { get; set; }
        public byte IsDiscontinued { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public byte Active { get; set; }
        public bool Elflag { get; set; }
        public bool Earflag { get; set; }
        public bool Qbriscflag { get; set; }
        public string CountryofOrigin { get; set; }
        public int ExceptionalItemId { get; set; }
        public byte Movementstatus { get; set; }
        public int CurrencyId { get; set; }
        public decimal BasePartPrice { get; set; }
        public decimal MEFlag { get; set; }
        public byte PartType { get; set; }
        public byte IsReturnableToPrinciple { get; set; }
        public byte IsReturnableToStore { get; set; }
        public bool IsAccessory { get; set; }
        public int AccessoryGuaranteeDays { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long VersionNo { get; set; }
        public long WebVersionNo { get; set; }
        public int? PartGroupId { get; set; }
    }
}

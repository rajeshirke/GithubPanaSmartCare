using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class TechPortalDbrepairTipsView
    {
        public int Id { get; set; }
        public string DocNo { get; set; }
        public DateTime? DocDate { get; set; }
        public string Category { get; set; }
        public int? Product { get; set; }
        public string ModelNo { get; set; }
        public string Subject { get; set; }
        public string Cause { get; set; }
        public string Solution { get; set; }
        public string DocName { get; set; }
        public string DocType { get; set; }
        public byte[] Document { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string AppRemarks { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string DocName2 { get; set; }
        public string DocType2 { get; set; }
        public byte[] Document2 { get; set; }
    }
}

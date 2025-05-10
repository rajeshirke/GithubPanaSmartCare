using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceLineItems = new HashSet<InvoiceLineItem>();
        }

        public long InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal? Discount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal? Balance { get; set; }
        public string InvoiceNumber { get; set; }
        public int? InvoiceTypeId { get; set; }
        public long ServiceRequestId { get; set; }
        public DateTime? FullPaymentDate { get; set; }
        public int? PaymentModeId { get; set; }
        public int? InvoiceStatusId { get; set; }

        public virtual InvoiceStatu InvoiceStatus { get; set; }
        public virtual InvoiceType InvoiceType { get; set; }
        public virtual PaymentMode PaymentMode { get; set; }
        public virtual ServiceRequest ServiceRequest { get; set; }
        public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }
    }
}

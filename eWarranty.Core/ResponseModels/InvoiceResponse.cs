using System;
using System.Collections.Generic;

namespace eWarranty.Core.ResponseModels
{
    public class InvoiceResponse
    {
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

        //public string InvoiceTypeName { get; set; }
        //public string InvoiceStatusName { get; set; }


        //public virtual InvoiceStatu InvoiceStatus { get; set; }
        //public virtual InvoiceType InvoiceType { get; set; }
        //public virtual PaymentMode PaymentMode { get; set; } 

        public string PaymentModeName { get; set; }

        public virtual ICollection<InvoiceLineItemResponse> InvoiceLineItems { get; set; }
    }
}

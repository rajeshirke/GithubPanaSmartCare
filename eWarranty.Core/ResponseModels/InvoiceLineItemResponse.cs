using System;
namespace eWarranty.Core.ResponseModels
{
    public class InvoiceLineItemResponse
    {
        public long InvoiceLineItemId { get; set; }
        public long InvoiceId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemTotalPrice { get; set; }
        public string CurrencyCode { get; set; }
    }
}

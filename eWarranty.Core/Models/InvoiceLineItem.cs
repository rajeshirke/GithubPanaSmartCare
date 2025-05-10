using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class InvoiceLineItem
    {
        public long InvoiceLineItemId { get; set; }
        public long InvoiceId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemTotalPrice { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}

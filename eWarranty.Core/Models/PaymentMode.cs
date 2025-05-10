using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class PaymentMode
    {
        public PaymentMode()
        {
            Invoices = new HashSet<Invoice>();
            Orders = new HashSet<Order>();
            PaymentModeCountries = new HashSet<PaymentModeCountry>();
        }

        public int PaymentModeId { get; set; }
        public string PaymentMode1 { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<PaymentModeCountry> PaymentModeCountries { get; set; }
    }
}

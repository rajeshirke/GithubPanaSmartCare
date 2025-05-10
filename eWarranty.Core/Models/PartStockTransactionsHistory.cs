using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class PartStockTransactionsHistory
    {
        public long TransactionId { get; set; }
        public long TransactionByPersonId { get; set; }
        public string Description { get; set; }
        public string PartNumber { get; set; }
        public DateTime TransactionDatetime { get; set; }

        public virtual Person TransactionByPerson { get; set; }
    }
}

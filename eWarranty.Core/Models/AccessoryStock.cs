using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class AccessoryStock
    {
        public long AccessoryStockId { get; set; }
        public int StockFlow { get; set; }
        public DateTime StockDate { get; set; }
        public int Quantity { get; set; }
        public long AccessoryMasterId { get; set; }

        public virtual AccessoryMaster AccessoryMaster { get; set; }
    }
}

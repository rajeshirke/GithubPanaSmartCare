using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ShoppingCartItem
    {
        public long ShoppingCartItemId { get; set; }
        public long CustomerPersonId { get; set; }
        public long AccessoryMasterId { get; set; }
        public int Quantity { get; set; }

        public virtual AccessoryMaster AccessoryMaster { get; set; }
        public virtual Person CustomerPerson { get; set; }
    }
}

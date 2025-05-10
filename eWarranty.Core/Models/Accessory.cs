using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class Accessory
    {
        public Accessory()
        {
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public int AccessoryId { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public long ProductModelId { get; set; }
        public int InitialQuantity { get; set; }
        public int CurrentQuantity { get; set; }
        public decimal InitialPrice { get; set; }
        public decimal CurrentPrice { get; set; }

        public virtual ProductModel ProductModel { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}

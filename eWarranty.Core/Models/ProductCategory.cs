using System;
using System.Collections.Generic;

namespace eWarranty.Core.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            WarrantyCustomerProducts = new HashSet<WarrantyCustomerProduct>();
            WarrantyMasterProductCategories = new HashSet<WarrantyMasterProductCategory>();
        }

        public int ProductCategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<WarrantyCustomerProduct> WarrantyCustomerProducts { get; set; }
        public virtual ICollection<WarrantyMasterProductCategory> WarrantyMasterProductCategories { get; set; }
    }
}

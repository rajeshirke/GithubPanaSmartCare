using eWarranty.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class ProductModelResponse
    {
        public long ProductModelId { get; set; }
        public int CustomerId { get; set; }
        public bool? IsProductExistInPrism { get; set; }
        public int? ProductCategoryId { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? ActiveWarrantyCustomerProductId { get; set; }
        public bool? IsDeleted { get; set; }

        public string ProductImageURL { get; set; } 
        public string ProductClassificationName { get; set; }
        public int? PurchaseCountryId { get; set; }
        public string ModelNumber { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string RegistrationNumber { get; set; }
        public string ReferenceNo { get; set; }
        public bool? IsAmcRequested { get; set; }
        public string DealerName { get; set; }
        public string DealerAddress { get; set; }
        public string PurchaseInvoiceNumber { get; set; }
        public DateTime? PurchaseInvoiceDate { get; set; }
        public string CustomerRemark { get; set; }
        public string PurchaseCountryName { get; set; }
        #region Kumar code
        public string ModelImageURL { get {

                if (! string.IsNullOrEmpty(ProductImageURL))
                    return ProductImageURL;
                else
                    return "http://devsrv01.panasonic.ae:83/images/productImages/defaultprod.png";

            } }
        #endregion

        public virtual ICollection<ProductFileResponse> ProductFiles { get; set; }
        public virtual ICollection<WarrantyCustomerProductResponse> WarrantyCustomerProducts { get; set; }
        public WarrantyCustomerProductResponse ActiveWarrantyCustomerProduct { get; set; }
    }
}

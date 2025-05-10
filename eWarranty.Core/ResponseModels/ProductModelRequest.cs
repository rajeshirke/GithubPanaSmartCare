using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eWarranty.Core.ResponseModels
{
    public class ProductModelRequest
    {
        public ProductModelDetails ProductModelDetails { get; set; }

        public List<FilesToUploadRequest> FilesToUpload { get; set; }
    }


    public class ProductModelDetails
    {
        public long ProductModelId { get; set; }
        public int CustomerId { get; set; }
        public bool? IsProductExistInPrism { get; set; }
        public int? ProductCategoryId { get; set; }
        public string ProductClassificationName { get; set; }
        
        public int PurchaseCountryId { get; set; }
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
        public string ModelName { get; set; }
        public bool? IsProductModelInWarranty { get; set; }
        public DateTime? RegistrationDate { get; set; }

    }


}

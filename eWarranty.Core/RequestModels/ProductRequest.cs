using System;
using System.Collections.Generic;
using eWarranty.Core.Models;

namespace eWarranty.Core.RequestModels
{
    public class ProductRequest
    {
        public ProductModel productModelDetails { get; set; }
        public List<FilesToUpload> filesToUpload { get; set; }
    }
}

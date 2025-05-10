using System;
using eWarranty.Core.Models;

namespace eWarranty.Models
{
    public class SRInputModel
    {
        public ProductModel SelectedProduct { get; set; }
        public ServiceCentorModel ServiceCentor { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class PrismModelMasterView
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string ModelDescreption { get; set; }
        public int BrandId { get; set; }
        public int ProductId { get; set; }
        public int? ProductClassificationId { get; set; }
        public byte Active { get; set; }
        public byte IsDiscontinued { get; set; }
    }
}
